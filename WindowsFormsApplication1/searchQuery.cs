using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1;

namespace WindowsFormsApplication1
{
    public class searchQuery
    {
        database courseList;
        string currentSearch = null;
        int lineCount;
        public searchQuery(database data)
        {
            courseList = data;
            Console.WriteLine(data.getCourses()[1].getCourseCode().Contains("COMP"));
            Console.WriteLine(data.getCourses()[100].getCourseCode());
            Console.WriteLine(data.getCourses()[200].getCourseCode());
            this.lineCount = data.getLineCount();
        }

        public searchResults searchByCode(string searchValue)
        {
            // These are the index values in the data structure
            // 0 : Course Code
            // 2 : Name (short)
            searchValue = searchValue.ToUpper();

            List<course> results = new List<course>();

            // This will only work for code and name
            for (int i = 0; i < lineCount; i++)
            {
                if (courseList.getCourses()[i].getCourseCode().Contains(searchValue))
                {
                    results.Add(new course(courseList.getCourses()[i]));

                }
            }
            return new searchResults(results);
        }

        // Search by time
        public searchResults searchByTime(string searchValue)
        {
            searchValue = searchValue.ToUpper();
            char[] delimiterChars = { ' ', ',' };
            string[] searchComponents = searchValue.Split(delimiterChars);
            List<course> results = new List<course>();
            for(int i = 0; i < lineCount; i++) //cycles through database
            {
                for(int j = 0; j < searchComponents.Length; j++) //cycles through words entered
                {
                    if (courseList.getCourses()[i].getDays().Contains(searchComponents[j])
                        || courseList.getCourses()[i].getEndTime().Contains(searchComponents[j])
                        || courseList.getCourses()[i].getStartTime().Contains(searchComponents[j]))
                    {
                        results.Add(new course(courseList.getCourses()[i]));
                    }
                }
            }
            return new searchResults(results);
        }
        //Search by department
        public searchResults searchByDepartment(string searchValue)
        {

            return null;
        }

        public searchResults searchByName(string searchValue)
        {
            // These are the index values in the data structure
            // 0 : Course Code
            // 2 : Name (short)
            searchValue = searchValue.ToUpper();

            List<course> results = new List<course>();

            // This will only work for code and name
            for (int i = 0; i < lineCount; i++)
            {
                if (this.courseList.getCourses()[i].getLongTitle().Contains(searchValue))
                {
                    results.Add(courseList.getCourses()[i]);
                }
            }

            //returns search results
            return new searchResults(results);
        }


        //other searches here

        internal int[] searchByCode()
        {
            throw new NotImplementedException();
        }
    }
}
