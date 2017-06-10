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
            //gets dates from user
            Console.WriteLine("Please enter two dates in mm/dd/yyyy format seperated by a comma");
            string datesIn = Console.ReadLine();

            //string array formats contains the accepted date formats
            string[] formats = {"M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt",
                         "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss",
                         "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt",
                         "M/d/yyyy h:mm", "M/d/yyyy h:mm",
                         "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm", "MM/dd/yyyy", "M/d/yyyy","M/dd/yyyy", "MM/d/yyyy"};

            //creates an empty list of strings which are used in the foreach loop below
            var parsedDates = new List<DateTime>();

            //splits user input into an array of dates
            String[] dates = datesIn.Split(',');

            //while loop makes sure that there are only two dates provided by the user
            while(dates.Length != 2)
            {   
                Console.WriteLine("Please enter only two dates, in the mm/dd/yyyy format seperated by a comma");
                dates = Console.ReadLine().Split(',');
            }
                
            // Sets a counter to count how many times the foreach loop is executed
            int count = 0;
          
            //foreach loop loops through the dates entered and ensures that they are in the correct format. 
            //if the dates are not in the correct format, the user is prompted to enter the dates again
            foreach (string date in dates)
            {
                DateTime parsedDate;
                
                if (DateTime.TryParseExact(date.Trim(), formats, new CultureInfo("es"), DateTimeStyles.None, out parsedDate))
                {
                    parsedDates.Add(parsedDate);
                }
                else
                {
                    Console.WriteLine("Sorry, your dates need to be in mm/dd/yyyy format seperated by a comma.");
                    Console.WriteLine("Please enter the {0} date in the correct format. ", count == 0 ? "first" : "second");
                    while (!DateTime.TryParseExact(Console.ReadLine().Trim(), formats, new CultureInfo("es"), DateTimeStyles.None, out parsedDate))
                        Console.WriteLine("Please enter the {0} date in the correct format. ", count == 0 ? "first" : "second");
                    parsedDates.Add(parsedDate);
                }
                count++;
            }

            //checks that the dates are in the correct order in parsedDates
            if (parsedDates[0] > parsedDates[1])
                parsedDates.Reverse();


            //assigns dates to their own variables 
            var a = parsedDates[0];
            var b = parsedDates[1];

            //math is done to determine time elapsed between the two provided dates
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