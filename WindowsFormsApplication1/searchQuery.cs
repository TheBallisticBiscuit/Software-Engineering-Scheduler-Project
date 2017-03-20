using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class searchQuery
    {

        string currentSearch = null;
        List<course> courseList = new List<course>();
        int lineCount;
        
        public searchQuery(List<course> crslst, int lineCount)
        {
            this.courseList = crslst;
            Console.WriteLine(courseList[1].getCourseCode().Contains("COMP"));
            Console.WriteLine(courseList[100].getCourseCode());
            Console.WriteLine(courseList[200].getCourseCode());
            this.lineCount = lineCount;
        }

        public int[] searchByCode(string searchValue)
        {
            // These are the index values in the data structure
            // 0 : Course Code
            // 2 : Name (short)
            searchValue = searchValue.ToUpper();

            int[] indexArray = new int[lineCount];
            int count = 0;

            // This will only work for code and name
            for (int i = 0; i < lineCount; i++)
            {
                if (courseList[i].getCourseCode().Contains(searchValue))
                {
                    //Console.WriteLine(courseList[i].getCourseCode());
                    indexArray[count] = i;
                    count++;

                }
            }
            //returns search results
            int[] returnArray = new int[count];
            for(int i = 0; i < count; i++)
            {
                returnArray[i] = indexArray[i];
            }
            if (count > 0)
            {
                return returnArray;
            }
            else
            {
                return null;
            }
        }
        // Search by time
        public int[] searchByTime(string searchValue, int startTime, int stopTime)
        {
            return null;
        }
        //Search by department
        public int[] searchByDepartment(string searchValue)
        {

            return null;
        }

        public int[] searchByName(string searchValue)
        {
            // These are the index values in the data structure
            // 0 : Course Code
            // 2 : Name (short)
            searchValue = searchValue.ToUpper();

            int[] indexArray = new int[lineCount];
            int count = 0;

            // This will only work for code and name
            for (int i = 0; i < lineCount; i++)
            {
                if (this.courseList[i].getLongTitle().Contains(searchValue))
                {
                    indexArray[count] = i;
                    count++;
                }
            }

            //returns search results

            int[] returnArray = new int[count];
            for (int i = 0; i < count; i++)
            {
                returnArray[i] = indexArray[i];
            }
            if (count > 0)
            {
                return returnArray;
            }
            else
            {
                return null;
            }
        }


        //other searches here

        internal int[] searchByCode()
        {
            throw new NotImplementedException();
        }
    }
}
