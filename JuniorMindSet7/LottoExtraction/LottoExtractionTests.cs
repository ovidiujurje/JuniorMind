using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LottoExtraction
{
    [TestClass]
    public class LottoExtractionTests
    {
        [TestMethod]
        public void SortNumbersAscending()
        {
            CollectionAssert.AreEqual( new byte[] { 4, 7, 18, 25, 39, 42 }, SortNumbersAscending(new byte[] { 7, 4, 18, 39, 42, 25 }));
        }
        byte[] SortNumbersAscending(byte[] lottoNumbers)
        {
            for (int i = 1; i < lottoNumbers.Length; i++)
            {
                DoInsertion(ref lottoNumbers, i, i - 1);
            }
            return lottoNumbers;
        }
        void DoInsertion(ref byte[] lottonumbers, int index, int previousIndex)
        {
            if (previousIndex < 0) return;
            if (lottonumbers[index] < lottonumbers[previousIndex])
            {
                Swap(ref lottonumbers[index], ref lottonumbers[previousIndex]);
                DoInsertion(ref lottonumbers, index - 1, previousIndex - 1);
            }
        }
        void Swap (ref byte first,ref  byte second)
        {
            byte temp = first;
            first = second;
            second = temp;
        }
    }
}
