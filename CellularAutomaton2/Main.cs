using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CellularAutomaton
{
    public partial class Main : Form
    {
        /// <summary>
        /// The currently loaded automaton.
        /// </summary>
        public Automaton CurrentAutomaton;

        /// <summary>
        /// The grid system.
        /// </summary>
        public Grid Grid = new Grid();

        /// <summary>
        /// The current timestep of the simulation.
        /// </summary>
        public long CurrentGeneration = 0;

        /// <summary>
        /// The number of milliseconds required to advance the simulation a single generation.
        /// </summary>
        public int UpdateInterval = 1;

        /// <summary>
        /// The number of milliseconds that have passed since last advancing the simulation a generation.
        /// </summary>
        public int UpdateFraction = 0;

        public int BrushSize = 0;

        /// <summary>
        /// Whether the simulation is currently running.
        /// </summary>
        public bool Running = false;

        /// <summary>
        /// Whether the current simulation has been seeded.
        /// </summary>
        public bool Seeded = false;

        /// <summary>
        /// Whether all of the algorithms should be randomized when pressing the start button.
        /// </summary>
        public bool RandomizeAlgorithmsOnStart = false;

        public bool RandomizeRulesOS = false;
        public bool RandomizeNeighborOS = false;
        public bool RandomizeSeedOS = false;
        public bool RandomizeRSOS = false;
        public bool RandomizeOverflowOS = false;
        public bool RandomizeGNSROS = false;
        public bool RandomizeGR1DCA = false;

        public bool? MouseState = null;

        /// <summary>
        /// Whether to restart the simulation after cells stop changing for 5 generations.
        /// </summary>
        public bool RestartOnFlatline = false;

        /// <summary>
        /// The default size of new atomatons.
        /// </summary>
        public int NewSize = 10;

        /// <summary>
        /// The number of generations that have occured since the automaton last changed cell configurations.
        /// </summary>
        public int GenerationsSinceChange = 0;

        public int[] PreviousGenerationData;

        /// <summary>
        /// The default seed algorithm of new atomatons.
        /// </summary>
        public Func<int, Cell[]> NewSeedAlgorithm = Algorithms.Seed_Random01;

        /// <summary>
        /// The default rule selection algorithm of new atomatons.
        /// </summary>
        public Func<List<Cell>, Cell> NewRuleSelectionAlgorithm = Algorithms.RuleSelection_First;

        /// <summary>
        /// The default neighbor algorithm of new atomatons.
        /// </summary>
        public Func<int[], Automaton, List<Cell>> NewNeighborAlgorithm = Algorithms.Neighbors_Moore;

        /// <summary>
        /// The default overflow algorithm of new atomatons.
        /// </summary>
        public Func<int[], Automaton, Cell> NewOverflowAlgorithm = Algorithms.Overflow_Assume0;

        /// <summary>
        /// The default set of rules for new atomatons.
        /// </summary>
        public List<Func<Cell, List<Cell>, Cell>> NewRules = new List<Func<Cell, List<Cell>, Cell>>()
        {
            Algorithms.Rule_ConwaysGameOfLife,
        };


        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Attach the grid to the panel
            this.GridPanel.Controls.Add(this.Grid);
            this.Grid.Focus();
            this.Grid.Series.PointMode_OFF();
            this.Grid.Origin = new double[] { 5, 5 };

            //Add the button event handlers for the grid
            this.Grid.KeyDown += Grid_KeyDown;
            this.Grid.MouseDown += Grid_MouseClick;
            this.Grid.MouseClick += Grid_MouseClick;
            this.Grid.MouseMove += Grid_MouseMove;
            this.Grid.MouseUp += Grid_MouseUp;

            //Initialize our algorithms
            PopulateAlgorithms();

            //Create a new automaton
            InitializeNewAutomaton();

            //Selecte the current automation to view
            this.AutomatonPG.SelectedObject = this.CurrentAutomaton;
        }

        private void Grid_MouseUp(object sender, MouseEventArgs e)
        {
            this.MouseState = null;
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.MouseState == null) return;
            if (this.MouseState == true)
            {
                if (this.CurrentAutomaton == null) return;
                try
                {
                    int[] coords = new int[] { (int)Math.Round(this.Grid.ChartArea.AxisX.PixelPositionToValue(e.X)), (int)Math.Round(this.Grid.ChartArea.AxisY.PixelPositionToValue(e.Y)) };
                    if (BrushSize == 0)
                    {
                        this.CurrentAutomaton[coords[0], coords[1]].State = 1;
                    }
                    else
                    {
                        for (int i = coords[0] - BrushSize; i <= coords[0] + BrushSize; i++)
                        {
                            for (int j = coords[1] - BrushSize; j <= coords[1] + BrushSize; j++)
                            {
                                this.CurrentAutomaton[i, j].State = 1;
                            }
                        }
                    }
                }
                catch (Exception) { };
            }
            else
            {
                if (this.CurrentAutomaton == null) return;
                try
                {
                    int[] coords = new int[] { (int)Math.Round(this.Grid.ChartArea.AxisX.PixelPositionToValue(e.X)), (int)Math.Round(this.Grid.ChartArea.AxisY.PixelPositionToValue(e.Y)) };
                    if (BrushSize == 0)
                    {
                        this.CurrentAutomaton[coords[0], coords[1]].State = 0;
                    }
                    else
                    {
                        for (int i = coords[0] - BrushSize; i <= coords[0] + BrushSize; i++)
                        {
                            for (int j = coords[1] - BrushSize; j <= coords[1] + BrushSize; j++)
                            {
                                this.CurrentAutomaton[i, j].State = 0;
                            }
                        }
                    }
                }
                catch (Exception) { };
            }
        }

        private void Grid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.MouseState = true;
                if (this.CurrentAutomaton == null) return;
                try
                {
                    int[] coords = new int[] { (int)Math.Round(this.Grid.ChartArea.AxisX.PixelPositionToValue(e.X)), (int)Math.Round(this.Grid.ChartArea.AxisY.PixelPositionToValue(e.Y)) };
                    if (BrushSize == 0)
                    {
                        this.CurrentAutomaton[coords[0], coords[1]].State = 1;
                    }
                    else
                    {
                        for (int i = coords[0] - BrushSize; i <= coords[0] + BrushSize; i++)
                        {
                            for (int j = coords[1] - BrushSize; j <= coords[1] + BrushSize; j++)
                            {
                                this.CurrentAutomaton[i, j].State = 1;
                            }
                        }
                    }
                }
                catch (Exception) { };
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.MouseState = false;
                if (this.CurrentAutomaton == null) return;
                try
                {
                    int[] coords = new int[] { (int)Math.Round(this.Grid.ChartArea.AxisX.PixelPositionToValue(e.X)), (int)Math.Round(this.Grid.ChartArea.AxisY.PixelPositionToValue(e.Y)) };
                    if (BrushSize == 0)
                    {
                        this.CurrentAutomaton[coords[0], coords[1]].State = 0;
                    }
                    else
                    {
                        for (int i = coords[0] - BrushSize; i <= coords[0] + BrushSize; i++)
                        {
                            for (int j = coords[1] - BrushSize; j <= coords[1] + BrushSize; j++)
                            {
                                this.CurrentAutomaton[i, j].State = 0;
                            }
                        }
                    }
                }
                catch (Exception) { };
            }

        }

        /// <summary>
        /// Populates the algorithms menus.
        /// </summary>
        public void PopulateAlgorithms()
        {
            //Get all of the algorithms
            foreach (FieldInfo Algorithm in typeof(Algorithms).GetFields())
            {
                if (Algorithm.Name.StartsWith("Option_")) continue;
                ToolStripMenuItem NewItem = new ToolStripMenuItem(Algorithm.Name);
                NewItem.ToolTipText = Algorithm.GetCustomAttribute<DescriptionAttribute>(false).Description;
                if (Algorithm.Name.StartsWith("Seed_")) Menu_Seeding.DropDownItems.Add(NewItem);
                if (Algorithm.Name.StartsWith("RuleSelection_")) Menu_RuleSelection.DropDownItems.Add(NewItem);
                if (Algorithm.Name.StartsWith("Rule_")) Menu_Rules.DropDownItems.Add(NewItem);
                if (Algorithm.Name.StartsWith("Neighbors_")) Menu_Neighbor.DropDownItems.Add(NewItem);
                if (Algorithm.Name.StartsWith("Overflow_")) Menu_Overflow.DropDownItems.Add(NewItem);
            }

            //Sort the algorithms
            //Menu_Seeding.DropDownItems.OfType<ToolStripMenuItem>().OrderBy(x => x.Text).ToArray();

            //Check the default settings
            Menu_Seeding.DropDownItems.Cast<ToolStripMenuItem>().ToList().Find(x => x.Text == "Seed_Random01").Checked = true;
            Menu_RuleSelection.DropDownItems.Cast<ToolStripMenuItem>().ToList().Find(x => x.Text == "RuleSelection_First").Checked = true;
            Menu_Rules.DropDownItems.Cast<ToolStripMenuItem>().ToList().Find(x => x.Text == "Rule_ConwaysGameOfLife").Checked = true;
            Menu_Neighbor.DropDownItems.Cast<ToolStripMenuItem>().ToList().Find(x => x.Text == "Neighbors_Moore").Checked = true;
            Menu_Overflow.DropDownItems.Cast<ToolStripMenuItem>().ToList().Find(x => x.Text == "Overflow_Assume0").Checked = true;
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                if (Simulation_Resume.Enabled)
                {
                    Simulation_Resume.PerformClick();
                }
                else if (Simulation_Pause.Enabled)
                {
                    Simulation_Pause.PerformClick();
                }
            }

            if (e.KeyData == Keys.S)
            {
                if (Simulation_Start.Enabled)
                {
                    Simulation_Start.PerformClick();
                }
                else if (Simulation_Stop.Enabled)
                {
                    Simulation_Stop.PerformClick();
                }
            }

            if (e.KeyData == Keys.R)
            {
                Simulation_Restart.PerformClick();
            }
        }



        /// <summary>
        /// Iterates the current automaton by a single generation.
        /// </summary>
        private void Iterate()
        {
            this.CurrentAutomaton.Iterate();

            if (this.RestartOnFlatline)
            {
                if (this.PreviousGenerationData == null)
                {
                    this.PreviousGenerationData = this.CurrentAutomaton.Grid.Select(x => x.State).ToArray();
                    return;
                }

                int[] CurrentData = this.CurrentAutomaton.Grid.Select(x => x.State).ToArray();
                if (this.PreviousGenerationData.SequenceEqual(CurrentData)) this.GenerationsSinceChange++;
                else this.GenerationsSinceChange = 0;
                this.PreviousGenerationData = CurrentData;

                if (GenerationsSinceChange >= 4) Simulation_Restart.PerformClick();
            }
        }

        private void OFD_FileOk(object sender, CancelEventArgs e)
        {
            if (OFD.FileName.EndsWith(".automaton"))
            {
                this.CurrentAutomaton = Serialization.DeserializeObject<Automaton>(OFD.FileName);
                this.Text = "Cellular Automata - " + OFD.FileName;
            }
            else if (OFD.FileName.EndsWith(".bautomaton"))
            {
                BufferedViewer BV = new BufferedViewer(Serialization.DeserializeObject<BufferedAutomaton>(OFD.FileName));
                BV.Text = "Buffered Automaton Viewer - " + OFD.FileName;
                BV.Show();
            }
        }

        private void Simulation_Start_Click(object sender, EventArgs e)
        {
            if (this.CurrentAutomaton == null) InitializeNewAutomaton();

            //Modify the menu selection
            Simulation_Start.Enabled = false;
            Simulation_Resume.Enabled = false;
            Simulation_Pause.Enabled = true;
            Simulation_Stop.Enabled = true;
            Simulation_Size.Enabled = false;
            Simulation_Seed.Enabled = false;
            Menu_File.Enabled = false;
            Simulation_RandomizeAlgorithms.Enabled = false;

            //Start the simulation (note that the update timer is ALWAYS on)
            this.Grid.Origin = new double[] { this.CurrentAutomaton.Size / 2, this.CurrentAutomaton.Size / 2};
            this.UpdateFraction = 0;
            this.CurrentGeneration = 0;
            this.GenerationsSinceChange = 0;
            this.Grid.Title.Text = "Generation 0";
            RandomizeThingsOnStart();
            if (!this.Seeded)
            {
                this.CurrentAutomaton.Seed();
                this.Seeded = true;
            }
            if (this.RestartOnFlatline) this.PreviousGenerationData = this.CurrentAutomaton.Grid.Select(x => x.State).ToArray();
            this.Running = true;
        }

        private void RandomizeThingsOnStart()
        {
            if (this.RandomizeAlgorithmsOnStart)
            {
                RandomizeAllAlgorithms();
                return;
            }
            else
            {
                if (this.RandomizeNeighborOS) RandomizeNeighbor();
                if (this.RandomizeOverflowOS) RandomizeOverflow();
                if (this.RandomizeRSOS) RandomizeRS();
                if (this.RandomizeRulesOS) RandomizeRules();
                if (this.RandomizeSeedOS) RandomizeSeeding();
            }

            if (this.RandomizeGNSROS) RandomizeGNSR();

            if (this.RandomizeGR1DCA)
            {
                int RN = Random.Integer(0, 255 - 1);
                Algorithms.Option_Global1DElementaryRule = Algorithms.RuleIntegerTo1DElementaryRule(RN);
                Simulation_GR1DCA_Value.Text = RN.ToString();
            }
        }

        private void Simulation_Resume_Click(object sender, EventArgs e)
        {
            //Modify the menu selection
            Simulation_Start.Enabled = false;
            Simulation_Resume.Enabled = false;
            Simulation_Pause.Enabled = true;
            Simulation_Stop.Enabled = true;
            Simulation_Size.Enabled = false;
            Simulation_Seed.Enabled = false;
            Menu_File.Enabled = false;

            //Resume the simulation
            this.Running = true;
        }

        private void Simulation_Pause_Click(object sender, EventArgs e)
        {
            //Modify the menu selection
            Simulation_Start.Enabled = false;
            Simulation_Resume.Enabled = true;
            Simulation_Pause.Enabled = false;
            Simulation_Stop.Enabled = true;
            Simulation_Size.Enabled = false;
            Simulation_Seed.Enabled = false;
            Menu_File.Enabled = false;

            //Pause the simulation
            this.Running = false;
        }

        private void Simulation_Stop_Click(object sender, EventArgs e)
        {
            //Modify the menu selection
            Simulation_Start.Enabled = true;
            Simulation_Resume.Enabled = false;
            Simulation_Pause.Enabled = false;
            Simulation_Stop.Enabled = false;
            Simulation_Size.Enabled = true;
            Simulation_Seed.Enabled = true;
            Menu_File.Enabled = true;
            Simulation_RandomizeAlgorithms.Enabled = true;

            //Stop the simulation
            this.Running = false;
            this.Seeded = false;
        }

        private void Simulation_UpdateInterval_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.UpdateInterval = Convert.ToInt32(e.ClickedItem.Text);
            this.UpdateFraction = 0;

            //Change checkmarks
            foreach (var item in Simulation_UpdateInterval.DropDownItems)
            {
                ToolStripMenuItem I = item as ToolStripMenuItem;
                if (I.Text == e.ClickedItem.Text) I.Checked = true;
                else I.Checked = false;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void Simulation_Seed_Click(object sender, EventArgs e)
        {
            if (this.CurrentAutomaton != null)
            {
                this.UpdateFraction = 0;
                this.CurrentGeneration = 0;
                this.Grid.Title.Text = "Generation 0";
                this.CurrentAutomaton.Seed();
                this.Seeded = true;
            }
        }

        private void Simulation_Size_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.NewSize = Convert.ToInt32(e.ClickedItem.Text);

            if (this.CurrentAutomaton != null)
            {
                this.CurrentAutomaton.Size = Convert.ToInt32(e.ClickedItem.Text);
                this.Grid.Origin = new double[] { this.CurrentAutomaton.Size / 2, this.CurrentAutomaton.Size / 2 };
                this.CurrentAutomaton.Seed();
            }

            //Change checkmarks
            foreach (var item in Simulation_Size.DropDownItems)
            {
                ToolStripMenuItem I = item as ToolStripMenuItem;
                if (I.Text == e.ClickedItem.Text) I.Checked = true;
                else I.Checked = false;
            }
        }

        private void Menu_Seeding_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Func<int, Cell[]> Algorithm = (Func<int, Cell[]>)typeof(Algorithms).GetField(e.ClickedItem.Text).GetValue(null);
            if (this.CurrentAutomaton != null) this.CurrentAutomaton.SeedAlgorithm = Algorithm;
            this.NewSeedAlgorithm = Algorithm;

            //Change checkmarks
            foreach (var item in Menu_Seeding.DropDownItems)
            {
                ToolStripMenuItem I = item as ToolStripMenuItem;
                if (I.Text == e.ClickedItem.Text) I.Checked = true;
                else I.Checked = false;
            }
        }

        private void Menu_Rules_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //Change checkmarks
            (e.ClickedItem as ToolStripMenuItem).Checked = !(e.ClickedItem as ToolStripMenuItem).Checked;
            bool IsChecked = (e.ClickedItem as ToolStripMenuItem).Checked;

            //Get the rule that was clicked
            Func<Cell, List<Cell>, Cell> Algorithm = (Func<Cell, List<Cell>, Cell>)typeof(Algorithms).GetField(e.ClickedItem.Text).GetValue(null);

            //Get if our new rule list contains the algorithm we clicked
            bool ContainsAlgorithm = this.NewRules.Contains(Algorithm);
            
            //If our new rule list doesn't contain the rule and the rule is checked, add it
            if (!ContainsAlgorithm && IsChecked)
            {
                if (this.CurrentAutomaton != null) this.CurrentAutomaton.Rules.Add(Algorithm);
                this.NewRules.Add(Algorithm);
            }
            else if (ContainsAlgorithm && !IsChecked) //Otherwise, if it DOES contain the rule and the rule ISN'T checked
            {
                if (this.CurrentAutomaton != null) this.CurrentAutomaton.Rules.Remove(Algorithm);
                this.NewRules.Remove(Algorithm);
            }
        }

        private void Menu_RuleSelection_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Func<List<Cell>, Cell> Algorithm = (Func<List<Cell>, Cell>)typeof(Algorithms).GetField(e.ClickedItem.Text).GetValue(null);
            if (this.CurrentAutomaton != null) this.CurrentAutomaton.RuleSelectionAlgorithm = Algorithm;
            this.NewRuleSelectionAlgorithm = Algorithm;

            //Change checkmarks
            foreach (var item in Menu_RuleSelection.DropDownItems)
            {
                ToolStripMenuItem I = item as ToolStripMenuItem;
                if (I.Text == e.ClickedItem.Text) I.Checked = true;
                else I.Checked = false;
            }
        }

        private void Menu_Neighbor_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Func<int[], Automaton, List<Cell>> Algorithm = (Func<int[], Automaton, List<Cell>>)typeof(Algorithms).GetField(e.ClickedItem.Text).GetValue(null);
            if (this.CurrentAutomaton != null) this.CurrentAutomaton.NeighborAlgorithm = Algorithm;
            this.NewNeighborAlgorithm = Algorithm;

            //Change checkmarks
            foreach (var item in Menu_Neighbor.DropDownItems)
            {
                ToolStripMenuItem I = item as ToolStripMenuItem;
                if (I.Text == e.ClickedItem.Text) I.Checked = true;
                else I.Checked = false;
            }
        }

        private void File_New_Click(object sender, EventArgs e)
        {
            var Result = MessageBox.Show("Are you sure you want to create a new automaton? Any unsaved changes to the current automaton will be discarded...", "New Automaton...", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                this.Text = "Cellular Automata - New Automaton";
                InitializeNewAutomaton();
            }
        }

        /// <summary>
        /// Sets the current automaton to a new automaton.
        /// </summary>
        public void InitializeNewAutomaton()
        {
            this.CurrentAutomaton = new Automaton(this.NewSize)
            {
                Rules = this.NewRules,
                NeighborAlgorithm = this.NewNeighborAlgorithm,
                RuleSelectionAlgorithm = this.NewRuleSelectionAlgorithm,
                SeedAlgorithm = this.NewSeedAlgorithm,
                OverflowAlgorithm = this.NewOverflowAlgorithm,
            };
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            //Stop the timer
            this.UpdateTimer.Stop();

            //If we have a simulation
            if (this.CurrentAutomaton != null)
            {
                //If we are running and need to iterate the simulation:
                if (this.Running)
                {
                    this.Running = false;
                    if (this.UpdateFraction >= this.UpdateInterval)
                    {
                        this.UpdateFraction = 0;
                        this.CurrentGeneration++;
                        Iterate();
                    }
                    else
                    {
                        this.UpdateFraction++;
                    }
                    this.Running = true;

                    //Update the automaton info if we are looking at it
                    if (Tabs.SelectedTab == Tab_Info)
                    {
                        AutomatonPG.SelectedObject = this.CurrentAutomaton;
                        AutomatonPG.Refresh();
                    }

                    if (Tabs.SelectedTab == Tab_Statistics)
                    {
                        UpdateStatistics();
                    }
                }

                //Draw the grid, but only if we are looking at it (to save memory and CPU)
                if (Tabs.SelectedTab == Tab_Grid)
                {
                    AutomatonPG.SelectedObject = null;
                    this.Grid.PlotAutomaton(this.CurrentAutomaton);
                    this.Grid.Title.Text = "Generation " + this.CurrentGeneration;
                }
            }
            

            //Start the timer
            this.UpdateTimer.Start();
        }

        private void UpdateStatistics()
        {
            if (this.CurrentAutomaton == null) return;
            string NL = Environment.NewLine;
            Automaton A = this.CurrentAutomaton;
            System.Diagnostics.Process ME = System.Diagnostics.Process.GetCurrentProcess();
            StatBox.Text = "A U T O M A T O N   S T A T I S T I C S" + NL;
            StatBox.Text += "---------------------------------------" + NL;
            StatBox.Text += "ALGORITHM INFORMATION" + NL;
            StatBox.Text += "Rules          : {" + String.Join(", ", Menu_Rules.DropDownItems.Cast<ToolStripMenuItem>().Where(x => x.Checked).Select(x => x.Text).ToArray()).Replace("Rule_", "") + "}" + NL;
            StatBox.Text += "Rule Selection : " + Menu_RuleSelection.DropDownItems.Cast<ToolStripMenuItem>().Where(x => x.Checked).Select(x => x.Text).ToArray()[0].Replace("RuleSelection_", "") + NL;
            StatBox.Text += "Neighbor       : " + Menu_Neighbor.DropDownItems.Cast<ToolStripMenuItem>().Where(x => x.Checked).Select(x => x.Text).ToArray()[0].Replace("Neighbors_", "") + NL;
            StatBox.Text += "Seed           : " + Menu_Seeding.DropDownItems.Cast<ToolStripMenuItem>().Where(x => x.Checked).Select(x => x.Text).ToArray()[0].Replace("Seed_", "") + NL;
            StatBox.Text += "Overflow       : " + Menu_Overflow.DropDownItems.Cast<ToolStripMenuItem>().Where(x => x.Checked).Select(x => x.Text).ToArray()[0].Replace("Overflow_", "") + NL;
            StatBox.Text += "Search Radius  : " + Algorithms.Option_GlobalSearchRadius + NL;
            StatBox.Text += NL + "ELEMENTARY ALGORITHM INFORMATION (if used)" + NL;
            StatBox.Text += "Global 1D Rule Number : " + Simulation_GR1DCA_Value.Text + NL;
            StatBox.Text += "Global 1D Rule        : {" + String.Join(", ", Algorithms.Option_Global1DElementaryRule.Select(x => x.ToString())) + "}" + NL;
            StatBox.Text += NL + "GRID STATISTICS" + NL;
            StatBox.Text += "Automaton Grid Size : " + A.Size + " x " + A.Size + NL;
            StatBox.Text += "Visible Grid Size   : " + Grid.GridSize.ToString("n1") + " x " + Grid.GridSize.ToString("n1") + NL;
            StatBox.Text += "Total Grid Cells    : " + (A.Size * A.Size) + NL;
            StatBox.Text += NL + "CELL STATISTICS" + NL;
            StatBox.Text += "Generation    : " + this.CurrentGeneration + NL;
            StatBox.Text += "Average State : " + A.Grid.Average(x => x.State).ToString("n4") + NL;
            StatBox.Text += "Minimum State : " + A.Grid.Min(x => x.State) + NL;
            StatBox.Text += "Maximum State : " + A.Grid.Max(x => x.State) + NL;
            StatBox.Text += NL + "COMPUTATION STATISTICS" + NL;
            StatBox.Text += "Memory Usage       : " + (((double)ME.PrivateMemorySize64 / 1024) / 1024).ToString("n2") + " MB" + NL;
            StatBox.Text += "Peak Memory Usage  : " + (((double)ME.PeakWorkingSet64 / 1024) / 1024).ToString("n2") + " MB" + NL;
            StatBox.Text += "Total Threads      : " + ME.Threads.Count + NL;
            StatBox.Text += "Priority           : " + ME.PriorityClass + NL;
        }

        private void Grid_HD_Click(object sender, EventArgs e)
        {
            Grid_HD.Checked = !Grid_HD.Checked;
            this.Grid.HighDefinition = Grid_HD.Checked;
        }

        private void Grid_PM_Click(object sender, EventArgs e)
        {
            Grid_PM.Checked = !Grid_PM.Checked;
            if (Grid_PM.Checked) this.Grid.Series.PointMode_ON();
            else this.Grid.Series.PointMode_OFF();
        }

        private void Menu_Overflow_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Func<int[], Automaton, Cell> Algorithm = (Func<int[], Automaton, Cell>)typeof(Algorithms).GetField(e.ClickedItem.Text).GetValue(null);
            if (this.CurrentAutomaton != null) this.CurrentAutomaton.OverflowAlgorithm = Algorithm;
            this.NewOverflowAlgorithm = Algorithm;

            //Change checkmarks
            foreach (var item in Menu_Overflow.DropDownItems)
            {
                ToolStripMenuItem I = item as ToolStripMenuItem;
                if (I.Text == e.ClickedItem.Text) I.Checked = true;
                else I.Checked = false;
            }
        }

        private void File_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Simulation_Buffer_Click(object sender, EventArgs e)
        {
            if (this.CurrentAutomaton != null)
            {
                if (!Seeded) this.CurrentAutomaton.Seed();
                Automaton A = this.CurrentAutomaton;
                this.CurrentAutomaton = null;
                (new BufferSimulation(A)).ShowDialog();
            }
        }

        private void Options_RandAlgs_Click(object sender, EventArgs e)
        {
            Options_RandSeed.Checked = !Options_RandSeed.Checked;
            this.RandomizeSeedOS = Options_RandSeed.Checked;
        }

        private void RandomizeRules()
        {
            for (int i = 0; i < Menu_Rules.DropDownItems.Count; i++)
            {
                if (Random.Boolean()) (Menu_Rules.DropDownItems[i] as ToolStripMenuItem).PerformClick();
            }
        }

        private void RandomizeAllAlgorithms()
        {
            RandomizeRules();
            RandomizeNeighbor();
            RandomizeOverflow();
            RandomizeRS();
            RandomizeSeeding();
        }

        private void RandomizeSeeding()
        {
            (Menu_Seeding.DropDownItems[Random.Integer(0, Menu_Seeding.DropDownItems.Count - 1)] as ToolStripMenuItem).PerformClick();
        }

        private void RandomizeGNSR()
        {
            (Simulation_GNSR.DropDownItems[Random.Integer(0, Simulation_GNSR.DropDownItems.Count - 1)] as ToolStripMenuItem).PerformClick();
        }

        private void RandomizeRS()
        {
            (Menu_RuleSelection.DropDownItems[Random.Integer(0, Menu_RuleSelection.DropDownItems.Count - 1)] as ToolStripMenuItem).PerformClick();
        }

        private void RandomizeNeighbor()
        {
            (Menu_Neighbor.DropDownItems[Random.Integer(0, Menu_Neighbor.DropDownItems.Count - 1)] as ToolStripMenuItem).PerformClick();
        }

        private void RandomizeOverflow()
        {
            (Menu_Overflow.DropDownItems[Random.Integer(0, Menu_Overflow.DropDownItems.Count - 1)] as ToolStripMenuItem).PerformClick();
        }

        private void Simulation_Restart_Click(object sender, EventArgs e)
        {
            if (Simulation_Start.Enabled)
            {
                Simulation_Start.PerformClick();
            }
            else if (Simulation_Stop.Enabled)
            {
                Simulation_Stop.PerformClick();
                Simulation_Start.PerformClick();
            }
        }

        private void Options_RestartOnFlatline_Click(object sender, EventArgs e)
        {
            Options_RestartOnFlatline.Checked = !Options_RestartOnFlatline.Checked;
            this.RestartOnFlatline = Options_RestartOnFlatline.Checked;
        }

        private void Simulation_GNSR_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Algorithms.Option_GlobalSearchRadius = Convert.ToInt32(e.ClickedItem.Text);

            //Change checkmarks
            foreach (var item in Simulation_GNSR.DropDownItems)
            {
                ToolStripMenuItem I = item as ToolStripMenuItem;
                if (I.Text == e.ClickedItem.Text) I.Checked = true;
                else I.Checked = false;
            }
        }

        private void Options_RandAll_Click(object sender, EventArgs e)
        {
            Options_RandAll.Checked = !Options_RandAll.Checked;

            if (Options_RandAll.Checked)
            {
                RandomizeAlgorithmsOnStart = true;
                RandomizeNeighborOS = true;
                RandomizeOverflowOS = true;
                RandomizeRSOS = true;
                RandomizeRulesOS = true;
                RandomizeSeedOS = true;
                Options_RandSeed.Checked = true;
                Options_RandNeighbor.Checked = true;
                Options_RandOverflow.Checked = true;
                Options_RandRS.Checked = true;
                Options_RandRules.Checked = true;
                Options_RandSeed.Enabled = false;
                Options_RandNeighbor.Enabled = false;
                Options_RandOverflow.Enabled = false;
                Options_RandRS.Enabled = false;
                Options_RandRules.Enabled = false;
            }
            else
            {
                RandomizeAlgorithmsOnStart = false;
                RandomizeNeighborOS = false;
                RandomizeOverflowOS = false;
                RandomizeRSOS = false;
                RandomizeRulesOS = false;
                RandomizeSeedOS = false;
                Options_RandSeed.Checked = false;
                Options_RandNeighbor.Checked = false;
                Options_RandOverflow.Checked = false;
                Options_RandRS.Checked = false;
                Options_RandRules.Checked = false;
                Options_RandSeed.Enabled = true;
                Options_RandNeighbor.Enabled = true;
                Options_RandOverflow.Enabled = true;
                Options_RandRS.Enabled = true;
                Options_RandRules.Enabled = true;
            }
            
        }

        private void Simulation_RandomizeAlgorithms_Click(object sender, EventArgs e)
        {
            RandomizeAllAlgorithms();
        }

        private void Options_RandRules_Click(object sender, EventArgs e)
        {
            Options_RandRules.Checked = !Options_RandRules.Checked;
            this.RandomizeRulesOS = Options_RandRules.Checked;
        }

        private void Options_RandRS_Click(object sender, EventArgs e)
        {
            Options_RandRS.Checked = !Options_RandRS.Checked;
            this.RandomizeRSOS = Options_RandRS.Checked;
        }

        private void Options_RandNeighbor_Click(object sender, EventArgs e)
        {
            Options_RandNeighbor.Checked = !Options_RandNeighbor.Checked;
            this.RandomizeNeighborOS = Options_RandNeighbor.Checked;
        }

        private void Options_RandOverflow_Click(object sender, EventArgs e)
        {
            Options_RandOverflow.Checked = !Options_RandOverflow.Checked;
            this.RandomizeOverflowOS = Options_RandOverflow.Checked;
        }

        private void Options_RandRadius_Click(object sender, EventArgs e)
        {
            Options_RandRadius.Checked = !Options_RandRadius.Checked;
            this.RandomizeGNSROS = Options_RandRadius.Checked;
        }

        private void brushSizeToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.BrushSize = Convert.ToInt32(e.ClickedItem.Text);

            //Change checkmarks
            foreach (var item in Grid_BrushSize.DropDownItems)
            {
                ToolStripMenuItem I = item as ToolStripMenuItem;
                if (I.Text == e.ClickedItem.Text) I.Checked = true;
                else I.Checked = false;
            }
        }

        private void Simulation_GR1DCA_Value_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    int INT = Convert.ToInt32(Simulation_GR1DCA_Value.Text);
                    if (INT > 255 || INT < 0) return;
                    Algorithms.Option_Global1DElementaryRule = Algorithms.RuleIntegerTo1DElementaryRule(INT);
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to convert rule code to binary representation...", "Oops!", MessageBoxButtons.OK);
                }
            }
        }

        private void Tabs_TabIndexChanged(object sender, EventArgs e)
        {
            if (Tabs.SelectedTab == Tab_Grid)
            {
                this.GridPanel.Focus();
                this.Grid.Focus();
            }
        }

        private void Simulation_GR1DCA_Value_Click(object sender, EventArgs e)
        {

        }

        private void Options_RandE1DRules_Click(object sender, EventArgs e)
        {
            Options_RandE1DRules.Checked = !Options_RandE1DRules.Checked;
            this.RandomizeGR1DCA = Options_RandE1DRules.Checked;
        }

        private void File_Open_Click(object sender, EventArgs e)
        {
            var Result = MessageBox.Show("Are you sure you want to open a previously saved automaton? Any unsaved changes to the current automaton will be discarded...", "Open Automaton...", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                OFD.ShowDialog();
            }
        }

        private void File_Save_Click(object sender, EventArgs e)
        {
            SFD.ShowDialog();
        }

        private void SFD_FileOk(object sender, CancelEventArgs e)
        {
            Serialization.SerializeObject<Automaton>(SFD.FileName, this.CurrentAutomaton);
            MessageBox.Show("Current automaton simulation successfully written to file!", "Save Successful...", MessageBoxButtons.OK);
            this.Text = "Cellular Automata - " + SFD.FileName;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.ApplicationExitCall)
            {
                var Result = MessageBox.Show("Are you sure you want to close the program? Any unsaved changes to the current automaton will be discarded...", "Close Program...", MessageBoxButtons.YesNo);
                if (Result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
