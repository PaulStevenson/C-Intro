using System;
using System.Collections.Generic;
using System.IO;
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
            GradeBook book = CreateGradeBook();

            //GetBookName(book);
            AddingGrades(book);
            SavingGrades(book);

            WritingResults(book);
        }

        private static GradeBook CreateGradeBook()
        {
            return new ThrowawayGradeBook();
        }

        private static void WritingResults(GradeBook book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest Grade", stats.HighestGrade);
            WriteResult("Lowest Grade", stats.LowestGrade);
            WriteResult("Grade", stats.LetterGrade);
        }

        private static void SavingGrades(GradeBook book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
        }

        private static void AddingGrades(GradeBook book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(GradeBook book)
        {
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //static void OnNameChanged(object sender, NamedChangedEventArgs args)
        //{
        //    Console.WriteLine($"GradeBook changing {args.ExistingName} to {args.NewName}");
        //}

        //static void WriteResult(string description, int result)
        //{
        //    Console.WriteLine(description + ": " + result);
        //}

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}", description, result);
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}", description, result);
        }
    }
}