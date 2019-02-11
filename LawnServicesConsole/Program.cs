using System;
using System.IO;
using System.Linq;

namespace LawnServicesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("/////////////////////");
            Console.WriteLine("/ Premium Lawns Inc /");
            Console.WriteLine("/////////////////////");
            Console.WriteLine("What Service is being requested?");
            Console.WriteLine("1. Mowing and Edging");
            Console.WriteLine("2. Moving, Edging, Trimming, Mulching, and Pruning");
            Console.WriteLine("3. One Time Clearing an Area");
            Console.WriteLine("4. Other Service");

            var service = Console.ReadLine();

            Console.WriteLine("Address to be serviced?");
            var address = Console.ReadLine();

            var lastline = File.ReadLines("schedule.txt").Last();
            var parts = lastline.Split(' ');
            var lastAppointment = DateTime.Parse(parts[0]);
            lastAppointment.AddMinutes(15);
            if (lastAppointment.Hour > 17)
            {
                lastAppointment.AddDays(1);
                lastAppointment.Add(new TimeSpan(9, 0, 0));
            }

            var appointmentText = Environment.NewLine + lastAppointment.ToShortTimeString() + " " + address;
            File.AppendAllText("schedule.txt", appointmentText);
        }
    }
}
