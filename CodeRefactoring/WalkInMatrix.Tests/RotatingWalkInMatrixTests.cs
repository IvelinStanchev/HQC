using System;
using RotatingWalkInMatrix;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Text;

namespace WalkInMatrix.Tests
{
    [TestClass]
    public class RotatingWalkInMatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InputtingAValue_AboveTheUpperBoundary_ThrowException()
        {
            Console.SetIn(new System.IO.StringReader("101"));
            RotatingWalkInMatrix.WalkInMatrix.InitializeMatrix(Console.ReadLine());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InputtingAValue_BelowTheDownBoundary_ThrowException()
        {
            Console.SetIn(new System.IO.StringReader("0"));
            RotatingWalkInMatrix.WalkInMatrix.InitializeMatrix(Console.ReadLine());
        }

        [TestInitialize]
        public void RefreshIncrementer()
        {
            FieldInfo refresh = typeof(RotatingWalkInMatrix.WalkInMatrix).GetField(
                "valueIncrementer", BindingFlags.NonPublic | BindingFlags.Static);
            refresh.SetValue(null, 1);
        }

        [TestMethod]
        public void CheckMatrixWithSize1()
        {
            var matrixGenerator = typeof(RotatingWalkInMatrix.WalkInMatrix).GetMethod(
                "GenerateMatrix", BindingFlags.Static | BindingFlags.NonPublic);

            int[,] gen = (int[,])matrixGenerator.Invoke(obj: null, parameters: new object[] { 1 });

            Assert.AreEqual<string>("1", MatrixToString(gen));
        }

        [TestMethod]
        public void CheckMatrixWithSize2()
        {
            var matrixGenerator = typeof(RotatingWalkInMatrix.WalkInMatrix).GetMethod(
                "GenerateMatrix", BindingFlags.Static | BindingFlags.NonPublic);

            int[,] gen = (int[,])matrixGenerator.Invoke(obj: null, parameters: new object[] { 2 });

            Assert.AreEqual<string>(string.Format("1 4{0}3 2", Environment.NewLine),
                MatrixToString(gen));
        }

        [TestMethod]
        public void CheckMatrixWithSize5()
        {
            var matrixGenerator = typeof(RotatingWalkInMatrix.WalkInMatrix).GetMethod(
                "GenerateMatrix", BindingFlags.Static | BindingFlags.NonPublic);

            int[,] gen = (int[,])matrixGenerator.Invoke(obj: null, parameters: new object[] { 5 });

            Assert.AreEqual<string>(string.Format("1 13 14 15 16{0}" +
                "12 2 21 22 17{0}" +
                "11 23 3 20 18{0}" +
                "10 25 24 4 19{0}" +
                "9 8 7 6 5",
                Environment.NewLine), MatrixToString(gen));
        }

        private String MatrixToString(int[,] gen)
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < gen.GetLength(0); row++)
            {
                for (int col = 0; col < gen.GetLength(0); col++)
                {
                    result.Append(gen[row, col]);
                    if (col != gen.GetLength(0) - 1)
                    {
                        result.Append(" ");
                    }
                }

                if (row != gen.GetLength(1) - 1)
                {
                    result.AppendLine();
                }
            }

            return result.ToString();
        }
    }
}
