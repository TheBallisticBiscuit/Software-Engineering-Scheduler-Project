using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CourseScheduler
{
    // database class is used to get the course database proved to us and store it. 
    public class database
    {
        int lineCount;
        private List<course> coursesList;
        //private List<course> testCoursesList;
        public database()
        {
            string[,] courseDBObject;
            // Opens the database csv file and 
            StreamReader data = null;
            try
            {
                data = new StreamReader("../../CourseDB_WithFictionalCapacities.csv");
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);   
            }
            
            lineCount = File.ReadLines("../../CourseDB_WithFictionalCapacities.csv").Count();
            courseDBObject = new string[lineCount,10];
            coursesList = new List<course>();
            data.ReadLine(); //Ignores titles of columns
            for (int i = 0; i < lineCount-1; i++)
            {
                string test = data.ReadLine();
                string[] temp = test.Split(',');
                for (int j = 0; j < 10; j++)
                {
                    courseDBObject[i, j] = temp[j];
                }
              
                int enrollment = Int32.Parse(courseDBObject[i, 8]);
                
                int capacity = Int32.Parse(courseDBObject[i, 9]);
                
                // Adds a new course to the list
                coursesList.Add(new CourseScheduler.course(enrollment, capacity, courseDBObject[i, 0],courseDBObject[i, 1],courseDBObject[i, 2],courseDBObject[i, 3],courseDBObject[i, 4],courseDBObject[i, 5],courseDBObject[i, 6],courseDBObject[i, 7]));
            }

            data.Close();

            //creates structure
            /*
            testCoursesList = new List<course>();
            testCoursesList.Add(new WindowsFormsApplication1.course(10, 30, "course1", "course1Short", "course1Long", "10:00", "10:50", "MWF", "STEM", "376"));
            testCoursesList.Add(new WindowsFormsApplication1.course(10, 30, "course2", "course2Short", "course2Long", "10:00", "10:50", "MWF", "STEM", "376"));
            testCoursesList.Add(new WindowsFormsApplication1.course(10, 30, "course3", "course3Short", "course3Long", "10:00", "10:50", "MWF", "STEM", "376"));
            testCoursesList.Add(new WindowsFormsApplication1.course(10, 30, "course4", "course4Short", "course4Long", "10:05", "11:15", "TH", "STEM", "376"));
            */
        }

        // Gets the list of courses
        public List<course> getCourses()
        {
            return coursesList;
        }
        /*public List<course> getTestCourses()
        {
            //return courseDBObject;
            return testCoursesList;
        }*/

        // Returns the number of courses in the database
        public int getLineCount()
        {
            return lineCount-1;
        }
    }
}
