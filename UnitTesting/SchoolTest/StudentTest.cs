using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoolTest
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void StudentConstructorTestName()
        {
            string name = "Pesho Peshov";
            int uniqueNumber = 12345;
            Student student = new Student(name, uniqueNumber);
            Assert.AreEqual(student.Name, "Pesho Peshov");
        }

        [TestMethod]
        public void StudentConstructorTestUniqueNumber()
        {
            string name = "Pesho Peshov";
            int uniqueNumber = 12345;
            Student student = new Student(name, uniqueNumber);
            Assert.AreEqual(student.UniqueNumber, 12345);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameTestNullValue()
        {
            string name = null;
            int uniqueNumber = 12345;
            Student student = new Student(name, uniqueNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameTestEmptyString()
        {
            string name = string.Empty;
            int uniqueNumber = 12345;
            Student student = new Student(name, uniqueNumber);
        }

        [TestMethod]
        public void UniqueNumberTestMinimumValue()
        {
            string name = "Pesho Peshov";
            int uniqueNumber = 10000;
            Student student = new Student(name, uniqueNumber);
            Assert.IsTrue(uniqueNumber >= 10000 && uniqueNumber <= 99999);
        }

        [TestMethod]
        public void UniqueNumberTestMaximumValue()
        {
            string name = "Pesho Peshov";
            int uniqueNumber = 99999;
            Student student = new Student(name, uniqueNumber);
            Assert.IsTrue(uniqueNumber >= 10000 && uniqueNumber <= 99999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UniqueNumberTestStartValueMinusOne()
        {
            string name = "Pesho Peshov";
            int uniqueNumber = 9999;
            Student student = new Student(name, uniqueNumber);
            Assert.IsTrue(uniqueNumber >= 10000 && uniqueNumber <= 99999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UniqueNumberTestEndValuePlusOne()
        {
            string name = "Pesho Peshov";
            int uniqueNumber = 100000;
            Student student = new Student(name, uniqueNumber);
            Assert.IsTrue(uniqueNumber >= 10000 && uniqueNumber <= 99999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UniqueNumberTestEndValuePlus10000()
        {
            string name = "Pesho Peshov";
            int uniqueNumber = 109999;
            Student student = new Student(name, uniqueNumber);
            Assert.IsTrue(uniqueNumber >= 10000 && uniqueNumber <= 99999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UniqueNumberTestZero()
        {
            string name = "Pesho Peshov";
            int uniqueNumber = 0;
            Student student = new Student(name, uniqueNumber);
            Assert.IsTrue(uniqueNumber >= 10000 && uniqueNumber <= 99999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UniqueNumberTestIntMaxValue()
        {
            string name = "Pesho Peshov";
            int uniqueNumber = int.MaxValue;
            Student student = new Student(name, uniqueNumber);
            Assert.IsTrue(uniqueNumber >= 10000 && uniqueNumber <= 99999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UniqueNumberTestNegativeValue()
        {
            string name = "Pesho Peshov";
            int uniqueNumber = -55555;
            Student student = new Student(name, uniqueNumber);
            Assert.IsTrue(uniqueNumber >= 10000 && uniqueNumber <= 99999);
        }

        [TestMethod]
        public void ToStringTest()
        {
            string name = "Pesho Peshov";
            int uniqueNumber = 12345;
            Student student = new Student(name, uniqueNumber);
            string expectedResult = "Student Pesho Peshov, ID 12345;";
            string actualResult;
            actualResult = student.ToString();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
