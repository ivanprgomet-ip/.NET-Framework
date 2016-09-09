using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            TraditionalDelegateSyntax();
            AnonymousMethodSyntax();
            LambdaExpressionSyntax();
            Console.ReadKey();
        }

        private static bool IsEvenNumber(int i)
        {
            return (i % 2) == 0;
        }

        private static void TraditionalDelegateSyntax()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            Predicate<int> callback = IsEvenNumber;//predicate is a delegate
            List<int> evenNumbers = list.FindAll(callback);

            PrintEvenNumbers(evenNumbers);
        }

        private static void AnonymousMethodSyntax()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            List<int> evenNumbers = list.FindAll(delegate (int i)//a method that takes in an int and...
            {
                return (i % 2) == 0;//... returns this
            });

            PrintEvenNumbers(evenNumbers);
        }

        private static void LambdaExpressionSyntax()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            List<int> evenNumbers = list.FindAll((int i) => (i % 2) == 0);

            PrintEvenNumbers(evenNumbers);
        }


        private static void PrintEvenNumbers(List<int> evenNumbers)
        {
            Console.WriteLine("here are your even numbers: ");
            foreach (int evenNumber in evenNumbers)
            {
                Console.WriteLine("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }
    }
}
