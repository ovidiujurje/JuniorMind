using System;
using System.Collections.Generic;
using System.Linq;
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
            var collection = new HashTable<string, int>(2) {
                { "zero", 0 },
                { "one", 1 }
            };
            Assert.Equal(1, collection["one"]);
            Assert.Equal(0, collection["zero"]);
        }
        [Fact]
        public void ShouldAdd()
        {
            var collection = new HashTable<string, int>(2) {
                { "zero", 0 },
                { "one", 1 }
            };
            var result = new KeyValuePair<string, int>[] { new KeyValuePair<string, int>("zero", 0), new KeyValuePair<string, int>("one", 1) };
            Assert.Equal(result , collection);
        }
    }
}
