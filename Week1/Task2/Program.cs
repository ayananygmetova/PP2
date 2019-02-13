using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    
    class Student
    {
        public string name;
        public string id;
        public long year;

        // Constructor with two parameters
        public Student(string name, string id) 
        {
            this.name = name;
            this.id = id;

        }
        //Print the result
        public void Print()
        {
            Console.WriteLine(name + " " + id + " " + year );
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            //give values for constructor
            Student st = new Student("Ayana", "11111111");
            //give the value for the year
            st.year = 2019;
            //- increment of the year
            st.year++; 
            st.Print();
        }
    }
}
