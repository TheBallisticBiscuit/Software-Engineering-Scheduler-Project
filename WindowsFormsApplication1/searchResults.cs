using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseScheduler
{
    // searchResults is the list of course that were found from the searchQuery.
    public class SearchResults
    {
        private List<Course> courseList;

        public SearchResults()
        {
            this.courseList = new List<Course>();
        }

        public SearchResults(List<Course> courseList)
        {
            this.courseList = courseList;
        }

        // returns the course based on the selected int
        public Course getIndex(int index)
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
        public List<Course> getResultsList()
        {
            return courseList;
        }
        
        // During a general search, this function will filter out the 
        // duplicates and adds only the courses that are new to the search
        // results list.
        public void combine(SearchResults list2)
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
