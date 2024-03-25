using System.Runtime.InteropServices;

namespace hackerrank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            //FizzBuzz.Run();

            start = DateTime.Now;
            StaleServerCount.RunBruteforce();
            Console.WriteLine("Brute force: "+(DateTime.Now - start).TotalMicroseconds);
            StaleServerCount.Run();
            start = DateTime.Now;
            Console.WriteLine("Optimize :"+(DateTime.Now - start).TotalMicroseconds);

            //start = DateTime.Now;
            //LowestSalePrice.RunBruteForce();
            //Console.WriteLine((DateTime.Now - start).TotalMicroseconds);
            //start = DateTime.Now;
            //LowestSalePrice.Run();
            //Console.WriteLine((DateTime.Now - start).TotalMicroseconds);
            
            //Turnstile.Run();
        }
    }
}
