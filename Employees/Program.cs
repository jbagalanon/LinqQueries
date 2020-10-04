using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Function Starts
            //takes integers and output integers
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(3));
            Console.WriteLine("End of multiplication function");
            Console.WriteLine();


            //takes two integers and outpyut integers
            Func<int, int, int> add = (int x, int y) => x + y;

            /*
            //alternative solution
            Func<int, int, int> add =( x,  y) =>
            {
                int temp = x + y;
                return temp;
            };
            */

            //Action method always retunr a boolean
            Action<int> write = x => Console.WriteLine(x);

            write(square(add(4, 5)));

            Console.WriteLine(square(add(3, 5)));
            Console.WriteLine("End of dual input");
            Console.WriteLine();
            #endregion

            var developers = new Employee[]
                        {
                new Employee {Id = 1, Name = "Joms"},
                new Employee {Id = 2, Name = "Sem"},
                new Employee {Id = 3, Name = "Richie"},
                new Employee {Id = 4, Name = "Roouch"}
                        };

            var sales = new List<Employee>()
            {
                new Employee {Id = 5, Name = "Shrek"},
                new Employee {Id = 6, Name = "Rick"}
            };


            Console.WriteLine("Beginning of lambda arrange by name");
            var query = developers.Where(e => e.Name.Length == 6)
                .OrderBy(e => e.Name);

            foreach (var employee in query)

            {

                Console.WriteLine(employee.Name);


            }

        }

        private static bool NameStartsWithS(Employee employee)
        {
            return employee.Name.StartsWith("S");
        }
    }
}
