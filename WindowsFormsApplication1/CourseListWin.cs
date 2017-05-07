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
    public partial class CourseListWin : MetroForm
    {
        public CourseListWin()
        {
            InitializeComponent();
        }

        private void ExtraCurWin_Load(object sender, EventArgs e)
        {
            
        }

        // Refreshes the list with courses in the calendar class
        public void view_courses(List<Course> courseList)
        {
            this.listBox1.Items.Clear();
            foreach(Course c in courseList)
            {
                this.listBox1.Items.Add(c.getCourseCode());
            }
        }

        // Returns the selected item in the list
        public string get_selected_item()
        {
            if (this.listBox1.SelectedIndex >= 0)
            {
                return this.listBox1.SelectedItem.ToString();
            }
            return "";
            
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
