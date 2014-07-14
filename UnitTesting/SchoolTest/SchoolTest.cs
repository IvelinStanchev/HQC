using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SchoolTest
{
    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void SchoolConstructorTest()
        {
            List<Course> courses = new List<Course>();
            School school = new School(courses);
            Assert.IsNotNull(school);
        }

        [TestMethod]
        public void AddCourseTest()
        {
            List<Course> courses = new List<Course>();
            Course course = new Course("C#");
            School school = new School(courses);
            school.AddCourse(course);
            Assert.AreEqual(course.Name, school.Courses[0].Name);
        }

        [TestMethod]
        public void RemoveCourseTest()
        {
            List<Course> courses = new List<Course>();
            School school = new School(courses);
            Course course = new Course("C#");
            school.AddCourse(course);
            school.RemoveCourse(course);
            Assert.IsTrue(school.Courses.Count == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNonExistingCourseTest()
        {
            List<Course> courses = new List<Course>();
            School school = new School(courses);
            Course course = new Course("C#");
            school.RemoveCourse(course);
        }
    }
}
