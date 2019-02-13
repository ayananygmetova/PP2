using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            // num of lines
            int n = int.Parse(Console.ReadLine());

            // creating triangular
            for (int i = 1; i <= n; i++)
            {
                //make the column dependence from lines
                for (int j = 0; j < i; j++)
                {
                    Console.Write("[*]");
                }
                // indent for each line
                Console.WriteLine();
            }

        }
    }
}
