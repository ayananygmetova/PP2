using System;
using System.Collections.Generic;
using System.IO;

namespace Task1
{
    class Program
    {

        static string Palind(string s, int l, int r)
        {
            if (l >= r)
            {
                return "Yes";
            }
            if (s[l] != s[r])
            {
                return "No";
            }
            return Palind(s, l + 1, r - 1);
        }

        static void Main(string[] args)
        {
            StreamReader st = new StreamReader("input.txt");
            string s = st.ReadLine();
            StreamWriter w = new StreamWriter("output.txt");
            w.WriteLine(Palind(s, 0, s.Length - 1));
            w.Close();
            Console.ReadKey();
        }
    }
}
