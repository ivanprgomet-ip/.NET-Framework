using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackPassword
{
    class Program
    {
        static void Main(string[] args)
        {
            //SIMULATE WAITING
            //while (true)
            //{
            //    for (int i = 0; i <= 10; i++)
            //    {
            //        Console.Clear();
            //        Console.WriteLine(i);
            //        System.Threading.Thread.Sleep(100);
            //    }
            //    break;
            //}

            //BREAK A PASSWORD
            Console.ForegroundColor = ConsoleColor.Cyan;
            List<string> passwords = new List<string>() { "car", "house", "screen", "cba", "kit" };
            Random rnd = new Random();
            int rndIndex = rnd.Next(0, passwords.Count);
            string rndPassword = passwords[rndIndex].ToString();
            Console.WriteLine("A password has been generated");
            Console.WriteLine("_____________________________");

            bool loginSucceded = false;
            int index = 0;

            Console.WriteLine("[1] Manual attempt");
            Console.WriteLine("[2] Crack password");
            string choice = Console.ReadLine();
            string passwordInput = string.Empty;
            while (!loginSucceded)
            {
                switch (choice)
                {
                    case "1":
                        //not implemented 
                        break;
                    case "2":
                        passwordInput = SeedNumberCombinations(index).ToString();//this is where the string conversion happens
                        if (rndPassword == passwordInput)
                        {
                            loginSucceded = true;
                        }
                        break;
                    default:
                        Console.WriteLine("Enter legit input");
                        break;
                }
                if (loginSucceded)
                {
                    Console.WriteLine("Login successful!");
                    Console.ReadKey();
                    break;
                }
                else
                    Console.WriteLine($"Attempt input: {index} = Login failed");
                index++;
            }

            Console.WriteLine(rndPassword);
            Console.WriteLine("_____________________________");
            Console.ResetColor();
            Console.ReadKey();
        }
        private static int SeedNumberCombinations(int index)
        {
            return index;
        }
        private static string SeedCombinations(int index, bool PasswordFound)
        {
            List<string> alphabet = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            if (index < alphabet.Count)
                return alphabet[index];
            else if (index > alphabet.Count)
                return alphabet[0] + alphabet[index];

            return string.Empty;
        }
    }
}
