
using GradingStudents;
using System;

namespace GradingStudents
{
    public abstract class StudentBase : Student, IStudent
    {

        public override string FirstName { get; set; }

        public override string LastName { get; set; }



        public StudentBase(string firstName, string lastName)
                        : base(firstName, lastName)
        {
        }

        public abstract void AddGrade(double grade);
        public void AddGrade(string grade)
        {
            double gradeDouble = 0;
            var isParsed = double.TryParse(grade, out gradeDouble);
            if (isParsed && gradeDouble > 0 && gradeDouble <= 6)
            {
                AddGrade(gradeDouble);
            }
            else
            {
                throw new ArgumentException($"Invalid argument: {nameof(grade)}. Only grades from 1 to 6 are allowed!");
            }
        }


        public abstract void ShowResult();

        public abstract Statistics GetStatistics();

        public void ShowStatistics()
        {
            var stat = GetStatistics();
            if (stat.Count != 0)
            {
                ShowResult();

                Console.WriteLine($"statistics:\n###########");
                Console.WriteLine($"Total grades: {stat.Count}");
                Console.WriteLine($"Highest grade: {stat.High:N2}");
                Console.WriteLine($"Lowest grade: {stat.Low:N2}");
                Console.WriteLine($"Average: {stat.Average:N2}\n");
            }
            else
            {
                Console.WriteLine($"Couldn't get statistics for {this.FirstName} {this.LastName} because no grade has been added.");
            }
        }
    }

}

