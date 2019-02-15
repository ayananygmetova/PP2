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
            
            //repeated elements of array
            int[] a2 = new int[2 * n];
            int k = 0;
            for (int i=0; i<n; i++)
            {
                a2[k] = a[i];
                k++;
                a2[k] = a[i];
                k++;
            }
            //print 
            for (int i = 0; i < a2.Length; i++)
                Console.Write(a2[i]  + " ");

            Console.ReadKey();
        }
    }
}
