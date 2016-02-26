using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomaton
{
    /// <summary>
    /// A static collection of commonly used algorithms.
    /// </summary>
    public static class Algorithms
    {
        /// <summary>
        /// The global search radius of all algorithms (that decide to utilize it)
        /// </summary>
        public static int Option_GlobalSearchRadius = 1;

        /// <summary>
        /// Returns a new random grid with all cells in states of 0 or 1
        /// </summary>
        [Description("Returns a new random grid with all cells in states of 0 or 1")]
        public static readonly Func<int, Cell[]> Seed_Random01 = S =>
        {
            Cell[] ReturnArray = new Cell[S * S];
            for (int i = 0; i < ReturnArray.Length; i++)
            {
                ReturnArray[i] = new Cell(Random.Integer(0, 1));
            }

            return ReturnArray;
        };

        

        /// <summary>
        /// Returns a new random grid with all cells in states of 0 or 1, with twice as much of a chance for a cell to have a state of 1.
        /// </summary>
        [Description("Returns a new random grid with all cells in states of 0 or 1, with twice as much of a chance for a cell to have a state of 1")]
        public static readonly Func<int, Cell[]> Seed_Random011 = S =>
        {
            Cell[] ReturnArray = new Cell[S * S];
            for (int i = 0; i < ReturnArray.Length; i++)
            {
                if (Random.Integer(0, 2) != 0) ReturnArray[i] = new Cell(1);
                else ReturnArray[i] = new Cell(0);
            }

            return ReturnArray;
        };

        /// <summary>
        /// Returns a new random grid with all cells in states of 0 or 1, with twice as much of a chance for a cell to have a state of 0.
        /// </summary>
        [Description("Returns a new random grid with all cells in states of 0 or 1, with twice as much of a chance for a cell to have a state of 0")]
        public static readonly Func<int, Cell[]> Seed_Random001 = S =>
        {
            Cell[] ReturnArray = new Cell[S * S];
            for (int i = 0; i < ReturnArray.Length; i++)
            {
                if (Random.Integer(0, 2) != 2) ReturnArray[i] = new Cell(0);
                else ReturnArray[i] = new Cell(1);
            }

            return ReturnArray;
        };

        /// <summary>
        /// Returns a new random grid with all cells in states of 0, 1, or 2
        /// </summary>
        [Description("Returns a new random grid with all cells in states of 0, 1, or 2")]
        public static readonly Func<int, Cell[]> Seed_Random012 = S =>
        {
            Cell[] ReturnArray = new Cell[S * S];
            for (int i = 0; i < ReturnArray.Length; i++)
            {
                ReturnArray[i] = new Cell(Random.Integer(0, 2));
            }

            return ReturnArray;
        };

        /// <summary>
        /// Returns a new random grid with all cells in states of 0 through state 4
        /// </summary>
        [Description("Returns a new random grid with all cells in states of 0 through state 4")]
        public static readonly Func<int, Cell[]> Seed_Random0To4 = S =>
        {
            Cell[] ReturnArray = new Cell[S * S];
            for (int i = 0; i < ReturnArray.Length; i++)
            {
                ReturnArray[i] = new Cell(Random.Integer(0, 4));
            }

            return ReturnArray;
        };

        /// <summary>
        /// Returns a new blank grid with the center cell initialized to 1
        /// </summary>
        [Description("Returns a new blank grid with the center cell initialized")]
        public static readonly Func<int, Cell[]> Seed_Center = S =>
        {
            Cell[] ReturnArray = new Cell[S * S];

            for (int i = 0; i < ReturnArray.Length; i++)
            {
                int y = i / S;
                int x = i % S;
                if (x == S / 2 && y == S / 2)
                {
                    ReturnArray[i] = new Cell(1);
                }
                else
                {
                    ReturnArray[i] = new Cell(0);
                }
            }

            return ReturnArray;
        };

        /// <summary>
        /// Returns a new blank grid with the cell located at (0, 0) initialized to 1
        /// </summary>
        [Description("Returns a new blank grid with the cell located at (0, 0) initialized to 1")]
        public static readonly Func<int, Cell[]> Seed_00 = S =>
        {
            Cell[] ReturnArray = new Cell[S * S];

            for (int i = 0; i < ReturnArray.Length; i++)
            {
                int y = i / S;
                int x = i % S;
                if (x == 0 && y == 0)
                {
                    ReturnArray[i] = new Cell(1);
                }
                else
                {
                    ReturnArray[i] = new Cell(0);
                }
            }

            return ReturnArray;
        };

        /// <summary>
        /// Returns a new blank grid with the outer shell initialized to 1
        /// </summary>
        [Description("Returns a new blank grid with the outer shell initialized to 1")]
        public static readonly Func<int, Cell[]> Seed_Shell = S =>
        {
            Cell[] ReturnArray = new Cell[S * S];

            for (int i = 0; i < ReturnArray.Length; i++)
            {
                int y = i / S;
                int x = i % S;
                if (x != S - 1 && y != S - 1 && x != 0 && y != 0)
                {
                    ReturnArray[i] = new Cell(0);
                }
                else
                {
                    ReturnArray[i] = new Cell(1);
                }
            }

            return ReturnArray;
        };

        /// <summary>
        /// Returns a new grid with all cells in state 0
        /// </summary>
        [Description("Returns a new grid with all cells in state 0")]
        public static readonly Func<int, Cell[]> Seed_All0 = S =>
        {
            Cell[] ReturnArray = new Cell[S * S];
            for (int i = 0; i < ReturnArray.Length; i++)
            {
                ReturnArray[i] = new Cell(0);
            }

            return ReturnArray;
        };

        /// <summary>
        /// Returns a new grid with all cells in state 1
        /// </summary>
        [Description("Returns a new grid with all cells in state 1")]
        public static readonly Func<int, Cell[]> Seed_All1 = S =>
        {
            Cell[] ReturnArray = new Cell[S * S];
            for (int i = 0; i < ReturnArray.Length; i++)
            {
                ReturnArray[i] = new Cell(1);
            }

            return ReturnArray;
        };

        /// <summary>
        /// Returns a new grid with cells in alternating states of 0 or 1
        /// </summary>
        [Description("Returns a new grid with cells in alternating states of 0 or 1")]
        public static readonly Func<int, Cell[]> Seed_Checkered = S =>
        {
            bool isone = true;
            Cell[] ReturnArray = new Cell[S * S];
            for (int i = 0; i < ReturnArray.Length; i++)
            {
                if (isone)
                {
                    ReturnArray[i] = new Cell(1);
                }
                else
                {
                    ReturnArray[i] = new Cell(0);
                }
                isone = !isone;
            }

            return ReturnArray;
        };

        /// <summary>
        /// A classical neighbor search algorithm with radius 1 based on Conway's Game of Life.
        /// </summary>
        [Description("A classical neighbor search algorithm based on Conway's Game of Life")]
        public static readonly Func<int[], Automaton, List<Cell>> Neighbors_Moore = (Position, Automaton) =>
        {
            //Create a new list of cells to store the neighbors in.
            List<Cell> Neighbors = new List<Cell>();

            //Iterate in the x direction
            for (int i = Position[0] - Option_GlobalSearchRadius; i <= Position[0] + Option_GlobalSearchRadius; i++)
            {
                //Iterate in the y direction
                for (int j = Position[1] - Option_GlobalSearchRadius; j <= Position[1] + Option_GlobalSearchRadius; j++)
                {
                    //Don't add our own cell
                    if (i == Position[0] && j == Position[1]) continue;

                    //Obtain the cell associated with this position
                    Cell Comparison = Automaton[i, j];

                    //Add the cell at these coordinates
                    Neighbors.Add(Comparison);
                }
            }

            Neighbors.TrimExcess();
            return Neighbors;
        };

        /// <summary>
        /// A classical neighbor search algorithm with radius 1 based on Conway's Game of Life that includes the cell in its own neighbor count.
        /// </summary>
        [Description("A classical neighbor search algorithm based on Conway's Game of Life that includes the cell in its own neighbor count")]
        public static readonly Func<int[], Automaton, List<Cell>> Neighbors_Moore_Inclusive = (Position, Automaton) =>
        {
            //Create a new list of cells to store the neighbors in.
            List<Cell> Neighbors = new List<Cell>();

            //Iterate in the x direction
            for (int i = Position[0] - Option_GlobalSearchRadius; i <= Position[0] + Option_GlobalSearchRadius; i++)
            {
                //Iterate in the y direction
                for (int j = Position[1] - Option_GlobalSearchRadius; j <= Position[1] + Option_GlobalSearchRadius; j++)
                {
                    //Obtain the cell associated with this position
                    Cell Comparison = Automaton[i, j];

                    //Add the cell at these coordinates
                    Neighbors.Add(Comparison);
                }
            }

            Neighbors.TrimExcess();
            return Neighbors;
        };

        /// <summary>
        /// A classical neighbor search algorithm with radius 1 that excludes "corner" cells.
        /// </summary>
        [Description("A classical neighbor search algorithm with radius 1 that excludes \"corner\" cells")]
        public static readonly Func<int[], Automaton, List<Cell>> Neighbors_Neumann = (Position, Automaton) =>
        {
            //Create a new list of cells to store the neighbors in.
            List<Cell> Neighbors = new List<Cell>();

            //Iterate in the x direction
            for (int i = Position[0] - Option_GlobalSearchRadius; i <= Position[0] + Option_GlobalSearchRadius; i++)
            {
                //Don't add our own cell
                if (i == Position[0]) continue;

                //Obtain the cell associated with this position
                Cell Comparison = Automaton[i, Position[1]];

                //Add the cell at these coordinates
                Neighbors.Add(Comparison);
            }

            //Iterate in the y direction
            for (int j = Position[1] - Option_GlobalSearchRadius; j <= Position[1] + Option_GlobalSearchRadius; j++)
            {
                //Don't add our own cell
                if (j == Position[1]) continue;

                //Obtain the cell associated with this position
                Cell Comparison = Automaton[Position[0], j];

                //Add the cell at these coordinates
                Neighbors.Add(Comparison);
            }

            Neighbors.TrimExcess();
            return Neighbors;
        };

        /// <summary>
        /// A classical neighbor search algorithm with radius 1 that excludes "corner" cells but includes the cell in its own neighbor count.
        /// </summary>
        [Description("A classical neighbor search algorithm with radius 1 that excludes \"corner\" cells but includes the cell in its own neighbor count.")]
        public static readonly Func<int[], Automaton, List<Cell>> Neighbors_Neumann_Inclusive = (Position, Automaton) =>
        {
            //Create a new list of cells to store the neighbors in.
            List<Cell> Neighbors = new List<Cell>();

            Neighbors.Add(Automaton[Position[0], Position[1]]);

            //Iterate in the x direction
            for (int i = Position[0] - Option_GlobalSearchRadius; i <= Position[0] + Option_GlobalSearchRadius; i++)
            {
                //Don't add our own cell
                if (i == Position[0]) continue;

                //Obtain the cell associated with this position
                Cell Comparison = Automaton[i, Position[1]];

                //Add the cell at these coordinates
                Neighbors.Add(Comparison);
            }

            //Iterate in the y direction
            for (int j = Position[1] - Option_GlobalSearchRadius; j <= Position[1] + Option_GlobalSearchRadius; j++)
            {
                //Don't add our own cell
                if (j == Position[1]) continue;

                //Obtain the cell associated with this position
                Cell Comparison = Automaton[Position[0], j];

                //Add the cell at these coordinates
                Neighbors.Add(Comparison);
            }

            Neighbors.TrimExcess();
            return Neighbors;
        };

        /// <summary>
        /// Only considers diagonal neighbors in enumeration.
        /// </summary>
        [Description("Only considers diagonal neighbors in enumeration")]
        public static readonly Func<int[], Automaton, List<Cell>> Neighbors_Diagonal = (Position, Automaton) =>
        {
            //Create a new list of cells to store the neighbors in.
            List<Cell> Neighbors = new List<Cell>();
            for (int i = 1; i <= Option_GlobalSearchRadius; i++)
            {
                Neighbors.Add(Automaton[Position[0] + i, Position[1] + i]);
                Neighbors.Add(Automaton[Position[0] + i, Position[1] - i]);
                Neighbors.Add(Automaton[Position[0] - i, Position[1] + i]);
                Neighbors.Add(Automaton[Position[0] - i, Position[1] - i]);
            }
            

            Neighbors.TrimExcess();
            return Neighbors;
        };

        /// <summary>
        /// Only considers diagonal neighbors in enumeration includes the cell in its own neighbor count.
        /// </summary>
        [Description("Only considers diagonal neighbors in enumeration and includes the cell in its own neighbor count")]
        public static readonly Func<int[], Automaton, List<Cell>> Neighbors_Diagonal_Inclusive = (Position, Automaton) =>
        {
            //Create a new list of cells to store the neighbors in.
            List<Cell> Neighbors = new List<Cell>();
            Neighbors.Add(Automaton[Position[0], Position[1]]);
            for (int i = 1; i <= Option_GlobalSearchRadius; i++)
            {
                Neighbors.Add(Automaton[Position[0] + i, Position[1] + i]);
                Neighbors.Add(Automaton[Position[0] + i, Position[1] - i]);
                Neighbors.Add(Automaton[Position[0] - i, Position[1] + i]);
                Neighbors.Add(Automaton[Position[0] - i, Position[1] - i]);
            }


            Neighbors.TrimExcess();
            return Neighbors;
        };

        /// <summary>
        /// Only considers horizontal neighbors in enumeration.
        /// </summary>
        [Description("Only considers horizontal neighbors in enumeration")]
        public static readonly Func<int[], Automaton, List<Cell>> Neighbors_Horizontal = (Position, Automaton) =>
        {
            //Create a new list of cells to store the neighbors in.
            List<Cell> Neighbors = new List<Cell>();
            for (int i = 1; i <= Option_GlobalSearchRadius; i++)
            {
                Neighbors.Add(Automaton[Position[0] + i, Position[1]]);
                Neighbors.Add(Automaton[Position[0] - i, Position[1]]);
            }

            Neighbors.TrimExcess();
            return Neighbors;
        };

        /// <summary>
        /// Only considers horizontal neighbors in enumeration in the +X direction.
        /// </summary>
        [Description("Only considers horizontal neighbors in enumeration in the +X direction")]
        public static readonly Func<int[], Automaton, List<Cell>> Neighbors_Right = (Position, Automaton) =>
        {
            //Create a new list of cells to store the neighbors in.
            List<Cell> Neighbors = new List<Cell>();
            for (int i = 1; i <= Option_GlobalSearchRadius; i++)
            {
                Neighbors.Add(Automaton[Position[0] + i, Position[1]]);
            }

            Neighbors.TrimExcess();
            return Neighbors;
        };

        /// <summary>
        /// Only considers horizontal neighbors in enumeration in the -X direction.
        /// </summary>
        [Description("Only considers horizontal neighbors in enumeration in the -X direction")]
        public static readonly Func<int[], Automaton, List<Cell>> Neighbors_Left = (Position, Automaton) =>
        {
            //Create a new list of cells to store the neighbors in.
            List<Cell> Neighbors = new List<Cell>();
            for (int i = 1; i <= Option_GlobalSearchRadius; i++)
            {
                Neighbors.Add(Automaton[Position[0] - i, Position[1]]);
            }

            Neighbors.TrimExcess();
            return Neighbors;
        };

        /// <summary>
        /// Only considers horizontal neighbors in enumeration, including the cell in its own neighbor count.
        /// </summary>
        [Description("Only considers horizontal neighbors in enumeration, including the cell in its own neighbor count")]
        public static readonly Func<int[], Automaton, List<Cell>> Neighbors_Horizontal_Inclusive = (Position, Automaton) =>
        {
            //Create a new list of cells to store the neighbors in.
            List<Cell> Neighbors = new List<Cell>();
            Neighbors.Add(Automaton[Position[0], Position[1]]);
            for (int i = 1; i <= Option_GlobalSearchRadius; i++)
            {
                Neighbors.Add(Automaton[Position[0] + i, Position[1]]);
                Neighbors.Add(Automaton[Position[0] - i, Position[1]]);
            }

            Neighbors.TrimExcess();
            return Neighbors;
        };

        /// <summary>
        /// Only considers vertical neighbors in enumeration.
        /// </summary>
        [Description("Only considers vertical neighbors in enumeration")]
        public static readonly Func<int[], Automaton, List<Cell>> Neighbors_Vertical = (Position, Automaton) =>
        {
            //Create a new list of cells to store the neighbors in.
            List<Cell> Neighbors = new List<Cell>();

            for (int i = 1; i <= Option_GlobalSearchRadius; i++)
            {
                Neighbors.Add(Automaton[Position[0], Position[1] + i]);
                Neighbors.Add(Automaton[Position[0], Position[1] - i]);
            }

            Neighbors.TrimExcess();
            return Neighbors;
        };

        /// <summary>
        /// Only considers vertical neighbors in enumeration in the +Y direction.
        /// </summary>
        [Description("Only considers vertical neighbors in enumeration in the +Y direction")]
        public static readonly Func<int[], Automaton, List<Cell>> Neighbors_Up = (Position, Automaton) =>
        {
            //Create a new list of cells to store the neighbors in.
            List<Cell> Neighbors = new List<Cell>();

            for (int i = 1; i <= Option_GlobalSearchRadius; i++)
            {
                Neighbors.Add(Automaton[Position[0], Position[1] + i]);
            }

            Neighbors.TrimExcess();
            return Neighbors;
        };

        /// <summary>
        /// Only considers vertical neighbors in enumeration in the -Y direction.
        /// </summary>
        [Description("Only considers vertical neighbors in enumeration in the -Y direction")]
        public static readonly Func<int[], Automaton, List<Cell>> Neighbors_Down = (Position, Automaton) =>
        {
            //Create a new list of cells to store the neighbors in.
            List<Cell> Neighbors = new List<Cell>();

            for (int i = 1; i <= Option_GlobalSearchRadius; i++)
            {
                Neighbors.Add(Automaton[Position[0], Position[1] - i]);
            }

            Neighbors.TrimExcess();
            return Neighbors;
        };

        /// <summary>
        /// Only considers vertical neighbors in enumeration, including the cell in its own neighbor count.
        /// </summary>
        [Description("Only considers vertical neighbors in enumeration, including the cell in its own neighbor count")]
        public static readonly Func<int[], Automaton, List<Cell>> Neighbors_Vertical_Inclusive = (Position, Automaton) =>
        {
            //Create a new list of cells to store the neighbors in.
            List<Cell> Neighbors = new List<Cell>();
            Neighbors.Add(Automaton[Position[0], Position[1]]);
            for (int i = 1; i <= Option_GlobalSearchRadius; i++)
            {
                Neighbors.Add(Automaton[Position[0], Position[1] + i]);
                Neighbors.Add(Automaton[Position[0], Position[1] - i]);
            }

            Neighbors.TrimExcess();
            return Neighbors;
        };

        /// <summary>
        /// Only considers cells on the outermost edge of the search radius to be neighbors.
        /// </summary>
        [Description("Only considers cells on the outermost edge of the search radius to be neighbors")]
        public static readonly Func<int[], Automaton, List<Cell>> Neighbors_Shell = (Position, Automaton) =>
        {
            //Create a new list of cells to store the neighbors in.
            List<Cell> Neighbors = new List<Cell>();

            //Iterate in the x direction
            for (int i = Position[0] - Option_GlobalSearchRadius; i <= Position[0] + Option_GlobalSearchRadius; i++)
            {
                //Iterate in the y direction
                for (int j = Position[1] - Option_GlobalSearchRadius; j <= Position[1] + Option_GlobalSearchRadius; j++)
                {
                    //Don't add inner cells
                    if (Math.Abs(i - Position[0]) < Option_GlobalSearchRadius && Math.Abs(j - Position[1]) < Option_GlobalSearchRadius) continue;

                    //Obtain the cell associated with this position
                    Cell Comparison = Automaton[i, j];

                    //Add the cell at these coordinates
                    Neighbors.Add(Comparison);
                }
            }

            Neighbors.TrimExcess();
            return Neighbors;
        };


        /// <summary>
        /// Only considers cells on the outermost edge of the search radius to be neighbors.
        /// </summary>
        [Description("Only considers cells on the outermost edge of the search radius to be neighbors, returning the 8 neighbors corresponding to the edge of the search radius in the 8 grid directions")]
        public static readonly Func<int[], Automaton, List<Cell>> Neighbors_PseudoShell = (Position, Automaton) =>
        {
            //Create a new list of cells to store the neighbors in.
            List<Cell> Neighbors = new List<Cell>();

            Neighbors.Add(Automaton[Position[0] + Option_GlobalSearchRadius, Position[1] + Option_GlobalSearchRadius]);
            Neighbors.Add(Automaton[Position[0] + Option_GlobalSearchRadius, Position[1]]);
            Neighbors.Add(Automaton[Position[0] + Option_GlobalSearchRadius, Position[1] - Option_GlobalSearchRadius]);
            Neighbors.Add(Automaton[Position[0] - Option_GlobalSearchRadius, Position[1] + Option_GlobalSearchRadius]);
            Neighbors.Add(Automaton[Position[0] - Option_GlobalSearchRadius, Position[1]]);
            Neighbors.Add(Automaton[Position[0] - Option_GlobalSearchRadius, Position[1] - Option_GlobalSearchRadius]);
            Neighbors.Add(Automaton[Position[0], Position[1] + Option_GlobalSearchRadius]);
            //Neighbors.Add(Automaton[Position[0], Position[1]]);
            Neighbors.Add(Automaton[Position[0], Position[1] - Option_GlobalSearchRadius]);

            Neighbors.TrimExcess();
            return Neighbors;
        };

        /// <summary>
        /// Only considers cells on the outside of the search radius to be neighbors.
        /// </summary>
        [Description("Only considers cells on the outside of the search radius to be neighbors, returning the 8 neighbors corresponding to the edge of the search radius in the 8 grid directions")]
        public static readonly Func<int[], Automaton, List<Cell>> Neighbors_PseudoShell_Inclusive = (Position, Automaton) =>
        {
            //Create a new list of cells to store the neighbors in.
            List<Cell> Neighbors = new List<Cell>();

            Neighbors.Add(Automaton[Position[0] + Option_GlobalSearchRadius, Position[1] + Option_GlobalSearchRadius]);
            Neighbors.Add(Automaton[Position[0] + Option_GlobalSearchRadius, Position[1]]);
            Neighbors.Add(Automaton[Position[0] + Option_GlobalSearchRadius, Position[1] - Option_GlobalSearchRadius]);
            Neighbors.Add(Automaton[Position[0] - Option_GlobalSearchRadius, Position[1] + Option_GlobalSearchRadius]);
            Neighbors.Add(Automaton[Position[0] - Option_GlobalSearchRadius, Position[1]]);
            Neighbors.Add(Automaton[Position[0] - Option_GlobalSearchRadius, Position[1] - Option_GlobalSearchRadius]);
            Neighbors.Add(Automaton[Position[0], Position[1] + Option_GlobalSearchRadius]);
            Neighbors.Add(Automaton[Position[0], Position[1]]);
            Neighbors.Add(Automaton[Position[0], Position[1] - Option_GlobalSearchRadius]);

            Neighbors.TrimExcess();
            return Neighbors;
        };


        ///// <summary>
        ///// Returns 21 neighbors with random states between 0 and 1.
        ///// </summary>
        //[Description("Returns 21 neighbors with random states between 0 and 1")]
        //public static readonly Func<int[], Automaton, List<Cell>> Neighbors_Random_21_01 = (Position, Automaton) =>
        //{
        //    List<Cell> ReturnArray = new List<Cell>(21);
        //    for (int i = 0; i < ReturnArray.Count; i++)
        //    {
        //        ReturnArray[i] = new Cell(Random.Integer(0,1));
        //    }

        //    return ReturnArray;
        //};

        ///// <summary>
        ///// Returns 9 neighbors with random states between 0 and 1.
        ///// </summary>
        //[Description("Returns 9 neighbors with random states between 0 and 1")]
        //public static readonly Func<int[], Automaton, List<Cell>> Neighbors_Random_9_01 = (Position, Automaton) => 
        //{
        //    List<Cell> ReturnArray = new List<Cell>(9);
        //    for (int i = 0; i < ReturnArray.Count; i++)
        //    {
        //        ReturnArray[i] = new Cell(Random.Integer(0, 1));
        //    }

        //    return ReturnArray;
        //};

        /// <summary>
        /// The classical unaltered Game of Life rule set.
        /// </summary>
        [Description("The classical unaltered Game of Life rule set")]
        public static readonly Func<Cell, List<Cell>, Cell> Rule_ConwaysGameOfLife = (Input, Neighbors) =>
        {
            int LiveNeighbors = Neighbors.Where(x => x.State == 1).ToList().Count;

            if (Input.State == 1)
            {
                //Any live cell with fewer than 2 live neighbours dies, as if caused by under-population
                if (LiveNeighbors < 2) return new Cell(0);

                //Any live cell with 2 or 3 live neighbours lives on to the next generation
                if (LiveNeighbors == 2 || LiveNeighbors == 3) return new Cell(1);

                //Any live cell with more than 3 live neighbours dies, as if by over-population
                if (LiveNeighbors > 3) return new Cell(0);
            }
            else if (Input.State == 0)
            {
                //Any dead cell with exactly 3 live neighbours becomes a live cell, as if by reproduction
                if (LiveNeighbors == 3) return new Cell(1);
            }

            return new Cell(Input.State);
        };

        /// <summary>
        /// The classical unaltered Game of Life rule set with the overpopulation restriction removed.
        /// </summary>
        [Description("The classical unaltered Game of Life rule set with the overpopulation restriction removed")]
        public static readonly Func<Cell, List<Cell>, Cell> Rule_ConwaysGameOfLife_NoOverpopulation = (Input, Neighbors) =>
        {
            int LiveNeighbors = Neighbors.Where(x => x.State == 1).ToList().Count;

            if (Input.State == 1)
            {
                //Any live cell with fewer than 2 live neighbours dies, as if caused by under-population
                if (LiveNeighbors < 2) return new Cell(0);

                //Any live cell with 2 or 3 live neighbours lives on to the next generation
                if (LiveNeighbors > 2) return new Cell(1);

                //Any live cell with more than 3 live neighbours dies, as if by over-population
                //if (LiveNeighbors > 3) return new Cell(0);
            }
            else if (Input.State == 0)
            {
                //Any dead cell with exactly 3 live neighbours becomes a live cell, as if by reproduction
                if (LiveNeighbors == 3) return new Cell(1);
            }

            return new Cell(Input.State);
        };

        /// <summary>
        /// The classical unaltered Game of Life rule set with the underpopulation restriction removed.
        /// </summary>
        [Description("The classical unaltered Game of Life rule set with the underpopulation restriction removed")]
        public static readonly Func<Cell, List<Cell>, Cell> Rule_ConwaysGameOfLife_NoUnderpopulation = (Input, Neighbors) =>
        {
            int LiveNeighbors = Neighbors.Where(x => x.State == 1).ToList().Count;

            if (Input.State == 1)
            {
                //Any live cell with fewer than 2 live neighbours dies, as if caused by under-population
                //if (LiveNeighbors < 2) return new Cell(0);

                //Any live cell with 2 or 3 live neighbours lives on to the next generation
                if (LiveNeighbors <= 3) return new Cell(1);

                //Any live cell with more than 3 live neighbours dies, as if by over-population
                if (LiveNeighbors > 3) return new Cell(0);
            }
            else if (Input.State == 0)
            {
                //Any dead cell with exactly 3 live neighbours becomes a live cell, as if by reproduction
                if (LiveNeighbors == 3) return new Cell(1);
            }

            return new Cell(Input.State);
        };

        /// <summary>
        /// The classical Game of Life rule set with no cell \"death\".
        /// </summary>
        [Description("The classical Game of Life rule set with no cell \"death\"")]
        public static readonly Func<Cell, List<Cell>, Cell> Rule_ConwaysGameOfLife_NoDeath = (Input, Neighbors) =>
        {
            int LiveNeighbors = Neighbors.Where(x => x.State == 1).ToList().Count;

            if (Input.State == 0)
            {
                //Any dead cell with exactly 3 live neighbours becomes a live cell, as if by reproduction
                if (LiveNeighbors == 3) return new Cell(1);
            }

            return new Cell(Input.State);
        };

        /// <summary>
        /// The classical Game of Life rule set with no cell \"death\" - reduced.
        /// </summary>
        [Description("The classical Game of Life rule set with no cell \"death\" - reduced")]
        public static readonly Func<Cell, List<Cell>, Cell> Rule_ConwaysGameOfLife_NoDeath_Reduced = (Input, Neighbors) =>
        {
            int LiveNeighbors = Neighbors.Where(x => x.State == 1).ToList().Count;

            if (Input.State == 0)
            {
                //Any dead cell with exactly 2 live neighbours becomes a live cell, as if by reproduction
                if (LiveNeighbors == 2) return new Cell(1);
            }

            return new Cell(Input.State);
        };

        /// <summary>
        /// The classical Game of Life rule set with no cell \"death\" - expanded.
        /// </summary>
        [Description("The classical Game of Life rule set with no cell \"death\" - expanded")]
        public static readonly Func<Cell, List<Cell>, Cell> Rule_ConwaysGameOfLife_NoDeath_Expanded = (Input, Neighbors) =>
        {
            int LiveNeighbors = Neighbors.Where(x => x.State == 1).ToList().Count;

            if (Input.State == 0)
            {
                //Any dead cell with exactly 4 live neighbours becomes a live cell, as if by reproduction
                if (LiveNeighbors == 4) return new Cell(1);
            }

            return new Cell(Input.State);
        };

        /// <summary>
        /// The classical unaltered Game of Life rule set with no "reproduction".
        /// </summary>
        [Description("The classical unaltered Game of Life rule set with no \"reproduction\"")]
        public static readonly Func<Cell, List<Cell>, Cell> Rule_ConwaysGameOfLife_NoReproduction = (Input, Neighbors) =>
        {
            int LiveNeighbors = Neighbors.Where(x => x.State == 1).ToList().Count;

            if (Input.State == 1)
            {
                //Any live cell with fewer than 2 live neighbours dies, as if caused by under-population
                if (LiveNeighbors < 2) return new Cell(0);

                //Any live cell with 2 or 3 live neighbours lives on to the next generation
                if (LiveNeighbors == 2 || LiveNeighbors == 3) return new Cell(1);

                //Any live cell with more than 3 live neighbours dies, as if by over-population
                if (LiveNeighbors > 3) return new Cell(0);
            }

            return new Cell(Input.State);
        };

        /// <summary>
        /// The classical Game of Life rule with each neighbor requirement reduced by 1.
        /// </summary>
        [Description("The classical Game of Life rule with each neighbor requirement reduced by 1")]
        public static readonly Func<Cell, List<Cell>, Cell> Rule_ConwaysGameOfLife_Reduced = (Input, Neighbors) =>
        {
            int LiveNeighbors = Neighbors.Where(x => x.State == 1).ToList().Count;

            if (Input.State == 1)
            {
                //Any live cell with fewer than 1 live neighbours dies, as if caused by under-population
                if (LiveNeighbors < 1) return new Cell(0);

                //Any live cell with 1 or 2 live neighbours lives on to the next generation
                if (LiveNeighbors == 1 || LiveNeighbors == 2) return new Cell(1);

                //Any live cell with more than 2 live neighbours dies, as if by over-population
                if (LiveNeighbors > 2) return new Cell(0);
            }
            else if (Input.State == 0)
            {
                //Any dead cell with exactly 2 live neighbours becomes a live cell, as if by reproduction
                if (LiveNeighbors == 2) return new Cell(1);
            }

            return new Cell(Input.State);
        };

        /// <summary>
        /// The classical Game of Life rule with each neighbor requirement increased by 1.
        /// </summary>
        [Description("The classical Game of Life rule with each neighbor requirement increased by 1")]
        public static readonly Func<Cell, List<Cell>, Cell> Rule_ConwaysGameOfLife_Expanded = (Input, Neighbors) =>
        {
            int LiveNeighbors = Neighbors.Where(x => x.State == 1).ToList().Count;

            if (Input.State == 1)
            {
                if (LiveNeighbors < 3) return new Cell(0);

                if (LiveNeighbors == 3 || LiveNeighbors == 4) return new Cell(1);

                if (LiveNeighbors > 4) return new Cell(0);
            }
            else if (Input.State == 0)
            {
                if (LiveNeighbors == 4) return new Cell(1);
            }

            return new Cell(Input.State);
        };

        /// <summary>
        /// Sets the state of the cell in question to 1 if the sum of its neighbor's states is an even number.
        /// </summary>
        [Description("Sets the state of the cell in question to 1 if the sum of its neighbor's states is an even number")]
        public static readonly Func<Cell, List<Cell>, Cell> Rule_Evens = (Input, Neighbors) =>
        {
            int NeighborSum = Neighbors.Sum(x => x.State);

            if (NeighborSum % 2 == 0) return new Cell(1);

            return new Cell(0);
        };

        /// <summary>
        /// Sets the state of the cell in question to 1 if the sum of its neighbor's states is a prime number.
        /// </summary>
        [Description("Sets the state of the cell in question to 1 if the sum of its neighbor's states is a prime number")]
        public static readonly Func<Cell, List<Cell>, Cell> Rule_Primes = (Input, Neighbors) =>
        {
            int NeighborSum = Neighbors.Sum(x => x.State);

            if (NeighborSum == 0 || NeighborSum == 1) return new Cell(0);
            if (NeighborSum == 2) return new Cell(1);

            int boundary = (int)Math.Floor(Math.Sqrt(NeighborSum));
            for (int i = 2; i <= boundary; ++i)
            {
                if (NeighborSum % i == 0) return new Cell(0);
            }

            return new Cell(1);
        };

        /// <summary>
        /// Sets the state of the cell in question to 1 if the sum of its neighbor's states is an odd number.
        /// </summary>
        [Description("Sets the state of the cell in question to 1 if the sum of its neighbor's states is an odd number")]
        public static readonly Func<Cell, List<Cell>, Cell> Rule_Odds = (Input, Neighbors) =>
        {
            int NeighborSum = Neighbors.Sum(x => x.State);

            if (NeighborSum % 2 != 0) return new Cell(1);

            return new Cell(0);
        };


        /// <summary>
        /// Sets the state of the cell in question to modulus between the sum of its neighbor's states and its previous state.
        /// </summary>
        [Description("Sets the state of the cell in question to modulus between the sum of its neighbor's states and its previous state")]
        public static readonly Func<Cell, List<Cell>, Cell> Rule_SumModulus = (Input, Neighbors) =>
        {
            int NeighborSum = Neighbors.Sum(x => x.State);

            if (Input.State <= 0) return new Cell(NeighborSum);
            
            return new Cell(NeighborSum % Input.State);
        };

        /// <summary>
        /// Sets the state of the cell in question to modulus between the maximum of its neighbor's states and its previous state.
        /// </summary>
        [Description("Sets the state of the cell in question to modulus between the maximum of its neighbor's states and its previous state")]
        public static readonly Func<Cell, List<Cell>, Cell> Rule_MaximumModulus = (Input, Neighbors) =>
        {
            int NeighborSum = Neighbors.Max(x => x.State);

            if (Input.State <= 0) return new Cell(NeighborSum);

            return new Cell(NeighborSum % Input.State);
        };

        /// <summary>
        /// Sets the state of a cell to the average state of its neighbors.
        /// </summary>
        [Description("Sets the state of a cell to the average state of its neighbors (rounded)")]
        public static readonly Func<Cell, List<Cell>, Cell> Rule_AverageStateOfNeighbors = (Input, Neighbors) => new Cell((int)Math.Round(Neighbors.Average(c => c.State)));

        /// <summary>
        /// Sets the state of a cell to the maximum state of its neighbors.
        /// </summary>
        [Description("Sets the state of a cell to the maximum state of its neighbors")]
        public static readonly Func<Cell, List<Cell>, Cell> Rule_MaximumStateOfNeighbors = (Input, Neighbors) => new Cell(Neighbors.Max(c => c.State));

        /// <summary>
        /// Sets the state of a cell to the minimum state of its neighbors.
        /// </summary>
        [Description("Sets the state of a cell to the minimum state of its neighbors")]
        public static readonly Func<Cell, List<Cell>, Cell> Rule_MinimumStateOfNeighbors = (Input, Neighbors) => new Cell(Neighbors.Min(c => c.State));

        /// <summary>
        /// An overflow handler that assumes that outside of our grid exists cells whose state is 0.
        /// </summary>
        [Description("Assumes that outside of our grid exists cells whose state is 0")]
        public static readonly Func<int[], Automaton, Cell> Overflow_Assume0 = (Position, Automaton) => new Cell(0);

        /// <summary>
        /// An overflow handler that assumes that outside of our grid exists cells whose state is 1.
        /// </summary>
        [Description("Assumes that outside of our grid exists cells whose state is 1")]
        public static readonly Func<int[], Automaton, Cell> Overflow_Assume1 = (Position, Automaton) => new Cell(1);

        /// <summary>
        /// An overflow handler that assumes that outside of our grid exists cells whose state is randomly either 0 or 1.
        /// </summary>
        [Description("Assumes that outside of our grid exists cells whose state is randomly either 0 or 1")]
        public static readonly Func<int[], Automaton, Cell> Overflow_Random01 = (Position, Automaton) => new Cell(Random.Integer(0, 1));

        /// <summary>
        /// An overflow handler that assumes that outside of our grid exists cells whose state is randomly either 0, 1 or 2.
        /// </summary>
        [Description("Assumes that outside of our grid exists cells whose state is randomly either 0, 1, or 2")]
        public static readonly Func<int[], Automaton, Cell> Overflow_Random012 = (Position, Automaton) => new Cell(Random.Integer(0, 2));

        /// <summary>
        /// An overflow handler that assumes that surpassing the edge of the grid results in reappearing on the opposite side of the grid.
        /// </summary>
        [Description("Assumes that surpassing the edge of the grid results in reappearing on the opposite side of the grid")]
        public static readonly Func<int[], Automaton, Cell> Overflow_Torroidal = (Position, Automaton) =>
        {
            int S = Automaton.Size - 1;

            int X = Position[0];
            int Y = Position[1];

            //Look at the X coordinates
            if (Position[0] >= S) X = 0 + (Position[0] - S);
            else if (Position[0] < 0) X = S - (0 - Position[0]);

            //Look at the Y coordinates
            if (Position[1] >= S) Y = 0 + (Position[1] - S);
            else if (Position[1] < 0) Y = S - (0 - Position[1]);

            return Automaton[X, Y];
        };

        /// <summary>
        /// An overflow handler that assumes that asking for a coordinate outside of the grid returns the closest valid coordinate.
        /// </summary>
        [Description("Assumes that asking for a coordinate outside of the grid returns the closest valid coordinate")]
        public static readonly Func<int[], Automaton, Cell> Overflow_Limiting = (Position, Automaton) =>
        {
            int S = Automaton.Size - 1;

            int X = Position[0];
            int Y = Position[1];

            //Look at the X coordinates
            if (Position[0] >= S) X = S;
            else if (Position[0] < 0) X = 0;

            //Look at the Y coordinates
            if (Position[1] >= S) Y = S;
            else if (Position[1] < 0) Y = 0;

            return Automaton[X, Y];
        };

        /// <summary>
        /// An overflow handler that assumes that asking for a coordinate outside of the grid returns a random valid coordinate.
        /// </summary>
        [Description("Assumes that asking for a coordinate outside of the grid returns a random valid coordinate")]
        public static readonly Func<int[], Automaton, Cell> Overflow_PickRandomValid = (Position, Automaton) => Automaton[Random.Integer(0, Automaton.Size - 1), Random.Integer(0, Automaton.Size - 1)];

        /// <summary>
        /// An overflow handler that assumes that surpassing the edge of the grid results in reappearing at the center of the grid.
        /// </summary>
        [Description("Assumes that surpassing the edge of the grid results in reappearing at the center of the grid")]
        public static readonly Func<int[], Automaton, Cell> Overflow_CenterWrapped = (Position, Automaton) =>
        {
            int S = Automaton.Size - 1;

            int X = Position[0];
            int Y = Position[1];

            //Look at the X coordinates
            if (Position[0] >= S) X = (S / 2) + (Position[0] - S);
            else if (Position[0] < 0) X = (S / 2) - (0 - Position[0]);

            //Look at the Y coordinates
            if (Position[1] >= S) Y = (S / 2) + (Position[1] - S);
            else if (Position[1] < 0) Y = (S / 2) - (0 - Position[1]);

            return Automaton[X, Y];
        };

        /// <summary>
        /// Always selects the first rule result in a list of results.
        /// </summary>
        [Description("Always selects the first rule result in a list of results")]
        public static readonly Func<List<Cell>, Cell> RuleSelection_First = (Results) => Results[0];

        /// <summary>
        /// Always selects the last rule result in a list of results.
        /// </summary>
        [Description("Always selects the last rule result in a list of results")]
        public static readonly Func<List<Cell>, Cell> RuleSelection_Last = (Results) => Results[Results.Count - 1];

        /// <summary>
        /// Selects a random rule result in a list of results.
        /// </summary>
        [Description("Selects a random rule result in a list of results")]
        public static readonly Func<List<Cell>, Cell> RuleSelection_Random = (Results) => Results[Random.Integer(0, Results.Count - 1)];

        /// <summary>
        /// Selects the rule that yeilds the highest state value.
        /// </summary>
        [Description("Selects the rule that yeilds the highest state value")]
        public static readonly Func<List<Cell>, Cell> RuleSelection_HighestState = (Results) => new Cell(Results.Max(c => c.State));

        /// <summary>
        /// Selects the rule that yeilds the lowest state value.
        /// </summary>
        [Description("Selects the rule that yeilds the lowest state value")]
        public static readonly Func<List<Cell>, Cell> RuleSelection_LowestState = (Results) => new Cell(Results.Min(c => c.State));

        /// <summary>
        /// Returns a new cell with the average state value produced by the rule list.
        /// </summary>
        [Description("Returns a new cell with the average state value produced by the rule list (rounded)")]
        public static readonly Func<List<Cell>, Cell> RuleSelection_AverageState = (Results) => new Cell((int)Math.Round(Results.Average(c => c.State)));
    }
}