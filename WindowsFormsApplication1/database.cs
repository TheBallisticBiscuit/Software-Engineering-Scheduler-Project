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
                data = new StreamReader("CourseDB_WithFictionalCapacities.csv");
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);   
            }

            
            lineCount = File.ReadLines("CourseDB_WithFictionalCapacities.csv").Count();
            Console.WriteLine(lineCount);
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

           // Console.WriteLine(courseObject[100,0]);

            data.Close();

            // Test to print out data results
            for (int i = 0; i < 10; i++)
            {
               // Console.WriteLine(courseObject[100, i]);
            }

            //creates structure
        }

        public string[,] getCourses()
        {
            return courseObject;
        }
        public int getLineCount()
        {
            return lineCount;
        }
    }
}
