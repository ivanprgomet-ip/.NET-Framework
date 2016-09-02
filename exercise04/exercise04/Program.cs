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
            studentGrades.Add("Joe", 77);
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

            //check for a specific key (student) in the dictionary
            string searchStudent = "Anna";
            Console.WriteLine(studentGrades.ContainsKey(searchStudent)?"The dictionary contains student "+ searchStudent : "the dictionary doesnt contain the student "+ searchStudent);

            //check for specific grade in dictionary and count how many students have that grade if any
            int searchGrade = 98;
            int instances = 0;
            foreach(KeyValuePair<string,int> sg in studentGrades)
            {
                if (sg.Value.Equals(searchGrade))
                    instances++;
            }
            if (instances != 0)
                Console.WriteLine($"{instances} student(s) have the grade {searchGrade}");
            else
                Console.WriteLine($"No student(s) found with the grade {searchGrade}");

            //remove keyvaluepair where student name matches
            string studentToRemove = "ivan";
            Console.WriteLine(studentGrades.Remove(studentToRemove)?studentToRemove+" was successfully removed":"A student named "+studentToRemove+" was not found and could thus not be removed");

            Console.WriteLine();

            //loop through dictionary and print key value pairs 
            foreach (KeyValuePair<string,int> sg in studentGrades)
            {
                Console.Write($"{sg.Key}: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" {sg.Value}p");
                Console.ResetColor();
            }

            //some more dictionary methods to demo
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"There is a total of {studentGrades.LongCount()} students in the class");

            //get the student name which has the highest points
            string bestStudent = string.Empty;
            foreach(KeyValuePair<string,int> kvp in studentGrades)
            {
                if(kvp.Value.Equals(studentGrades.Values.Max()))
                {
                    bestStudent = kvp.Key;
                }
            }
            Console.WriteLine($"The student with the highest points is {bestStudent} and has {studentGrades.Values.Max()} in score");
            Console.ResetColor();
        }
    }
    //TODO: bonus , make icomparer class that sorts on names
}
