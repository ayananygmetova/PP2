using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class FarManager
    {
        public string path;
        public int cursor, sz;
        public bool ok;
        DirectoryInfo directory = null;
        FileSystemInfo currentFs = null;

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
                currentFs = fs; // to remember where is cursor 
            }
            else if (fs.GetType() == typeof(DirectoryInfo)) //coloring directories
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (fs.GetType() == typeof(FileInfo))
            {
                Console.BackgroundColor = ConsoleColor.Green; //coloring files
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }

        //Function which allows to see folders and files
        public void Show()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            directory = new DirectoryInfo(path);
            //folder which has folders and files(PP2)
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            //array of folders only
            FileSystemInfo[] fs1 = directory.GetDirectories();
            //array of files only
            FileSystemInfo[] fs2 = directory.GetFiles();
            sz = fs1.Length + fs2.Length; //unit lenght
            DirectoryInfo[] dir = directory.GetDirectories();
            //Print all folders and files
            //k - is the index of cursor indepent from hidden or unblock directory
            int h = 0; //index for files
            for (int i = 0, k = 0; i < fs1.Length; i++)
            {
                if (ok == false && fs1[i].Name.StartsWith("."))
                    continue;
                Color(fs1[i], k);
                Console.WriteLine(k + 1 + ". " + fs1[i]);
                k++;
                h++;
            }
            for (int i = 0; i < fs2.Length; i++)
            {
                if (ok == false && fs2[i].Name.StartsWith("."))
                    continue;
                Color(fs2[i], h);
                Console.WriteLine(h + 1 + ". " + fs2[i]);
                h++;
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


        //Calculating of size, which depends on hidden folders
        public void CalcSize()
        {
            directory = new DirectoryInfo(path);
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            sz = fs.Length;
            if (ok == false)
                for (int i = 0; i < fs.Length; i++)
                    if (fs[i].Name[0] == '.')
                        sz--;                   //decrease the size

        }


        //main function, where all actions happen
        public void Start()
        {
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            while (consoleKey.Key != ConsoleKey.Escape)
            {
                Show();
                CalcSize();
                consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.UpArrow)
                    Up();
                if (consoleKey.Key == ConsoleKey.DownArrow)
                    Down();
                if (consoleKey.Key == ConsoleKey.RightArrow)
                {
                    ok = false;
                    cursor = 0;
                }
                if (consoleKey.Key == ConsoleKey.LeftArrow)
                {
                    cursor = 0;
                    ok = true;
                }
                if (consoleKey.Key == ConsoleKey.Enter)
                {
                    if (currentFs.GetType() == typeof(DirectoryInfo))     //to open directories
                    {
                        cursor = 0;
                        path = currentFs.FullName;

                    }
                    if (currentFs.GetType() == typeof(FileInfo))        //to open files and read
                    {
                        StreamReader st = new StreamReader(currentFs.FullName);
                        Console.WriteLine(st.ReadToEnd());
                        st.Close();
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                if (consoleKey.Key == ConsoleKey.Backspace)         //returns back
                {
                    cursor = 0;
                    path = directory.Parent.FullName;
                }
                if (consoleKey.Key == ConsoleKey.D)                 //delete files or directories
                {
                    if (currentFs.GetType() == typeof(FileInfo))
                    {
                        FileInfo fi = new FileInfo(currentFs.FullName);
                        fi.Delete();
                    }
                    if (currentFs.GetType() == typeof(DirectoryInfo))
                    {
                        DirectoryInfo di = new DirectoryInfo(currentFs.FullName);
                        di.Delete(true);
                    }
                }
                if (consoleKey.Key == ConsoleKey.R)                 //renames folders of files
                {
                    if (currentFs.GetType() == typeof(FileInfo))
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        string fiName = Console.ReadLine();
                        File.Move(currentFs.FullName, Path.GetDirectoryName(currentFs.FullName) + "/" + fiName);
                    }

                    if (currentFs.GetType() == typeof(DirectoryInfo))
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        string newdi = Console.ReadLine();
                        Directory.Move(currentFs.FullName, Path.GetDirectoryName(currentFs.FullName) + "/" + newdi);
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:/Users/Ayana/Documents/PP2";
            Task1.FarManager farManager = new Task1.FarManager(path);
            farManager.Start();
        }
    }
}
