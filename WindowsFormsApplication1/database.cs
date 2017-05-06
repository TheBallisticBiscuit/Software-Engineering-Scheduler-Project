using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CourseScheduler
{
    // database class is used to get the course database proved to us and store it. 
    public class Database
    {
        int lineCount;
        private List<Course> coursesList;
        //private List<course> testCoursesList;
        public Database()
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
            coursesList = new List<Course>();
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
                coursesList.Add(new CourseScheduler.Course(enrollment, capacity, courseDBObject[i, 0],courseDBObject[i, 1],courseDBObject[i, 2],courseDBObject[i, 3],courseDBObject[i, 4],courseDBObject[i, 5],courseDBObject[i, 6],courseDBObject[i, 7]));
            }
            data.Close();
        }

        // Gets the list of courses
        public List<Course> getCourses()
        {
            return coursesList;
        }

        // Returns the number of courses in the database
        public int getLineCount()
        {
            return lineCount-1;
        }
    }
}
