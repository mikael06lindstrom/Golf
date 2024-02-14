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
            I2  =72,
            I3 = 69,
            I4 = 66,
            I5 = 63,
            I6 = 59,
            I7 = 55,
            I8 = 53,
            I9  = 49,
            PW = 45,
            SW = 38,
            PUTTER = 3
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

            // Start the game itself
            TheGame();
        }
        
        /// <summary>
        /// The game itself
        /// </summary>
        static void TheGame()
        {
            // Set the run status of this game to true
            IsRun = true;

            // Create new three double arrays for the 10 valid strokes
            start = new double[10];
            distance = new double[10];
            end = new double[10];

            // Set the stroke to zero
            stroke = 0;

            // Set inital location to goal and range of cource
            initLocationToGoal = (double)random.Next(300, 500);
            courceRange = initLocationToGoal * 1.02;
            distanceToGoal = initLocationToGoal;

            // Run until status of IsRun are true
            while(IsRun == true)
            {
                // Make a empty console window then show the name of the program
                Console.Clear();
                Console.WriteLine(ProgramName);

                // Set or reset angle to zero
                angle = 0;

                // Tell the user how long they have to goal
                Console.WriteLine($"You have {distanceToGoal} to goal.");

                // Ask the user for in which velocity they will swing in
                Console.Write("In which velocity (m/s) are you swing in? ");
                double.TryParse(Console.ReadLine(), out velocity);

                Console.WriteLine("Golfclubs \t Angle");
                foreach (int item in Enum.GetValues(typeof(GolfClubs)))
                {
                    Console.WriteLine($"{Enum.GetName(typeof(GolfClubs), item)} \t {item}");
                }

                // Ask the user for which club they will swing by
                Console.Write("Write which club you will swing by: ");
                strClub = Console.ReadLine();

                // Set angle
                foreach(int item in Enum.GetValues(typeof(GolfClubs))) 
                {
                    if(Enum.GetName(typeof(GolfClubs), item).Equals(strClub.ToUpper()))
                    {
                        angle = item;
                        break;
                    }
                }

                // Set start of stroke location and the distance of the stroke
                start[stroke] = distanceToGoal;
                distance[stroke] = Distance(velocity, AngleInRadians(angle));

                try
                {
                    // Set end of stroke and distance to goal for next stroke
                    end[stroke] = start[stroke] - distance[stroke];
                    distanceToGoal = end[stroke];

                    // Check if the distance to goal are less then zero
                    if (distanceToGoal < 0.0)
                    {
                        // Convert end of stroke and distance to goal to greater than zero
                        distanceToGoal *= -1;
                        end[stroke] *= -1;

                        if (distanceToGoal > (courceRange - initLocationToGoal))
                            throw new OutOfBoundsException("The out of bounds");
                    }

                    // Check if the user had make too many strokes and don't get the ball in the goal
                    if (stroke >= 9 && distanceToGoal > 10.0)
                        throw new ForManyStrokeException("Too many strokes are done");

                    // Check if the ball are close the goal for gimme
                    if (distanceToGoal < 10.0)
                        break;
                }
                catch(OutOfBoundsException ex)
                {
                    Console.WriteLine(ex.Message);
                    IsRun = false;
                }
                catch(ForManyStrokeException ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
                stroke++;
            }
            Console.WriteLine("********** The game is over **********");

            for(int i = 0;i < stroke;i++) 
            {
                Console.WriteLine($"Stroke {i + 1} started in {Math.Round(start[i], 0)} to goal and end in {Math.Round(end[i], 0)}, which are a stroke by distance of {Math.Round(distance[i], 0)}.");
            }
        }

        /// <summary>
        /// Convert angle in grade to angle in radians
        /// </summary>
        /// <param name="angle">Angle in grades</param>
        /// <returns>Angle in radians</returns>
        static double AngleInRadians(double angle) => Math.PI / 180 * angle;
        /// <summary>
        /// Calculate the distance the golfball flying
        /// </summary>
        /// <param name="velocity">Speed in m/s</param>
        /// <param name="angleInRadians">Angle in radians</param>
        /// <returns>Distance in meter</returns>
        static double Distance(double velocity, double angleInRadians) => Math.Pow(velocity, 2) / GRAVITY * Math.Sin(2 * angleInRadians);
    }
}
