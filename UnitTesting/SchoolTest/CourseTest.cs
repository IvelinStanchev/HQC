using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SchoolTest
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void CourseConstructorTestName()
        {
            string name = "C#";
            Course course = new Course(name);
            Assert.AreEqual(course.Name, "C#");
        }

        [TestMethod]
        public void CourseConstructorTestListStudents()
        {
            string name = "C#";
            Student student = new Student("Pesho Peshev", 12345);
            IList<Student> students = new List<Student>();
            Course course = new Course(name, students);
            course.AddStudent(student);
            Assert.IsTrue(course.Students.Contains(student));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameTestNullValue()
        {
            string name = null;
            Course course = new Course(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameTestEmptyString()
        {
            string name = string.Empty;
            Course course = new Course(name);
        }

        [TestMethod]
        public void AddStudentTestOneStudent()
        {
            string name = "C#";
            IList<Student> students = new List<Student>();
            Course course = new Course(name, students);
            Student student = new Student("Pesho Peshev", 12345);
            course.AddStudent(student);
            Assert.IsTrue(course.Students.Count == 1);
        }

        [TestMethod]
        public void AddStudentTestTwoStudents()
        {
            string name = "C#";
            IList<Student> students = new List<Student>();
            Course course = new Course(name, students);
            Student firstStudent = new Student("Pesho Peshev", 12345);
            Student secondStudent = new Student("Kiro Kirov", 23445);
            course.AddStudent(firstStudent);
            course.AddStudent(secondStudent);
            Assert.IsTrue(course.Students.Count == 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStudentTestSameStudentTwoTimes()
        {
            string name = "C#";
            IList<Student> students = new List<Student>();
            Course course = new Course(name, students);
            Student student = new Student("Pesho Peshev", 12345);
            course.AddStudent(student);
            course.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddStudentTestMoreThanMaximumStudents()
        {
            string name = "C#";
            IList<Student> students = new List<Student>();
            Course course = new Course(name, students);

            for (int i = 0; i < 35; i++)
            {
                course.AddStudent(new Student("Pesho Peshev", i));
            }
        }

        [TestMethod]
        public void RemoveStudentTest()
        {
            string name = "C#";
            IList<Student> students = new List<Student>();
            Course course = new Course(name, students);
            Student firstStudent = new Student("Pesho Peshev", 12345);
            Student secondStudent = new Student("Kiro Kirov", 23445);
            course.AddStudent(firstStudent);
            course.AddStudent(secondStudent);
            course.RemoveStudent(secondStudent);
            Assert.IsTrue(course.Students.Count == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNonExistingStudentTest()
        {
            string name = "C#";
            IList<Student> students = new List<Student>();
            Course course = new Course(name, students);
            Student student = new Student("Pesho Peshev", 12345);
            course.RemoveStudent(student);
        }

        [TestMethod]
        public void ToStringTestOneStudent()
        {
            string name = "C#";
            Student student = new Student("Pesho Peshev", 12345);
            IList<Student> students = new List<Student>();
            Course course = new Course(name, students);
            course.AddStudent(student);
            string expectedResult = "Course name C#; Student Pesho Peshev, ID 12345;";
            string actualResult;
            actualResult = course.ToString();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ToStringTestTwoStudents()
        {
            string name = "C#";
            Student firstStudent = new Student("Pesho Peshev", 12345);
            Student secondStudent = new Student("Kiro Kirov", 23445);
            IList<Student> students = new List<Student>();
            Course course = new Course(name, students);
            course.AddStudent(firstStudent);
            course.AddStudent(secondStudent);
            string expectedResult = "Course name C#; Student Pesho Peshev, ID 12345; Student Kiro Kirov, ID 23445;";
            string actualResult;
            actualResult = course.ToString();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
