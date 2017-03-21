using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WindowsFormsApplication1
{
    public class searchResults
    {
        //private List<course> results = new List<course>();
        private List<course> courseList;
        //private int selected;
        public searchResults()
        {
            this.courseList = new List<course>();
        }
        public searchResults(List<course> courseList)
        {
            this.courseList = courseList;
        }
        // Clears the results and returns a new list base on
        // the search results.
        // OBSOLETE
        /*public List<course> updateResults(int[] resultIndex)
        {
            if (this.results.Count() > 0)
            {
                this.results.Clear();
            }
            if (resultIndex != null)
            {
                for (int i = 0; i < resultIndex.Length; i++)
                {
                    this.results.Add(courseList[resultIndex[i]]);
                }
                return this.results;
            }
            else
            {
                return null;
            }
        }*/
        //-----------------------------------

        // returns the course based on the selected int
        public course getIndex(int index)
        {
            return this.courseList[index];
        }

        public bool hasCourses()
        {
            if (courseList.Count > 0)
            {
                return true;
            }
            return false;
        }

        public int size()
        {
            return courseList.Count;
        }
    }
}
