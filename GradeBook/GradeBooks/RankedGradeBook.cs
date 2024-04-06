using GradeBook.Enums;
using System.Linq;
using System;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }
          public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
         public override void CalculateStatistics()
        {
            if (Students.Count >= 5)
            {
                base.CalculateStatistics();
            }
            else
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
        }
         public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            
            var Hold = (int)Math.Ceiling(Students.Count * 0.2);

            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades.IndexOf(averageGrade) < Hold)
                return 'A';
            else if (grades.IndexOf(averageGrade) < Hold * 2)
                return 'B';
            else if (grades.IndexOf(averageGrade) < Hold * 3)
                return 'C';
            else if (grades.IndexOf(averageGrade) < Hold * 4)
                return 'D';
            else
                return 'F';
        }
    }
}
    

