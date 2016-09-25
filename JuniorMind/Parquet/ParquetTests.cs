using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Parquet
{
    [TestClass]
    public class ParquetTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            float parquet = CalculateNumberOfParquetPiecesRequiredForRoom(68, 51, 40, 20);
            Assert.AreEqual(6, parquet);
        }
        float CalculateNumberOfParquetPiecesRequiredForRoom(float nRoomLength, float mRoomWidth, float aParquetPieceLength, float bParquetPieceWidth)
        {
            return nRoomLength / (aParquetPieceLength - 0.15f * aParquetPieceLength) * mRoomWidth / (bParquetPieceWidth - 0.15f * bParquetPieceWidth);
        }
    }
}
