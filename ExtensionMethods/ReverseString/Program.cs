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
