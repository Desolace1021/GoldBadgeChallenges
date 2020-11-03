using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {   
                    Console.Write("Enter your birtdate (mm/DD/YYYY)...: ");
                    DateTime birthDate = DateTime.Parse(Console.ReadLine());

                    int Days = (DateTime.Now.Year * 365 + DateTime.Now.DayOfYear) - (birthDate.Year * 365 + birthDate.DayOfYear);
                    int Years = Days / 365;
                    string message = (Days >= 365) ? "Your age: " + Years + " years" : "Your age: " + Days + " days";

                    Console.WriteLine(message);
                }
                catch
                {
                    Console.WriteLine("You have entered an invalid date.\n");
                }

                Console.WriteLine("Exit? (y/n)");
                string userValue = Console.ReadLine();

                if (userValue == "y")
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}