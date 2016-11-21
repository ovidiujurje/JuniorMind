using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableProject
{
    public class NullKeyException : Exception
    {
        public NullKeyException(string message)
        {
            message = "Key is null";
        }
    }
    public class TakenKeyException : Exception
    {
        public TakenKeyException(string message)
        {
            message = "An element with the same key already exists in this collection";

        }
    }
    public class HashTable<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private struct Pair
        {
            public TKey key;
            public TValue value;
            public int next;
        }

        private int[] buckets;
        private Pair[] pairs;
        private int count;
        private int vacancyPosition;
        private int numberOfVacancies;

        public HashTable(int size)
        {
            buckets = new int[size];
            pairs = new Pair[size];
            count = 0;
            vacancyPosition = -1;
            numberOfVacancies = 0;
            for (int i = 0; i < pairs.Length; i++)
            {
                buckets[i] = -1;
                pairs[i].next = -1;
            }
        }

        private int FindIndex(TKey key)
        {
            if (buckets == null)
                return -1;

            var index = GetKeyIndex(key);
            for (int i = buckets[index]; i > -1; i = pairs[i].next)
            {
                if (pairs[i].key.Equals(key))
                    return i;
            }

            return -1;
        }

        private int GetKeyIndex(TKey key) => Math.Abs(key.GetHashCode() % buckets.Length);

        public TValue this[TKey key]
        {
            get
            {
                return pairs[FindIndex(key)].value;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get
            {
                return count - numberOfVacancies;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null) throw new NullKeyException("Key is null");
            if (FindIndex(key) != -1) throw new TakenKeyException("An element with the same key already exists in this collection");

            var bucket = GetKeyIndex(key);
            var index = FindFreePair();
            pairs[index].key = key;
            pairs[index].value = value;
            pairs[index].next = buckets[bucket];
            buckets[bucket] = index;
            count++;

        }

        private int FindFreePair()
        {
            return HasVacancies() ? UseNextFreePair() : count;
        }

        private bool HasVacancies()
        {
            return numberOfVacancies > 0;
        }

        private int UseNextFreePair()
        {
            var nextFreeIndex = vacancyPosition;
            vacancyPosition = pairs[vacancyPosition].next;
            numberOfVacancies--;
            return nextFreeIndex;
        }

        public void Clear()
        {
            if (count <= 0)
                return;
            for (int i = 0; i < buckets.Length; i++) buckets[i] = -1;
            Array.Clear(pairs, 0, count);
            count = 0;
            vacancyPosition = -1;
            numberOfVacancies = 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return FindIndex(item.Key) > -1;
        }

        public bool ContainsKey(TKey key)
        {
            if (key == null) throw new NullKeyException("Key is null");

            return FindIndex(key) > -1;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            if (key == null) throw new NullKeyException("Key is null");

            int bucket = GetKeyIndex(key);
            int previous = -1;
            for (int i = buckets[bucket]; i >= 0; previous = i, i = pairs[i].next)
            {
                if (pairs[i].key.Equals(key))
                {
                    RemovePair(bucket, previous, i);
                    return true;
                }
            }
            return false;
        }

        private void RemovePair(int bucket, int previous, int index)
        {
            if (previous < 0)
            {
                buckets[bucket] = pairs[index].next;
            }
            else
            {
                pairs[previous].next = pairs[index].next;
            }
            AddPairToVacant(index);
        }

        private void AddPairToVacant(int index)
        {
            pairs[index] = default(Pair);
            pairs[index].next = vacancyPosition;
            vacancyPosition = index;
            numberOfVacancies++;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {

            for (int i = 0; i < pairs.Length; i++)
            {
                yield return new KeyValuePair<TKey, TValue>(pairs[i].key, pairs[i].value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}