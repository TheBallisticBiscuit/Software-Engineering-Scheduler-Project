﻿using System;
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
    public partial class ExtraCurWin : Form
    {
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
    }
}
