using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CellularAutomaton
{
    public partial class BufferedViewer : Form
    {
        public BufferedAutomaton B;

        public Grid Grid = new Grid();

        public int S = 0;

        public int CurrentGeneration = 0;

        public bool Loop = false;

        public bool Running = false;

        public BufferedViewer(BufferedAutomaton B)
        {
            InitializeComponent();
            this.B = B;
        }

        private void BufferedViewer_Load(object sender, EventArgs e)
        {
            //Attach the grid to the panel
            this.GridPanel.Controls.Add(this.Grid);
            this.Grid.Focus();
            this.Grid.Series.PointMode_OFF();
            this.S = B.GridEvolution[0].Length;
            this.TB.Maximum = B.GridEvolution.Length - 1;
            this.Grid.Origin = new double[] { S / 2, S / 2 };
            this.Grid.GridSize = S;

            //Add the button event handlers for the grid
            this.Grid.KeyDown += Grid_KeyDown;
            this.TB.KeyDown += Grid_KeyDown;

            this.Grid.PlotBuffered(this.B, this.CurrentGeneration);

            UpdateTimer.Start();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                if (Playback_Start.Enabled)
                {
                    Playback_Start.PerformClick();
                }
                else if (Playback_Stop.Enabled)
                {
                    Playback_Stop.PerformClick();
                }
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateTimer.Stop();
            if (Running)
            {
                if (this.CurrentGeneration >= TB.Maximum)
                {
                    if (Loop)
                    {
                        TB.Value = 0;
                    }
                    else
                    {
                        Playback_Start.Enabled = true;
                        Playback_Stop.Enabled = false;
                        this.Running = false;
                    }
                }
                else
                {
                    TB.Value++;
                }
            }
            this.Grid.PlotBuffered(this.B, this.CurrentGeneration);
            UpdateTimer.Start();
        }

        private void Playback_Start_Click(object sender, EventArgs e)
        {
            Playback_Start.Enabled = false;
            Playback_Stop.Enabled = true;
            this.Grid.Title.Text = "Generation 0";
            this.Running = true;
        }

        private void Playback_Loop_Click(object sender, EventArgs e)
        {
            Playback_Loop.Checked = !Playback_Loop.Checked;
            Loop = !Loop;
        }

        private void Playback_Stop_Click(object sender, EventArgs e)
        {
            Playback_Start.Enabled = true;
            Playback_Stop.Enabled = false;
            this.Running = false;
        }

        private void TB_ValueChanged(object sender, EventArgs e)
        {
            this.CurrentGeneration = TB.Value;
            //TB.Value = this.CurrentGeneration;
            this.Grid.Title.Text = "Generation " + this.CurrentGeneration;
        }

        private void TB_Scroll(object sender, EventArgs e)
        {
            
        }

        private void Grid_HD_Click(object sender, EventArgs e)
        {
            this.Grid.HighDefinition = !this.Grid.HighDefinition;
            Grid_HD.Checked = !Grid_HD.Checked;
        }

        private void Grid_PM_Click(object sender, EventArgs e)
        {
            Grid_PM.Checked = !Grid_PM.Checked;
            if (Grid_PM.Checked)
            {
                this.Grid.Series.PointMode_ON();
            }
            else
            {
                this.Grid.Series.PointMode_OFF();
            }
        }
    }
}
