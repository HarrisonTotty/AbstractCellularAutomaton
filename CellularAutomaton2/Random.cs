using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellularAutomaton
{
    /// <summary>
    /// Provides various static methods for the generation of random numbers, expressions, and other data.
    /// </summary>
    public static class Random
    {
        /// <summary>
        /// General purpose pseudo-random generator.
        /// </summary>
        private static readonly System.Random RandomGen = new System.Random();

        /// <summary>
        /// A localized general purpose pseudo-random generator.
        /// </summary>
        [ThreadStatic]
        private static System.Random LocalGen;

        /// <summary>
        /// Used to prevent parallel threads from accidentally generating the same random number.
        /// </summary>
        /// <remarks>
        /// See https://stackoverflow.com/questions/767999/random-number-generator-only-generating-one-random-number for more details.
        /// </remarks>
        private static readonly object GenSyncLock = new object();

        /// <summary>
        /// Generates a random integer value.
        /// </summary>
        /// <param name="Lowerbound">The lowerbound of the generated number (inclusive)</param>
        /// <param name="Upperbound">The upperbound of the generated number (inclusive)</param>
        public static int Integer(int Lowerbound, int Upperbound)
        {
            int ReturnInt = 0;
            if (LocalGen == null)
            {
                int seed;
                lock (RandomGen) seed = RandomGen.Next();
                LocalGen = new System.Random(seed);
            }
            ReturnInt = LocalGen.Next(Lowerbound, Upperbound + 1);
            return ReturnInt;
        }

        /// <summary>
        /// Returns a random double value between two double values.
        /// </summary>
        /// <param name="Lowerbound">The lowerbound value</param>
        /// <param name="Upperbound">The upperbound value</param>
        public static double Double(double Lowerbound, double Upperbound)
        {
            if (LocalGen == null)
            {
                int seed;
                lock (RandomGen) seed = RandomGen.Next();
                LocalGen = new System.Random(seed);
            }
            return LocalGen.NextDouble() * (Upperbound - Lowerbound) + Lowerbound;
        }

        /// <summary>
        /// Returns a random boolean value.
        /// </summary>
        public static bool Boolean()
        {
            bool ReturnBool;
            if (LocalGen == null)
            {
                int seed;
                lock (RandomGen) seed = RandomGen.Next();
                LocalGen = new System.Random(seed);
            }
            ReturnBool = (LocalGen.Next(0, 2) == 1);
            return ReturnBool;
        }


        /// <summary>
        /// Generates a new random alphanumeric string of a particular length.
        /// </summary>
        /// <param name="Length">The number of characters to generate</param>
        public static string AlphaNumeric(int Length)
        {
            string PickString = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";

            string ReturnString = "";

            if (LocalGen == null)
            {
                int seed;
                lock (RandomGen) seed = RandomGen.Next();
                LocalGen = new System.Random(seed);
            }

            for (int i = 0; i < Length; i++)
            {
                ReturnString += PickString[LocalGen.Next(0, PickString.Length)];
            }
            return ReturnString;
        }
    }
}
