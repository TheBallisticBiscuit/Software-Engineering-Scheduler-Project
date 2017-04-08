using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseScheduler
{
    class TestClass
    {
        private database courselist;
        private searchQuery courseSearch;
        private searchResults results;
        /*public TestClass()
        {
            this.courselist = new database();
            this.courseSearch = new searchQuery(courselist.getCourses(), courselist.getLineCount());
            this.results = new searchResults(courselist.getCourses());
        }

        public void SearchTest()
        {
            int type = 1;
            string search;
            while (type != 0)
            {
                Console.WriteLine("Select Test Type. (1-4, 0 to exit)");
                //type = Int32.Parse(Console.ReadLine());
                if (Int32.TryParse(Console.ReadLine(), out type))
                {

                }
                else
                {
                    type = 5;
                }
                if (type == 0)
                {
                    return;
                }
                else if (type == 1)
                {
                    Console.WriteLine("Search Course Code");
                    search = Console.ReadLine();
                    int[] arr = courseSearch.searchByCode(search);
                    
                    List<course> temp = results.updateResults(arr);
                    if (temp != null)
                    {
                        for (int i = 0; i < temp.Count; i++)
                        {
                            Console.WriteLine(temp[i].getCourseCode());
                        }
                    }
                    else
                    {
                        Console.WriteLine("DNE");
                    }
                }
                else if (type == 2)
                {
                    Console.WriteLine("Search Name");
                    search = Console.ReadLine();
                    int[] arr = courseSearch.searchByName(search);
                    List<course> temp = results.updateResults(arr);
                    if (temp != null)
                    {
                        for (int i = 0; i < temp.Count; i++)
                        {
                            Console.WriteLine(temp[i].getLongTitle());
                        }
                    }
                    else
                    {
                        Console.WriteLine("DNE");
                    }
                }
                else if (type == 3)
                {
                    Console.WriteLine("Search Day/Time");
                }
                else if (type == 4)
                {
                    Console.WriteLine("Search Department");
                    search = Console.ReadLine();
                    int[] arr = courseSearch.searchByDepartment(search);
                    List<course> temp = results.updateResults(arr);
                    if (temp != null)
                    {
                        for (int i = 0; i < temp.Count; i++)
                        {
                            Console.WriteLine(temp[i].getLongTitle());
                        }
                    }
                    else
                    {
                        Console.WriteLine("DNE");
                    }

                }
                else
                {
                    Console.WriteLine("Incorrect Value");
                }
            }
        }
        public void test()
        {
            int te = 0;
            List<course> cl = courselist.getCourses();
            for (int i = 0; i < 761; i++)
            {
                //Console.WriteLine(cl[i].getCourseCode());
                string ta = "Com";
                ta = ta.ToUpper();
                if(cl[i].getCourseCode().Contains(ta))
                {
                    te++;
                }

            }
            Console.WriteLine(te);
        }*/
    }
}
