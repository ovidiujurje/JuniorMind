using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TowersOfHanoi
{
    [TestClass]
    public class TowersOfHanoiTests
    {
        [TestMethod]
        public void StackThreeDiscs()
        {
            CollectionAssert.AreEqual(new byte[] { 3, 2, 1 } , StackGivenNumberOfDiscsOnTowerValuesAreDiscSizes(3));
        }
        [TestMethod]
        public void MovesForThreeDiscs()
        {
            CollectionAssert.AreEqual(StackGivenNumberOfDiscsOnTowerValuesAreDiscSizes(3), MoveDiscsFromTowerAToTowerC(3));
        }
        [TestMethod]
        public void MovesForTwentyDiscs()
        {
            CollectionAssert.AreEqual(StackGivenNumberOfDiscsOnTowerValuesAreDiscSizes(20), MoveDiscsFromTowerAToTowerC(20));
        }
        byte[] MoveDiscsFromTowerAToTowerC(int numberOfDiscs)
        {
            byte[] towerA = StackGivenNumberOfDiscsOnTowerValuesAreDiscSizes(numberOfDiscs);
            byte[] towerB = new byte[0];
            byte[] towerC = new byte[0];
            int numberOfMoves =(int)(Math.Pow(2, numberOfDiscs) - 1);
            for (int i = 1; i <= numberOfMoves; i++)
                {
                if (numberOfDiscs % 2 != 0)
                {
                    if (i % 3 == 1)
                        MoveDiscCorrectly(ref towerA, ref towerC);
                    if (i % 3 == 2)
                        MoveDiscCorrectly(ref towerA, ref towerB);
                    if (i % 3 == 0)
                        MoveDiscCorrectly(ref towerB, ref towerC);
                }
                else
                {
                    if (i % 3 == 1)
                        MoveDiscCorrectly(ref towerA, ref towerB);
                    if (i % 3 == 2)
                        MoveDiscCorrectly(ref towerA, ref towerC);
                    if (i % 3 == 0)
                        MoveDiscCorrectly(ref towerC, ref towerB);
                }
            }
            return towerC;
        }
        void MoveDiscCorrectly(ref byte[] towerOne, ref byte[] towerTwo)
        {
            if (towerOne.Length == 0)
            {
                AddElementToArray(ref towerOne, towerTwo[towerTwo.Length - 1]);
                Array.Resize(ref towerTwo, towerTwo.Length - 1);
            }
            else if (towerTwo.Length == 0)
            {
                AddElementToArray(ref towerTwo, towerOne[towerOne.Length - 1]);
                Array.Resize(ref towerOne, towerOne.Length - 1);
            }
            else if (towerOne[towerOne.Length - 1] > towerTwo[towerTwo.Length - 1])
            {
                AddElementToArray(ref towerOne, towerTwo[towerTwo.Length - 1]);
                Array.Resize(ref towerTwo, towerTwo.Length - 1);
            }
            else
            {
                AddElementToArray(ref towerTwo, towerOne[towerOne.Length - 1]);
                Array.Resize(ref towerOne, towerOne.Length - 1);
            }
        }
        byte[] StackGivenNumberOfDiscsOnTowerValuesAreDiscSizes(int number)
        {
            byte[] array = new byte[number];
            for (int i = 0; i < number; i++)
            {
                array[i] = (byte)(array.Length - i);
            }
            array[array.Length - 1] = 1;
            return array;
        }
        byte[] AddElementToArray(ref byte[] array, byte element)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = element;
            return array;
        }

        void Swap (ref byte[] first, ref byte[] second)
        {
            byte[] temp = first;
            first = second;
            second = temp;
        }
    }
}
