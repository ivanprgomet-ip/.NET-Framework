using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise07
{
    class Student : Person
    {
        public bool studiesCompleted;

        public Student(string firstname, string lastname) : base(firstname, lastname)
        {
            //when new student gets created, studies just started, and thus 
            //are not completed
            studiesCompleted = false; 
        }
    }
}
