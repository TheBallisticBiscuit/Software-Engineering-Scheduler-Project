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
    public partial class Alert : Form
    {
        public Alert()
        {
            InitializeComponent();
        }

        private void Alert_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Alerts the user what the warning is
        public void set_text_alert(string txt, bool realine = false)
        {
            if (realine == false)
            {
                this.label1.Location = new System.Drawing.Point(71, 21);
            }
            else
            {
                this.label1.Location = new System.Drawing.Point(40, 21);
            }
            this.label1.Text = txt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
