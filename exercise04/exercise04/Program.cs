using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise04
{
    //class has to be static for extension method to work
    static class Program
    {
        static void Main(string[] args)
        {
            //Custom addrange made for adding to lists togetger into a Dictionary (same as below extension method)
            List<string> keys = new List<string>() { "Bob", "Cindy", "Kelly", "Tai","Bernie", "Connor", "Greg", "Bud", "Victor", "Mark" };
            List<int> values = new List<int>() { 44, 36, 76,73,34,67,77,99,43,26 };
            Dictionary<string, int> MyDict = new Dictionary<string, int>();
            MyDict.Add("Eric", 100);
            AddRange(MyDict, keys, values);
            PrintDictionary(MyDict);
            Console.ReadLine();
            Console.ReadKey();

            //Extension method for dictionary class (same as above)
            List<string> keys2 = new List<string>() { "exolar", "bubbus", "analius", "taios3", "gegeki", "furya", "butcher bay", "death star", "holomon"};
            List<int> values2 = new List<int>() { 4356644, 535, 7353546, 73253, 323454, 64567, 734657, 346599, 45367, 454356 };
            Dictionary<string, int> MyDict2 = new Dictionary<string, int>();
            MyDict2.Add("dagobah", 34987);
            MyDict2.AddRangeExtension(keys2, values2);
            PrintDictionary(MyDict2);
            Console.ReadLine();
            Console.ReadKey();



            //add some key value pairs to the dictionary one at a time
            Dictionary<string, int> studentGrades = new Dictionary<string, int>();
            studentGrades.Add("Mark", 69);
            studentGrades.Add("Simon", 98);
            studentGrades.Add("Anna", 97);
            studentGrades.Add("Lisa", 47);
            studentGrades.Add("Billy", 63);
            studentGrades.Add("Joe", 77);
            studentGrades.Add("Tom", 77);
            studentGrades.Add("Anne", 93);
            studentGrades.Add("Mary", 98);
            studentGrades.Add("Sid", 93);

            //add 3 key values using for loop al at once
            Random rnd = new Random();
            for (int i = 0; i < 3; i++)
            {
                string myStudent = "Student" + i;

                int rndGrade = rnd.Next(0, 100);
                studentGrades.Add(myStudent, rndGrade);
            }

            //check for a specific key (student) in the dictionary
            string searchStudent = "Anna";
            Console.WriteLine(studentGrades.ContainsKey(searchStudent) ? "The dictionary contains student " + searchStudent : "the dictionary doesnt contain the student " + searchStudent);

            //check for specific grade in dictionary and count how many students have that grade if any
            int searchGrade = 98;
            int instances = 0;
            foreach (KeyValuePair<string, int> sg in studentGrades)
            {
                if (sg.Value.Equals(searchGrade))
                    instances++;
            }
            if (instances != 0)
                Console.WriteLine($"{instances} student(s) have the grade {searchGrade}");
            else
                Console.WriteLine($"No student(s) found with the grade {searchGrade}");

            //remove keyvaluepair where student name matches
            string studentToRemove = "ivan";
            Console.WriteLine(studentGrades.Remove(studentToRemove) ? studentToRemove + " was successfully removed" : "A student named " + studentToRemove + " was not found and could thus not be removed");

            Console.WriteLine();

            //loop through dictionary and print key value pairs 
            foreach (KeyValuePair<string, int> sg in studentGrades)
            {
                Console.Write($"{sg.Key}: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" {sg.Value}p");
                Console.ResetColor();
            }
            Console.WriteLine();

            //some more dictionary methods to demo
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"There is a total of {studentGrades.LongCount()} students in the class");

            //get the student name which has the highest points
            List<string> bestStudents = new List<string>();


            foreach (KeyValuePair<string, int> kvp in studentGrades)
            {
                if (kvp.Value.Equals(studentGrades.Values.Max()))
                {
                    //add students that have the highest scores to the list
                    string bestStudent = kvp.Key;
                    bestStudents.Add(bestStudent);
                }
            }
            Console.WriteLine();

            Console.WriteLine("The student(s) with the best scores are: ");
            foreach (string student in bestStudents)
            {
                Console.WriteLine($"{student}: {studentGrades.Values.Max()}p");
            }
            Console.ResetColor();
        }

        private static void PrintDictionary(Dictionary<string, int> myDict)
        {
            foreach (KeyValuePair<string, int> kvp in myDict)
            {
                Console.WriteLine(kvp.Key + ": " + kvp.Value);
            }
        }

        public static void AddRange(Dictionary<string, int> myDict, List<string> keys, List<int> values)
        {

            //see if there are more keys or more values in the two lists
            int count = 0;

            if (keys.Count > values.Count)
            {
                count = keys.Count;

                //more keys than values supplied, handling it by giving the overflow keys default values
                for (int i = 0; i < count; i++)
                {
                    if (i >= values.Count)//if current index is higher than or equal to the total amount of values, give values a default 
                        myDict.Add(keys[i], -1);
                    else
                        myDict.Add(keys[i], values[i]);
                }
            }
            else if (values.Count > keys.Count)
            {
                count = values.Count;

                //more values than keys supplied, handling it by giving the values default keys
                for (int i = 0; i < count; i++)
                {
                    if (i >= keys.Count)
                        myDict.Add("DefaultKey"+i, values[i]);
                    else
                        myDict.Add(keys[i], values[i]);
                }
            }
            else
            {
                count = keys.Count;

                //simplest scenario to handle. the total amount of keys and values supplied are the same.
                for (int i = 0; i < count; i++)
                {
                        myDict.Add(keys[i], values[i]);
                }
            }
        }

        static void AddRangeExtension(this Dictionary<string,int> myDict, List<string>keys, List<int>values)
        {

            //see if there are more keys or more values in the two lists
            int count = 0;

            if (keys.Count > values.Count)
            {
                count = keys.Count;

                //more keys than values supplied, handling it by giving the overflow keys default values
                for (int i = 0; i < count; i++)
                {
                    if (i >= values.Count)//if current index is higher than or equal to the total amount of values, give values a default 
                        myDict.Add(keys[i], -1);
                    else
                        myDict.Add(keys[i], values[i]);
                }
            }
            else if (values.Count > keys.Count)
            {
                count = values.Count;

                //more values than keys supplied, handling it by giving the values default keys
                for (int i = 0; i < count; i++)
                {
                    if (i >= keys.Count)
                        myDict.Add("DefaultKey" + i, values[i]);
                    else
                        myDict.Add(keys[i], values[i]);
                }
            }
            else
            {
                count = keys.Count;

                //simplest scenario to handle. the total amount of keys and values supplied are the same.
                for (int i = 0; i < count; i++)
                {
                    myDict.Add(keys[i], values[i]);
                }
            }
        }
    }
}
