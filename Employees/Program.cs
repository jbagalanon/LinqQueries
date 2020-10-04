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
           

            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee {Id = 1, Name = "Joms"},
                new Employee {Id = 2, Name = "Jem"},
                new Employee {Id = 3, Name = "Richie"}
            };

            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee {Id = 4, Name = "Alex"}
            };


            foreach (var person in developers)
            {
                Console.WriteLine(person.Name);
            }

            IEnumerator<Employee> enumerator = developers.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }
        }
    }
}
