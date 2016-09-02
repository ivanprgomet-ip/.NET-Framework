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


            List<string> lastnames= new List<string>() { "svensson", "eriksson", "gustaffsson", "prgomet", "niederschmidt", "arneklint" };
            List<string> firstnames = new List<string>() { "ivan","erik","anna","lisa","ruben","robert","ellie","bob","karl","johanna"};

            Student s1 = new Student("ivan", "prgomet");
            Student s2 = new Student("ivan", "prgomet");
            Student s3 = new Student("ivan", "prgomet");
            Student s4 = new Student("ivan", "prgomet");
            Student s5 = new Student("ivan", "prgomet");

        }
    }
}
