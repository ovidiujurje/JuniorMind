using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HashTableProject
{
    public class HashTableTests
    {
        [Fact]
        public void ShouldCountElements()
        {
            var collection = new HashTable<string, int>(2) {
                { "zero", 0 },
                { "one", 1 }
            };
            Assert.Equal( 2, collection.Count);
        }
        [Fact]
        public void ShouldGiveValueAssociatedWithSpecifiedKey()
        {
            var collection = new HashTable<string, int>(3) {
                { "zero", 0 },
                { "one", 1 }
            };
            Assert.Equal(1, collection["one"]);
            Assert.Equal(0, collection["zero"]);
        }
        [Fact]
        public void ShouldAdd()
        {
            var collection = new HashTable<string, int>(3) {
                { "zero", 0 },
                { "one", 1 }
            };
            collection.Add("two", 2);
            Assert.True(collection.Contains(new KeyValuePair<string, int>("zero", 0)));
            Assert.True(collection.Contains(new KeyValuePair<string, int>("one", 1)));
            Assert.True(collection.Contains(new KeyValuePair<string, int>("two", 2)));
        }
        [Fact]
        public void ShouldThrowNullKeyException()
        {
            var collection = new HashTable<string, int>(3) {
                { "zero", 0 },
                { "one", 1 }
            };
            Assert.Throws<NullKeyException>(() => collection.Add(null, 3));
        }
        [Fact]
        public void ShouldThrowtakenKeyException()
        {
            var collection = new HashTable<string, int>(3) {
                { "zero", 0 },
                { "one", 1 }
            };
            Assert.Throws<TakenKeyException>(() => collection.Add("zero", 3));
        }
        [Fact]
        public void ShouldRemove()
        {
            var collection = new HashTable<string, int>(2) {
                { "zero", 0 },
                { "one", 1 }
            };
            collection.Remove("zero");
            Assert.False(collection.Contains(new KeyValuePair<string, int>("zero", 0)));
            Assert.True(collection.Contains(new KeyValuePair<string, int>("one", 1)));
        }
        [Fact]
        public void ShouldThrowNullKeyException2()
        {
            var collection = new HashTable<string, int>(3) {
                { "zero", 0 },
                { "one", 1 }
            };
            Assert.Throws<NullKeyException>(() => collection.Remove(null));
        }
        [Fact]
        public void ShouldOccupyVacantPosition()
        {
            var collection = new HashTable<string, int>(2) {
                { "zero", 0 },
                { "one", 1 }
            };
            collection.Remove("zero");
            collection.Add("two", 2);
            Assert.False(collection.Contains(new KeyValuePair<string, int>("zero", 0)));
            Assert.True(collection.Contains(new KeyValuePair<string, int>("one", 1)));
            Assert.True(collection.Contains(new KeyValuePair<string, int>("two", 2)));
        }
        [Fact]
        public void ShouldClearHashTable()
        {
            var collection = new HashTable<string, int>(2) {
                { "zero", 0 },
                { "one", 1 }
            };
            collection.Clear();
            Assert.Equal(0, collection.Count);
            Assert.False(collection.Contains(new KeyValuePair<string, int>("zero", 0)));
            Assert.False(collection.Contains(new KeyValuePair<string, int>("one", 1)));
        }
    }
}
