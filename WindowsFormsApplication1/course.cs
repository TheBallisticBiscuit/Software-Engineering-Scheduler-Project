using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class course : activity
    {
        int enrollment;
        int capacity;
        string courseCode;
        string shortTitle;
        string longTitle;
        float beginTime;
        float endTime;
        string daysMeeting;
        string building;
        string room;

        public course()
            : base()
        {
            //initialize course
        }
        public course(int newEnrollment, int newCapacity, string newCourseCode, string newShortTitle, string newLongTitle, float newBeginTime, float newEndTime, string newDaysMeeting,
        string newBuilding, string newRoom)
        {
            enrollment = newEnrollment;
            capacity = newCapacity;
            courseCode = newCourseCode;
            shortTitle = newShortTitle;
            longTitle = newLongTitle;
            beginTime = newBeginTime;
            endTime = newEndTime;
            daysMeeting = newDaysMeeting;
            building = newBuilding;
            room = newRoom;
        }
    }
}
