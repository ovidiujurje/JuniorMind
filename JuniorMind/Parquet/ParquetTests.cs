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
            float lossInLengthFromEachParquetPiece = 0.15f * aParquetPieceLength;
            float lossInWidthFromEachParquetPiece = 0.15f * bParquetPieceWidth;
            float remainingParquetPieceLength = aParquetPieceLength - lossInLengthFromEachParquetPiece;
            float remainingParquetPieceWidth = bParquetPieceWidth - lossInWidthFromEachParquetPiece;
            return nRoomLength / remainingParquetPieceLength * mRoomWidth / remainingParquetPieceWidth;
        }
    }
}
