using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class Program
    {
        public record Student(string Name, int Points, char Egzam);
        static void Main(string[] args)
        {

            ISet<string> setA = new HashSet<string>();
            setA.Add("ala");
            setA.Add("ola");
            setA.Add("ewa");

            Console.WriteLine($"Zbiór A: {String.Join(", ", setA)}");

            string[] names = { "karol", "adam", "ola" };
            ISet<String> setB = new SortedSet<string>(names);

            Console.WriteLine($"Zbiór B: {String.Join(", ", setB)}");

            Console.WriteLine($"Czy zbiór A jest podzbiorem B: {setA.IsSubsetOf(setB)}");

            ISet<string> result = new HashSet<string>(setA);
            result.IntersectWith(setB);

            Console.WriteLine($"Cześć wspólna zbiorów A i B: {String.Join(", ", result)}");

            result = new HashSet<string>(setA);
            result.UnionWith(setB);

            Console.WriteLine($"Połączenie zbiorów A i B: {String.Join(", ", result)}");

            result = new HashSet<string>(setA);
            result.ExceptWith(setB);
            Console.WriteLine($"Zbiór A po usunięciu części wspólnej ze zbiorem B: {String.Join(", ", result)}");


            //MyCollection<string> names2 = new MyCollection<string>(new string[] { "adam", null, "karol" });
            //foreach (var i in names2)
            //{
            //   
            //   Console.WriteLine(i);
            //}
                /*
                (double temperature, char unit, char destination) measurement = (200, 'f', 'c');
                double conversion = measurement switch
                {
                    { unit: 'c', destination: 'f' } => measurement.temperature * 9.0 / 5.0 + 32,
                    { unit: 'f', destination: 'c' } => (measurement.temperature - 32) * 5.0 / 9.0,
                    _ => throw new ArgumentException("Nieznane jednostki")
                };
                Console.WriteLine(conversion);

                Student student = new Student("Adam", 45, 'F');
                Console.WriteLine(student);
                Console.WriteLine(student.Equals(new Student("Adam", 45, 'F')));
                Console.WriteLine(student == (new Student("Adam", 45, 'F')));
                Console.WriteLine(student.GetHashCode());
                Console.WriteLine(new Student("Adam", 45, 'F').GetHashCode());

                var studentWithChanges = student with { Name = "Ewa" };
                Console.WriteLine(studentWithChanges);
                */
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
            return new MyEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class MyEnumerator<T> : IEnumerator<T>
    {
        private MyCollection<T> collection;
        private int index = -1;

        public MyEnumerator(MyCollection<T> items)
        {
            this.collection=items;
        }
        public T Current
        {
            get => collection.items[index];
        } 

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
             index++;
            while(index<collection.items.Length && collection.items[index] == null)
            {
                index++;
            }
            return index < collection.items.Length;
        }

        public void Reset()
        {
            index = 0;
        }
    }
    
    
}
