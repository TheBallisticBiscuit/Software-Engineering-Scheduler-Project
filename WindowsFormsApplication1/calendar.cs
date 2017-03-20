using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class calendar
    {
        public course[] addCourse(course[] courseList, course newCourse)
        {
            if (courseList.Contains(newCourse))
            {
                Console.Write("ALREADY EXISTS");
                return null;
            }
            else
            {
                //Creates space for the new course
                int newLength = courseList.Length + 1;

                //Creating a deep copy of array
                course[] newList = new course[newLength];
                for (int i = 0; i < courseList.Length; i++)
                {
                    newList[i] = courseList[i];
                }

                //Adding new course to the empty spot
                newList[newLength - 1] = newCourse;

                //NEED TO CALL UPDATE CAL BEFORE RETURN?

                return newList;
            }
        }

        public course removeCourse(course[] courseList, course oldCourse)
        {
            return null;
        }

        public calendar updateCalander(calendar Update)
        {
            return null;
        }
    }
}
