using System;
using System.Collections;
using System.Collections.Generic;

namespace Iterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyCollection<string> names = new MyCollection<string>(new string[] { "adam", null, "karol" });
            foreach (var i in names)
            {
                Console.WriteLine(i);
            }
        }
    }
    public class MyCollection<T> : IEnumerable<T>
    {
        internal T[] items;
        public MyCollection(T[] items)
        {
            this.items = items;
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
            {
                if (item != null) // chodzi tu o tworzenie własnego enumeratora z własną logiką
                {
                    yield return item; 
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
