using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
        class FarManager {
        string path;
        int cursor,sz;
        bool ok;
        
        public FarManager(string path)
        {
            this.path = path;
            cursor = 0;
            ok = true;
        }

        public void Color(FileSystemInfo fs, int index)
        {
            //Colour of cursor
            if (cursor == index) 
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;

            }
            else if (fs.GetType() == typeof(DirectoryInfo))
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (fs.GetType() == typeof(FileInfo))
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }

        public void Show()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            DirectoryInfo directory = new DirectoryInfo(path);
            //folder which has folders and files(PP2)
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            sz = fs.Length;
            //Print all folders and files
            for (int i=0,k=0; i<fs.Length; i++)
            {
                if (ok == false && fs[i].Name.StartsWith("."))
                {
                    continue;
                }
                Color(fs[i],i);
                Console.WriteLine((fs[i].Name));
                k++;
            }
        }
        // Moving cursor
        public void Up()
        {
            cursor--;
            if (cursor < 0)
                cursor = sz - 1;
        }
        public void Down()
        {
            cursor++;
            if (cursor >= sz)
                cursor = 0;
        }
        public void Start()
        {
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            while(consoleKey.Key != ConsoleKey.Escape)
            {
                Show();
                consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.UpArrow)
                    Up();
                if (consoleKey.Key == ConsoleKey.DownArrow)
                    Down();
                if (consoleKey.Key == ConsoleKey.RightArrow)
                    ok = false;
                if (consoleKey.Key == ConsoleKey.LeftArrow)
                    ok = true; 
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args) {
            string path = "C:/Users/Ayana/Documents/PP2";
        Task1.FarManager farManager = new Task1.FarManager(path);
        farManager.Start();
        }
    }

