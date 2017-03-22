using System;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    partial class Form1
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
            ((System.ComponentModel.ISupportInitialize)(this.calendarView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.AcceptsReturn = true;
            this.searchBox.Location = new System.Drawing.Point(2, 26);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(190, 20);
            this.searchBox.TabIndex = 0;
            this.searchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchBox_Enter);
            // 
            // searchResultsBox
            // 
            this.searchResultsBox.FormattingEnabled = true;
            this.searchResultsBox.Location = new System.Drawing.Point(2, 79);
            this.searchResultsBox.Name = "searchResultsBox";
            this.searchResultsBox.Size = new System.Drawing.Size(190, 121);
            this.searchResultsBox.TabIndex = 2;
            this.searchResultsBox.SelectedIndexChanged += new System.EventHandler(this.course_Description_Update);
            // 
            // courseDataBox
            // 
            this.courseDataBox.Location = new System.Drawing.Point(2, 206);
            this.courseDataBox.Name = "courseDataBox";
            this.courseDataBox.ReadOnly = true;
            this.courseDataBox.Size = new System.Drawing.Size(190, 96);
            this.courseDataBox.TabIndex = 4;
            this.courseDataBox.Text = "";
            // 
            // addCourseButton
            // 
            this.addCourseButton.Location = new System.Drawing.Point(2, 308);
            this.addCourseButton.Name = "addCourseButton";
            this.addCourseButton.Size = new System.Drawing.Size(75, 23);
            this.addCourseButton.TabIndex = 5;
            this.addCourseButton.Text = "Add";
            this.addCourseButton.UseVisualStyleBackColor = true;
            this.addCourseButton.Click += new System.EventHandler(this.update_calendar_add);
            // 
            // removeCourseBox
            // 
            this.removeCourseBox.Location = new System.Drawing.Point(117, 308);
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
            "Day & Time",
            "Department"});
            this.searchMenu.Location = new System.Drawing.Point(2, 52);
            this.searchMenu.Name = "searchMenu";
            this.searchMenu.Size = new System.Drawing.Size(190, 21);
            this.searchMenu.TabIndex = 7;
            this.searchMenu.SelectedIndexChanged += new System.EventHandler(this.searchMenu_NewSelect);
            // 
            // compareButton
            // 
            this.compareButton.Location = new System.Drawing.Point(325, 308);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(75, 23);
            this.compareButton.TabIndex = 8;
            this.compareButton.Text = "Compare";
            this.compareButton.UseVisualStyleBackColor = true;
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(467, 308);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 9;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            // 
            // calendarView
            // 
            this.calendarView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.calendarView.Location = new System.Drawing.Point(209, 26);
            this.calendarView.Name = "calendarView";
            this.calendarView.Size = new System.Drawing.Size(435, 271);
            this.calendarView.TabIndex = 10;
            this.calendarView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.calendarView_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(656, 24);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 336);
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
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Course Scheduler";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.calendarView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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


    }
}

