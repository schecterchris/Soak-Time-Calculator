using System;
using System.Linq;

namespace soaktimecalcconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            DateTime currenttime = DateTime.Now;
            string atheathours;
            string atheatmins;
            string soak;
            string toleranceover;
            string toleranceunder;

            //Get user input
            Console.WriteLine("Enter at heat date ("+currenttime.ToString("MM/dd/yyyy")+" for example)");
            DateTime inputtedDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter job at heat time on a 24 hour clock:");
            string atheattime = Console.ReadLine();

            int[] intArray = new int[atheattime.Length];
            for (int i=0; i< atheattime.Length; i++){
                string val = atheattime[i].ToString();
                intArray[i] = int.Parse(val);
            };

            atheathours = intArray[0].ToString()+intArray[1].ToString();
            atheatmins = intArray[2].ToString() + intArray[3].ToString();


            Console.WriteLine("Enter soak time:");
            soak = Console.ReadLine();

            Console.WriteLine("Enter time tolerance overrun:");
            toleranceover = Console.ReadLine();

            Console.WriteLine("Enter time tolerance underrun:");
            toleranceunder = Console.ReadLine();

            //Add some space between user input and the program output.
            Console.WriteLine("\n\n\n");

            //Converted variables for new datetime object created with the at heat time in mind.
            int hours = Convert.ToInt32(atheathours);
            int minutes = Convert.ToInt32(atheatmins);
            int seconds = 00;
            var atheatobj = new DateTime(inputtedDate.Year, inputtedDate.Month, inputtedDate.Day, hours, minutes, seconds);
          
            //Get a timespan object representing the difference between the current time and at heat time.
            TimeSpan difference = currenttime - atheatobj;

            //Write total at heat time in minutes
            Console.WriteLine(difference.TotalMinutes.ToString() + " minutes have elapsed at heat.\n");

            //Subtract soak time from total time to get the amount of minutes needed to soak
            int timerval = Convert.ToInt32(soak) - Convert.ToInt32(difference.TotalMinutes);

            //High and low timer values utilizing the time tolerance
            //The -2 and +2 are to account for untimeliness in setting the timer. 
            //Just narrowing the window of the tolerance makes the run safer.
            //No one actually sets the timer that close to the tolerance.
            int timerhigh = timerval + Convert.ToInt32(toleranceover) - 2;
            int timerlow = timerval - Convert.ToInt32(toleranceunder) + 2;

            //Print what time the timer should be set to
            Console.WriteLine("Set timer between "+timerlow.ToString()+" and "+timerhigh.ToString()+" minutes.\n");

            Console.WriteLine("Soak time ignoring the time tolerances:" + timerval.ToString());

            Console.ReadLine();

        }
    }
}