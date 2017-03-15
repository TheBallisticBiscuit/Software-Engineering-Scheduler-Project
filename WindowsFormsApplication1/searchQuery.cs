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
        string[,] courseList;
        int lineCount;
        
        public searchQuery(string[,] crslst, int lineCount)
        {
            this.courseList = crslst;
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
                if (courseList[i, 0].Contains(searchValue))
                {
                    indexArray[count] = i;
                    count++;
                }
            }

            //returns search results

            if (count > 0)
            {
                return indexArray;
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
                if (courseList[i, 2].Contains(searchValue))
                {
                    indexArray[count] = i;
                    count++;
                }
            }

            //returns search results

            if (count > 0)
            {
                return indexArray;
            }
            else
            {
                return null;
            }
        }


        //other searches here
    }
}
