using GradeBook.Enums;
using System.Linq;
using System;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }
         public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Less than 5 Students");
            
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
    

