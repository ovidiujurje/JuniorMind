using System;
using System.Collections.Generic;
using Xunit;

namespace LinkedListGroup
{
    public class GroupTests
    {
        [Fact]
        public void AddFirst()
        {
            Group<string> set = new Group<string>(new string[] { "one", "two", "three" });
            set.AddFirst("four");
            Assert.Equal(new string[] { "four", "one", "two", "three" }, set);
        }
        [Fact]
        public void AddLast()
        {
            Group<string> set = new Group<string>(new string[] { "one", "two", "three" });
            set.AddLast("four");
            Assert.Equal(new string[] { "one", "two", "three", "four" }, set);
        }
        [Fact]
        public void InsertBefore()
        {
            Group<string> set = new Group<string>(new string[] { "one", "two", "three" });
            set.Insert("two", "four");
            Assert.Equal(new string[] {  "one", "four", "two", "three" }, set);
        }
        [Fact]
        public void RemoveFirst()
        {
            Group<string> set = new Group<string>(new string[] { "one", "two", "three" });
            set.RemoveFirst();
            Assert.Equal(new string[] { "two", "three" }, set);
        }
        [Fact]
        public void RemoveLast()
        {
            Group<string> set = new Group<string>(new string[] { "one", "two", "three" });
            set.RemoveLast();
            Assert.Equal(new string[] { "one", "two"}, set);
        }
        [Fact]
        public void Remove()
        {
            Group<string> set = new Group<string>(new string[] { "one", "two", "three" });
            set.Remove("two");
            Assert.Equal(new string[] { "one", "three" }, set);
        }
    }
}
