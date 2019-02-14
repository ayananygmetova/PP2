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
            //Creating directory path1
            string path1 = @"C:/Users/Ayana/Documents/Proj";
            DirectoryInfo dir = Directory.CreateDirectory(path1);
            //Creating file in folder - proj1
            FileInfo f = new FileInfo(@"C:/Users/Ayana/Documents/Proj/Info.txt");
            if (!f.Exists) {
                f.Create();
            }
            //Create other folder in which the file will be coped
            string path2 = @"C:/Users/Ayana/Documents/Proj2";
            DirectoryInfo dir2 = Directory.CreateDirectory(path2);
            if (!dir2.Exists) {
                dir2.Create();
            }
            // Coping the file to folder proj2
            File.Copy(@"C:/Users/Ayana/Documents/Proj/Info.txt", @"C:/Users/Ayana/Documents/Proj2/Info.txt");
            //delete original file in proj1
            File.Delete(@"C:/Users/Ayana/Documents/Proj/Info.txt");
        }
    }
}