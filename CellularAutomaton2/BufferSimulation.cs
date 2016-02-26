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
    public partial class BufferSimulation : Form
    {
        public Automaton A;
        public BufferedAutomaton B = new BufferedAutomaton();
        public int CurrentGeneration = 0;

        public BufferSimulation(Automaton A)
        {
            InitializeComponent();
            this.A = A;
        }

        private void Buffer_Click(object sender, EventArgs e)
        {
            GenCount.Enabled = false;
            Buffer.Enabled = false;
            this.Text = "Buffering...";
            this.PB.Maximum = (int)GenCount.Value;

            //Initialize the grid
            B.GridEvolution = new Cell[(int)GenCount.Value][][];

            //Set the initial generation
            B.GridEvolution[0] = new Cell[A.Size][];
            for (int i = 0; i < A.Size; i++)
            {
                B.GridEvolution[0][i] = new Cell[A.Size];
                for (int j = 0; j < A.Size; j++)
                {
                    B.GridEvolution[0][i][j] = A[i, j];
                }
            }

            UpdateTimer.Start();
        }

        private void BufferSimulation_Load(object sender, EventArgs e)
        {

        }

        public void Iterate()
        {
            //Iterate the automaton
            this.A.Iterate();

            //Save the automaton grid to the buffered automaton
            B.GridEvolution[CurrentGeneration] = new Cell[A.Size][];
            for (int i = 0; i < A.Size; i++)
            {
                B.GridEvolution[CurrentGeneration][i] = new Cell[A.Size];
                for (int j = 0; j < A.Size; j++)
                {
                    B.GridEvolution[CurrentGeneration][i][j] = A[i, j];
                }
            }
        }

        public void Finish()
        {
            (new BufferedViewer(this.B)).Show();
            this.Close();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            //Stop the timer
            UpdateTimer.Stop();

            if (CurrentGeneration >= GenCount.Value - 1)
            {
                this.Text = "Buffer Complete...";
                Status.Text = "Buffer Complete...";
                Finish();
            }
            else
            {
                CurrentGeneration++;
                Iterate();
                PB.Value = CurrentGeneration;
                Status.Text = "Calculating generation " + CurrentGeneration + " of " + GenCount.Value + "...";
                this.Refresh();
                UpdateTimer.Start();
            }
        }
    }
}
