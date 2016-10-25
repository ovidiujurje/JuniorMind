using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elections
{
    [TestClass]
    public class ElectionsTests
    {
        [TestMethod]
        public void CentralizeAndSortCandidatesDescending()
        {
            CollectionAssert.AreEqual(new Candidate[] { new Candidate(Name.Kennedy, 130), new Candidate(Name.Bush, 80), new Candidate(Name.Nixon, 55) },
          CentralizeResults(new PollingPlace[] { new PollingPlace(new Candidate[] { new Candidate(Name.Bush, 20), new Candidate(Name.Nixon, 15), new Candidate(Name.Kennedy, 10) }),
                                                 new PollingPlace(new Candidate[] { new Candidate(Name.Nixon, 30), new Candidate(Name.Kennedy, 20), new Candidate(Name.Bush, 10) }),
                                                 new PollingPlace(new Candidate[] { new Candidate(Name.Kennedy, 100), new Candidate(Name.Bush, 50), new Candidate(Name.Nixon, 10) }) }));
        }
        public enum Name { Bush, Nixon, Kennedy }
        public struct Candidate
        {
            public Name name;
            public int votes;
            public Candidate(Name name, int votes)
            {
                this.name = name;
                this.votes = votes;
            }
        }
        public struct PollingPlace
        {
            public Candidate[] candidates;
            public PollingPlace(Candidate[] candidates)
            {
                this.candidates = candidates;
            }
        }
        Candidate[] CentralizeResults(PollingPlace[] results)
        {
            PollingPlace central = results[0];
            for (int i = 1; i < results.Length; i++)
            {
                for (int j = 0; j < results[i].candidates.Length; j++)
                {
                    for (int k = 0; k < results[0].candidates.Length; k++)
                    {
                        if (results[0].candidates[k].name == results[i].candidates[j].name) results[0].candidates[k].votes += results[i].candidates[j].votes;
                    }
                }
            }
            for (int i = 1; i < results[0].candidates.Length; i++)
            {
                DoInsertion(ref results[0].candidates, i, i - 1);
            }
            return results[0].candidates;
        }
        void DoInsertion(ref Candidate[] candidates, int index, int previousIndex)
        {
            if (previousIndex < 0) return;
            if (candidates[index].votes > candidates[previousIndex].votes)
            {
                Swap(ref candidates[index], ref candidates[previousIndex]);
                DoInsertion(ref candidates, index - 1, previousIndex - 1);
            }
        }
        void Swap (ref Candidate first,ref Candidate second)
        {
            Candidate temp = first;
            first = second;
            second = temp;
        }
    }
}
