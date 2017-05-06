using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseScheduler;

namespace CourseScheduler
{
    // searchQuery class is used to determine which search will be used to parse the database.
    public class SearchQuery
    {
        Database courseList;
        int lineCount;
        public SearchQuery(Database data)
        {
            courseList = data;
            this.lineCount = data.getLineCount();
        }

        // search by course code
        public SearchResults searchByCode(string searchValue)
        {
            searchValue = searchValue.ToUpper();

            List<Course> results = new List<Course>();

            for (int i = 0; i < lineCount; i++)
            {
                if (courseList.getCourses()[i].getCourseCode().Contains(searchValue))
                {
                    results.Add(new Course(courseList.getCourses()[i]));
                }
            }
            return new SearchResults(results);
        }


        // Search the courses by day and/or time
        public SearchResults searchByTime(string daysChecked, string startTime)
        {
            string[] searchComponents = daysChecked.Split(',');
            if (!String.IsNullOrWhiteSpace(startTime))
            {
                startTime = Calendar.fixStartTime(startTime);
            }
            List<Course> results = new List<Course>();
            List<Course> daySearchResults = new List<Course>();

            for (int i = 0; i < lineCount; i++) //cycles through database
            {
                bool added = false;
                foreach (string j in searchComponents)
                {
                    if (courseList.getCourses()[i].getDays().Contains(j))
                    {
                        if (!added)
                        {
                            daySearchResults.Add(courseList.getCourses()[i]);
                            added = true;
                        }
                    }
                    else //if there is a day that is not in the course, remove it, if it was never added in the first place this returns false
                    {
                        daySearchResults.Remove(courseList.getCourses()[i]);
                        break;
                    }

                }
            }
            foreach (Course i in daySearchResults)
            {
                if (!String.IsNullOrEmpty(startTime))
                {
                    if (Calendar.fixStartTime(i.getStartTime()) == startTime)
                    {
                        results.Add(i);
                    }
                }
                else
                {
                    return new SearchResults(daySearchResults);
                }
            }
            return new SearchResults(results);
        }

        //Search by department
        public SearchResults searchByDepartment(string searchValue)
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
            List<Course> results = new List<Course>();
            for (int i = 0; i < lineCount; i++)
            {
                if (courseList.getCourses()[i].getCourseCode().Contains(mapResult))
                {
                    results.Add(courseList.getCourses()[i]);
                }
            }

            //returns search results
            return new SearchResults(results);
        }

        // Searchs courses by short and long name
        public SearchResults searchByName(string searchValue)
        {
            searchValue = searchValue.ToUpper();

            List<Course> results = new List<Course>();

            for (int i = 0; i < lineCount; i++)
            {
                if (this.courseList.getCourses()[i].getLongTitle().Contains(searchValue) || this.courseList.getCourses()[i].getShortTitle().Contains(searchValue))
                {
                    results.Add(courseList.getCourses()[i]);
                }
            }

            //returns search results
            return new SearchResults(results);
        }

        // Generic search that does all searches.
        public SearchResults genericSearch(string searchValue)
        {
            searchValue = searchValue.ToUpper();

            SearchResults results = new SearchResults();

            results = searchByCode(searchValue);
            results.combine(searchByName(searchValue)); //adds the results of searching the same term by name
            results.combine(searchByTime(searchValue, null)); //adds the results of searching the same term by time
            results.combine(searchByDepartment(searchValue)); //adds the results of searching the same term by department

            return results;
        }
    }
}
