using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerrank
{
    internal class FizzBuzz
    {
        internal static void Run()
        {
            Console.WriteLine("Enter Value of 'n'");
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    Console.WriteLine("FizzBuzz");
                else if (i % 3 == 0 && i % 5 != 0)
                    Console.WriteLine("Fizz");
                else if (i % 3 != 0 && i % 5 == 0)
                    Console.WriteLine("Buzz");
                else
                    Console.WriteLine(i);
            }
        }
    }
}
