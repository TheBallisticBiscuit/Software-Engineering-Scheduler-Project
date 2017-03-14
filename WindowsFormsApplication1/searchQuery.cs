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
        string[,] courseObject;
        int lineCount;
        public searchQuery(string[,] crslst, int lineCount)
        {
            this.courseObject = crslst;
            this.lineCount = lineCount;
        }

        public int[] search(string searchValue, int searchType = 2)
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
                if (courseObject[i, searchType].Contains(searchValue))
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
        public int[] search(string searchValue, int startTime, int stopTime)
        {

            return null;
        }
        //Search by department
        public int[] search(string searchValue)
        {

            return null;
        }
    }
}
