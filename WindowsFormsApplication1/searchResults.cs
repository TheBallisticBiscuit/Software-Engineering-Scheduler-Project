using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseScheduler
{
    // searchResults is the list of course that were found from the searchQuery.
    public class searchResults
    {
        private List<course> courseList;

        public searchResults()
        {
            this.courseList = new List<course>();
        }

        public searchResults(List<course> courseList)
        {
            this.courseList = courseList;
        }

        // returns the course based on the selected int
        public course getIndex(int index)
        {
            return this.courseList[index];
        }

        // Checks to see if the courses exist in the results
        public bool hasCourses()
        {
            if (courseList.Count > 0)
            {
                return true;
            }
            return false;
        }

        // Size of the list
        public int size()
        {
            return courseList.Count;
        }
    }
}
