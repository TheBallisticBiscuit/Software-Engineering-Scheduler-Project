using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseScheduler
{
    public class extracurricular : course //stub class for extracurricular, child of course, primarily for organization
    {
        public extracurricular()
            : base()
        {}
        public extracurricular(string newShortTitle, string newBuilding, string newRoom, string newBeginTime, string newEndTime, string newDaysMeeting)
        {
            enrollment = 0;
            capacity = 0;
            courseCode = newShortTitle;
            shortTitle = newShortTitle;
            longTitle = null;
            beginTime = newBeginTime;
            endTime = newEndTime;
            daysMeeting = newDaysMeeting;
            building = newBuilding;
            room = newRoom;
            editable = true;
        }
        public new bool isEditable() { return editable; } //indicates that the object is an extracurricular
    }
}
