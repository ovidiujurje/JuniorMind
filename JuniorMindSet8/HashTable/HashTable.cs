using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableProject
{
    public class HashTable<TKey, TValue>:IDictionary<TKey, TValue>
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
            if (buckets != null)
            {
                for (int i = buckets[key.GetHashCode() % buckets.Length]; i > -1; i = pairs[i].next)
                {
                    try
                    {
                        if (pairs[i].key.Equals(key))
                            return i;
                    }
                    catch (NullReferenceException)
                    {
                        return -1;
                    }
                }
            }
            return -1;
        }

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
            int bucket = key.GetHashCode() % buckets.Length;
            int index;
            if (numberOfVacancies > 0)
            {
                index = vacancyPosition;
                vacancyPosition = pairs[index].next;
                numberOfVacancies--;
                pairs[index].key = key;
                pairs[index].value = value;
                buckets[bucket] = index;
            }
            else
            {
                pairs[count].key = key;
                pairs[count].value = value;
                if (buckets[bucket] != -1)
                    pairs[count].next = buckets[bucket];
                buckets[bucket] = count;
                count++;
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return FindIndex(item.Key) > -1;
        }

        public bool ContainsKey(TKey key)
        {
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
            if (buckets != null)
            {
                int bucket = key.GetHashCode() % buckets.Length;
                int previous = -1;
                for (int i = buckets[bucket]; i >= 0; previous = i, i = pairs[i].next)
                {
                    if (pairs[i].key.Equals(key))
                    {
                        if (previous < 0)
                        {
                            buckets[bucket] = pairs[i].next;
                        }
                        else
                        {
                            pairs[previous].next = pairs[i].next;
                        }
                        pairs[i].next = vacancyPosition;
                        pairs[i] = default(Pair);
                        vacancyPosition = i;
                        numberOfVacancies++;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {

            for (int i = 0; i < pairs.Length; i++)
            {
                yield return new KeyValuePair< TKey, TValue >(pairs[i].key, pairs[i].value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}