using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomaton
{
    /// <summary>
    /// Represents a single cellular automaton with all of the neccessary components for self-propigation.
    /// </summary>
    [Serializable]
    public class Automaton
    {
        /// <summary>
        /// Creates a new cellular automaton with an initial grid size and blank initial configuration.
        /// </summary>
        /// <param name="Size">The overall size of the grid (N), creating an N x N x N grid</param>
        public Automaton(int Size)
        {
            this.Size = Size;
            this.Grid = Algorithms.Seed_All0(this.Size);
        }

        /// <summary>
        /// The grid of all contained cells in this cellular automaton.
        /// </summary>
        /// <remarks>
        /// Note that this is a compactified version of the origional 2D array.
        /// </remarks>
        [Description("The grid of all contained cells in this cellular automaton")]
        public Cell[] Grid
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the cell contained at a particular location on this grid.
        /// </summary>
        /// <param name="X">The "X" coordinate of the cell to obtain</param>
        /// <param name="Y">The "Y" coordinate of the cell to obtain</param>
        public Cell this[int X, int Y]
        {
            get
            {
                if (this.IsWithinGrid(X, Y)) return this.Grid[(Y * this.Size) + X];
                return this.OverflowAlgorithm(new int[] { X, Y }, this);
            }
            set
            {
                if (this.IsWithinGrid(X, Y)) this.Grid[(Y * this.Size) + X] = value;
            }
        }

        /// <summary>
        /// Gets the coordinates of a cell contained in this grid.
        /// </summary>
        public int[] this[Cell Cell]
        {
            get
            {
                return this.GridIndexTo2D(this.Grid.ToList().FindIndex(x => x == Cell));
            }
        }

        /// <summary>
        /// The list of rules for transforming cells based on the conditions of neighboring cells.
        /// </summary>
        /// <remarks>
        /// Inputs are the cell, and neighboring cells.
        /// Output is a new cell.
        /// </remarks>
        [Browsable(false)]
        public List<Func<Cell, List<Cell>, Cell>> Rules
        {
            get;
            set;
        }

        /// <summary>
        /// The algorithm used for finding "neighbors" of this cell.
        /// </summary>
        /// <remarks>
        /// Input is the coordinates of the cell and the grid of cells
        /// Output is the collection of neighbors of the cell.
        /// </remarks>
        [Browsable(false)]
        public Func<int[], Automaton, List<Cell>> NeighborAlgorithm
        {
            get;
            set;
        }

        /// <summary>
        /// The algorithm used for determining which rule result(s) is/are ultimately selected.
        /// </summary>
        [Browsable(false)]
        public Func<List<Cell>, Cell> RuleSelectionAlgorithm
        {
            get;
            set;
        }

        /// <summary>
        /// The algorithm used for seeding this automaton to its initial configuration.
        /// </summary>
        /// <remarks>
        /// Input is the size of the grid
        /// Output is the new grid
        /// </remarks>
        [Browsable(false)]
        public Func<int, Cell[]> SeedAlgorithm
        {
            get;
            set;
        }

        /// <summary>
        /// The algorithm used for determining what psudocell should be returned when testing coordinates ourside of the grid.
        /// </summary>
        /// <remarks>
        /// Inputs are the coordinate that overflowed and the automaton as a whole
        /// Output is a pseudocell
        /// </remarks>
        [Browsable(false)]
        public Func<int[], Automaton, Cell> OverflowAlgorithm
        {
            get;
            set;
        }

        /// <summary>
        /// The overall size of the grid (N), creating an N x N grid.
        /// </summary>
        [ReadOnly(true), Description("The overall size of one dimension (N) of this grid (as an N x N grid)")]
        public int Size
        {
            get;
            set;
        }

        ///// <summary>
        ///// A summary of all cell data.
        ///// </summary>
        //[Description("A summary of all cell position and state data.")]
        //public string[] CellData
        //{
        //    get
        //    {
        //        return this.Grid.Select(x => "{" + String.Join(", ", this[x]) + "} => " + x.State.ToString()).ToArray();
        //    }
        //}

        /// <summary>
        /// Applies the list of transformation rules to a single cell, returning a new cell.
        /// </summary>
        /// <param name="Input">The cell to transform</param>
        public Cell ApplyTo(Cell Input)
        {
            //Get the neighbors of this cell.
            List<Cell> Neighbors = this.NeighborAlgorithm(this[Input], this);

            //A list to store the results of rules.
            List<Cell> Results = new List<Cell>(this.Rules.Count);

            //////For each rule:
            //Parallel.For(0, this.Rules.Count, i =>
            //{
            //    //Obtain the result of applying the rule
            //    Cell Result = this.Rules[i](Input, Neighbors);

            //    //Store the result in the list of results
            //    lock (Results)
            //    {
            //        Results.Add(Result);
            //    }
            //});

            if (this.Rules == null || this.Rules.Count == 0) return new Cell(Input.State);

            //For each rule:
            for (int i = 0; i < this.Rules.Count; i++)
            {
                //Obtain the result of applying the rule
                Cell Result = this.Rules[i](Input, Neighbors);

                //Store the result in the list of results
                Results.Add(Result);
            }

            //Trim the results
            Results.TrimExcess();

            //Return the actual result
            return this.RuleSelectionAlgorithm(Results);
        }

        /// <summary>
        /// Iterates this cellular automaton by a single generation.
        /// </summary>
        public void Iterate()
        {
            Cell[] NewGrid = new Cell[this.Size * this.Size];

            try
            {
                Parallel.For(0, this.Grid.Length, i =>
                {
                    Cell Result = this.ApplyTo(this.Grid[i]);
                    lock (NewGrid)
                    {
                        NewGrid[i] = Result;
                    }
                });
            }
            catch (Exception)
            {
                return;
            }

            //for (int i = 0; i < this.Grid.Length; i++)
            //{
            //    Cell Result = this.ApplyTo(this.Grid[i]);
            //    NewGrid[i] = Result;
            //}

            this.Grid = NewGrid;
        }

        /// <summary>
        /// Seeds this cellular automaton using the assigned seed algorithm. If no algorithm is found, a blank configuration is used.
        /// </summary>
        public void Seed()
        {
            if (this.SeedAlgorithm == null) this.Grid = Algorithms.Seed_All0(this.Size);
            else this.Grid = this.SeedAlgorithm(this.Size);
        }

        /// <summary>
        /// Converts an index in the flat grid array to its 2D varient.
        /// </summary>
        /// <param name="Index">The index to convert</param>
        public int[] GridIndexTo2D(int Index)
        {
            int y = Index / this.Size;
            int x = Index % this.Size;
            return new int[] { x, y };
        }

        /// <summary>
        /// Determines whether or not a set of 2D coordinates are within the bounds of the grid
        /// </summary>
        /// <param name="X">The "X" coordinate</param>
        /// <param name="Y">The "Y" coordinate</param>
        public bool IsWithinGrid(int X, int Y)
        {
            if (X < 0 || X >= this.Size) return false;
            if (Y < 0 || Y >= this.Size) return false;
            return true;
        }
    }
}
