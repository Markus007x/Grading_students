namespace GradingStudents
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello to the University app.");
            Console.WriteLine("############################\n");

            bool CloseApp = false;

            while (!CloseApp)
            {
                Console.WriteLine(
                    "1 - Add grades to the memory\n" +
                    "2 - Add grades to the .txt file\n" +
                    "Q - Close app\n");

                Console.WriteLine("Press key 1, 2 or Q: ");
                var userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        AddGradesToMemory();
                        break;
                    case "2":
                        AddGradesToTxtFile();
                        break;
                    case "Q" or "q":
                        CloseApp = true;
                        break;
                    default:
                        Console.WriteLine("Invalid operation.\n");
                        continue;
                }
            }
            Console.WriteLine("\nGood Bye. Press any key to leave.");
            Console.ReadKey();
        }
        private static void AddGradesToMemory()
        {
            string firstName = GetValueFromUser("Please insert student's first name: ");
            string lastName = GetValueFromUser("Please insert student's last name: ");
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                var inMemoryStudent = new StudentInMemory(firstName, lastName);
                EnterGrade(inMemoryStudent);
                inMemoryStudent.ShowStatistics();
            }
            else
            {
                Console.WriteLine("Student's firstname and lastname can not be empty!");
            }
        }
        private static void AddGradesToTxtFile()
        {
            string firstName = GetValueFromUser("Please insert student's first name: ");
            string lastName = GetValueFromUser("Please insert student's last name: ");
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                var savedStudent = new StudentInFile(firstName, lastName);
                EnterGrade(savedStudent);
                savedStudent.ShowStatistics();
            }
            else
            {
                Console.WriteLine("Student's firstname and lastname can not be empty!");
            }
        }

        private static void EnterGrade(IStudent student)
        {
            while (true)
            {
                Console.WriteLine($"Enter grade for {student.FirstName} {student.LastName}:");
                var input = Console.ReadLine();
                if (input == "q" || input == "Q")
                {
                    break;
                }
                try
                {
                    student.AddGrade(input);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine($"To leave and show statistics enter 'q'.");
                }
            }
        }
        private static string GetValueFromUser(string comment)
        {
            Console.WriteLine(comment);
            string userInput = Console.ReadLine();
            return userInput;
        }
    }
}

