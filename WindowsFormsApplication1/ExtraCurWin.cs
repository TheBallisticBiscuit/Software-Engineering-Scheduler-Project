using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CourseScheduler
{
    public partial class ExtraCurWin : MetroForm
    {
        string M, T, W, R, F = "";
        public bool okPressed = false;
        public extracurricular newExtra;

        public ExtraCurWin()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();  //kills the window without saving anything
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            okPressed = true;
            newExtra = returnCourse();
        }

        // Based on the data entered 
        private extracurricular returnCourse()
        {
            if (this.metroTextBox1.Text != "")
            {
                string title = this.metroTextBox1.Text;
                string location = this.metroTextBox3.Text;
                string startTime = this.metroTextBox4.Text;
                string endTime = this.metroTextBox5.Text;
                int roomNum = 0;
                string room = "None";
                string[] parsedLoc = location.Split(' ');
                string startHr = startTime.Split(':')[0];
                string endHr = endTime.Split(':')[0];
                string startMin = ":00";
                string endMin = ":00";
                
                // Checks to see if only a single int or a string with
                // in the format was HH:MM
                if (startTime.Split(':').Count() > 1)
                {
                    startMin = ":" + startTime.Split(':')[1];
                }
                if (endTime.Split(':').Count() > 1)
                {
                    endMin = ":"+endTime.Split(':')[1];
                }
                int start, end = 0;

                // Checks to see if an int was entered for start hours and converts it to military time
                if (Int32.TryParse(startTime, out start))
                {
                    if (this.metroCheckBox6.Checked)
                    {
                        start = start + 12;
                    }
                    startTime = start.ToString() + ":00";
                }
                else if(Int32.TryParse(startHr, out start))
                {
                    if (this.metroCheckBox6.Checked)
                    {
                        start = start + 12;
                    }
                    startTime = start.ToString() + startMin;
                }

                // Checks to see if an int was entered for end hours and converts it to military time
                if (Int32.TryParse(endTime, out end))
                {
                    if (this.metroCheckBox7.Checked)
                    {
                        end = end + 12;
                    }
                    endTime = end.ToString() + ":00";
                }
                else if (Int32.TryParse(endHr, out end))
                {
                    if (this.metroCheckBox7.Checked)
                    {
                        end = end + 12;
                    }
                    endTime = end.ToString() + endMin;
                }
                
                // If the start time is greater than the end time
                // it returns early since this course has bad inputs for time
                if (start > end)
                {
                    return null;
                }
                // if the hours are the same, the minutes are checked just in case.
                else if (start == end)
                {
                    int testSMin,testEMin;
                    if (Int32.TryParse(startMin.Split(':')[0], out testSMin) && Int32.TryParse(endMin.Split(':')[0], out testEMin))
                    {
                        if (testSMin > testEMin)
                        {
                            return null;
                        }
                    }
                    return null;
                }
                // If the times are off the calendar in the program
                else if (start > 21 || start < 8 || end > 21 || end < 8 || startTime == "" || endTime == "")
                {
                    return null;                
                }

                // Checks to see if there was a room number entered
                foreach (string word in parsedLoc)
                {
                    if (Int32.TryParse(word, out roomNum))
                    {
                        room = roomNum.ToString();
                    }
                }

                string days = M + T + W + R + F;

                return new extracurricular(title, location, room, startTime, endTime, days);
            }

            return null;
        }

        // Sets the extra curricular to be on Monday
        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked)
            {
                M = "M";
            }
            else
            {
                M = "";
            }
        }

        // Sets the extra curricular to be on Tuesday
        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked)
            {
                T = "T";
            }
            else
            {
                T = "";
            }
        }

        // Sets the extra curricular to be on Wednesday
        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox3.Checked)
            {
                W = "W";
            }
            else
            {
                W = "";
            }
        }

        // Sets the extra curricular to be on Thursday
        private void metroCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox4.Checked)
            {
                R = "R";
            }
            else
            {
                R = "";
            }
        }

        // Sets the extra curricular to be on Friday
        private void metroCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox5.Checked)
            {
                F = "F";
            }
            else
            {
                F = "";
            }
        }
    }
}
