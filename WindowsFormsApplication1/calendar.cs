using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CourseScheduler
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
                Console.WriteLine("COURSE ALREADY EXISTS");
                Alert AlertWin = new Alert();
                AlertWin.Show();
                AlertWin.set_text_alert("Course already added.");
            }
            else
            {
                for(int i = 0; i < courseList.Count; i++)
                {
                    if ( (courseList[i].getDays().Contains(newCourse.getDays()) || newCourse.getDays().Contains(courseList[i].getDays()))&& courseList[i].getStartTime() == newCourse.getStartTime() )
                    {
                        //
                        Console.WriteLine("Date/Time conflict");
                        Alert AlertWin = new Alert();
                        AlertWin.Show();
                        string txt = "Date/Time conflict with this course at\nDay(s): " + newCourse.getDays() + " Time: " + newCourse.getStartTime(); 
                        AlertWin.set_text_alert(txt,true);
                        return false; 
                    }
                }
                if (newCourse != null)
                {
                    courseList.Add(newCourse);
                    return true;
                }
            }
            return false;
        }

        // Removes a selected course from the calander class
        // Removes all courses given a course it will remove all
        // courses with the same course code.
        public bool removeCourse(course oldCourse)
        {
            //string code = oldCourse.getCourseCode();
            int count = 0;
            List<course> toBeRemoved = new List<course>();
            for(int i = 0; i < courseList.Count;i++)
            {
                if (courseList[i].getCourseCode() == oldCourse.getCourseCode())
                {
                    toBeRemoved.Add(courseList[i]);
                    count++;
                }
            }
            foreach (var cs in toBeRemoved)
            {
                courseList.Remove(cs);
            }
            if (count > 0)
            {
                return true;
            }
            // Old way of removing courses
            /*if (courseList.Contains(oldCourse))
            {
                courseList.Remove(oldCourse);
                return true;
            }*/
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

        // returns a course based on course code and day the course is active
        public course getCourse(string courseCode, string day)
        {
            for (int i = 0; i < courseList.Count; i++)
            {
                if (courseList[i].getCourseCode() == courseCode && courseList[i].getDays().Contains(day))
                {
                    return courseList[i];
                }
            }
            return null;
        }

        public string fixStartTime(string oddStart)
        {
            string timeOfDay = " AM";

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

            if (hour >= 12)
            {
                hour = hour - 12;
                if (hour == 0)
                {
                    hour = 12;
                }
                timeOfDay = " PM";
            }

            sTime[0] = Convert.ToString(hour); //convert the hour back to a string

            if (minute < 10) //if minute is less than 10 (read 0), we stick an extra 0 in front to maintain the format
                sTime[1] = '0' + Convert.ToString(minute);
            else
                sTime[1] = Convert.ToString(minute); //otherwise, just convert minutes back to a string

            string fixTime = sTime[0] + ':' + sTime[1] + timeOfDay; //recombine the time

            return fixTime; //return the fixed time
        }

        public string fixEndTime(string oddEnd)
        {
            string timeOfDay = " AM";

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

            if (hour >= 12)
            {
                hour = hour - 12;
                if(hour == 0)
                {
                    hour = 12;
                }
                timeOfDay = " PM";
            }

            sTime[0] = Convert.ToString(hour); //convert the hour back into a string

            if (minute < 10) //if the minute is less than 10, stick a '0' in front to maintain the format
                sTime[1] = '0' + Convert.ToString(minute);
            else
                sTime[1] = Convert.ToString(minute); //otherwise just convert it to a string

            string fixTime = sTime[0] + ':' + sTime[1] + timeOfDay; //recombine the time

            return fixTime; //return the fixed time
        }

        public void save(string loc)
        {
            StreamWriter data = null;
            try
            {
                data = new StreamWriter(loc);
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be written:");
                Console.WriteLine(e.Message);   
            }

            foreach(course c in courseList)
            {
                string line = c.getCourseCode() + "," +
                              c.getShortTitle() + "," +
                              c.getLongTitle() + "," +
                              c.getStartTime() + "," +
                              c.getEndTime() + "," +
                              c.getDays() + "," +
                              c.getBuilding() + "," +
                              c.getRoom() + "," +
                              c.getEnrollment() + "," +
                              c.getCapacity();
                
                data.WriteLine(line);
            }
            data.Close();
        }

        public void open(string loc)
        {
            StreamReader data = null;
            try
            {
                data = new StreamReader(loc);
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            int count = File.ReadLines(loc).Count();
            this.courseList.Clear();
            for (int i = 0; i < count; i++)
            {
                string readLn = data.ReadLine();
                string[] splitLn = readLn.Split(',');

                // Adds a course to the list
                try
                {
                    this.courseList.Add(new course(Int32.Parse(splitLn[8]),
                                                   Int32.Parse(splitLn[9]),
                                                   splitLn[0],
                                                   splitLn[1],
                                                   splitLn[2],
                                                   splitLn[3],
                                                   splitLn[4],
                                                   splitLn[5],
                                                   splitLn[6],
                                                   splitLn[7]));
                }
                catch //(Exception e)
                {
                    Alert AlertWin = new Alert();
                    AlertWin.Show();
                    AlertWin.set_text_alert("File doesn't match correct format",true);
                    break;
                }
            }

            data.Close();
        }

    }
}
