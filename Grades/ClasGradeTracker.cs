using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class ClasGradeTracker
    {
        public abstract void AddGrade(float grade);

        public abstract GradeStatistics ComputeStatistics();

        public abstract void WriteGrades(TextWriter destination)

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Not allowed to be null nor empty");
                }

                if (_name != value && NameChanged != null)
                {
                    NamedChangedEventArgs args = new NamedChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;

                    NameChanged(this, args);
                }

                _name = value;

            }
        }


    }
}
