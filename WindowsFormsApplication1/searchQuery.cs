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

        string currentSearch = null;
        List<course> courseList = new List<course>();
        int lineCount;
        
        public searchQuery(List<course> crslst, int lineCount)
        {
            this.courseList = crslst;
            Console.WriteLine(courseList[1].getCourseCode().Contains("COMP"));
            Console.WriteLine(courseList[100].getCourseCode());
            Console.WriteLine(courseList[200].getCourseCode());
            this.lineCount = lineCount;
        }

        public int[] searchByCode(string searchValue)
        {
            // These are the index values in the data structure
            // 0 : Course Code
            // 2 : Name (short)
            searchValue = searchValue.ToUpper();

            int[] indexArray = new int[lineCount];
            int count = 0;

            // This will only work for code and name
            for (int i = 0; i < lineCount; i++)
            {
                if (courseList[i].getCourseCode().Contains(searchValue))
                {
                    //Console.WriteLine(courseList[i].getCourseCode());
                    indexArray[count] = i;
                    count++;

                }
            }
            //returns search results
            int[] returnArray = new int[count];
            for(int i = 0; i < count; i++)
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
                    if (courseList[i].getDays().Contains(searchComponents[j])
                        || courseList[i].getEndTime().Contains(searchComponents[j])
                        || courseList[i].getStartTime().Contains(searchComponents[j]))
                    {
                        results.Add(new course(courseList[i]));
                    }
                }
            }
            return new searchResults(results);
        }
        //Search by department
        public int[] searchByDepartment(string searchValue)
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

        public int[] searchByName(string searchValue)
        {
            // These are the index values in the data structure
            // 0 : Course Code
            // 2 : Name (short)
            searchValue = searchValue.ToUpper();

            int[] indexArray = new int[lineCount];
            int count = 0;

            // This will only work for code and name
            for (int i = 0; i < lineCount; i++)
            {
                if (this.courseList[i].getLongTitle().Contains(searchValue))
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


        //other searches here

        internal int[] searchByCode()
        {
            throw new NotImplementedException();
        }
    }
}
