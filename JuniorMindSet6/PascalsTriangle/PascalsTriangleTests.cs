using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PascalsTriangle
{
    [TestClass]
    public class PascalsTriangleTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            CollectionAssert.AreEqual(new int[,] { {1, 0, 0 }, { 1, 1, 0 }, { 1, 2, 1 } }, GeneratePascalsTriangle(3));
        }
        int[,] GeneratePascalsTriangle (int level)
        {
            int[,] triangle = new int[level, level];
            for (int i = 0; i < level; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    triangle[i, j] = GenerateLine(i, j);
                }
            }
            return triangle;
        }
        int GenerateLine(int row, int col)
        {
            if (col == 0 || col == row) return 1;
            if (row == 0 || row == 1) return 1;
            return GenerateLine(row - 1, col - 1) + GenerateLine(row - 1, col);
        }
    }
}
