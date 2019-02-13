using System;
using System.Collections.Generic;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //read the information
            StreamReader st = new StreamReader("input.txt");
            StreamWriter w = new StreamWriter("output.txt");
            string[] s = st.ReadLine().Split();
            int[] a = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                a[i] = int.Parse(s[i]);
            }
            for (int i = 0; i < a.Length; i++)
            {
                //make the variable for testing num is prime or not
                bool ok = true;
                // 1 - isn't prime, it has one divider
                if (a[i] == 1)
                {
                    continue;
                }
                for (int j = 2; j < a[i]; j++)
                {
                    if (a[i] % j == 0)
                    {
                        ok = false;
                    }
                }
                // print all primes
                if (ok)
                {
                    w.Write(a[i] + " ");
                }
            }
            w.Close();
        }
    }
}
