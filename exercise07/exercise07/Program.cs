using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise07
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Student> students = new Queue<Student>();
            List<string> lastnames = new List<string>() { "young", "smith", "nelson", "ingamells", "gibson", "almond", "abrams", "niederschmidt", "ashbury" };
            List<string> firstnames = new List<string>() { "mark", "bobby", "axel", "ivan", "eric", "tom", "anne", "cindy", "robert", "alex", "becky", "carl", "rupert", "joanne" };
            Random rnd = new Random();

            //generate random students based on lists containning pre-fixed firstnames and lastnames
            Console.WriteLine("WELCOME TO SCHOOL");
            Console.WriteLine("------------------");
            for (int i = 0; i < 10; i++)
            {
                //retrieve random index between 0 and total amount of values in the list (count)
                int rndFirstname = rnd.Next(0, firstnames.Count);
                int rndLastname = rnd.Next(0, lastnames.Count);

                //uses the random index to access an existing value from list
                string firstname = firstnames[rndFirstname];
                string lastname = lastnames[rndLastname];

                //generates a random student with random firstname and lastname for every iteration
                Student currentStudent = new Student(firstname, lastname);
                students.Enqueue(currentStudent);//adding current student to the queue

                //print the first student in FIFO
                System.Threading.Thread.Sleep(600);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine((i + 1) + ": " + currentStudent.firstName + " " + currentStudent.lastName + " :" + currentStudent.studiesCompleted);
                Console.ResetColor();
            }

            //finnish studies one student at a time FIFO
            Console.WriteLine("------------------");
            Console.WriteLine("GRADUATION YEAR");
            int j = 1;
            foreach (Student s in students)
            {
                System.Threading.Thread.Sleep(600);
                s.studiesCompleted = true;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(j + ": " + s.firstName + " " + s.lastName + " :" + s.studiesCompleted);
                Console.ResetColor();
                j++;
            }

        }
    }
}
