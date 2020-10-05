using System;
using System.CodeDom;
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

            var query = from car in cars
                where car.Manufacturer == "BMW" && car.Year == 2016
                orderby car.Combined descending, car.Name ascending
                select new
                {
                    car.Manufacturer,
                    car.Name,
                    car.Combined
                };

            var result = cars.SelectMany(c => c.Name);


            foreach (var character in result)
            {
               
                    Console.WriteLine(character);
                   

            }
            Console.ReadKey();



        }

        private static List<Car> ProcessFile(string path)
        {


            var query = File.ReadAllLines(path)
                .Skip(1).Where(l => l.Length > 1).ToCar();

            return query.ToList();

            //Note: nasa 6 of number 4 na ako
        }
    }


    //this is another class
    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)

        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new Car

                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3]),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7])

                };
            }
        }

    }

}

