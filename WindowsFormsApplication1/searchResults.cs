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

        // Size of the list
        public int size()
        {
            return courseList.Count;
        }

        public List<course> getResultsList()
        {
            return courseList;
        }

        public void add(searchResults results)
        {
           /* foreach (course c in results.getResultsList())
            {
                if (this.courseList.Contains(c) == false)
                {
                    this.courseList.Add(c);
                }
                else
                {
                    Console.WriteLine(c.getCourseCode());
                }
            }*/

            List<course> temp = results.getResultsList();

            bool found = false;
            for (int i = 0; i < temp.Count; i++)
            {
                for (int j = 0; j < this.courseList.Count; j++)
                {
                    if (temp[i].getCourseCode() == this.courseList[j].getCourseCode())
                    {
                        found = true;
                    }
                }
                if (found)
                { 
                    this.courseList.Add(temp[i]);
                }
                found = false;
            }

            //List<course> temp = this.courseList.Union(results.getResultsList());

            //this.courseList.AddRange(results.getResultsList());
        }

        public void filter()
        {

            for (int i = 0; i < size(); i++)
            {
                for (int j = 1; j < size(); j++)
                {
                    if (this.courseList[i].getCourseCode() == this.courseList[j].getCourseCode())
                    {
                      this.courseList.RemoveAt(j);
                    }
                }
            }
   
        }

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
