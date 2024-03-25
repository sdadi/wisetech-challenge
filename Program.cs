using System.Runtime.InteropServices;

namespace hackerrank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FizzBuzz.Run();
            //StaleServerCount.Run();
            DateTime start = DateTime.Now;
            LowestSalePrice.RunBruteForce();
            Console.WriteLine((DateTime.Now - start).TotalMicroseconds);
            start = DateTime.Now;
            LowestSalePrice.Run();
            Console.WriteLine((DateTime.Now - start).TotalMicroseconds);
            //Turnstile.Run();
        }
    }
}
