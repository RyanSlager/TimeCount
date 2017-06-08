using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DurationFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            var reg = new Regex(@"\d{1,2}\/\d{1,2}\/\d{1,4}\s{0,}\,\s{0,}\d{1,2}\/\d{1,2}\/\d{1,4}");

            Console.WriteLine("Please enter two dates in dd/mm/yyyy format seperated by a comma");
            string datesIn = Console.ReadLine();

            string tempDate = " ";
            bool regMatch = reg.IsMatch(datesIn);

            while (reg.IsMatch(datesIn) != true);
            {
                Console.WriteLine("Sorry, please make sure to enter your dates in dd/mm/yyyy format seperated by a comma.");
                tempDate.Replace(" " , Console.ReadLine());
                datesIn.Replace(datesIn, tempDate);
            }

            String[] dates = datesIn.Split(',');

            foreach (var date in dates)
                Console.WriteLine(date.Trim());
            Console.ReadLine();
        }
    }
}
