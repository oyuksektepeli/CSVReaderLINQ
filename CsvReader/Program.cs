using System;
using System.Collections.Generic;

namespace CSVReaderDataManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"C:\Repos\CSVReaderDataManipulation\CountryPopulations.csv";

            Reader csvreader = new Reader(filepath);

            List<Country> countries = csvreader.ReadAllCountries();
            csvreader.RemoveCommaCountries(countries);

            Console.WriteLine("Enter no. of countries to display> ");
            bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);
            if (!inputIsInt || userInput <= 0)
            {
                Console.WriteLine("You must type in a +ve integer. Exiting");
                return;
            }

            int maxToDisplay = userInput;

            //foreach(Country country in countries)
            //for (int i =0; i<countries.Count; i++)
            for (int i = countries.Count -1; i>=0; i--)
            {
                int displayIndex = countries.Count - 1 - i;
                if (displayIndex > 0 && (displayIndex % maxToDisplay == 0))
                {
                    Console.WriteLine("Hit return to continue, anything else to quit>");
                    if (Console.ReadLine() != "")
                        break;
                }

                Country country = countries[i];
                Console.WriteLine($"{displayIndex+1}: {Formatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
            Console.WriteLine($"{countries.Count} countries");
        }
    }
}
