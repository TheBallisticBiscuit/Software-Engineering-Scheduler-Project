using System;
using System.Windows.Forms;
namespace CourseScheduler
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchResultsBox = new System.Windows.Forms.ListBox();
            this.courseDataBox = new System.Windows.Forms.RichTextBox();
            this.addCourseButton = new System.Windows.Forms.Button();
            this.removeCourseBox = new System.Windows.Forms.Button();
            this.searchMenu = new System.Windows.Forms.ComboBox();
            this.compareButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.calendarView = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createTimeslotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTimeslotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.calendarView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.AcceptsReturn = true;
            this.searchBox.Location = new System.Drawing.Point(12, 26);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(190, 20);
            this.searchBox.TabIndex = 0;
            this.searchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchBox_Enter);
            // 
            // searchResultsBox
            // 
            this.searchResultsBox.FormattingEnabled = true;
            this.searchResultsBox.Location = new System.Drawing.Point(12, 79);
            this.searchResultsBox.Name = "searchResultsBox";
            this.searchResultsBox.Size = new System.Drawing.Size(190, 368);
            this.searchResultsBox.TabIndex = 2;
            this.searchResultsBox.SelectedIndexChanged += new System.EventHandler(this.course_Description_Update);
            // 
            // courseDataBox
            // 
            this.courseDataBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.courseDataBox.Location = new System.Drawing.Point(12, 452);
            this.courseDataBox.Name = "courseDataBox";
            this.courseDataBox.ReadOnly = true;
            this.courseDataBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.courseDataBox.Size = new System.Drawing.Size(190, 113);
            this.courseDataBox.TabIndex = 4;
            this.courseDataBox.Text = "";
            this.courseDataBox.TextChanged += new System.EventHandler(this.courseDataBox_TextChanged);
            // 
            // addCourseButton
            // 
            this.addCourseButton.Location = new System.Drawing.Point(12, 571);
            this.addCourseButton.Name = "addCourseButton";
            this.addCourseButton.Size = new System.Drawing.Size(75, 23);
            this.addCourseButton.TabIndex = 5;
            this.addCourseButton.Text = "Add";
            this.addCourseButton.UseVisualStyleBackColor = true;
            this.addCourseButton.Click += new System.EventHandler(this.update_calendar_add);
            // 
            // removeCourseBox
            // 
            this.removeCourseBox.Location = new System.Drawing.Point(127, 571);
            this.removeCourseBox.Name = "removeCourseBox";
            this.removeCourseBox.Size = new System.Drawing.Size(75, 23);
            this.removeCourseBox.TabIndex = 6;
            this.removeCourseBox.Text = "Remove";
            this.removeCourseBox.UseVisualStyleBackColor = true;
            this.removeCourseBox.Click += new System.EventHandler(this.update_calendar_remove);
            // 
            // searchMenu
            // 
            this.searchMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.searchMenu.FormattingEnabled = true;
            this.searchMenu.Items.AddRange(new object[] {
            "Course Code",
            "Course Name",
            "Days Meeting",
            "Department"});
            this.searchMenu.Location = new System.Drawing.Point(12, 52);
            this.searchMenu.Name = "searchMenu";
            this.searchMenu.Size = new System.Drawing.Size(190, 21);
            this.searchMenu.TabIndex = 7;
            this.searchMenu.SelectedIndexChanged += new System.EventHandler(this.searchMenu_NewSelect);
            // 
            // compareButton
            // 
            this.compareButton.Location = new System.Drawing.Point(12, 600);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(75, 23);
            this.compareButton.TabIndex = 8;
            this.compareButton.Text = "Compare";
            this.compareButton.UseVisualStyleBackColor = true;
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(127, 600);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 9;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            // 
            // calendarView
            // 
            this.calendarView.AllowUserToAddRows = false;
            this.calendarView.AllowUserToDeleteRows = false;
            this.calendarView.AllowUserToResizeColumns = false;
            this.calendarView.AllowUserToResizeRows = false;
            this.calendarView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.calendarView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.calendarView.DefaultCellStyle = dataGridViewCellStyle1;
            this.calendarView.Location = new System.Drawing.Point(218, 26);
            this.calendarView.Name = "calendarView";
            this.calendarView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LimeGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.calendarView.RowHeadersVisible = false;
            this.calendarView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.calendarView.RowTemplate.ReadOnly = true;
            this.calendarView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.calendarView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.calendarView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.calendarView.Size = new System.Drawing.Size(602, 597);
            this.calendarView.TabIndex = 10;
            this.calendarView.TabStop = false;
            this.calendarView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.calendarView_CellContentClick);
            this.calendarView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.selected_cell);
            this.calendarView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.do_not_sort);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(831, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createTimeslotToolStripMenuItem,
            this.editTimeslotToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // createTimeslotToolStripMenuItem
            // 
            this.createTimeslotToolStripMenuItem.Name = "createTimeslotToolStripMenuItem";
            this.createTimeslotToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.createTimeslotToolStripMenuItem.Text = "Create Timeslot";
            this.createTimeslotToolStripMenuItem.Click += new System.EventHandler(this.createTimeslotToolStripMenuItem_Click);
            // 
            // editTimeslotToolStripMenuItem
            // 
            this.editTimeslotToolStripMenuItem.Name = "editTimeslotToolStripMenuItem";
            this.editTimeslotToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.editTimeslotToolStripMenuItem.Text = "Edit Timeslot";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::CourseScheduler.Properties.Resources.header_logo;
            this.pictureBox1.Location = new System.Drawing.Point(362, 643);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 677);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.calendarView);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.compareButton);
            this.Controls.Add(this.searchMenu);
            this.Controls.Add(this.removeCourseBox);
            this.Controls.Add(this.addCourseButton);
            this.Controls.Add(this.courseDataBox);
            this.Controls.Add(this.searchResultsBox);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Course Scheduler";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.calendarView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ListBox searchResultsBox;
        private System.Windows.Forms.RichTextBox courseDataBox;
        private System.Windows.Forms.Button addCourseButton;
        private System.Windows.Forms.Button removeCourseBox;
        private System.Windows.Forms.ComboBox searchMenu;
        private System.Windows.Forms.Button compareButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.DataGridView calendarView;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem createTimeslotToolStripMenuItem;
        private ToolStripMenuItem editTimeslotToolStripMenuItem;
        private PictureBox pictureBox1;


    }
}

