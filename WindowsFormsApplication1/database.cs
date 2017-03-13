using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApplication1
{
    public class database
    {
        int lineCount;
        string[,] courseObject;
        public database()
        {
            //Console.Write("TEST\n");
            //Console.Write("TEST\n");
            /*FileStream fs;
            try
            {
                fs = new FileStream("C:/Users/BensingJM1/Documents/COMP 350/TestCSharp/WindowsFormsApplication1/CourseDB_WithFictionalCapacities.xlsx", FileMode.Open, FileAccess.Read);
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);   
            }*/

            StreamReader data = null;
            try
            {
                data = new StreamReader("C:/Users/BensingJM1/Documents/COMP 350/TestCSharp/WindowsFormsApplication1/CourseDB_WithFictionalCapacities.csv");
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);   
            }

            
            lineCount = File.ReadLines("C:/Users/BensingJM1/Documents/COMP 350/TestCSharp/WindowsFormsApplication1/CourseDB_WithFictionalCapacities.csv").Count();
            //Console.WriteLine(lineCount);
            courseObject = new string[lineCount,10];
            for (int i = 0; i < lineCount; i++)
            {
                string test = data.ReadLine();
                string[] temp = test.Split(',');
                for (int j = 0; j < 10; j++)
                {
                    courseObject[i, j] = temp[j];
                    //Console.WriteLine(courseObject[i, j]);
                }
            }

            //Console.WriteLine(courseObject[100,0]);

            data.Close();

            // Test to print out data results
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(courseObject[100, i]);
            }

            //creates structure
        }
        public int[] search(string searchValue,int searchType = 2)
        {
            // These are the index values in the data structure
            // 0 : Course Code
            // 2 : Name (short)
            searchValue = searchValue.ToUpper();

            int[] indexArray = new int[lineCount];
            int count=0;

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
