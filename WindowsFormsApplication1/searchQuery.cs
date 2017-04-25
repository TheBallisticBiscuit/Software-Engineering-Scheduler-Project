using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseScheduler;

namespace CourseScheduler
{
    // searchQuery class is used to determine which search will be used to parse the database.
    public class searchQuery
    {
        database courseList;
        string currentSearch = null;
        int lineCount;
        public searchQuery(database data)
        {
            courseList = data;
            /*Console.WriteLine(data.getCourses()[1].getCourseCode().Contains("COMP"));
            Console.WriteLine(data.getCourses()[100].getCourseCode());
            Console.WriteLine(data.getCourses()[200].getCourseCode());*/
            this.lineCount = data.getLineCount();
        }

        // search by course code
        public searchResults searchByCode(string searchValue)
        {
            searchValue = searchValue.ToUpper();

            List<course> results = new List<course>();

            for (int i = 0; i < lineCount; i++)
            {
                if (courseList.getCourses()[i].getCourseCode().Contains(searchValue))
                {
                    results.Add(new course(courseList.getCourses()[i]));
                }
            }
            return new searchResults(results);
        }

        public searchResults searchByTime(string daysChecked, string startTime, string endTime)
        {
            string[] searchComponents = daysChecked.Split(',');
            startTime = calendar.fixStartTime(startTime);
            endTime = calendar.fixEndTime(endTime); 
            List<course> results = new List<course>();
            List<course> daySearchResults = new List<course>();

            for (int i = 0; i < lineCount; i++) //cycles through database
            {
                foreach (string j in searchComponents)
                {
                    if (courseList.getCourses()[i].getDays().Contains(j))
                    {
                        daySearchResults.Add(courseList.getCourses()[i]);
                    }
                    else //if there is a day that is not in the course, remove it, if it was never added in the first place this returns false
                    {
                        daySearchResults.Remove(courseList.getCourses()[i]);
                    }

                }
            }
            foreach(course i in daySearchResults)
            {
                if (calendar.fixStartTime(i.getStartTime()).Contains(startTime) && calendar.fixEndTime(i.getEndTime()).Contains(endTime))
                {
                    results.Add(i);
                }
            }
            return new searchResults(results);
        }

        //Search by department
        public searchResults searchByDepartment(string searchValue)
        {
            string mapResult = "";
            var map = new Dictionary<string, string>();
            map["COMPUTER SCIENCE"] = "COMP";
            map["COMPUTER"] = "COMP";
            map["ACCOUNTING AND FINANCE"] = "ACCT";
            map["ACCOUNTING"] = "ACCT";
            map["BIBLICAL AND RELIGOUS STUDIES"] = "RELI";
            map["BIBLICAL STUDIES"] = "RELI";
            map["RELIGOUS STUDIES"] = "RELI";
            map["BIBLICAL"] = "RELI";
            map["RELIGOUS"] = "RELI";
            map["PHILOSOPHY"] = "PHIL";
            map["BIOLOGY"] = "BIOL";
            map["MANAGEMENT AND MARKETING"] = "BUSA";
            map["MANAGEMENT"] = "BUSA";
            map["MARKETING"] = "BUSA";
            map["CHEMISTRY"] = "CHEM";
            map["COMMUNICATION"] = "COMM";
            map["VISUAL ARTS"] = "ART";
            map["ECONOMICS"] = "ECON";
            map["SOCIOLOGY"] = "SOCI";
            map["EDUCATION"] = "EDUC";
            map["SPECIAL EDUCATION"] = "SEDU";
            map["ELECTRICAL ENGINEERING"] = "ELEE";
            map["ELECTRICAL"] = "ELEE";
            map["ENGLISH"] = "ENGL";
            map["ENTREPRENEURSHIP"] = "ENTR";
            map["HISTORY"] = "HIST";
            map["HUMANITIES"] = "HUMA";
            map["MATHEMATICS"] = "MATH";
            map["MATH"] = "MATH";
            map["MECHANICAL ENGINEERING"] = "MECE";
            map["MECHANICAL"] = "MECE";
            map["MUSIC"] = "MUSI";
            map["EXERCISE SCIENCE"] = "EXER";
            map["PHYSICAL EDUCATION"] = "PHYE";
            map["PHYSICAL"] = "PHYE";
            map["PHYSICS"] = "PHYS";
            map["POLITICAL SCIENCE"] = "POLS";
            map["PSYCHOLOGY"] = "PSYC";
            map["SOCIAL WORK"] = "SOCW";
            map["SOCIAL"] = "SOCW";
            map["SOCIOLOGY"] = "SOCI";
            map["SCIENCE"] = "SCIC";

            searchValue = searchValue.ToUpper();

            map.TryGetValue((searchValue), out mapResult);

            if (!map.Values.Contains(mapResult))
            {
                mapResult = "DNE";
            }
            List<course> results = new List<course>();
            for (int i = 0; i < lineCount; i++)
            {
                if (courseList.getCourses()[i].getCourseCode().Contains(mapResult))
                {
                    results.Add(courseList.getCourses()[i]);
                }
            }

            //returns search results
            return new searchResults(results);
        }

        public searchResults searchByName(string searchValue)
        {
            searchValue = searchValue.ToUpper();

            List<course> results = new List<course>();

            for (int i = 0; i < lineCount; i++)
            {
                if (this.courseList.getCourses()[i].getLongTitle().Contains(searchValue) || this.courseList.getCourses()[i].getShortTitle().Contains(searchValue))
                {
                    results.Add(courseList.getCourses()[i]);
                }
            }

            //returns search results
            return new searchResults(results);
        }

        public searchResults genericSearch(string searchValue)
        {
            searchValue = searchValue.ToUpper();

            searchResults results = new searchResults();

            results = searchByCode(searchValue);
            results.combine(searchByName(searchValue)); //adds the results of searching the same term by name
            results.combine(searchByTime(searchValue, null, null)); //adds the results of searching the same term by time
            results.combine(searchByDepartment(searchValue)); //adds the results of searching the same term by department

            return results;
        }
        //other searches here

    }
}
