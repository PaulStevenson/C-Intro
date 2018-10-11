using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Paul's grade book";
            
           
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Hello! This is the grade book program");

            GradeBook book = new GradeBook();

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine("The average grade is: " + stats.AverageGrade);
            Console.WriteLine("The lowest grade is: " + stats.HighestGrade);
            Console.WriteLine("The highest grade is: " + stats.HighestGrade);
           

        }
    }
}
