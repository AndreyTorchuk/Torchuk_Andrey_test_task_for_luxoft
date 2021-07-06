using System;
using System.Collections;
using System.Collections.Generic;

namespace Torchuk_Andrey_test_task
{
    public class CustomStructure : IEnumerable
    {
        SortedDictionary<string, int[]> collection = new SortedDictionary<string, int[]>();
        public void Add(string key, int[] value)
        {
            if (value.Length == 0)
                return;
            if (collection.ContainsKey(key))
            {
                List<int> list = new List<int>(collection[key]);
                foreach (int i in value)
                {
                    if (!list.Contains(i))
                        list.Add(i);
                }
                list.Sort();
                collection[key] = list.ToArray();
            }
            else
            {
                collection.Add(key, value);
            }

        }

        public void Remove(string key, int[] value)
        {
            if (value.Length == 0)
                return;
            if (collection.ContainsKey(key))
            {
                List<int> list = new List<int>(collection[key]);
                foreach (int i in value)
                {
                    list.Remove(i);
                }
                if (list.Count == 0)
                {
                    collection.Remove(key);
                }
                else
                {
                    list.Sort();
                    collection[key] = list.ToArray();
                }
            }
        }
        public void Merge(CustomStructure source)
        {
            foreach (KeyValuePair<string, int[]> i in source)
            {
                Add(i.Key, i.Value);
            }
        }

        public void Cut(CustomStructure source)
        {
            foreach (KeyValuePair<string, int[]> i in source)
            {
                Remove(i.Key, i.Value);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return collection.GetEnumerator();
        }
    }
}
