using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public interface IGradeTracker : IEnumerable
    {
        event NamedChangeDelegate NameChanged;

        string Name { get; set; }


        void AddGrade(float grade);

        GradeStatistics ComputeStatistics();

        void WriteGrades(TextWriter textWriter);

        void DoSomething();

        IEnumerator GetEnumerator();

    }


}
