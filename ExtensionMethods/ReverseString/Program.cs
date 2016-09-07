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
            Console.WriteLine("Enter a word: ");
            string word = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine(word.ReverseString());
            Console.WriteLine();
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
            chars.Reverse();

            string reversed = string.Empty;
            foreach(char c in chars)
            {
                reversed += c;
            }
            return reversed;
        }
    }
}
