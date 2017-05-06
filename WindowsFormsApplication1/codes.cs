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
    public partial class codes : MetroForm
    {
        public codes()
        {
            InitializeComponent();
        }

        private void htmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                Clipboard.SetText(listBox1.SelectedItem.ToString());
            }
        }

        private void listBox1_Double_Click(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                Clipboard.SetText(listBox1.SelectedItem.ToString());
            }
        }

        private void codes_Load(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(listBox1.SelectedItem.ToString());
        }
        
    }
}
