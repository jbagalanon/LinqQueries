using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
           

            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee {Id = 1, Name = "Joms"},
                new Employee {Id = 2, Name = "Sem"},
                new Employee {Id = 3, Name = "Richie"}
            };

            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee {Id = 4, Name = "Shrek"}
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
                Console.WriteLine(employee.Name);
                Console.WriteLine("");

            }
 
      
        }

        private static bool NameStartsWithS(Employee employee)
        {
            return employee.Name.StartsWith("S"); 
        }
    }
}
