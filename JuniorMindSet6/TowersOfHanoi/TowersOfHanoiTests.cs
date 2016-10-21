using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TowersOfHanoi
{
    [TestClass]
    public class TowersOfHanoiTests
    {
        [TestMethod]
        public void MovesForThreeDiscs()
        {
            string response = "";
            MoveDiscsFromTowerAToTowerC(3, "A", "B", "C", ref response);
            Assert.AreEqual("A->C|A->B|C->B|A->C|B->A|B->C|A->C|", response);
        }
        [TestMethod]
        public void MovesForFiveDiscs()
        {
            string response = "";
            MoveDiscsFromTowerAToTowerC(5, "A", "B", "C", ref response);
            Assert.AreEqual("A->C|A->B|C->B|A->C|B->A|B->C|A->C|A->B|C->B|C->A|B->A|C->B|A->C|A->B|C->B|A->C|B->A|B->C|A->C|B->A|C->B|C->A|B->A|B->C|A->C|A->B|C->B|A->C|B->A|B->C|A->C|", response);
        }
        void MoveDiscsFromTowerAToTowerC(int numberOfDiscs, string towerA, string towerB, string towerC, ref string solution)
        {
            if (numberOfDiscs > 0)
            {
                MoveDiscsFromTowerAToTowerC(numberOfDiscs - 1, towerA, towerC, towerB, ref solution);
                solution += towerA + "->" + towerC + "|";
                MoveDiscsFromTowerAToTowerC(numberOfDiscs - 1, towerB, towerA, towerC, ref solution);
            }
        }
    }
}
