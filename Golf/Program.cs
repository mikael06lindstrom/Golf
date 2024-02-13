using System;

namespace Golf
{
    /// <summary>
    /// The class for this program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The name of this program
        /// </summary>
        public const string ProgramName = "The Golfswing 2000";
        
        /// <summary>
        /// The start point of this program
        /// </summary>
        /// <param name="args">Anything</param>
        static void Main(string[] args)
        {
            // Welcome the user to this program
            Console.WriteLine($"Welcome to {ProgramName}!");

            // Make a pause in the program
            Console.ReadKey();
        }
    }
}
