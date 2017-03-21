using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class calendar
    {
        List<course> courseList;

        public calendar()
        {
            courseList = new List<course>();
        }
        // Adds a selected course to the calander class
        public bool addCourse(course newCourse)
        {
            if (courseList.Contains(newCourse))
            {
                Console.Write("ALREADY EXISTS");
            }
            else
            {
                for(int i = 0; i < courseList.Count; i++)
                {
                    if(courseList[i].getStartTime() == newCourse.getStartTime() && courseList[i].getDays() == newCourse.getDays())
                    {
                        Console.WriteLine("Date/Time conflict");
                        return false; 
                    }
                }
                courseList.Add(newCourse);
                return true;
            }
            return false;
        }

        // Removes a selected course from the calander class
        public bool removeCourse(course oldCourse)
        {
            if (courseList.Contains(oldCourse))
            {
                courseList.Remove(oldCourse);
                return true;
            }
            return false;
        }

        // Returns the lists of courses in the calander class
        public List<course> returnList()
        {
            return courseList;
        }

        // Returns whether or not a course has been added based on course code
        public bool hasCourse(string courseCode)
        {
            for (int i = 0; i < courseList.Count; i++)
            {
                if (courseList[i].getCourseCode() == courseCode)
                {
                    return true;
                }
            }
            return false;
        }

        // returns a course based on course code
        public course getCourse(string courseCode)
        {
            for(int i = 0; i < courseList.Count; i++)
            {
                if (courseList[i].getCourseCode() == courseCode)
                {
                    return courseList[i];
                }
            }
            return null;
        }
    }
}
