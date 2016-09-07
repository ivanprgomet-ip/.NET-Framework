using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    public class Person
    {
        public string Firstname;
        public string Lastname;
        public string Adress;
        public string Age;

        public Person()
        {

        }
        public Person(string firstname, string lastname, string adress, string age)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Adress = adress;
            this.Age = age;
        }

    }
    public static class PersonExtensions
    {
        public static Person SearchPerson(this List<Person> persons, string searchName)
        {
            foreach(Person p in persons)
            {
                if(p.Firstname.ToUpper() == searchName.ToUpper())
                {
                    return p;
                }
            }
            return null;
        }
    }
}
