using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read the string and convert into integer type
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            //Read new string
            // By space splitted elements set down in array of string 
            string[] s = Console.ReadLine().Split();
            List<int> list = new List<int>();
            //Transfer each element of string into integer type
            for (int i = 0; i < n; i++)
                a[i] = int.Parse(s[i]);
            //Make double loop to check number prime or not
            for (int i = 0; i < n; i++)
            {
                // 1 - is not prime number
                if (a[i] == 1)
                    continue;

                bool ok = true;
                for (int j = 2; j < a[i]; j++)
                {
                    if (a[i] % j == 0)
                    {
                        ok = false;
                        break;
                    }
                }
                // Add all primes into dynamic array, i.e. list
                if (ok)
                    list.Add(a[i]);
            }
            //Print number of primes
            Console.WriteLine(list.Count);
            //Print number of primes too
            for (int i = 0; i < list.Count; i++)
                Console.Write(list[i] + " ");
            Console.ReadKey();
        }
    }
}
