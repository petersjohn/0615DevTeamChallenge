using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0615_CLASS_NOTES
{
    class Program
    {
        static void Main(string[] args)
        {
            Person nick = new Employee
            {
               Name.
            }
            
        }
    }

    class Person
    {
        public string Name { get; set; }
        public DateTime BirtDate { get; set; }
        public int HeightInCentimeters { get; set; }
        public string Gender { get; set; }

        public void Poop()
        {
            Console.WriteLine("One sec, I'm almost done.");
        }

    }

    class Employee : Person
    {
        public string Title { get; set; }

        public void ClockIn()
        {
            Console.WriteLine("Clocking In");
        }


    }
}
