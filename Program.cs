using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {

        static void Main(string[] args)
        {
            //Gradebook book = new Gradebook("Pout pout fish");
            IGradeTracker book = CreateGradeBook();


            try
            {
                using ( FileStream stream = File.Open("grades.txt", FileMode.Open))
                using ( StreamReader reader = new StreamReader(stream))
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        float grade = float.Parse(line);
                        book.AddGrade(grade);
                        line = reader.ReadLine();
                    }
                }
            }


            catch (FileNotFoundException ex)
            {
                Console.WriteLine("I'm Sorry but your file could not be found (:");
                Console.WriteLine(ex.Message);
                return;
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine("Could you please enter a valid input?");
                Console.WriteLine(ex.Message);
                return;
            }

            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Sorry, You do not have access to this file.");
                return;
            }


            book.DoSomething();

            foreach (float grade in book)
            {
                book.WriteGrades(Console.Out);
            }


            try
            {
                //Console.Write("Please enter the name of your book: ");
                //book.Name = Console.ReadLine();
                //Console.WriteLine("Cynthia likes " + book.Name);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("You input is invalid. Please enter a string and try again");
            }


            GradeStatistics stats = book.ComputeStatistics();

            //book.NameChanged = new NamedChangeDelegate(OnNameChanged);

            //Multicast Delegates - Syntax is simplified from line above
            book.NameChanged += OnNameChanged;
            book.NameChanged += OnNameChanged;
            book.NameChanged -= OnNameChanged;
            book.NameChanged += OnNameChanged2;


            book.Name = "Gator Pie";


            Console.WriteLine("Average Grade = " + stats.AverageGrade);
            Console.WriteLine("Lowest Grade = " + stats.LowestGrade);
            Console.WriteLine("Highest Grade = " + stats.HighestGrade);
            Console.WriteLine("\n" + "My final grade is {0} which is {1}: ", stats.LetterGrade, stats.Description);

            Console.ReadLine();
        }

        private static IGradeTracker CreateGradeBook() 
        {
            IGradeTracker book = new ThrowAwayGradeBook("Barney & Friends");
            return book;
        }


        private static void OnNameChanged2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("\n" + "^^^^^^^^^^^^^^^ ------ ^^^^^^^^^^^^^^^" + "\n");
        }

        private static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("Cynthia L.'s book name is {0}. Brody M.'s book name is {1}", args.OldValue, args.NewValue);
        }


    }
}
