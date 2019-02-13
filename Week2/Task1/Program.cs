using System;
using System.Collections.Generic;
using System.IO;

namespace Task1
{
    class Program
    {
        // create the function of palindrom
        //check extreme elements 
        static string Palind(string s, int l, int r)
        {
            // if nothing has happened through all checking, print "Yes", which means it is a palindrom and stop testing
            if (l >= r)
            {
                return "Yes";
            }
            // if elements aren't equal, print "No" and stop checking
            if (s[l] != s[r])
            {
                return "No";
            }
            //move with both sides to the center
            return Palind(s, l + 1, r - 1);
        }

        static void Main(string[] args)
        {
            //read from the file
            StreamReader st = new StreamReader("input.txt");
            string s = st.ReadLine();
            //write the output in other file
            StreamWriter w = new StreamWriter("output.txt");
            //call the function and set initial parameters
            w.WriteLine(Palind(s, 0, s.Length - 1));
            // close the path
            w.Close();
            Console.ReadKey();
        }
    }
}
