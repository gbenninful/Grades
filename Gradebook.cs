using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Grades
{
    public class Gradebook : GradeTracker, IEnumerable
    {
        protected List<float> _grades;

        public Gradebook()
        {
            _grades = new List<float>();
        }

        public Gradebook(string name)
        {
            Console.WriteLine("GradeBook ctor");
            _grades = new List<float>();
            Name = name;
        }

        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                _grades.Add(grade);
            }
        }


        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("Gradebook Compute statistics method");
            GradeStatistics stats = new GradeStatistics();

            float sum = 0f;

            foreach (float grade in _grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);

                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);

                sum += grade;
            }

            stats.AverageGrade = sum / _grades.Count;

            return stats;
        }

        public override void WriteGrades(TextWriter textWriter)
        {
            textWriter.WriteLine("Here are your Grades: ");

            foreach (float grade in _grades)
            {
                textWriter.WriteLine(grade);
            }

            textWriter.WriteLine("\n");
        }

        public override void DoSomething()
        {
            Console.WriteLine("I'm doing something!!!");
        }

        public override IEnumerator GetEnumerator()
        {
            return _grades.GetEnumerator();
        }
    }
}
