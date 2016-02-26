using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellularAutomaton
{
    /// <summary>
    /// Represents an automaton who's states have been previously calculated.
    /// </summary>
    [Serializable]
    public class BufferedAutomaton
    {
        /// <summary>
        /// Gets/sets the 3D cell array corresponding to the evolution of the base grid's cells over time.
        /// </summary>
        public Cell[][][] GridEvolution
        {
            get;
            set;
        }

        /// <summary>
        /// Gets/sets the 2D grid of this buffered automaton at the specified generation step.
        /// </summary>
        /// <param name="Generation">The generation step to access the grid</param>
        public Cell[][] this[int Generation]
        {
            get
            {
                return this.GridEvolution[Generation];
            }
            set
            {
                this.GridEvolution[Generation] = value;
            }
        }
    }
}