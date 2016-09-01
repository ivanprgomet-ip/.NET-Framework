using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise02
{
    /// <summary>
    /// Exercise 2 and 3
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // EXERCISE 2

            //ADDING 3 VALUES ONE AT A TIME
            List<int> numbers = new List<int> { 5, 2, 25 };

            //ADDING 6 VALUES AT ONCE
            for(int i = 0; i < 6; i++)
            {
                numbers.Add(i + 1);
            }

            //PRINT INDEX AND CORRESPONDING VALUE IN THE LIST
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine($"index: {i}| value: {numbers[i]}");
            }

            //USE THE CONTAINS METHOD ON THE LIST
            Console.WriteLine(numbers.Contains(25) ? "the list contains the number 25" : "the list doesnt contain the number 25");
            Console.WriteLine(numbers.Contains(23) ? "the list contains the number 23" : "the list doesnt contain the number 23");

            //REMOVE FIRST INSTANCE OF A VALUE THAT HAS A DUPLICATE OR MORE IN THE LIST
            numbers.Sort();
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                    numbers.RemoveAt(i);
            }

            //REMOVE THE VALUE THATS ON INDEX 3 IN THE LIST
            numbers.RemoveAt(3);

            //PRINTING ALL VALUES IN THE LIST USING FOREACH
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
            Console.ResetColor();

            // EXERCISE 3



        }
    }
}
