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
        public List<course> results = new List<course>();
        private List<course> courseList;
        //private int selected;
        public searchResults(List<course> courseList)
        {
            this.courseList = courseList;
        }
        // Clears the results and returns a new list base on
        // the search results.
        public List<course> updateResults(int[] resultIndex)
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
        }
        // returns the course based on the selected int
        public course getSelected(int selected)
        {
            return this.results[selected];
        }
    }
}
