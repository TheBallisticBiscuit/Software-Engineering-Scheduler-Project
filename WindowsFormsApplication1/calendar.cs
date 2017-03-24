using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class calendar
    {
        public List<course> courseList;

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

        public string fixStartTime(string oddStart)
        {
            string[] sTime = oddStart.Split(':'); //splits the input by the ':'

            int hour = Convert.ToInt32(sTime[0]); //gets the hour
            int minute = Convert.ToInt32(sTime[1]); //gets the minute

            if (minute <= 15) //if the class starts before quater past, we say it starts on the hour
                minute = 0;
            else if (minute > 15 && minute <= 45) //if the class starts between quarter past and quarter till, we
                minute = 30;                      //say it starts at half past
            else if (minute > 45) //if the class starts after quarter till, we say it starts at the top of the next hour
            {
                minute = 0;
                hour++;
            }

            sTime[0] = Convert.ToString(hour); //convert the hour back to a string

            if (minute < 10) //if minute is less than 10 (read 0), we stick an extra 0 in front to maintain the format
                sTime[1] = '0' + Convert.ToString(minute);
            else
                sTime[1] = Convert.ToString(minute); //otherwise, just convert minutes back to a string

            string fixTime = sTime[0] + ':' + sTime[1] + ':' + sTime[2]; //recombine the time

            return fixTime; //return the fixed time
        }

        public string fixEndTime(string oddEnd)
        {
            string[] sTime = oddEnd.Split(':'); //split the input by the ':'

            int hour = Convert.ToInt32(sTime[0]); //get the hour
            int minute = Convert.ToInt32(sTime[1]); //get the minute

            if (minute < 15) //if the class ends before quarter past, we say it ends at the top of the hour
                minute = 0;
            else if (minute >= 15 && minute <= 30) //if the class ends after quarter past, but before half past
                minute = 30;                       //we say it ends at half past
            else if (minute > 30) //if the class ends after half past, we say it ends at the top of the following hour
            {
                minute = 0;
                hour++;
            }

            sTime[0] = Convert.ToString(hour); //convert the hour back into a string

            if (minute < 10) //if the minute is less than 10, stick a '0' in front to maintain the format
                sTime[1] = '0' + Convert.ToString(minute);
            else
                sTime[1] = Convert.ToString(minute); //otherwise just convert it to a string

            string fixTime = sTime[0] + ':' + sTime[1] + ':' + sTime[2]; //recombine the time array

            return fixTime; //return the fixed time
        }
    }
}
