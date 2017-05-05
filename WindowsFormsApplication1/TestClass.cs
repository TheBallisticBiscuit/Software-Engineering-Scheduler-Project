using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CourseScheduler
{
    class TestClass
    {
        database courselist;
        searchQuery courseSearch;
        searchResults results;
        calendar courseCalendar = new calendar();

        public TestClass()
        {
            this.courselist = new database();
            this.courseSearch = new searchQuery(courselist);
            this.results = new searchResults();
        }

        public void run()
        {
            TestSearch();
            TestCalendarAdd();
            TestCalendarRemove();
        }

        public void TestSearch()
        {
            this.results = this.courseSearch.searchByCode("HUMA 102");
            Debug.Assert(this.results.getResultsList().Count == 10, "Incorrect course count for HUMA 102");
            this.results = this.courseSearch.searchByCode("MATH 222");
            Debug.Assert(this.results.getResultsList().Count == 4, "Incorrect course count for MATH 222");
            this.results = this.courseSearch.searchByCode("SCIC");
            Debug.Assert(this.results.getResultsList().Count == 14, "Incorrect course count for SCIC");
            this.results = this.courseSearch.searchByName("Calculus");
            Debug.Assert(this.results.getResultsList().Count == 18, "Incorrect course count for Calculus");
            this.results = this.courseSearch.searchByDepartment("SCIENCE");
            Debug.Assert(this.results.getResultsList().Count == 14, "Incorrect course count for Science");
        }

        public void TestCalendarAdd()
        {
            course testCourse = new course(10, 20, "TEST 101", "TEST COURSE", "TESTING COURSE TEST COURSE", "10:00", "11:00", "MWF", "BUILDING","100");
            Debug.Assert(this.courseCalendar.addCourse(testCourse) == true, "CLASS FAILED TO BE REMOVED");
            testCourse = new course(10, 20, "TEST 201", "TEST COURSE 2", "TESTING COURSE TEST COURSE 2", "13:00", "15:00", "MWF", "BUILDING","20");
            this.courseCalendar.addCourse(testCourse);
            Debug.Assert(this.courseCalendar.getCourse("TEST 201").getCourseCode() == "TEST 201", "CLASS FAILED TO BE ADDEDD");
        }

        public void TestCalendarRemove()
        {
            course testCourse = new course(10, 20, "TEST 101", "TEST COURSE", "TESTING COURSE TEST COURSE", "10:00", "11:00", "MWF", "BUILDING","100");
            Debug.Assert(this.courseCalendar.removeCourse(testCourse)==true, "CLASS FAILED TO BE REMOVED");

            //Debug.Assert(this.courseCalendar.removeCourse(testCourse) == false, "COURSE REMOVED"); 
        }
    }
}
