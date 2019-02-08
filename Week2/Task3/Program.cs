using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    class Program
    {
        public static void Print(int lvl)
        {
            for (int i = 0; i < lvl; i++)
                Console.Write("     ");
        }
        public static void Direct(DirectoryInfo d, int lvl)
        {
            DirectoryInfo[] dir = d.GetDirectories();
            FileInfo[] f = d.GetFiles();
            Print(lvl);
            foreach (FileInfo fi in f)
            {
                Console.WriteLine("     " + fi.Name);
            }
            foreach (DirectoryInfo di in dir)
            {
                Console.WriteLine("     " + di.Name);
                Direct(di, lvl++);
            }


        }
        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo("/Users/Ayana/Documents/PP2/Week1");
            Console.WriteLine(d.Name);
            Direct(d, 0);
            Console.ReadKey();
        }
    }
}
