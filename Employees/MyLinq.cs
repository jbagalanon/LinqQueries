﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public static  class MyLinq
    {
        public static int Count<T>(IEnumerable<T>sequence)
        {
            int count = 0;
            foreach (var item in sequence)
            {
                count += 1;
            }

            return count;

        }
    }
}
