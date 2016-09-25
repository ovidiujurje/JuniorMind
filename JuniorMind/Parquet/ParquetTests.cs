using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Parquet
{
    [TestClass]
    public class ParquetTests
    {
        [TestMethod]
        public void ParquetForSixtyEightByFiftyOneRoom()
        {
            float parquet = CalculateNumberOfParquetPiecesRequiredForRoom(68, 51, 40, 20);
            Assert.AreEqual(6, parquet);
        }
        [TestMethod]
        public void ParquetForTwoFiftyFiveByTwoOFourRoom()
        {
            float parquet = CalculateNumberOfParquetPiecesRequiredForRoom(255, 204, 100, 60);
            Assert.AreEqual(12, parquet);
        }
        float CalculateNumberOfParquetPiecesRequiredForRoom(float nRoomLength, float mRoomWidth, float aParquetPieceLength, float bParquetPieceWidth)
        {
            float lossInLengthFromEachParquetPiece = 0.15f * aParquetPieceLength;
            float lossInWidthFromEachParquetPiece = 0.15f * bParquetPieceWidth;
            float remainingParquetPieceLength = aParquetPieceLength - lossInLengthFromEachParquetPiece;
            float remainingParquetPieceWidth = bParquetPieceWidth - lossInWidthFromEachParquetPiece;
            float parquetRequiredLengthwise = nRoomLength / remainingParquetPieceLength;
            float parquetRequiredWidthwise = mRoomWidth / remainingParquetPieceWidth;
            return parquetRequiredLengthwise * parquetRequiredWidthwise;
        }
    }
}
