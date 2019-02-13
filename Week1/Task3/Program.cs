using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            // number of integers &transfer to integer type
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            string[] s = Console.ReadLine().Split();

            //string of nums convert in int type && elements of array
            for (int i = 0; i < n; i++)
                a[i] = int.Parse(s[i]);

            //print 
            for (int i = 0; i < n; i++)
                Console.Write(a[i] + " " + a[i] + " ");

            Console.ReadKey();
        }
    }
}
