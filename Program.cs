using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Gradebook book = new Gradebook("Cynthia's favorite book");
            //book.Name = "Cynthia's favorite book";

            book.AddGrade(91f);
            book.AddGrade(89.1f);
            book.AddGrade(75f);

            book.Name = "Brody's All-favorite book: Gator Pie";

            book.NameChanged = new NamedChangeDelegate(OnNameChange);
            GradeStatistics stats = book.ComputeStatistics();

            Console.WriteLine("Average Grade = " + stats.AverageGrade);
            Console.WriteLine("Lowest Grade = " + stats.LowestGrade);
            Console.WriteLine("Highest Grade = " + stats.HighestGrade);

            Console.ReadLine();
        }

        private static void OnNameChange(string oldValue, string newValue)
        {
            Console.WriteLine("Old book name {0}, New book name {1}", oldValue, newValue);
        }
    }
}
