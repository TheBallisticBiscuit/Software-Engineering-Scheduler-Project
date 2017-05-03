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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.searchResultsBox = new System.Windows.Forms.ListBox();
            this.courseDataBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createTimeslotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCourseListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideTipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.searchMenu = new MetroFramework.Controls.MetroComboBox();
            this.searchBox = new MetroFramework.Controls.MetroTextBox();
            this.calendarView = new MetroFramework.Controls.MetroGrid();
            this.removeCourseBox = new MetroFramework.Controls.MetroTile();
            this.exportButton = new MetroFramework.Controls.MetroButton();
            this.compareButton = new MetroFramework.Controls.MetroButton();
            this.addCourseButton = new MetroFramework.Controls.MetroTile();
            this.metroToggle1 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroBar = new MetroFramework.Controls.MetroProgressBar();
            this.mondayCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.tuesdayCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.wednesdayCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.thursdayCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.fridayCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.startTimeBox = new MetroFramework.Controls.MetroTextBox();
            this.PMCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calendarView)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchResultsBox
            // 
            this.searchResultsBox.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchResultsBox.FormattingEnabled = true;
            this.searchResultsBox.ItemHeight = 19;
            this.searchResultsBox.Location = new System.Drawing.Point(20, 211);
            this.searchResultsBox.Name = "searchResultsBox";
            this.searchResultsBox.Size = new System.Drawing.Size(190, 270);
            this.searchResultsBox.TabIndex = 2;
            this.metroToolTip1.SetToolTip(this.searchResultsBox, "Select any course and double click to add");
            this.searchResultsBox.SelectedIndexChanged += new System.EventHandler(this.course_Description_Update);
            this.searchResultsBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.update_calendar_add);
            // 
            // courseDataBox
            // 
            this.courseDataBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.courseDataBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.courseDataBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.courseDataBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.courseDataBox.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseDataBox.Location = new System.Drawing.Point(1, -1);
            this.courseDataBox.Name = "courseDataBox";
            this.courseDataBox.ReadOnly = true;
            this.courseDataBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.courseDataBox.Size = new System.Drawing.Size(188, 124);
            this.courseDataBox.TabIndex = 4;
            this.courseDataBox.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(758, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createTimeslotToolStripMenuItem,
            this.viewCourseListToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // createTimeslotToolStripMenuItem
            // 
            this.createTimeslotToolStripMenuItem.Name = "createTimeslotToolStripMenuItem";
            this.createTimeslotToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.createTimeslotToolStripMenuItem.Text = "Create Timeslot";
            this.createTimeslotToolStripMenuItem.Click += new System.EventHandler(this.createTimeslotToolStripMenuItem_Click);
            // 
            // viewCourseListToolStripMenuItem
            // 
            this.viewCourseListToolStripMenuItem.Name = "viewCourseListToolStripMenuItem";
            this.viewCourseListToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.viewCourseListToolStripMenuItem.Text = "View Course List";
            this.viewCourseListToolStripMenuItem.Click += new System.EventHandler(this.viewCourseListToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideTipsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // hideTipsToolStripMenuItem
            // 
            this.hideTipsToolStripMenuItem.Name = "hideTipsToolStripMenuItem";
            this.hideTipsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.hideTipsToolStripMenuItem.Text = "Hide Tips";
            this.hideTipsToolStripMenuItem.Click += new System.EventHandler(this.hideTipsToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.Filter = "CSV files|*.csv";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "csv";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "csv files|*.csv";
            // 
            // searchMenu
            // 
            this.searchMenu.FormattingEnabled = true;
            this.searchMenu.ItemHeight = 23;
            this.searchMenu.Items.AddRange(new object[] {
            "General",
            "Course Code",
            "Course Name",
            "Date/Time",
            "Department"});
            this.searchMenu.Location = new System.Drawing.Point(20, 125);
            this.searchMenu.Name = "searchMenu";
            this.searchMenu.Size = new System.Drawing.Size(190, 29);
            this.searchMenu.TabIndex = 12;
            this.metroToolTip1.SetToolTip(this.searchMenu, "Narrow your search results");
            this.searchMenu.UseSelectable = true;
            this.searchMenu.SelectedIndexChanged += new System.EventHandler(this.searchMenu_NewSelect);
            this.searchMenu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchBox_Enter);
            // 
            // searchBox
            // 
            // 
            // 
            // 
            this.searchBox.CustomButton.Image = null;
            this.searchBox.CustomButton.Location = new System.Drawing.Point(168, 1);
            this.searchBox.CustomButton.Name = "";
            this.searchBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.searchBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.searchBox.CustomButton.TabIndex = 1;
            this.searchBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.searchBox.CustomButton.UseSelectable = true;
            this.searchBox.CustomButton.Visible = false;
            this.searchBox.Lines = new string[0];
            this.searchBox.Location = new System.Drawing.Point(20, 96);
            this.searchBox.MaxLength = 32767;
            this.searchBox.Name = "searchBox";
            this.searchBox.PasswordChar = '\0';
            this.searchBox.PromptText = "Search anything";
            this.searchBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchBox.SelectedText = "";
            this.searchBox.SelectionLength = 0;
            this.searchBox.SelectionStart = 0;
            this.searchBox.ShortcutsEnabled = true;
            this.searchBox.Size = new System.Drawing.Size(190, 23);
            this.searchBox.TabIndex = 13;
            this.metroToolTip1.SetToolTip(this.searchBox, "Type anything and press enter");
            this.searchBox.UseSelectable = true;
            this.searchBox.WaterMark = "Search anything";
            this.searchBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.searchBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.searchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchBox_Enter);
            // 
            // calendarView
            // 
            this.calendarView.AllowUserToAddRows = false;
            this.calendarView.AllowUserToDeleteRows = false;
            this.calendarView.AllowUserToResizeColumns = false;
            this.calendarView.AllowUserToResizeRows = false;
            this.calendarView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.calendarView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.calendarView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.calendarView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.calendarView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.calendarView.DefaultCellStyle = dataGridViewCellStyle2;
            this.calendarView.EnableHeadersVisualStyles = false;
            this.calendarView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.calendarView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.calendarView.Location = new System.Drawing.Point(216, 96);
            this.calendarView.MultiSelect = false;
            this.calendarView.Name = "calendarView";
            this.calendarView.ReadOnly = true;
            this.calendarView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.calendarView.RowHeadersVisible = false;
            this.calendarView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.calendarView.RowTemplate.ReadOnly = true;
            this.calendarView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.calendarView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.calendarView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.calendarView.Size = new System.Drawing.Size(561, 596);
            this.calendarView.TabIndex = 10;
            this.calendarView.TabStop = false;
            //this.calendarView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.calendarView_CellContentClick);
            this.calendarView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.selected_cell);
            this.calendarView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.update_calendar_remove);
            // 
            // removeCourseBox
            // 
            this.removeCourseBox.ActiveControl = null;
            this.removeCourseBox.Location = new System.Drawing.Point(120, 568);
            this.removeCourseBox.Name = "removeCourseBox";
            this.removeCourseBox.Size = new System.Drawing.Size(90, 40);
            this.removeCourseBox.TabIndex = 17;
            this.removeCourseBox.Text = "Remove";
            this.removeCourseBox.UseSelectable = true;
            this.removeCourseBox.Click += new System.EventHandler(this.update_calendar_remove);
            // 
            // exportButton
            // 
            this.exportButton.DisplayFocus = true;
            this.exportButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.exportButton.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.exportButton.Highlight = true;
            this.exportButton.Location = new System.Drawing.Point(120, 616);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(90, 40);
            this.exportButton.TabIndex = 17;
            this.exportButton.Text = " Get Codes";
            this.exportButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroToolTip1.SetToolTip(this.exportButton, "Generate a list of codes for myGCC");
            this.exportButton.UseSelectable = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // compareButton
            // 
            this.compareButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.compareButton.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.compareButton.Highlight = true;
            this.compareButton.Location = new System.Drawing.Point(20, 616);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(90, 40);
            this.compareButton.TabIndex = 15;
            this.compareButton.Text = " Compare";
            this.compareButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.compareButton.UseSelectable = true;
            this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
            // 
            // addCourseButton
            // 
            this.addCourseButton.ActiveControl = null;
            this.addCourseButton.Location = new System.Drawing.Point(20, 568);
            this.addCourseButton.Name = "addCourseButton";
            this.addCourseButton.Size = new System.Drawing.Size(90, 40);
            this.addCourseButton.TabIndex = 16;
            this.addCourseButton.Text = "Add";
            this.addCourseButton.UseSelectable = true;
            this.addCourseButton.Click += new System.EventHandler(this.update_calendar_add);
            // 
            // metroToggle1
            // 
            this.metroToggle1.AutoSize = true;
            this.metroToggle1.Location = new System.Drawing.Point(120, 675);
            this.metroToggle1.Name = "metroToggle1";
            this.metroToggle1.Size = new System.Drawing.Size(80, 17);
            this.metroToggle1.TabIndex = 17;
            this.metroToggle1.Text = "Off";
            this.metroToolTip1.SetToolTip(this.metroToggle1, "Click to toggle dark theme");
            this.metroToggle1.UseSelectable = true;
            this.metroToggle1.CheckedChanged += new System.EventHandler(this.metroToggle1_CheckedChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 673);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(70, 19);
            this.metroLabel1.TabIndex = 18;
            this.metroLabel1.Text = "Night Shift";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.courseDataBox);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 438);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(190, 124);
            this.metroPanel1.TabIndex = 19;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroBar
            // 
            this.metroBar.Location = new System.Drawing.Point(20, 428);
            this.metroBar.Name = "metroBar";
            this.metroBar.Size = new System.Drawing.Size(190, 6);
            this.metroBar.TabIndex = 20;
            // 
            // mondayCheckBox
            // 
            this.mondayCheckBox.AutoSize = true;
            this.mondayCheckBox.Location = new System.Drawing.Point(23, 160);
            this.mondayCheckBox.Name = "mondayCheckBox";
            this.mondayCheckBox.Size = new System.Drawing.Size(34, 15);
            this.mondayCheckBox.TabIndex = 21;
            this.mondayCheckBox.Text = "M";
            this.mondayCheckBox.UseSelectable = true;
            this.mondayCheckBox.Visible = false;
            this.mondayCheckBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchBox_Enter);
            // 
            // tuesdayCheckBox
            // 
            this.tuesdayCheckBox.AutoSize = true;
            this.tuesdayCheckBox.Location = new System.Drawing.Point(63, 160);
            this.tuesdayCheckBox.Name = "tuesdayCheckBox";
            this.tuesdayCheckBox.Size = new System.Drawing.Size(30, 15);
            this.tuesdayCheckBox.TabIndex = 22;
            this.tuesdayCheckBox.Text = "T";
            this.tuesdayCheckBox.UseSelectable = true;
            this.tuesdayCheckBox.Visible = false;
            this.tuesdayCheckBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchBox_Enter);
            // 
            // wednesdayCheckBox
            // 
            this.wednesdayCheckBox.AutoSize = true;
            this.wednesdayCheckBox.Location = new System.Drawing.Point(99, 160);
            this.wednesdayCheckBox.Name = "wednesdayCheckBox";
            this.wednesdayCheckBox.Size = new System.Drawing.Size(34, 15);
            this.wednesdayCheckBox.TabIndex = 23;
            this.wednesdayCheckBox.Text = "W";
            this.wednesdayCheckBox.UseSelectable = true;
            this.wednesdayCheckBox.Visible = false;
            this.wednesdayCheckBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchBox_Enter);
            // 
            // thursdayCheckBox
            // 
            this.thursdayCheckBox.AutoSize = true;
            this.thursdayCheckBox.Location = new System.Drawing.Point(139, 160);
            this.thursdayCheckBox.Name = "thursdayCheckBox";
            this.thursdayCheckBox.Size = new System.Drawing.Size(30, 15);
            this.thursdayCheckBox.TabIndex = 24;
            this.thursdayCheckBox.Text = "R";
            this.thursdayCheckBox.UseSelectable = true;
            this.thursdayCheckBox.Visible = false;
            this.thursdayCheckBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchBox_Enter);
            // 
            // fridayCheckBox
            // 
            this.fridayCheckBox.AutoSize = true;
            this.fridayCheckBox.Location = new System.Drawing.Point(175, 160);
            this.fridayCheckBox.Name = "fridayCheckBox";
            this.fridayCheckBox.Size = new System.Drawing.Size(29, 15);
            this.fridayCheckBox.TabIndex = 25;
            this.fridayCheckBox.Text = "F";
            this.fridayCheckBox.UseSelectable = true;
            this.fridayCheckBox.Visible = false;
            this.fridayCheckBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchBox_Enter);
            // 
            // startTimeBox
            // 
            // 
            // 
            // 
            this.startTimeBox.CustomButton.Image = null;
            this.startTimeBox.CustomButton.Location = new System.Drawing.Point(91, 1);
            this.startTimeBox.CustomButton.Name = "";
            this.startTimeBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.startTimeBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.startTimeBox.CustomButton.TabIndex = 1;
            this.startTimeBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.startTimeBox.CustomButton.UseSelectable = true;
            this.startTimeBox.CustomButton.Visible = false;
            this.startTimeBox.Lines = new string[0];
            this.startTimeBox.Location = new System.Drawing.Point(20, 182);
            this.startTimeBox.MaxLength = 32767;
            this.startTimeBox.Name = "startTimeBox";
            this.startTimeBox.PasswordChar = '\0';
            this.startTimeBox.PromptText = "Start Time";
            this.startTimeBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.startTimeBox.SelectedText = "";
            this.startTimeBox.SelectionLength = 0;
            this.startTimeBox.SelectionStart = 0;
            this.startTimeBox.ShortcutsEnabled = true;
            this.startTimeBox.Size = new System.Drawing.Size(113, 23);
            this.startTimeBox.TabIndex = 26;
            this.startTimeBox.UseSelectable = true;
            this.startTimeBox.Visible = false;
            this.startTimeBox.WaterMark = "Start Time";
            this.startTimeBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.startTimeBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.startTimeBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchBox_Enter);
            // 
            // PMCheckBox1
            // 
            this.PMCheckBox1.AutoSize = true;
            this.PMCheckBox1.Location = new System.Drawing.Point(139, 185);
            this.PMCheckBox1.Name = "PMCheckBox1";
            this.PMCheckBox1.Size = new System.Drawing.Size(41, 15);
            this.PMCheckBox1.TabIndex = 27;
            this.PMCheckBox1.Text = "PM";
            this.PMCheckBox1.UseSelectable = true;
            this.PMCheckBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchBox_Enter);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 714);
            this.Controls.Add(this.PMCheckBox1);
            this.Controls.Add(this.searchResultsBox);
            this.Controls.Add(this.startTimeBox);
            this.Controls.Add(this.fridayCheckBox);
            this.Controls.Add(this.thursdayCheckBox);
            this.Controls.Add(this.wednesdayCheckBox);
            this.Controls.Add(this.tuesdayCheckBox);
            this.Controls.Add(this.mondayCheckBox);
            this.Controls.Add(this.metroBar);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroToggle1);
            this.Controls.Add(this.removeCourseBox);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.addCourseButton);
            this.Controls.Add(this.compareButton);
            this.Controls.Add(this.calendarView);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.searchMenu);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.metroPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Course Scheduler";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calendarView)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox searchResultsBox;
        private System.Windows.Forms.RichTextBox courseDataBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem createTimeslotToolStripMenuItem;
        private PictureBox pictureBox1;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private MetroFramework.Controls.MetroComboBox searchMenu;
        private MetroFramework.Controls.MetroTextBox searchBox;
        private MetroFramework.Controls.MetroGrid calendarView;
        private MetroFramework.Controls.MetroButton exportButton;
        private MetroFramework.Controls.MetroButton compareButton;
        private MetroFramework.Controls.MetroTile addCourseButton;
        private MetroFramework.Controls.MetroTile removeCourseBox;
        private MetroFramework.Controls.MetroToggle metroToggle1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroProgressBar metroBar;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem hideTipsToolStripMenuItem;
        private MetroFramework.Controls.MetroCheckBox mondayCheckBox;
        private MetroFramework.Controls.MetroCheckBox tuesdayCheckBox;
        private MetroFramework.Controls.MetroCheckBox wednesdayCheckBox;
        private MetroFramework.Controls.MetroCheckBox thursdayCheckBox;
        private MetroFramework.Controls.MetroCheckBox fridayCheckBox;
        private MetroFramework.Controls.MetroTextBox startTimeBox;
        private MetroFramework.Controls.MetroCheckBox PMCheckBox1;
        private ToolStripMenuItem viewCourseListToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}

