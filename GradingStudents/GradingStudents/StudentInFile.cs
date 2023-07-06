
using GradingStudents;
using System;

using System.IO;

using System.Text;


namespace GradingStudents
{
    public class StudentInFile : StudentBase
    {
        private const string fileName = "grades.txt";
        private string firstName;
        private string lastName;
        private string fullNameAndSurname;

        public override string FirstName
        {
            get
            {
                return (firstName);
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    firstName = value;
                }
            }
        }

        public override string LastName
        {
            get
            {
                return (LastName);
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    lastName = value;
                }
            }
        }


        public StudentInFile(string firstName, string lastName)
                        : base(firstName, lastName)
        {
            fullNameAndSurname = ($"{firstName}_{lastName}{fileName}");
        }


        public override void AddGrade(double grade)
        {
            if (grade > 0 && grade <= 6)
            {
                using (var writer = File.AppendText($"{fullNameAndSurname}"))
                using (var writer2 = File.AppendText($"CheckingStudent.txt"))
                {
                    writer.WriteLine(grade);
                    writer2.WriteLine($"{FirstName} {LastName} - {grade} {DateTime.UtcNow}");

                }
            }
            else
            {
                throw new ArgumentException($"Invalid argument: {nameof(grade)}. Only grades from 1 to 6 are allowed!");
            }
        }


        public override void ShowResult()
        {
            StringBuilder sb = new StringBuilder($"{this.FirstName} {this.LastName} grades are: ");

            using (var reader = File.OpenText(($"{fullNameAndSurname}")))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    sb.Append($"{line}; ");
                    line = reader.ReadLine();
                }
            }
            Console.WriteLine($"\n{sb}");
        }



        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            if (File.Exists($"{fullNameAndSurname}"))
            {
                using (var reader = File.OpenText($"{fullNameAndSurname}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = double.Parse(line);
                        result.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return result;
        }
    }
}

