using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseScheduler
{
    public partial class MainWindow: MetroForm
    {
        database courselist;
        searchQuery courseSearch;
        searchResults results;
        calendar courseCalendar = new calendar();
        DataTable data = new DataTable();
        int searchType = 0;

        public MainWindow()
        {
            InitializeComponent();

            this.courselist = new database();
            this.courseSearch = new searchQuery(courselist);
            this.results = new searchResults();

            data = csvToTable("blankCalendar.csv", true);

            calendarView.DataSource = data;


            foreach (DataGridViewColumn col in calendarView.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            }

            courseDataBox.Enabled = false;

            calendarView.Columns[0].Width = 60;

            calendarView.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;

            Console.Write(courseCalendar.fixEndTime("14:50:00"));

            this.searchMenu.SelectedIndex = 0;
      

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

            
        }


        public static DataTable csvToTable(string file, bool isRowOneHeader)
        {
            DataTable csvTable = new DataTable();

            string csvFile = System.IO.File.ReadAllText(file);

            String[] csvData = csvFile.Split(new char[] { '\n' });

            String[] headers = csvData[0].Split(',');
            int index = 0;
            if (isRowOneHeader)
            {
                index = 1;

                for (int i = 0; i < headers.Length; i++)
                {
                    headers[i] = headers[i].Replace(" ", "_");

                    csvTable.Columns.Add(headers[i], typeof(string));
                  
                }
            }
            else
            {
                for (int i = 0; i < headers.Length; i++)
                {
                    csvTable.Columns.Add("col" + (i + 1).ToString(), typeof(string));
                }
            }



            for (int i = index; i < csvData.Length-1; i++)
            {
                csvTable.Rows.Add(csvData[i].Split(','));
            }

            return csvTable;
        }


        private void calendarView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            calendarView.Rows[e.RowIndex].ReadOnly = true;
        }


        // When a query is entered into the text field and enter is pressed, the database will be searched
        private void searchBox_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                Console.WriteLine("ENTER PRESSED!");
                string searchString = this.searchBox.Text;
                if(searchType == 0)
                {
                    this.results = this.courseSearch.genericSearch(searchString);
                }
                else if (searchType == 1)
                {
                    this.results = this.courseSearch.searchByCode(searchString);
                }
                else if (searchType == 2)
                {
                    this.results = this.courseSearch.searchByName(searchString);
                }
                else if (searchType == 3)
                {
                    this.results = this.courseSearch.searchByTime(searchString);
                }
                else if (searchType == 4)
                {
                    this.results = this.courseSearch.searchByDepartment(searchString);
                }
                if (this.results.hasCourses())
                {
                    if (this.searchResultsBox.Items.Count > 0)
                    {
                        this.searchResultsBox.Items.Clear();
                    }
                    for (int i = 0; i < this.results.size(); i++)
                    {
                        Console.WriteLine(this.results.getIndex(i).getCourseCode());
                        this.searchResultsBox.Items.Add(this.results.getIndex(i).getCourseCode());
                    }
                }
                else
                {
                    if (this.searchResultsBox.Items.Count > 0)
                    {
                        this.searchResultsBox.Items.Clear();
                    }
                    Console.WriteLine("DNE");
                }
            }
            this.courseDataBox.Text = "";
        }

        // Changes the search type
        private void searchMenu_NewSelect(object sender, EventArgs e)
        {
            int index = this.searchMenu.SelectedIndex;
            string str = "Selection " + index + "!";
            Console.WriteLine(str);
            this.searchType = index;
        }

        // Writes the course info based a selected class in the search results
        private void course_Description_Update(object sender, EventArgs e)
        {
            //Console.WriteLine("NEW SELECTION!");
            course selectedCourse = this.results.getIndex(this.searchResultsBox.SelectedIndex);
            Console.WriteLine(selectedCourse.getCourseCode());

            printInfo(selectedCourse);

        }

        // Updates the calendar when a course is added
        private void update_calendar_add(object sender, EventArgs e)
        {
            bool added = false;
            if (this.searchResultsBox.SelectedIndex < 0)
            {
                // Nothing to add to list (no selection)
                return;
            }
            added = this.courseCalendar.addCourse(this.results.getIndex(this.searchResultsBox.SelectedIndex));
            if (added == true)
            {
                foreach (course c in courseCalendar.courseList)
                {
                    string fixedStartTime = courseCalendar.fixStartTime(c.getStartTime()); //these functions make the times in the proper format
                    string fixedEndTime = courseCalendar.fixEndTime(c.getEndTime());
                    List<int> daysCols = new List<int>();
                    daysCols = findDaysCols(c.getDays());  //find the columns we need to add this course to
                    bool inSession = false; //used to indicate when all appropriate timeslots have been filled
                    foreach (DataRow dr in data.Rows) //cycle through rows
                    {
                        if (inSession && dr[0].ToString() != fixedEndTime) //if we haven't hit the end of the class yet, add it to the calendar
                        {
                            foreach (int i in daysCols) //adding to appropriate columns
                            {
                                dr[i] = c.getCourseCode();
                                
                                
                            }
                        }
                        else if (dr[0].ToString() == fixedStartTime) //this starts the loop of adding to time slots
                        {
                            foreach (int i in daysCols)
                            {
                                dr[i] = c.getCourseCode(); //add first timeslot
                               
                            }
                            
                            inSession = true; //set up to add to all timeslots
                        }
                        else if(dr[0].ToString() == fixedEndTime) //this ends the loop of adding to timeslots
                        {
                            inSession = false;
                        }
                    }
                }
            }
            else
            { Console.WriteLine("Course could not be added due to a conflict"); }

        }


        // Updates the calendar when a course is removed
        private void update_calendar_remove(object sender, EventArgs e)
        {
            bool removed = false;
            // Ensures only one cell is selected to removed a certain course
            if (this.calendarView.SelectedCells.Count != 1)
            {
                return;
            }

            else if (this.calendarView.SelectedCells.Count == 1 && this.courseCalendar.hasCourse(this.calendarView.SelectedCells[0].Value.ToString()))
            {
               
                course toRemove = this.courseCalendar.getCourse(this.calendarView.SelectedCells[0].Value.ToString());
                Console.WriteLine(toRemove.getCourseCode());
                string removeName = toRemove.getCourseCode();
                removed = this.courseCalendar.removeCourse(toRemove);
                if (removed == true)
                {
                    Console.WriteLine("COURSE REMOVED!");
                    foreach (DataColumn col in data.Columns) //cycle through columns
                    {
                        foreach (DataRow row in data.Rows) //cycle through rows
                        {
                            if (row[col.ColumnName].ToString() == removeName) //if the course is being removed, then set cell to empty
                            {
                                row[col.ColumnName] = "";
                            }
                        }
                    }
                }
                else
                { Console.WriteLine("Course could not be removed due to an error"); } //error if course trying to be removed is not there
            }
        }

        private void createTimeslotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtraCurWin win2 = new ExtraCurWin(); //creates the new timeslot window
            win2.Show(); //displays the window
        }

        private List<int> findDaysCols(string days) //formats a list of days into indices in our data table
        {
            char[] toFind = days.ToCharArray();
            List<int> results = new List<int>();
            foreach(char c in toFind)
            {
                switch (c)
                {
                    case 'M':
                        results.Add(1);
                        break;
                    case 'T':
                        results.Add(2);
                        break;
                    case 'W':
                        results.Add(3);
                        break;
                    case 'R':
                        results.Add(4);
                        break;
                    case 'F':
                        results.Add(5);
                        break;
                }
            }
            return results;
        }

        // Test attempt to prevent calendar from sorting when header is clicked
        private void do_not_sort(object sender, DataGridViewCellMouseEventArgs e)
        {
            Console.WriteLine("do not sort");
        }

        // Prints info based of selected cell on on the calendar.
        private void selected_cell(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.calendarView.SelectedCells.Count == 1 && this.courseCalendar.hasCourse(this.calendarView.SelectedCells[0].Value.ToString()))
            {
                
                string day;
                if (this.calendarView.SelectedCells[0].ColumnIndex == 2)
                {
                    day = "T";
                }
                else if (this.calendarView.SelectedCells[0].ColumnIndex == 4)
                {
                    day = "R";
                }
                else
                {
                    day = "MWF";
                }
                Console.WriteLine(day);
                course selectedCourse = this.courseCalendar.getCourse(this.calendarView.SelectedCells[0].Value.ToString(), day);
                Console.WriteLine(selectedCourse.getCourseCode());

                

                printInfo(selectedCourse);

            }
            else
            {
                this.courseDataBox.Text = "";
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void courseDataBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void printInfo(course selectedCourse)
        {
            this.courseDataBox.Text = "Code: " + selectedCourse.getCourseCode() + "\n" +
                                      "Title: " + selectedCourse.getShortTitle() + "\n" +
                                      "Day(s): " + selectedCourse.getDays() + "\n" +
                                      "Time: " + selectedCourse.getStartTime() + " - " + selectedCourse.getEndTime() + "\n" +
                                      "Building: " + selectedCourse.getBuilding() + "\n" +
                                      "Room: " + selectedCourse.getRoom() + "\n" +
                                      "Current Enrollment: " + selectedCourse.getEnrollment();
            courseDataBox.SelectAll();
            courseDataBox.SelectionColor = Color.Black;
        }

        private void exportButton_Click(object sender, EventArgs e)
        {

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Theme = this.Theme == MetroFramework.MetroThemeStyle.Light ? MetroFramework.MetroThemeStyle.Dark : MetroFramework.MetroThemeStyle.Light;
            this.Refresh();
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            this.Theme = this.Theme == MetroFramework.MetroThemeStyle.Light ? MetroFramework.MetroThemeStyle.Dark : MetroFramework.MetroThemeStyle.Light;
            if (this.Theme == MetroFramework.MetroThemeStyle.Dark)
            {
                this.calendarView.Theme = MetroFramework.MetroThemeStyle.Dark;
                this.calendarView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
                calendarView.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
            }
            else
            {
                this.calendarView.Theme = MetroFramework.MetroThemeStyle.Light;
                this.calendarView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
                calendarView.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
            }

            this.Refresh();
        }

        private void compareButton_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void metroToolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void turnOffHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.turnOffHelpToolStripMenuItem.Text = this.turnOffHelpToolStripMenuItem.Text == "Hide Tips" ? this.turnOffHelpToolStripMenuItem.Text = "Show Tips" : this.turnOffHelpToolStripMenuItem.Text = "Hide Tips";
            if (this.turnOffHelpToolStripMenuItem.Text == "Show Tips")
            {
                metroToolTip1.Active = false;
            }
            else
            {
                metroToolTip1.Active = true;
            }
        }


    }
}
