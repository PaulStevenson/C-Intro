using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
   public class ThrowawayGradeBook : GradeBook
    {
        public GradeStatistics ComputeStatistics()
        {

            Console.WriteLine("ThrowayGradeBook::ComputeStatistics");

            float lowest = float.MaxValue;
            foreach (float grade in grades)
            {
                lowest = Math.Min(grade, lowest);
            }

            grades.Remove(lowest);

            return base.ComputeStatistics();
        }

    }
}

