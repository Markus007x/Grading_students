using GradingStudents;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingStudents
{
    public interface IStudent
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        void AddGrade(double grade);

        void AddGrade(string grade);

        void ShowResult();
        Statistics GetStatistics();
        void ShowStatistics();
    }

}
