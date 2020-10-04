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
           
            //takes integers and output integers
            Func<int, int> square= x => x * x;
            Console.WriteLine(square(3));
            Console.WriteLine("End of multiplication function");
            Console.WriteLine();


            //takes two integers and output integers
            Func<int, int, int> add = (int x, int y) => x + y;
            Console.WriteLine(square(add(3,5)));
            Console.WriteLine("End of dual input");
            Console.WriteLine();

            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee {Id = 1, Name = "Joms"},
                new Employee {Id = 2, Name = "Sem"},
                new Employee {Id = 3, Name = "Richie"},
                new Employee {Id = 4, Name = "Roouch"}
            };

            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee {Id = 5, Name = "Shrek"},
                new Employee {Id = 6, Name = "Rick"}
            };

            Console.WriteLine(developers.Count());
            IEnumerator<Employee> enumerator = developers.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }

            foreach (var employee in developers.Where(e
                => e.Name.StartsWith("S")  
            ))
            {
                Console.WriteLine("");
                Console.WriteLine(employee.Name);
              

            }
 
      
        }

        private static bool NameStartsWithS(Employee employee)
        {
            return employee.Name.StartsWith("S"); 
        }
    }
}
