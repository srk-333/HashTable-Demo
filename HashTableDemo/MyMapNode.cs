using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableDemo
{
    public class MyMapNode<K, V>
    {
        public struct KeyValue<k, v>
        {
            public k Key { get; set; }
            public v Value { get; set; }
        }
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;
        /// <summary>
        /// Initializes a new instance of the <see cref="MyMapNode{K, V}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        /// <summary>
        /// Gets the array position.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        protected int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        /// <summary>
        /// Gets the array and linked list position.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public LinkedList<KeyValue<K, V>> GetArrayAndLinkedListPosition(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            return linkedList;
        }
        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public V Get(K key)
        {
            var linkedList = GetArrayAndLinkedListPosition(key);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }
        /// <summary>
        /// Adds the specified key value..
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(K key, V value)
        {
            var linkedList = GetArrayAndLinkedListPosition(key);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
            if (linkedList.Count != 0)
            {
                foreach (KeyValue<K, V> item1 in linkedList)
                {
                    if (item1.Key.Equals(key))
                    {
                        Remove(key);
                        break;
                    }                   
                }
            }
            linkedList.AddLast(item);
        }
        public bool Exists(K key)
        {
            var linkedList = GetArrayAndLinkedListPosition(key);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Remove(K key)
        {
            var linkedList = GetArrayAndLinkedListPosition(key);
            bool itemFound = false;
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }
        /// <summary>
        /// Gets the linked list.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            foreach (var linkedlist in items)
            {
                if (linkedlist != null)
                {
                    foreach (var element in linkedlist)
                    {
                        string res = element.ToString();
                        if (res != null)
                            Console.WriteLine(element.Key +"  "+element.Value);
                    }
                }
            }
        }
    }
}