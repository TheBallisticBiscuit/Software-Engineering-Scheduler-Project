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
            if (courseList.Count > 0) { return this.courseList[index]; }
            else { return null; }
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

        // Returns the size of the list
        public int size()
        {
            return courseList.Count;
        }

        // Gets the course list
        public List<course> getResultsList()
        {
            return courseList;
        }
        
        // During a general search, this function will filter out the 
        // duplicates and adds only the courses that are new to the search
        // results list.
        public void combine(searchResults list2)
        {

            for (int i = 0; i < this.size(); i++)
            {
                for (int j = 0; j < list2.size(); j++)
                {
                    if (this.courseList[i].getCourseCode() == list2.courseList[j].getCourseCode()) //checks if for duplicates
                    {
                        list2.courseList.RemoveAt(j); //if a duplicate is found, remove it from the second list
                    }
                }
            }

            this.courseList.AddRange(list2.courseList); // combine the two lists
        }

    }
}
