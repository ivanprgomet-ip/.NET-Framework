using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    public class Person : IComparable
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

        public int CompareTo(object other)
        {
            Person p = (Person)other;
            return this.Firstname.CompareTo(p.Firstname);
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
        public static void SortList(this List<Person> persons)
        {
            persons.Sort();
            Console.WriteLine("List sorted by firstname");
        }
        public static void SortListOnFirstname(this List<Person> persons)
        {
            //NOT IMPLEMENTED
        }
    }
}
