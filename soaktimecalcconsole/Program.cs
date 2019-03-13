using System;

namespace soaktimecalcconsole
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime currenttime = DateTime.Now;

            string atheathours;
            string atheatmins;

            string soak;
            string toleranceover;
            string toleranceunder;

            Console.WriteLine("Enter at heat date ("+currenttime.ToString("MM/dd/yyyy")+" for example)");
            DateTime inputtedDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter job at heat hour:");
            atheathours = Console.ReadLine();

            Console.WriteLine("Enter job at heat minute:");
            atheatmins = Console.ReadLine();

            Console.WriteLine("Enter soak time:");
            soak = Console.ReadLine();

            Console.WriteLine("Enter time tolerance overrun:");
            toleranceover = Console.ReadLine();

            Console.WriteLine("Enter time tolerance underrun:");
            toleranceunder = Console.ReadLine();

            
            int hours = Convert.ToInt32(atheathours);
            int minutes = Convert.ToInt32(atheatmins);
            int seconds = 00;
            var atheatobj = new DateTime(inputtedDate.Year, inputtedDate.Month, inputtedDate.Day, hours, minutes, seconds);
          

            TimeSpan difference = currenttime - atheatobj;

            Console.WriteLine(difference.TotalMinutes.ToString() + " minutes have elapsed at heat.");

            int timerval = Convert.ToInt32(soak) - Convert.ToInt32(difference.TotalMinutes);

            int timerhigh = timerval + Convert.ToInt32(toleranceover) - 2;
            int timerlow = timerval - Convert.ToInt32(toleranceunder) + 2;

            Console.WriteLine("Set timer between "+timerlow.ToString()+" and "+timerhigh.ToString()+" minutes.");

            Console.ReadLine();
        }
    }
}