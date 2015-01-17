using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
   public abstract class GradeTracker : IGradeTracker, IEnumerable
    {
        private string _name;

        public event NamedChangeDelegate NameChanged;

        public string Name
        {

            get
            {
                return _name;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Like I said before, Name cannot be null or empty");
                }

                if (_name != value)
                {
                    var oldValue = _name;
                    _name = value;

                    if (NameChanged != null)
                    {

                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.OldValue = oldValue;
                        args.NewValue = value;

                        NameChanged(this, args);
                    }
                }

            }
        }



       public abstract void AddGrade(float grade);

       public abstract GradeStatistics ComputeStatistics();

       public abstract void WriteGrades(TextWriter textWriter);

       public abstract void DoSomething();

       public abstract IEnumerator GetEnumerator();

    }
}
