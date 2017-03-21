using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        database courselist;
        searchQuery courseSearch;
        searchResults results;
        List<course> searchResultList;
        calendar courseCalendar = new calendar();
        int searchType = 1;
        public Form1()
        {
            InitializeComponent();

            this.courselist = new database();
            this.courseSearch = new searchQuery(courselist);
            this.results = new searchResults();

            DataTable data = csvToTable("blankCalendar.csv", true);

            calendarView.DataSource = data;
        }

        private void Form1_Load(object sender, EventArgs e)
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



            for (int i = index; i < csvData.Length; i++)
            {
                csvTable.Rows.Add(csvData[i].Split(','));
            }

            return csvTable;
        }

        private void calendarView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable data = csvToTable("blankCalendar.csv", true);

            calendarView.DataSource = data;
        }

        private void searchBox_Enter(object sender, KeyPressEventArgs e)
        {
            //int[] searchIndex;
            if (e.KeyChar == (char)Keys.Return)
            {
                Console.WriteLine("ENTER PRESSED!");
                string searchString = this.searchBox.Text;
                if (searchType == 0)
                {
                    //searchIndex = this.courseSearch.searchByCode(searchString);
                    //this.searchResultList = results.updateResults(searchIndex);
                    this.results = this.courseSearch.searchByCode(searchString);
                }
                else if (searchType == 1)
                {
                    //searchIndex = this.courseSearch.searchByName(searchString);
                    //this.searchResultList = results.updateResults(searchIndex);
                    this.results = this.results = this.courseSearch.searchByName(searchString);
                }
                else if (searchType == 2)
                {
                    //searchIndex = this.courseSearch.searchByTime(searchString);
                    this.results = this.results = this.courseSearch.searchByTime(searchString);
                }
                else if (searchType == 3)
                {
                    //searchIndex = this.courseSearch.searchByDepartment(searchString);
                    //this.searchResultList = results.updateResults(searchIndex);
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

        private void searchMenu_NewSelect(object sender, EventArgs e)
        {
            
            int index = this.searchMenu.SelectedIndex;
            string str = "Selection " + index + "!";
            Console.WriteLine(str);
            this.searchType = index;
        }

        private void course_Description_Update(object sender, EventArgs e)
        {
            Console.WriteLine("NEW SELECTION!");
            course selectedCourse = this.results.getIndex(this.searchResultsBox.SelectedIndex);
            Console.WriteLine(selectedCourse.getCourseCode());
            this.courseDataBox.Text = "Code: " + selectedCourse.getCourseCode()+"\n"+
                                      "Title: " + selectedCourse.getShortTitle()+"\n"+
                                      "Day(s): " + selectedCourse.getDays() + "\n"+
                                      "Time: " + selectedCourse.getStartTime()+ " - " + selectedCourse.getEndTime();
        }

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
            { Console.WriteLine("Course Added"); }
            else
            { Console.WriteLine("Course could not be added due to a conflict"); }
        }
        private void update_calendar_remove(object sender, EventArgs e)
        {
            bool removed = false;
            if (this.searchResultsBox.SelectedIndex < 0)
            {
                // Nothing to remove to list (no selection)
                return;
            }
            removed = this.courseCalendar.removeCourse(this.results.getIndex(this.searchResultsBox.SelectedIndex));
            if (removed == true)
            { Console.WriteLine("Course Removed"); }
            else
            { Console.WriteLine("Course could not be removed due to an error"); }
        }
    }

}
