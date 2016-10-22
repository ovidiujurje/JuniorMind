using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PascalsTriangle
{
    [TestClass]
    public class PascalsTriangleTests
    {
        [TestMethod]
        public void LevelThreeTriangle()
        {
            CollectionAssert.AreEqual(new int[,] { { 1, 0, 0 },
                                                   { 1, 1, 0 },
                                                   { 1, 2, 1 } }, GeneratePascalsTriangle(3));
        }
        [TestMethod]
        public void LevelSevenTriangle()
        {
            CollectionAssert.AreEqual(new int[,] { { 1, 0, 0, 0, 0, 0, 0 },
                                                   { 1, 1, 0, 0, 0, 0, 0 },
                                                   { 1, 2, 1, 0, 0, 0, 0 },
                                                   { 1, 3, 3, 1, 0, 0, 0 },
                                                   { 1, 4, 6, 4, 1, 0, 0 },
                                                   { 1, 5, 10, 10, 5, 1, 0 },
                                                   { 1, 6, 15, 20, 15, 6, 1 } }, GeneratePascalsTriangle(7));
        }
        int[,] GeneratePascalsTriangle (int level)
        {
            int[,] triangle = new int[level, level];
            for (int i = 0; i < level; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    triangle[i, j] = GenerateElement(i, j);
                }
            }
            return triangle;
        }
        int GenerateElement(int row, int col)
        {
            if (col == 0 || col == row) return 1;
            return GenerateElement(row - 1, col - 1) + GenerateElement(row - 1, col);
        }
    }
}
