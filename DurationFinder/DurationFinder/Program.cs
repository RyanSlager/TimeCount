using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DurationFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter two dates in mm/dd/yyyy format seperated by a comma");
            string datesIn = Console.ReadLine();

            string[] formats = {"M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt",
                         "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss",
                         "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt",
                         "M/d/yyyy h:mm", "M/d/yyyy h:mm",
                         "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm", "MM/dd/yyyy", "M/d/yyyy","M/dd/yyyy", "MM/d/yyyy"};

            var parsedDates = new List<DateTime>();

            String[] dates = datesIn.Split(',');

            foreach (string date in dates)
            {
                DateTime parsedDate;
                int count = 0;

                Console.WriteLine(date.Trim());
                if (DateTime.TryParseExact(date.Trim(), formats, new CultureInfo("es"), DateTimeStyles.None, out parsedDate))
                {
                    parsedDates.Add(parsedDate);
                    count++;
                }
                else
                {
                    Console.WriteLine("Sorry, your dates need to be in mm/dd/yyyy format seperated by a comma.");
                }
            }


            if (parsedDates[0] > parsedDates[1])
                parsedDates.Reverse();

            var a = parsedDates[0];
            var b = parsedDates[1];

            var totalMonths = (b.Year - a.Year) * 12 + b.Month - a.Month;
            totalMonths += b.Day > a.Day ? -1 : 0;
            var years = totalMonths / 12;
            var months = totalMonths % 12;
            var days = b.Subtract(a.AddMonths(totalMonths)).Days;

            Console.WriteLine("{0} years, {1} months, and {2} days have elapsed between your two dates.", years, months, days);

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}