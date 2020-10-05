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


            var query1 = from car in cars
                         where car.Manufacturer == "BMW" && car.Year == 2016
                         orderby car.Combined descending, car.Name ascending
                         select car;


            /* first options
            var top = cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                .OrderByDescending(c => c.Combined)
                .ThenBy(c => c.Name)
                .Select(c => c)
                .First();

            */
            //second options

            var top = cars
                .OrderByDescending(c => c.Combined)
                .ThenBy(c => c.Name)
                .Select(c => c)
                .First(c=>c.Manufacturer =="BMW" && c.Year==2016);


            Console.WriteLine($"This is the car top efficient {top.Manufacturer} {top.Name}");
            Console.WriteLine();

            var query = cars.OrderByDescending(c => c.Combined)
       .ThenBy(c => c.Name);

            foreach (var car in query1.Take(20))
            {
                Console.WriteLine($"{car.Name} : {car.Combined} ");
            }
        }

        private static List<Car> ProcessFile(string path)
        {
            
            /*
            //first solutiongggggggggggrgggrsesw
            return 
            File.ReadAllLines(path)
                .Skip(1) //skip 1 string array to avoid processing. Partition operator
                .Where(line => line.Length > 1) //if more than 1 this is valid
                .Select(Car.ParseFromCsv) //invoke method from model
                .ToList();
                */

            //recommended implementation

            var query = from line in File.ReadAllLines(path)
                    .Skip(1)
                        where line.Length > 1
                        select Car.ParseFromCsv(line);

            return query.ToList();


            //Note: nasa 6 of number 4 na ako
        }

    }
}
