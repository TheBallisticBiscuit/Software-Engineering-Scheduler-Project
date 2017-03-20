using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1;

namespace WindowsFormsApplication1
{
    public class searchQuery
    {
        database courseList;
        string currentSearch = null;
        int lineCount;
        public searchQuery(database data)
        {
            courseList = data;
            Console.WriteLine(data.getCourses()[1].getCourseCode().Contains("COMP"));
            Console.WriteLine(data.getCourses()[100].getCourseCode());
            Console.WriteLine(data.getCourses()[200].getCourseCode());
            this.lineCount = data.getLineCount();
        }

        public searchResults searchByCode(string searchValue)
        {
            // These are the index values in the data structure
            // 0 : Course Code
            // 2 : Name (short)
            searchValue = searchValue.ToUpper();

            List<course> results = new List<course>();

            // This will only work for code and name
            for (int i = 0; i < lineCount; i++)
            {
                if (courseList.getCourses()[i].getCourseCode().Contains(searchValue))
                {
                    results.Add(new course(courseList.getCourses()[i]));

                }
            }
            return new searchResults(results);
        }

        // Search by time
        public searchResults searchByTime(string searchValue)
        {
            searchValue = searchValue.ToUpper();
            char[] delimiterChars = { ' ', ',' };
            string[] searchComponents = searchValue.Split(delimiterChars);
            List<course> results = new List<course>();
            for(int i = 0; i < lineCount; i++) //cycles through database
            {
                for(int j = 0; j < searchComponents.Length; j++) //cycles through words entered
                {
                    if (courseList.getCourses()[i].getDays().Contains(searchComponents[j])
                        || courseList.getCourses()[i].getEndTime().Contains(searchComponents[j])
                        || courseList.getCourses()[i].getStartTime().Contains(searchComponents[j]))
                    {
                        results.Add(new course(courseList.getCourses()[i]));
                    }
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

            int[] indexArray = new int[lineCount];
            int count = 0;

            map.TryGetValue((searchValue), out mapResult);


            if (!map.Values.Contains(mapResult))
            {
                mapResult = "DNE";
            }

            for (int i = 0; i < lineCount; i++)
            {
                if (courseList[i].getCourseCode().Contains(mapResult))
                {
                    indexArray[count] = i;
                    count++;
                }
            }

            //returns search results

            int[] returnArray = new int[count];
            for (int i = 0; i < count; i++)
            {
                returnArray[i] = indexArray[i];
            }
            if (count > 0)
            {
                return returnArray;
            }
            else
            {
                return null;
            }
        }

        public searchResults searchByName(string searchValue)
        {
            // These are the index values in the data structure
            // 0 : Course Code
            // 2 : Name (short)
            searchValue = searchValue.ToUpper();

            List<course> results = new List<course>();

            // This will only work for code and name
            for (int i = 0; i < lineCount; i++)
            {
                if (this.courseList.getCourses()[i].getLongTitle().Contains(searchValue))
                {
                    results.Add(courseList.getCourses()[i]);
                }
            }

            //returns search results
            return new searchResults(results);
        }


        //other searches here

        internal int[] searchByCode()
        {
            throw new NotImplementedException();
        }
    }
}
