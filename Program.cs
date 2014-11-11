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
            Gradebook book = new Gradebook("Pout pout fish");

            book.AddGrade(91f);
            book.AddGrade(89.1f);
            book.AddGrade(75f);

            GradeStatistics stats = book.ComputeStatistics();

            book.NameChanged = new NamedChangeDelegate(OnNameChanged);

            book.Name = "Gator Pie";


            Console.WriteLine("Average Grade = " + stats.AverageGrade);
            Console.WriteLine("Lowest Grade = " + stats.LowestGrade);
            Console.WriteLine("Highest Grade = " + stats.HighestGrade);

            Console.ReadLine();
        }

        private static void OnNameChanged(string oldValue, string newValue)
        {
            Console.WriteLine("Cynthia's book name is {0}. Brody's book name is {1}", oldValue, newValue);
        }
    }
}
