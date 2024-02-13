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

        // A const variable for earth gravity
        const double GRAVITY = 9.8;

        // Property for status of this program
        public static bool IsRun { get; set; }

        // Some field for this program / game
        static double initLocationToGoal, courceRange, distanceToGoal, angle, velocity;
        static double[] start, distance, end;
        static int stroke;
        static string strClub;

        // A instans of Random class for creating of randomly values
        static Random random = new Random();

        // Enum for predefine golfclubs
        enum GolfClubs
        {
            PUTTER = 3,
            SW = 38,
            PW = 45,
            I9 = 49,
            I8 = 53,
            I7 = 55,
            I6 = 59,
            I5 = 63,
            I4 = 66,
            I3 = 69,
            I2 = 72
        }

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
