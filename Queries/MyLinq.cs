using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{
    public static class MyLinq
    {


        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var result = new List<T>();

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    /*    You use a yield return statement to return each element one at a time. ...
                        When a yield return statement is reached in the iterator method, expression 
                            is returned, and the current location in code is retained. Execution is
                            restarted from that location the next time that the iterator function is called. */
                    yield return item;
                }
            }


        }
    }
}
