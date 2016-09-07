using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            //INCLASS EX 1
            Console.WriteLine("Enter a word: ");
            string word = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine(word.ReverseString());
            Console.WriteLine();

            //INCLASS EX 2
            List<Person> persons = new List<Person>()
            {
                new Person("ivan","prgomet","plöjargränd", "24"),
                new Person("Mark","Stevens","5th Avenue","42"),
                new Person("Cindy","Kellson","8th Avenue","42"),
                new Person("Bobby","Smith","CrystalStreet","42"),
                new Person("Kelly","Schmidt","19th Avenue","42"),
            };

            Console.WriteLine("Search on Firstname: ");
            string search = Console.ReadLine();

            Person result = persons.SearchPerson(search);

            if(result==null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Person not found...");
                Console.ReadKey();
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Fullname: {result.Firstname}, {result.Lastname}, adress: {result.Adress}, age: {result.Age}");
                Console.ReadKey();
                Console.ResetColor();
            }



            //INCLASS EX 3
            Console.WriteLine("__________________________");
            Console.WriteLine("BEFORE SORTING ON FIRSTNAME");
            foreach(Person p in persons)
            {
                Console.WriteLine($"Fullname: {p.Firstname}, {p.Lastname}, adress: {p.Adress}, age: {p.Age}");
            }
            Console.WriteLine("__________________________");
            Console.WriteLine("AFTER SORTING ON FIRSTNAME");
            persons.Sort();
            foreach (Person p in persons)
            {
                Console.WriteLine($"Fullname: {p.Firstname}, {p.Lastname}, adress: {p.Adress}, age: {p.Age}");
            }

        }
    }
    static class StringExtensions
    {
        public static string ReverseString(this string s)
        {
            List<char> chars = new List<char>();
            foreach(char c in s)
            {
                chars.Add(c);
            }

            List<char> reversedChars = new List<char>();
            for (int i = chars.Count-1; i >= 0; i--)
            {
                reversedChars.Add(chars[i]);
            }

            string reversed = string.Empty;
            foreach(char c in reversedChars)
            {
                reversed += c;
            }
            return reversed;
        }
    }
}
