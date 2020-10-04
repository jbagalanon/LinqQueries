using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("Fuel.csv");
            foreach (var car in cars)
            {
                Console.WriteLine(car.Name);
            }
        }

        private static List<Car> ProcessFile(string path)
        {
            return 
            File.ReadAllLines(path)
                .Skip(1) //skip 1 string array to avoid processing. Partition operator
                .Where(line => line.Length > 1) //if more than 1 this is valid
                .Select(Car.ParseFromCsv) //invoke method from model
                .ToList();
        }

    }
}
