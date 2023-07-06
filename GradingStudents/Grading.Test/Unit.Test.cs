using System;
using NUnit;
using GradingStudents;

namespace Unit.Test
{
    public class GradingTest
    {
        [Test]
        public void Test1()
        {
            // arrange
            var student = new StudentInMemory("Angela", "Merkel");
            student.AddGrade(5.5);
            student.AddGrade(6);
            student.AddGrade(4.5);
            student.AddGrade(3);
            student.AddGrade(2);

            // act
            var result = student.GetStatistics();

            // assert
            Assert.AreEqual(4.2, result.Average, 1);
            Assert.AreEqual(6, result.High, 1);
            Assert.AreEqual(2, result.Low, 1);
        }
    }
}