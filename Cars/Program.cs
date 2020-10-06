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
            var cars = ProcessCars("Fuel.csv");
            var manufacturers = ProcessManufacturers("manufacturers.csv");

            var query = from car in cars
                group car by car.Manufacturer
                into carGroup
                select new
                {
                    Name = carGroup.Key,
                    Max = carGroup.Max(c => c.Combined),
                    Min = carGroup.Min(c => c.Combined),
                    Avg = carGroup.Average(c => c.Combined)

                }
                into result
                orderby result.Max descending
                select result;


            var query2 = manufacturers.GroupJoin(cars, m => m.Name,
                    c => c.Manufacturer, (m, g) =>
                        new
                        {
                            Manufacturer = m,
                            Cars = g
                        })
                .GroupBy(m => m.Manufacturer.Headquarters);


            foreach (var result in query)
            {
                Console.WriteLine($"{result.Name} ");
                Console.WriteLine($"\t Max: {result.Max} ");
                Console.WriteLine($"\t Min: {result.Min} ");
                Console.WriteLine($"\t Average: {result.Avg} ");

              
            }



        }

        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            var query = File.ReadAllLines(path)
                .Where(l => l.Length > 1)
                .Select(l =>
                {
                    var columns = l.Split(',');
                    return new Manufacturer
                    {
                        Name = columns[0],
                        Headquarters = columns[1],
                        Year = int.Parse(columns[2])
                    };
                });

            return query.ToList();
        }

        private static List<Car> ProcessCars(string path)
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

