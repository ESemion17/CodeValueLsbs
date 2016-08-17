using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    public class MultiDictionary<K, V> : IMultiDictionary<K, V>, IEnumerable<KeyValuePair<K, IEnumerable< V>>>
    {
        private readonly Dictionary<K, LinkedList<V>> _dictionary=new Dictionary<K, LinkedList<V>>();
        public int Count
        {
            get
            {
                int counter = 0;
                foreach (var pair in _dictionary)
                    foreach (var item in pair.Value)
                        counter++;
                return counter;
            }
        }

        public ICollection<K> Keys
        {
            get
            {
                return _dictionary.Keys;
            }
        }

        public ICollection<V> Values
        {
            get
            {
                ICollection<V> coll=new List<V>();
                foreach (var pair in _dictionary)
                    foreach (var item in pair.Value)
                        coll.Add(item);
                return coll;
            }
        }

        public void Add(K key, V value)
        {
            var node = new LinkedListNode<V>(value);
            LinkedList<V> linkedList;
            if (_dictionary.ContainsKey(key))
            {
                _dictionary.TryGetValue(key, out linkedList);
                linkedList.AddLast(node);
            }
            else
            {
                linkedList = new LinkedList<V>();
                linkedList.AddLast(node);
                _dictionary.Add(key, linkedList);
            }
        }

        public void CreateNewValue(K key)
        {
            if (!_dictionary.ContainsKey(key))
            {
                var linkedList = new LinkedList<V>();
                _dictionary.Add(key, linkedList);
            }
        }
        public void Clear()
        {
            foreach (var item in _dictionary)
                Remove(item.Key);
        }

        public bool Contains(K key, V value)
        {
            if (ContainsKey(key))
                foreach (var item in _dictionary[key])
                    if (value.Equals(item))
                        return true;
            return false;
        }

        public bool ContainsKey(K key)
        {
            return _dictionary.ContainsKey(key);
        }
                
        public IEnumerator<KeyValuePair<K, IEnumerable<V>>> GetEnumerator()
        {
            foreach (var pair in _dictionary)
                yield return new KeyValuePair<K, IEnumerable<V>>(pair.Key, pair.Value);
        }

        public bool Remove(K key)
        {
            return _dictionary.Remove(key);
        }

        public bool Remove(K key, V value)
        {
            LinkedList<V> linkedList;
            _dictionary.TryGetValue(key, out linkedList);
            return linkedList.Remove(value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }
    }
}
