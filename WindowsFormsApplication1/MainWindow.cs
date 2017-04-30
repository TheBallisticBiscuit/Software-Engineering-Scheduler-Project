﻿using MetroFramework.Forms;
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
        MetroFramework.Controls.MetroGrid calendarView2 = new MetroFramework.Controls.MetroGrid();
        int searchType = 0;
        bool expanded = false;

        ExtraCurWin extraWin;

        public MainWindow()
        {
            InitializeComponent();

            this.courselist = new database();
            this.courseSearch = new searchQuery(courselist);
            this.results = new searchResults();

            data = csvToTable("../../blankCalendar.csv", true);

            calendarView.DataSource = data;


            foreach (DataGridViewColumn col in calendarView.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            }

            courseDataBox.Enabled = false;

            calendarView.Columns[0].Width = 60;

            calendarView.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;

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
            string noResults = "";
            metroBar.Value = 0;
            metroBar.Update();
            if (e.KeyChar == (char)Keys.Return)
            {
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
                    searchString = "";
                    if (mondayCheckBox.Checked)
                    {
                        searchString += "M,";
                    }
                    if (tuesdayCheckBox.Checked)
                    {
                        searchString += "T,";
                    }
                    if (wednesdayCheckBox.Checked)
                    {
                        searchString += "W,";
                    }
                    if (thursdayCheckBox.Checked)
                    {
                        searchString += "R,";
                    }
                    if (fridayCheckBox.Checked)
                    {
                        searchString += "F";
                    }
                    this.results = this.courseSearch.searchByTime(searchString, startTimeBox.Text, endTimeBox.Text);
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
                        this.searchResultsBox.Items.Add(this.results.getIndex(i).getCourseCode());
                        metroBar.Value = i * 100 / this.results.size();
                        metroBar.Update();             
                    }
                    metroBar.Value = 100;
                    metroBar.Update();
                }
                else
                {
                    if (this.searchResultsBox.Items.Count > 0)
                    {
                        this.searchResultsBox.Items.Clear();
                    }
                    noResults = "No results found";
                    this.searchResultsBox.Items.Add(noResults);
                }
            }
            this.courseDataBox.Text = "";
        }

        // Changes the search type
        private void searchMenu_NewSelect(object sender, EventArgs e)
        {
            int index = this.searchMenu.SelectedIndex;
            string str = "Selection " + index + "!";
            this.searchType = index;
            if (index == 3)
            {
                int oldHeight = searchResultsBox.Height;
                Point oldLoc = searchResultsBox.Location;
                mondayCheckBox.Visible = true;
                tuesdayCheckBox.Visible = true;
                wednesdayCheckBox.Visible = true;
                thursdayCheckBox.Visible = true;
                fridayCheckBox.Visible = true;
                startTimeBox.Visible = true;
                endTimeBox.Visible = true;
                searchResultsBox.Height = 213;
                searchResultsBox.Location = new Point(20, 217);
            }
            else
            {
                searchResultsBox.Height = 270;
                searchResultsBox.Location = new Point(20, 160);
                mondayCheckBox.Visible = false;
                tuesdayCheckBox.Visible = false;
                wednesdayCheckBox.Visible = false;
                thursdayCheckBox.Visible = false;
                fridayCheckBox.Visible = false;
                startTimeBox.Visible = false;
                endTimeBox.Visible = false;

            }
        }

        // Writes the course info based a selected class in the search results
        private void course_Description_Update(object sender, EventArgs e)
        {
            course selectedCourse = this.results.getIndex(this.searchResultsBox.SelectedIndex);
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
                updateCalendarGraphic();
            }
            else
            {
            }
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
                //Console.WriteLine(toRemove.getCourseCode());
                string removeName = toRemove.getCourseCode();
                removed = this.courseCalendar.removeCourse(toRemove);
                if (removed == true)
                {
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
                {
                }
            }
        }

        private void updateCalendarGraphic()
        {
            foreach (course c in courseCalendar.courseList)
            {
                string fixedStartTime = calendar.fixStartTime(c.getStartTime()); //these functions make the times in the proper format
                string fixedEndTime = calendar.fixEndTime(c.getEndTime());
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
                    else if (dr[0].ToString() == fixedEndTime) //this ends the loop of adding to timeslots
                    {
                        inSession = false;
                    }
                }
            }
        }

        private void clearCalendarGraphic()
        {
            foreach (DataColumn col in data.Columns) //cycle through columns
            {
                foreach (DataRow row in data.Rows) //cycle through rows
                {
                    if (col.ColumnName.ToString() != "Time")
                    {
                        row[col.ColumnName] = "";
                    }
                }
            }
        }


        private void createTimeslotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            extraWin = new ExtraCurWin(); //creates the new timeslot window
            extraWin.Show(); //displays the window
            extraWin.metroTile1.Click += (addExtraCur);
        }

        private void addExtraCur(object sender, EventArgs e)
        {
            if (extraWin.okPressed)
            {
                //Console.WriteLine("TRUE");
                if (courseCalendar.addCourse(extraWin.newExtra))
                {
                    //Console.WriteLine("Adding course");
                    extraWin.Close();
                }
                else
                {
                    Alert AlertWin = new Alert();
                    AlertWin.set_text_alert("Extracurricular conflicts with a course", true);
                }
            }
            updateCalendarGraphic();
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
                else if (this.calendarView.SelectedCells[0].ColumnIndex == 1)
                {
                    day = "M";
                }
                else if (this.calendarView.SelectedCells[0].ColumnIndex == 3)
                {
                    day = "W";
                }
                else if (this.calendarView.SelectedCells[0].ColumnIndex == 5)
                {
                    day = "F";
                }
                else
                {
                    day = "MWF";
                }

                course selectedCourse = this.courseCalendar.getCourse(this.calendarView.SelectedCells[0].Value.ToString(), day);


                
                if (selectedCourse != null)
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
            if (selectedCourse != null)
            {
                this.courseDataBox.Text = "Code: " + selectedCourse.getCourseCode() + "\n" +
                    "Title: " + selectedCourse.getShortTitle() + "\n" +
                    "Day(s): " + selectedCourse.getDays() + "\n" +
                    "Time: " + selectedCourse.getConvStartTime() + " - " + selectedCourse.getConvEndTime() + "\n" +
                    "Building: " + selectedCourse.getBuilding() + "\n" +
                    "Room: " + selectedCourse.getRoom() + "\n" +
                    "Current Enrollment: " + selectedCourse.getEnrollment();
            }
            else
            {
                this.courseDataBox.Text = "";
            }
            courseDataBox.SelectAll();
            courseDataBox.SelectionColor = Color.Black;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = this.saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            { 
                // Save the file
                courseCalendar.save(this.saveFileDialog1.FileName);
                Console.WriteLine(this.saveFileDialog1.FileName);
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Open the file
                courseCalendar.open(this.openFileDialog1.FileName);
                Console.WriteLine(this.openFileDialog1.FileName);
                clearCalendarGraphic();
                updateCalendarGraphic();
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            codes export = new codes();
            export.Show();
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
                this.compareButton.Theme = MetroFramework.MetroThemeStyle.Dark;
                this.exportButton.Theme = MetroFramework.MetroThemeStyle.Dark;
                this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
                this.metroToggle1.Theme = MetroFramework.MetroThemeStyle.Dark;
                this.menuStrip1.BackColor = BackColor;
                this.menuStrip1.ForeColor = Color.LightGray;
                this.searchBox.Theme = MetroFramework.MetroThemeStyle.Dark;
                this.searchMenu.Theme = MetroFramework.MetroThemeStyle.Dark;
                this.searchResultsBox.ForeColor = Color.LightGray;
                this.searchResultsBox.BackColor = BackColor;
                this.courseDataBox.BackColor = BackColor;
                calendarView.ForeColor = Color.WhiteSmoke;
                if (expanded == true)
                {
                    this.calendarView2.Theme = MetroFramework.MetroThemeStyle.Dark;
                    this.calendarView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
                    this.calendarView2.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
                    this.calendarView2.ForeColor = Color.WhiteSmoke;
                }
                
            }
            else
            {
                this.calendarView.Theme = MetroFramework.MetroThemeStyle.Light;
                this.calendarView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
                calendarView.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
                this.compareButton.Theme = MetroFramework.MetroThemeStyle.Light;
                this.exportButton.Theme = MetroFramework.MetroThemeStyle.Light;
                this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
                this.metroToggle1.Theme = MetroFramework.MetroThemeStyle.Light;
                this.menuStrip1.BackColor = Color.WhiteSmoke;
                this.menuStrip1.ForeColor = Color.Black;
                this.searchBox.Theme = MetroFramework.MetroThemeStyle.Light;
                this.searchMenu.Theme = MetroFramework.MetroThemeStyle.Light;
                this.searchResultsBox.ForeColor = Color.Black;
                this.searchResultsBox.BackColor = BackColor;
                this.courseDataBox.ForeColor = Color.Black;
                this.courseDataBox.BackColor = BackColor;
                if (expanded == true)
                {
                    this.calendarView2.Theme = MetroFramework.MetroThemeStyle.Light;
                    this.calendarView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
                    this.calendarView2.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
                }


            }

            this.Refresh();
        }

        private void compareButton_Click(object sender, EventArgs e)
        {
            
            if (expanded == false)
            {
                DialogResult result = this.openFileDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                    DataTable data2 = csvToTable("../../blankCalendar.csv", true);

                    calendar compCalendar = new calendar();

                    // Open the file
                    compCalendar.open(this.openFileDialog1.FileName);
                    Console.WriteLine(this.openFileDialog1.FileName);

                    foreach (course c in compCalendar.courseList)
                    {
                        string fixedStartTime = calendar.fixStartTime(c.getStartTime()); //these functions make the times in the proper format
                        string fixedEndTime = calendar.fixEndTime(c.getEndTime());
                        List<int> daysCols = new List<int>();
                        daysCols = findDaysCols(c.getDays());  //find the columns we need to add this course to
                        bool inSession = false; //used to indicate when all appropriate timeslots have been filled
                        foreach (DataRow dr in data2.Rows) //cycle through rows
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
                            else if (dr[0].ToString() == fixedEndTime) //this ends the loop of adding to timeslots
                            {
                                inSession = false;
                            }
                        }
                    }

                    calendarView2.DataSource = data2;
                }
                else
                {
                    return;
                }
                

                    
                    calendarView2.Location = new Point(calendarView.Left + 575, calendarView.Top);
                    calendarView2.AllowUserToAddRows = false;
                    calendarView2.AllowUserToDeleteRows = false;
                    calendarView2.AllowUserToResizeColumns = false;
                    calendarView2.AllowUserToResizeRows = false;
                    calendarView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    calendarView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    calendarView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
                    calendarView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
                    calendarView2.EnableHeadersVisualStyles = false;
                    calendarView2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
                    calendarView2.MultiSelect = false;
                    calendarView2.Name = "calendarView2";
                    calendarView2.ReadOnly = true;
                    calendarView2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
                    calendarView2.RowHeadersVisible = false;
                    calendarView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                    calendarView2.RowTemplate.ReadOnly = true;
                    calendarView2.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
                    calendarView2.ScrollBars = System.Windows.Forms.ScrollBars.None;
                    calendarView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
                    calendarView2.Size = new System.Drawing.Size(601, 596);
                    calendarView2.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
                    calendarView2.Enabled = true;
                    this.Controls.Add(calendarView2);
                    calendarView2.Columns[0].Width = 60;
                    foreach (DataGridViewColumn col in calendarView2.Columns)
                    {
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
                    }
                    this.WindowState = FormWindowState.Maximized;
                    compareButton.Text = "Close";
                    expanded = true;
                    if (this.Theme == MetroFramework.MetroThemeStyle.Dark)
                    {
                        this.calendarView2.Theme = MetroFramework.MetroThemeStyle.Dark;
                        this.calendarView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
                        this.calendarView2.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
                        this.calendarView2.ForeColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        this.calendarView2.Theme = MetroFramework.MetroThemeStyle.Light;
                        this.calendarView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
                        this.calendarView2.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
                    }
                
                
            }
            else
            {
                this.Controls.Remove(calendarView2);
                this.WindowState = FormWindowState.Normal;
                compareButton.Text = "Compare";
                expanded = false;
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void metroToolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void metroProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hideTipsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.hideTipsToolStripMenuItem.Text = this.hideTipsToolStripMenuItem.Text == "Hide Tips" ? this.hideTipsToolStripMenuItem.Text = "Show Tips" : this.hideTipsToolStripMenuItem.Text = "Hide Tips";
            if (this.hideTipsToolStripMenuItem.Text == "Show Tips")
            {
                metroToolTip1.Active = false;
            }
            else
            {
                metroToolTip1.Active = true;
            }
        }

        private void pmCheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
