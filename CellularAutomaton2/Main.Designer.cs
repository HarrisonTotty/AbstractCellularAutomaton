namespace CellularAutomaton
{
    partial class Main
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
            this.Menu_File = new System.Windows.Forms.ToolStripMenuItem();
            this.File_New = new System.Windows.Forms.ToolStripMenuItem();
            this.File_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.File_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.File_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Simulation = new System.Windows.Forms.ToolStripMenuItem();
            this.Simulation_RandomizeAlgorithms = new System.Windows.Forms.ToolStripMenuItem();
            this.Simulation_Seed = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Simulation_Start = new System.Windows.Forms.ToolStripMenuItem();
            this.Simulation_Resume = new System.Windows.Forms.ToolStripMenuItem();
            this.Simulation_Pause = new System.Windows.Forms.ToolStripMenuItem();
            this.Simulation_Restart = new System.Windows.Forms.ToolStripMenuItem();
            this.Simulation_Stop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Simulation_UpdateInterval = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.Simulation_Size = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.Simulation_GNSR = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.Simulation_GR1DCA = new System.Windows.Forms.ToolStripMenuItem();
            this.Simulation_GR1DCA_Value = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.Simulation_Buffer = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.Options_RandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.Options_RandSeed = new System.Windows.Forms.ToolStripMenuItem();
            this.Options_RandRules = new System.Windows.Forms.ToolStripMenuItem();
            this.Options_RandRS = new System.Windows.Forms.ToolStripMenuItem();
            this.Options_RandNeighbor = new System.Windows.Forms.ToolStripMenuItem();
            this.Options_RandOverflow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Options_RandRadius = new System.Windows.Forms.ToolStripMenuItem();
            this.Options_RandE1DRules = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.Options_RestartOnFlatline = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Grid = new System.Windows.Forms.ToolStripMenuItem();
            this.Grid_HD = new System.Windows.Forms.ToolStripMenuItem();
            this.Grid_PM = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.Grid_BrushSize = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem23 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Seperator = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Seeding = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Rules = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_RuleSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Neighbor = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Overflow = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            this.GridPanel = new System.Windows.Forms.Panel();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.Tab_Grid = new System.Windows.Forms.TabPage();
            this.Tab_Info = new System.Windows.Forms.TabPage();
            this.AutomatonPG = new System.Windows.Forms.PropertyGrid();
            this.Tab_Statistics = new System.Windows.Forms.TabPage();
            this.StatBox = new System.Windows.Forms.TextBox();
            this.MainMenu.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.Tab_Grid.SuspendLayout();
            this.Tab_Info.SuspendLayout();
            this.Tab_Statistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_File,
            this.Menu_Simulation,
            this.Menu_Options,
            this.Menu_Grid,
            this.Menu_Seperator,
            this.Menu_Seeding,
            this.Menu_Rules,
            this.Menu_RuleSelection,
            this.Menu_Neighbor,
            this.Menu_Overflow});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.ShowItemToolTips = true;
            this.MainMenu.Size = new System.Drawing.Size(866, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "MainMenu";
            // 
            // Menu_File
            // 
            this.Menu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_New,
            this.File_Open,
            this.File_Save,
            this.toolStripSeparator3,
            this.File_Exit});
            this.Menu_File.Name = "Menu_File";
            this.Menu_File.Size = new System.Drawing.Size(37, 20);
            this.Menu_File.Text = "File";
            // 
            // File_New
            // 
            this.File_New.Name = "File_New";
            this.File_New.Size = new System.Drawing.Size(152, 22);
            this.File_New.Text = "New";
            this.File_New.Click += new System.EventHandler(this.File_New_Click);
            // 
            // File_Open
            // 
            this.File_Open.Name = "File_Open";
            this.File_Open.Size = new System.Drawing.Size(152, 22);
            this.File_Open.Text = "Open";
            this.File_Open.Click += new System.EventHandler(this.File_Open_Click);
            // 
            // File_Save
            // 
            this.File_Save.Name = "File_Save";
            this.File_Save.Size = new System.Drawing.Size(152, 22);
            this.File_Save.Text = "Save";
            this.File_Save.Click += new System.EventHandler(this.File_Save_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // File_Exit
            // 
            this.File_Exit.Name = "File_Exit";
            this.File_Exit.Size = new System.Drawing.Size(152, 22);
            this.File_Exit.Text = "Exit";
            this.File_Exit.Click += new System.EventHandler(this.File_Exit_Click);
            // 
            // Menu_Simulation
            // 
            this.Menu_Simulation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Simulation_RandomizeAlgorithms,
            this.Simulation_Seed,
            this.toolStripSeparator4,
            this.Simulation_Start,
            this.Simulation_Resume,
            this.Simulation_Pause,
            this.Simulation_Restart,
            this.Simulation_Stop,
            this.toolStripSeparator1,
            this.Simulation_UpdateInterval,
            this.Simulation_Size,
            this.Simulation_GNSR,
            this.Simulation_GR1DCA,
            this.toolStripSeparator5,
            this.Simulation_Buffer});
            this.Menu_Simulation.Name = "Menu_Simulation";
            this.Menu_Simulation.Size = new System.Drawing.Size(76, 20);
            this.Menu_Simulation.Text = "Simulation";
            // 
            // Simulation_RandomizeAlgorithms
            // 
            this.Simulation_RandomizeAlgorithms.Name = "Simulation_RandomizeAlgorithms";
            this.Simulation_RandomizeAlgorithms.Size = new System.Drawing.Size(278, 22);
            this.Simulation_RandomizeAlgorithms.Text = "Randomize Algorithms";
            this.Simulation_RandomizeAlgorithms.Click += new System.EventHandler(this.Simulation_RandomizeAlgorithms_Click);
            // 
            // Simulation_Seed
            // 
            this.Simulation_Seed.Name = "Simulation_Seed";
            this.Simulation_Seed.Size = new System.Drawing.Size(278, 22);
            this.Simulation_Seed.Text = "Seed";
            this.Simulation_Seed.Click += new System.EventHandler(this.Simulation_Seed_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(275, 6);
            // 
            // Simulation_Start
            // 
            this.Simulation_Start.Name = "Simulation_Start";
            this.Simulation_Start.Size = new System.Drawing.Size(278, 22);
            this.Simulation_Start.Text = "Start (S)";
            this.Simulation_Start.Click += new System.EventHandler(this.Simulation_Start_Click);
            // 
            // Simulation_Resume
            // 
            this.Simulation_Resume.Enabled = false;
            this.Simulation_Resume.Name = "Simulation_Resume";
            this.Simulation_Resume.Size = new System.Drawing.Size(278, 22);
            this.Simulation_Resume.Text = "Resume (Space)";
            this.Simulation_Resume.Click += new System.EventHandler(this.Simulation_Resume_Click);
            // 
            // Simulation_Pause
            // 
            this.Simulation_Pause.Enabled = false;
            this.Simulation_Pause.Name = "Simulation_Pause";
            this.Simulation_Pause.Size = new System.Drawing.Size(278, 22);
            this.Simulation_Pause.Text = "Pause (Space)";
            this.Simulation_Pause.Click += new System.EventHandler(this.Simulation_Pause_Click);
            // 
            // Simulation_Restart
            // 
            this.Simulation_Restart.Name = "Simulation_Restart";
            this.Simulation_Restart.Size = new System.Drawing.Size(278, 22);
            this.Simulation_Restart.Text = "Restart (R)";
            this.Simulation_Restart.Click += new System.EventHandler(this.Simulation_Restart_Click);
            // 
            // Simulation_Stop
            // 
            this.Simulation_Stop.Enabled = false;
            this.Simulation_Stop.Name = "Simulation_Stop";
            this.Simulation_Stop.Size = new System.Drawing.Size(278, 22);
            this.Simulation_Stop.Text = "Stop (S)";
            this.Simulation_Stop.Click += new System.EventHandler(this.Simulation_Stop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(275, 6);
            // 
            // Simulation_UpdateInterval
            // 
            this.Simulation_UpdateInterval.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem4,
            this.toolStripMenuItem3,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.Simulation_UpdateInterval.Name = "Simulation_UpdateInterval";
            this.Simulation_UpdateInterval.Size = new System.Drawing.Size(278, 22);
            this.Simulation_UpdateInterval.Text = "Update Interval (ms)";
            this.Simulation_UpdateInterval.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Simulation_UpdateInterval_DropDownItemClicked);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Checked = true;
            this.toolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem2.Text = "1";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem4.Text = "10";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem3.Text = "50";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem5.Text = "100";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem6.Text = "1000";
            // 
            // Simulation_Size
            // 
            this.Simulation_Size.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem12,
            this.toolStripMenuItem7,
            this.toolStripMenuItem11,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10});
            this.Simulation_Size.Name = "Simulation_Size";
            this.Simulation_Size.Size = new System.Drawing.Size(278, 22);
            this.Simulation_Size.Text = "Size (N x N)";
            this.Simulation_Size.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Simulation_Size_DropDownItemClicked);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem12.Text = "5";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Checked = true;
            this.toolStripMenuItem7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem7.Text = "10";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem11.Text = "20";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem8.Text = "50";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem9.Text = "100";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem10.Text = "200";
            // 
            // Simulation_GNSR
            // 
            this.Simulation_GNSR.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem13,
            this.toolStripMenuItem14,
            this.toolStripMenuItem15,
            this.toolStripMenuItem16,
            this.toolStripMenuItem17});
            this.Simulation_GNSR.Name = "Simulation_GNSR";
            this.Simulation_GNSR.Size = new System.Drawing.Size(278, 22);
            this.Simulation_GNSR.Text = "Global Neighbor Search Radius";
            this.Simulation_GNSR.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Simulation_GNSR_DropDownItemClicked);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Checked = true;
            this.toolStripMenuItem13.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem13.Text = "1";
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem14.Text = "2";
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem15.Text = "3";
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem16.Text = "4";
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem17.Text = "6";
            // 
            // Simulation_GR1DCA
            // 
            this.Simulation_GR1DCA.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Simulation_GR1DCA_Value});
            this.Simulation_GR1DCA.Name = "Simulation_GR1DCA";
            this.Simulation_GR1DCA.Size = new System.Drawing.Size(278, 22);
            this.Simulation_GR1DCA.Text = "Global Rule For 1D Cellular Automaton";
            // 
            // Simulation_GR1DCA_Value
            // 
            this.Simulation_GR1DCA_Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Simulation_GR1DCA_Value.Name = "Simulation_GR1DCA_Value";
            this.Simulation_GR1DCA_Value.Size = new System.Drawing.Size(100, 23);
            this.Simulation_GR1DCA_Value.Text = "30";
            this.Simulation_GR1DCA_Value.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Simulation_GR1DCA_Value_KeyDown);
            this.Simulation_GR1DCA_Value.Click += new System.EventHandler(this.Simulation_GR1DCA_Value_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(275, 6);
            // 
            // Simulation_Buffer
            // 
            this.Simulation_Buffer.Name = "Simulation_Buffer";
            this.Simulation_Buffer.Size = new System.Drawing.Size(278, 22);
            this.Simulation_Buffer.Text = "Buffer Simulation...";
            this.Simulation_Buffer.Click += new System.EventHandler(this.Simulation_Buffer_Click);
            // 
            // Menu_Options
            // 
            this.Menu_Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Options_RandAll,
            this.toolStripSeparator6,
            this.Options_RandSeed,
            this.Options_RandRules,
            this.Options_RandRS,
            this.Options_RandNeighbor,
            this.Options_RandOverflow,
            this.toolStripSeparator2,
            this.Options_RandRadius,
            this.Options_RandE1DRules,
            this.toolStripSeparator7,
            this.Options_RestartOnFlatline});
            this.Menu_Options.Name = "Menu_Options";
            this.Menu_Options.Size = new System.Drawing.Size(61, 20);
            this.Menu_Options.Text = "Options";
            // 
            // Options_RandAll
            // 
            this.Options_RandAll.Name = "Options_RandAll";
            this.Options_RandAll.Size = new System.Drawing.Size(337, 22);
            this.Options_RandAll.Text = "Randomize all algorithms on start";
            this.Options_RandAll.Click += new System.EventHandler(this.Options_RandAll_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(334, 6);
            // 
            // Options_RandSeed
            // 
            this.Options_RandSeed.Name = "Options_RandSeed";
            this.Options_RandSeed.Size = new System.Drawing.Size(337, 22);
            this.Options_RandSeed.Text = "Randomize seed algorithm on start";
            this.Options_RandSeed.Click += new System.EventHandler(this.Options_RandAlgs_Click);
            // 
            // Options_RandRules
            // 
            this.Options_RandRules.Name = "Options_RandRules";
            this.Options_RandRules.Size = new System.Drawing.Size(337, 22);
            this.Options_RandRules.Text = "Randomize simulation rules on start";
            this.Options_RandRules.Click += new System.EventHandler(this.Options_RandRules_Click);
            // 
            // Options_RandRS
            // 
            this.Options_RandRS.Name = "Options_RandRS";
            this.Options_RandRS.Size = new System.Drawing.Size(337, 22);
            this.Options_RandRS.Text = "Randomize rule selection algorithm on start";
            this.Options_RandRS.Click += new System.EventHandler(this.Options_RandRS_Click);
            // 
            // Options_RandNeighbor
            // 
            this.Options_RandNeighbor.Name = "Options_RandNeighbor";
            this.Options_RandNeighbor.Size = new System.Drawing.Size(337, 22);
            this.Options_RandNeighbor.Text = "Randomize neighbor algorithm on start";
            this.Options_RandNeighbor.Click += new System.EventHandler(this.Options_RandNeighbor_Click);
            // 
            // Options_RandOverflow
            // 
            this.Options_RandOverflow.Name = "Options_RandOverflow";
            this.Options_RandOverflow.Size = new System.Drawing.Size(337, 22);
            this.Options_RandOverflow.Text = "Randomize overflow algorithm on start";
            this.Options_RandOverflow.Click += new System.EventHandler(this.Options_RandOverflow_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(334, 6);
            // 
            // Options_RandRadius
            // 
            this.Options_RandRadius.Name = "Options_RandRadius";
            this.Options_RandRadius.Size = new System.Drawing.Size(337, 22);
            this.Options_RandRadius.Text = "Randomize global neighbor search radius on start";
            this.Options_RandRadius.Click += new System.EventHandler(this.Options_RandRadius_Click);
            // 
            // Options_RandE1DRules
            // 
            this.Options_RandE1DRules.Name = "Options_RandE1DRules";
            this.Options_RandE1DRules.Size = new System.Drawing.Size(337, 22);
            this.Options_RandE1DRules.Text = "Randomize global ruleset for 1D cellular automata";
            this.Options_RandE1DRules.Click += new System.EventHandler(this.Options_RandE1DRules_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(334, 6);
            // 
            // Options_RestartOnFlatline
            // 
            this.Options_RestartOnFlatline.Name = "Options_RestartOnFlatline";
            this.Options_RestartOnFlatline.Size = new System.Drawing.Size(337, 22);
            this.Options_RestartOnFlatline.Text = "Restart simulation on flatline";
            this.Options_RestartOnFlatline.ToolTipText = "Restarts the simulation if no cells change states within 4 generations";
            this.Options_RestartOnFlatline.Click += new System.EventHandler(this.Options_RestartOnFlatline_Click);
            // 
            // Menu_Grid
            // 
            this.Menu_Grid.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Grid_HD,
            this.Grid_PM,
            this.toolStripSeparator8,
            this.Grid_BrushSize});
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
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(152, 6);
            // 
            // Grid_BrushSize
            // 
            this.Grid_BrushSize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem23,
            this.toolStripMenuItem18,
            this.toolStripMenuItem19,
            this.toolStripMenuItem20,
            this.toolStripMenuItem21});
            this.Grid_BrushSize.Name = "Grid_BrushSize";
            this.Grid_BrushSize.Size = new System.Drawing.Size(155, 22);
            this.Grid_BrushSize.Text = "Brush Radius";
            this.Grid_BrushSize.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.brushSizeToolStripMenuItem_DropDownItemClicked);
            // 
            // toolStripMenuItem23
            // 
            this.toolStripMenuItem23.Checked = true;
            this.toolStripMenuItem23.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem23.Name = "toolStripMenuItem23";
            this.toolStripMenuItem23.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem23.Text = "0";
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem18.Text = "1";
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem19.Text = "2";
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            this.toolStripMenuItem20.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem20.Text = "4";
            // 
            // toolStripMenuItem21
            // 
            this.toolStripMenuItem21.Name = "toolStripMenuItem21";
            this.toolStripMenuItem21.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem21.Text = "8";
            // 
            // Menu_Seperator
            // 
            this.Menu_Seperator.Enabled = false;
            this.Menu_Seperator.Name = "Menu_Seperator";
            this.Menu_Seperator.Size = new System.Drawing.Size(22, 20);
            this.Menu_Seperator.Text = "|";
            // 
            // Menu_Seeding
            // 
            this.Menu_Seeding.Name = "Menu_Seeding";
            this.Menu_Seeding.Size = new System.Drawing.Size(101, 20);
            this.Menu_Seeding.Text = "Seed Algorithm";
            this.Menu_Seeding.ToolTipText = "The algorithm used to intialize the current cellular automaton";
            this.Menu_Seeding.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Menu_Seeding_DropDownItemClicked);
            // 
            // Menu_Rules
            // 
            this.Menu_Rules.Name = "Menu_Rules";
            this.Menu_Rules.Size = new System.Drawing.Size(107, 20);
            this.Menu_Rules.Text = "Simulation Rules";
            this.Menu_Rules.ToolTipText = "The various rules which govern the current cellular automaton - one of which will" +
    " be selected as the true result as according to the rule selection algorithm";
            this.Menu_Rules.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Menu_Rules_DropDownItemClicked);
            // 
            // Menu_RuleSelection
            // 
            this.Menu_RuleSelection.Name = "Menu_RuleSelection";
            this.Menu_RuleSelection.Size = new System.Drawing.Size(150, 20);
            this.Menu_RuleSelection.Text = "Rule Selection Algorithm";
            this.Menu_RuleSelection.ToolTipText = "The algorithm whic determines wich simulation rule will be accepted as the true r" +
    "esult of this generation";
            this.Menu_RuleSelection.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Menu_RuleSelection_DropDownItemClicked);
            // 
            // Menu_Neighbor
            // 
            this.Menu_Neighbor.Name = "Menu_Neighbor";
            this.Menu_Neighbor.Size = new System.Drawing.Size(126, 20);
            this.Menu_Neighbor.Text = "Neighbor Algorithm";
            this.Menu_Neighbor.ToolTipText = "The algorithm which specifies which cells are considered \"neighbors\" to the cell " +
    "in question";
            this.Menu_Neighbor.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Menu_Neighbor_DropDownItemClicked);
            // 
            // Menu_Overflow
            // 
            this.Menu_Overflow.Name = "Menu_Overflow";
            this.Menu_Overflow.Size = new System.Drawing.Size(124, 20);
            this.Menu_Overflow.Text = "Overflow Algorithm";
            this.Menu_Overflow.ToolTipText = "The algorithm that specifies what cell should be returned when asking for the sta" +
    "te of a cell whose position is outside the grid";
            this.Menu_Overflow.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Menu_Overflow_DropDownItemClicked);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Enabled = true;
            this.UpdateTimer.Interval = 1;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // OFD
            // 
            this.OFD.Filter = "Automaton Simulation|*.automaton|Buffered Automaton Simulation|*.bautomaton|All F" +
    "iles|*.*";
            this.OFD.Title = "Open Automaton Simulation...";
            this.OFD.FileOk += new System.ComponentModel.CancelEventHandler(this.OFD_FileOk);
            // 
            // SFD
            // 
            this.SFD.Filter = "Automaton Simulation|*.automaton|All Files|*.*";
            this.SFD.Title = "Save Automaton Simulation...";
            this.SFD.FileOk += new System.ComponentModel.CancelEventHandler(this.SFD_FileOk);
            // 
            // GridPanel
            // 
            this.GridPanel.BackColor = System.Drawing.Color.White;
            this.GridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridPanel.Location = new System.Drawing.Point(3, 3);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(852, 482);
            this.GridPanel.TabIndex = 1;
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.Tab_Grid);
            this.Tabs.Controls.Add(this.Tab_Info);
            this.Tabs.Controls.Add(this.Tab_Statistics);
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabs.Location = new System.Drawing.Point(0, 24);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(866, 514);
            this.Tabs.TabIndex = 2;
            this.Tabs.TabStop = false;
            this.Tabs.TabIndexChanged += new System.EventHandler(this.Tabs_TabIndexChanged);
            // 
            // Tab_Grid
            // 
            this.Tab_Grid.Controls.Add(this.GridPanel);
            this.Tab_Grid.Location = new System.Drawing.Point(4, 22);
            this.Tab_Grid.Name = "Tab_Grid";
            this.Tab_Grid.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Grid.Size = new System.Drawing.Size(858, 488);
            this.Tab_Grid.TabIndex = 0;
            this.Tab_Grid.Text = "Grid";
            this.Tab_Grid.UseVisualStyleBackColor = true;
            // 
            // Tab_Info
            // 
            this.Tab_Info.Controls.Add(this.AutomatonPG);
            this.Tab_Info.Location = new System.Drawing.Point(4, 22);
            this.Tab_Info.Name = "Tab_Info";
            this.Tab_Info.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Info.Size = new System.Drawing.Size(858, 488);
            this.Tab_Info.TabIndex = 1;
            this.Tab_Info.Text = "Raw Automaton Data";
            this.Tab_Info.UseVisualStyleBackColor = true;
            // 
            // AutomatonPG
            // 
            this.AutomatonPG.BackColor = System.Drawing.Color.White;
            this.AutomatonPG.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.AutomatonPG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AutomatonPG.HelpBackColor = System.Drawing.Color.White;
            this.AutomatonPG.Location = new System.Drawing.Point(3, 3);
            this.AutomatonPG.Name = "AutomatonPG";
            this.AutomatonPG.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.AutomatonPG.Size = new System.Drawing.Size(852, 482);
            this.AutomatonPG.TabIndex = 0;
            this.AutomatonPG.TabStop = false;
            // 
            // Tab_Statistics
            // 
            this.Tab_Statistics.Controls.Add(this.StatBox);
            this.Tab_Statistics.Location = new System.Drawing.Point(4, 22);
            this.Tab_Statistics.Name = "Tab_Statistics";
            this.Tab_Statistics.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Statistics.Size = new System.Drawing.Size(858, 488);
            this.Tab_Statistics.TabIndex = 2;
            this.Tab_Statistics.Text = "Statistics";
            this.Tab_Statistics.UseVisualStyleBackColor = true;
            // 
            // StatBox
            // 
            this.StatBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatBox.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatBox.Location = new System.Drawing.Point(3, 3);
            this.StatBox.Multiline = true;
            this.StatBox.Name = "StatBox";
            this.StatBox.ReadOnly = true;
            this.StatBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StatBox.Size = new System.Drawing.Size(852, 482);
            this.StatBox.TabIndex = 0;
            this.StatBox.TabStop = false;
            this.StatBox.Text = "Ready...";
            this.StatBox.WordWrap = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(866, 538);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cellular Automata - New Automaton";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.Tabs.ResumeLayout(false);
            this.Tab_Grid.ResumeLayout(false);
            this.Tab_Info.ResumeLayout(false);
            this.Tab_Statistics.ResumeLayout(false);
            this.Tab_Statistics.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem Menu_File;
        private System.Windows.Forms.ToolStripMenuItem Menu_Simulation;
        private System.Windows.Forms.ToolStripMenuItem Simulation_Start;
        private System.Windows.Forms.ToolStripMenuItem Simulation_Pause;
        private System.Windows.Forms.ToolStripMenuItem Simulation_Stop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.ToolStripMenuItem File_New;
        private System.Windows.Forms.ToolStripMenuItem File_Open;
        private System.Windows.Forms.ToolStripMenuItem File_Save;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.SaveFileDialog SFD;
        private System.Windows.Forms.ToolStripMenuItem Simulation_UpdateInterval;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem Menu_Seeding;
        private System.Windows.Forms.ToolStripMenuItem Menu_Rules;
        private System.Windows.Forms.ToolStripMenuItem Menu_Neighbor;
        private System.Windows.Forms.ToolStripMenuItem Menu_RuleSelection;
        private System.Windows.Forms.ToolStripMenuItem Simulation_Size;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem File_Exit;
        private System.Windows.Forms.ToolStripMenuItem Simulation_Resume;
        private System.Windows.Forms.ToolStripMenuItem Simulation_Seed;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.Panel GridPanel;
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage Tab_Grid;
        private System.Windows.Forms.TabPage Tab_Info;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.PropertyGrid AutomatonPG;
        private System.Windows.Forms.ToolStripMenuItem Menu_Grid;
        private System.Windows.Forms.ToolStripMenuItem Grid_HD;
        private System.Windows.Forms.ToolStripMenuItem Grid_PM;
        private System.Windows.Forms.ToolStripMenuItem Menu_Overflow;
        private System.Windows.Forms.TabPage Tab_Statistics;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem Simulation_Buffer;
        private System.Windows.Forms.ToolStripMenuItem Menu_Options;
        private System.Windows.Forms.ToolStripMenuItem Options_RandSeed;
        private System.Windows.Forms.ToolStripMenuItem Menu_Seperator;
        private System.Windows.Forms.ToolStripMenuItem Simulation_RandomizeAlgorithms;
        private System.Windows.Forms.ToolStripMenuItem Simulation_Restart;
        private System.Windows.Forms.ToolStripMenuItem Options_RestartOnFlatline;
        private System.Windows.Forms.ToolStripMenuItem Simulation_GNSR;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
        private System.Windows.Forms.ToolStripMenuItem Options_RandRules;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem Options_RandRS;
        private System.Windows.Forms.ToolStripMenuItem Options_RandNeighbor;
        private System.Windows.Forms.ToolStripMenuItem Options_RandOverflow;
        private System.Windows.Forms.ToolStripMenuItem Options_RandAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem Options_RandRadius;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem Grid_BrushSize;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem18;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem19;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem20;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem21;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem23;
        private System.Windows.Forms.TextBox StatBox;
        private System.Windows.Forms.ToolStripMenuItem Simulation_GR1DCA;
        private System.Windows.Forms.ToolStripTextBox Simulation_GR1DCA_Value;
        private System.Windows.Forms.ToolStripMenuItem Options_RandE1DRules;
    }
}

