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

        private void startTimeBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroDateTime1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            okPressed = true;
            newExtra = returnCourse();
        }

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

                if (startTime.Split(':').Count() > 1)
                {
                    startMin = ":" + startTime.Split(':')[1];
                }
                if (endTime.Split(':').Count() > 1)
                {
                    endMin = ":"+endTime.Split(':')[1];
                }
                int start, end = 0;
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

                if (start > end)
                {
                    return null;
                }
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
                }
                else if (start > 18 || start < 8 || end > 24 || end < 8 || startTime == "" || endTime == "")
                {
                    return null;                
                }

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
