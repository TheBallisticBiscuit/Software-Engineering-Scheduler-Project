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

            if (newCourse == null)
            {
                // If there is some invalid time entered or the title is empty.
                Alert AlertWin = new Alert();
                AlertWin.Show();
                AlertWin.set_text_alert("Incorrect Times or missing title! \n(Check start and Stop Times)", true);
            }
            else
            if (courseList.Contains(newCourse))
            {
                Alert AlertWin = new Alert();
                AlertWin.Show();
                AlertWin.set_text_alert("Course already added.");
            }
            else
            {
                foreach(course c in courseList)// (int i = 0; i < courseList.Count; i++)
                {
                    // Checks to see if there is a time conflict during a particular day.
                    if (containsDays(c.getDays(), newCourse.getDays()) && c.getStartTime() == newCourse.getStartTime() || checkInbetweenTimes(newCourse.getStartTime(), newCourse.getEndTime(), newCourse.getDays()))
                    {
                        Alert AlertWin = new Alert();
                        AlertWin.Show();
                        string txt = "Date/Time conflict with this course at\nDay(s): " + c.getDays() + " Time: " + fixStartTime(c.getStartTime());
                        AlertWin.set_text_alert(txt, true);
                        return false;
                    }
                }
                if (newCourse != null)
                {
                    // If an extracurricular has empty times or days parameters
                    if ((newCourse.getDays() == "" || newCourse.getStartTime() == "" || newCourse.getEndTime() == "" || newCourse.correctTime()) && (newCourse.getDays() != "NULL" && newCourse.getStartTime() != "NULL"))
                    {
                        Alert AlertWin = new Alert();
                        AlertWin.Show();
                        AlertWin.set_text_alert("Extra Curricular contains invalid information!", true);
                        return false;
                    }

                    // Alerts the user that a class is added, but won't be seen on the calendar since
                    // it has NULL time or days
                    if (newCourse.getDays() == "NULL" || newCourse.getStartTime() == "NULL")
                    {
                        foreach (course c in courseList)
                        {
                            if (newCourse.getCourseCode() == c.getCourseCode())
                            {
                                Alert AlertWin1 = new Alert();
                                AlertWin1.Show();
                                AlertWin1.set_text_alert("Course already added!", false);
                                return false;
                            }
                        }
                        Alert AlertWin = new Alert();
                        AlertWin.Show();
                        AlertWin.set_text_alert("Course being added will not\nappear on the calendar!", true);
                    }
                    courseList.Add(newCourse);
                    return true;
                }
            }
            
            return false;
        }
        
        // Checks to see if two courses exist on the same day
        private bool containsDays(string course1Days, string course2Days)
        {
            foreach (char c in course2Days)
            {
                if (course1Days.Contains(c))
                {
                    return true;
                }
            }

            return false;
        }

        // Checks to see if current course trying to be added exsist 
        // in between course times or vice versa
        private bool checkInbetweenTimes(string startTime, string endTime, string days)
        {
            foreach (course c in courseList)
            {
                if (containsDays(c.getDays(), days))
                {
                    // If the course being added has a longer time than the an exisiting course

                    if (Int32.Parse(startTime.Split(':')[0]) < Int32.Parse(c.getStartTime().Split(':')[0]) && Int32.Parse(endTime.Split(':')[0]) > Int32.Parse(c.getEndTime().Split(':')[0]))
                    {
                        return true;
                    }

                    // If the course being added start time exsists between the start and stop
                    // times of an exsisting course.
                    if (Int32.Parse(c.getStartTime().Split(':')[0]) < Int32.Parse(startTime.Split(':')[0]) && Int32.Parse(startTime.Split(':')[0]) < Int32.Parse(c.getEndTime().Split(':')[0]))
                    {
                        return true;
                    }

                    // If the course being added end time exsists between the start and stop
                    // times of an exsisting course.
                    if (Int32.Parse(c.getStartTime().Split(':')[0]) < Int32.Parse(endTime.Split(':')[0]) && Int32.Parse(endTime.Split(':')[0]) < Int32.Parse(c.getEndTime().Split(':')[0]))
                    {
                        return true;
                    }

                    // If the start and stop dates are the same
                    if (Int32.Parse(startTime.Split(':')[0]) == Int32.Parse(c.getStartTime().Split(':')[0]) || Int32.Parse(startTime.Split(':')[0]) == Int32.Parse(c.getEndTime().Split(':')[0]))
                    {
                        if (Int32.Parse(startTime.Split(':')[0]) == Int32.Parse(c.getStartTime().Split(':')[0]))// && Int32.Parse(startTime.Split(':')[1]) < Int32.Parse(c.getStartTime().Split(':')[1]))
                        {
                            return true;
                        }
                        if (Int32.Parse(startTime.Split(':')[0]) == Int32.Parse(c.getEndTime().Split(':')[0]) && Int32.Parse(startTime.Split(':')[1]) < Int32.Parse(c.getEndTime().Split(':')[1]))
                        {
                            return true;
                        }
                    }
                    // If the start and stop dates are the same
                    if (Int32.Parse(endTime.Split(':')[0]) == Int32.Parse(c.getStartTime().Split(':')[0]) || Int32.Parse(endTime.Split(':')[0]) == Int32.Parse(c.getEndTime().Split(':')[0]))
                    {
                        if (Int32.Parse(endTime.Split(':')[0]) == Int32.Parse(c.getStartTime().Split(':')[0]) && Int32.Parse(endTime.Split(':')[1]) > Int32.Parse(c.getStartTime().Split(':')[1]))
                        {
                            return true;
                        }
                        if (Int32.Parse(endTime.Split(':')[0]) == Int32.Parse(c.getEndTime().Split(':')[0])) // && Int32.Parse(endTime.Split(':')[1]) < Int32.Parse(c.getEndTime().Split(':')[1]))
                        {
                            return true;
                        }
                    }
                    // If the start and stop dates are the same
                    if (Int32.Parse(startTime.Split(':')[0]) == Int32.Parse(c.getStartTime().Split(':')[0]) && Int32.Parse(endTime.Split(':')[0]) == Int32.Parse(c.getEndTime().Split(':')[0]))
                    {
                        return true;
                    }
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
            for (int i = 0; i < courseList.Count; i++)
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
            for (int i = 0; i < courseList.Count; i++)
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

        // Fixes the start times from miltary to regular
        // Makes it so the start time extends to the earliest half hour.
        public static string fixStartTime(string oddStart)
        {
            string timeOfDay = " AM";
            string[] sTime = oddStart.Split(':'); //splits the input by the ':'
            int hour, minute;
            if (!String.IsNullOrEmpty(sTime[0]) && sTime[0] != "NULL")
            {
                hour = Convert.ToInt32(sTime[0]); //gets the hour
                if (sTime.Length > 1)
                {
                    minute = Convert.ToInt32(sTime[1]); //gets the minute
                }
                else
                {
                    minute = 0;
                    string[] extendedString = new string[2];
                    extendedString[0] = sTime[0];
                    sTime = extendedString;
                }
            }
            else
            {
                return "NULL";
            }
            if (minute <= 15) //if the class starts before quarter past, we say it starts on the hour
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

        // Fixes end time from military to regular. 
        // Makes it so the end time extends to the nearest half hour past the end time.
        public static string fixEndTime(string oddEnd)
        {
            string timeOfDay = " AM";
            if (oddEnd != null && oddEnd != "NULL")
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

                if (hour >= 12)
                {
                    hour = hour - 12;
                    if (hour == 0)
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
            else
            {
                return null;
            }
        }

        // Saves the schedule to a .csv file
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

            foreach (course c in courseList)
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

        // Opens and loads a .csv file to the software
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
                catch
                {
                    Alert AlertWin = new Alert();
                    AlertWin.Show();
                    AlertWin.set_text_alert("File doesn't match correct format", true);
                    break;
                }
            }

            data.Close();
        }

    }
}
