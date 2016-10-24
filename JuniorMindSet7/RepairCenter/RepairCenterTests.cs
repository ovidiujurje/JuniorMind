using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RepairCenter
{
    [TestClass]
    public class RepairCenterTests
    {
        [TestMethod]
        public void SortByPriorityHighestToLowest()
        {
            CollectionAssert.AreEqual(new Case[] { new Case(Priority.High),new Case(Priority.High), new Case(Priority.Medium), new Case(Priority.Medium), new Case(Priority.Medium), new Case(Priority.Low), new Case(Priority.Low) },
                                      SortByPriority(new Case[] { new Case(Priority.Medium), new Case(Priority.Low), new Case(Priority.High), new Case(Priority.High), new Case(Priority.Low), new Case(Priority.Medium), new Case(Priority.Medium) }));
        }
        public enum Priority { High, Medium, Low }
        public struct Case
        {
            public Priority priority;
            public Case(Priority priority)
            {
                this.priority = priority;
            }
        }
        Case[] SortByPriority(Case[] cases)
        {
            for (int i = 1; i < cases.Length; i++)
            {
                DoInsertion(ref cases, i, i - 1);
            }
            return cases;
        }
        void DoInsertion(ref Case[] cases, int index, int previousIndex)
        {
            if (previousIndex < 0) return;
            if ((byte)cases[index].priority < (byte)cases[previousIndex].priority)
            {
                Swap(ref cases[index], ref cases[previousIndex]);
                DoInsertion(ref cases, index - 1, previousIndex - 1);
            }
        }
        void Swap(ref Case first, ref Case second)
        {
            Case temp = first;
            first = second;
            second = temp;
        }
    }
}
