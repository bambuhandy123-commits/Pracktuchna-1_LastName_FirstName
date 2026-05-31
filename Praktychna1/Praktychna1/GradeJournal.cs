using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Praktychna1
{
    public class GradeJournal
    {


        private Dictionary<string, double> _subjectGrades = new();

        public IReadOnlyDictionary<string, double> SubjectGrades => _subjectGrades;
        public void SetGrade(string subject, double grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentOutOfRangeException(nameof(grade), "Оцінка має бути від 0 до 100");
            if (string.IsNullOrWhiteSpace(subject))
                throw new ArgumentException("Назва предмета не може бути порожньою");
            _subjectGrades[subject] = grade;
        }

        public double CalculateAverage()
        {
            if (_subjectGrades.Count == 0) return 0;
            return Math.Round(_subjectGrades.Values.Average(), 2);
        }

        public bool RemoveSubject(string subject) => _subjectGrades.Remove(subject);
        public string GetGradesSummary()
        {

            if (_subjectGrades.Count == 0) return "Оцінок ще немає.";
            return string.Join(", ", _subjectGrades.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
        }
    }
}
