using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path1 = "/Users/Ayana/Documents/Proj";
            DirectoryInfo dir = Directory.CreateDirectory(path1);
            File.Create("/Users/Ayana/Documents/Proj/Info.txt");
            string path2 = "/Users/Ayana/Documents/Proj2";
            DirectoryInfo dir2 = Directory.CreateDirectory(path2);
            File.Copy("/Users/Ayana/Documents/Proj/Info.txt", "/Users/Ayana/Documents/Proj2/Info.txt");
            File.Delete("path1/Info.txt");

        }
    }
}