using System;
using System.Collections.Generic;
using Xunit;

namespace LinkedListGroup
{
    public class GroupTests
    {
        [Fact]
        public void ShouldCount()
        {
            var list = new LinkedList<string> { "one", "two" };
            Assert.Equal(2, list.Count);
        }
        [Fact]
        public void ShouldAddElement()
        {
            var list = new LinkedList<string> { "one", "two" };
            list.Add("three");
            Assert.Equal(new string[] { "one", "two", "three" }, list);
        }
        [Fact]
        public void ShouldAddElementAtBeginning()
        {
            var list = new LinkedList<string> { "one", "two" };
            list.AddFirst("three");
            Assert.Equal(new string[] { "three", "one", "two" }, list);
        }
        [Fact]
        public void ShouldInsertBeforeValue()
        {
            var list = new LinkedList<string> { "one", "two" };
            list.InsertBefore("two", "three");
            Assert.Equal(new string[] { "one", "three", "two" }, list);
        }
        [Fact]
        public void ShouldRemoveFirst()
        {
            var list = new LinkedList<string> { "one", "two" };
            list.RemoveFirst();
            Assert.Equal(new string[] { "two" }, list);
        }
        [Fact]
        public void ShouldRemoveLast()
        {
            var list = new LinkedList<string> { "one", "two" };
            list.RemoveLast();
            Assert.Equal(new string[] { "one" }, list);
        }
        [Fact]
        public void ShouldRemoveValue()
        {
            var list = new LinkedList<string> { "one", "two" };
            list.RemoveValue("two");
            Assert.Equal(new string[] { "one" }, list);
        }
        
        [Fact]
        public void ShouldKeepTheCoutZeroWhenRemovingFirstOfAnEmptyList()
        {
            var list = new LinkedList<int>();
            list.RemoveFirst();
            Assert.Equal(0, list.Count);
        }
        [Fact]
        public void FindFirst()
        {
            var list = new LinkedList<string> { "one", "two" };
            Assert.Equal("two", list.FindFirst("two").Value);
        }
        [Fact]
        public void FindLast()
        {
            var list = new LinkedList<string> { "one", "two" };
            Assert.Equal("two", list.FindLast("two").Value);
        }
    }
}
