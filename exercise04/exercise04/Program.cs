using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise04
{
    class Program
    {
        static void Main(string[] args)
        {
            //add some key value pairs to the dictionary one at a time
            Dictionary<string, int> studentGrades = new Dictionary<string, int>();
            studentGrades.Add("Mark", 69);
            studentGrades.Add("Simon", 88);
            studentGrades.Add("Anna", 97);
            studentGrades.Add("Lisa", 47);
            studentGrades.Add("Billy", 63);
            studentGrades.Add("Joe", 76);
            studentGrades.Add("Tom", 77);
            studentGrades.Add("Anne", 93);
            studentGrades.Add("Mary", 98);
            studentGrades.Add("Sid", 93);

            //add 3 key values using for loop al at once
            Random rnd = new Random();
            for (int i = 0; i < 3; i++)
            {
                string myStudent = "Student" + i;
                
                int rndGrade = rnd.Next(0, 100);
                studentGrades.Add(myStudent, rndGrade);
            }

            //loop through dictionary and print key values
            foreach(KeyValuePair<string,int> sg in studentGrades)
            {
                Console.Write($"{sg.Key}: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" {sg.Value}p");
                Console.ResetColor();
            }


        }
    }
}
