using System;
using System.Collections.Generic;
using System.Linq;

namespace CSVReaderLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"C:\Repos\CsvReaderLINQ\CountryPopulations.csv";

            Reader csvreader = new Reader(filepath);

            List<Country> countries = csvreader.ReadAllCountries();


            foreach (Country country in countries.Where(x => !x.Name.Contains(',')).Take(20))
            {
                Console.WriteLine($"{Formatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
            Console.WriteLine($"{countries.Count} countries");
        }
    }
}
