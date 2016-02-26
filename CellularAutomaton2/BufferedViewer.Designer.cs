namespace CellularAutomaton
{
    partial class BufferedViewer
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
            this.components = new System.ComponentModel.Container();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.Menu_Playback = new System.Windows.Forms.ToolStripMenuItem();
            this.Playback_Start = new System.Windows.Forms.ToolStripMenuItem();
            this.Playback_Stop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Playback_Loop = new System.Windows.Forms.ToolStripMenuItem();
            this.TB = new System.Windows.Forms.TrackBar();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.GridPanel = new System.Windows.Forms.Panel();
            this.Menu_Grid = new System.Windows.Forms.ToolStripMenuItem();
            this.Grid_HD = new System.Windows.Forms.ToolStripMenuItem();
            this.Grid_PM = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TB)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Playback,
            this.Menu_Grid});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(698, 24);
            this.MainMenu.TabIndex = 0;
            // 
            // Menu_Playback
            // 
            this.Menu_Playback.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Playback_Start,
            this.Playback_Stop,
            this.toolStripSeparator1,
            this.Playback_Loop});
            this.Menu_Playback.Name = "Menu_Playback";
            this.Menu_Playback.Size = new System.Drawing.Size(66, 20);
            this.Menu_Playback.Text = "Playback";
            // 
            // Playback_Start
            // 
            this.Playback_Start.Name = "Playback_Start";
            this.Playback_Start.Size = new System.Drawing.Size(101, 22);
            this.Playback_Start.Text = "Start";
            this.Playback_Start.Click += new System.EventHandler(this.Playback_Start_Click);
            // 
            // Playback_Stop
            // 
            this.Playback_Stop.Enabled = false;
            this.Playback_Stop.Name = "Playback_Stop";
            this.Playback_Stop.Size = new System.Drawing.Size(101, 22);
            this.Playback_Stop.Text = "Stop";
            this.Playback_Stop.Click += new System.EventHandler(this.Playback_Stop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(98, 6);
            // 
            // Playback_Loop
            // 
            this.Playback_Loop.Name = "Playback_Loop";
            this.Playback_Loop.Size = new System.Drawing.Size(101, 22);
            this.Playback_Loop.Text = "Loop";
            this.Playback_Loop.Click += new System.EventHandler(this.Playback_Loop_Click);
            // 
            // TB
            // 
            this.TB.AutoSize = false;
            this.TB.BackColor = System.Drawing.Color.White;
            this.TB.Dock = System.Windows.Forms.DockStyle.Top;
            this.TB.Location = new System.Drawing.Point(0, 24);
            this.TB.Maximum = 100;
            this.TB.Name = "TB";
            this.TB.Size = new System.Drawing.Size(698, 30);
            this.TB.TabIndex = 1;
            this.TB.TabStop = false;
            this.TB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TB.Scroll += new System.EventHandler(this.TB_Scroll);
            this.TB.ValueChanged += new System.EventHandler(this.TB_ValueChanged);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 2;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // GridPanel
            // 
            this.GridPanel.BackColor = System.Drawing.Color.White;
            this.GridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridPanel.Location = new System.Drawing.Point(0, 54);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(698, 445);
            this.GridPanel.TabIndex = 2;
            // 
            // Menu_Grid
            // 
            this.Menu_Grid.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Grid_HD,
            this.Grid_PM});
            this.Menu_Grid.Name = "Menu_Grid";
            this.Menu_Grid.Size = new System.Drawing.Size(41, 20);
            this.Menu_Grid.Text = "Grid";
            // 
            // Grid_HD
            // 
            this.Grid_HD.Name = "Grid_HD";
            this.Grid_HD.Size = new System.Drawing.Size(155, 22);
            this.Grid_HD.Text = "High Definition";
            this.Grid_HD.Click += new System.EventHandler(this.Grid_HD_Click);
            // 
            // Grid_PM
            // 
            this.Grid_PM.Name = "Grid_PM";
            this.Grid_PM.Size = new System.Drawing.Size(155, 22);
            this.Grid_PM.Text = "Point Mode";
            this.Grid_PM.Click += new System.EventHandler(this.Grid_PM_Click);
            // 
            // BufferedViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 499);
            this.Controls.Add(this.GridPanel);
            this.Controls.Add(this.TB);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "BufferedViewer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buffered Automaton Viewer";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BufferedViewer_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.TrackBar TB;
        private System.Windows.Forms.ToolStripMenuItem Menu_Playback;
        private System.Windows.Forms.ToolStripMenuItem Playback_Start;
        private System.Windows.Forms.ToolStripMenuItem Playback_Stop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Playback_Loop;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.Panel GridPanel;
        private System.Windows.Forms.ToolStripMenuItem Menu_Grid;
        private System.Windows.Forms.ToolStripMenuItem Grid_HD;
        private System.Windows.Forms.ToolStripMenuItem Grid_PM;
    }
}