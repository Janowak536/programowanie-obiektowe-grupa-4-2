using System;
using System.Collections.Generic;

namespace Kolekcje
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region ICollection
            string[] array = { "adam", "ola", "karol" };
            ICollection<string> namesToCollection = new LinkedList<string>(array);

            Console.WriteLine("Przeglądanie instrukcją foreach");
            foreach (var name in namesToCollection)
            {
                Console.WriteLine(name);
            }
            namesToCollection.Add("ewa");
            Console.WriteLine($"Lista po dodaniu nowego imienia: {String.Join(", ", namesToCollection)})");
            Console.WriteLine($"Czy lista zawiera imię 'ola': {namesToCollection.Contains("ola")}");
            namesToCollection.Remove("adam");
            Console.WriteLine($"Lista po usunięciu umienia 'adam': {namesToCollection.Contains("ola")}");
            #endregion

            #region IList
            IList<string> namesToList = new List<string>() { "adam", "ola", "karol" };

            Console.WriteLine($"Liczba elementów: {namesToList.Count}");
            Console.WriteLine($"Element pod indeksem 2: {namesToList[2]}");
            Console.WriteLine($"Pozycja imienia 'ola': {namesToList.IndexOf("ola")}");
            namesToList.RemoveAt(1);
            Console.WriteLine($"Lista po usunięciu elementu o indeksie 1: {String.Join(", ", namesToList)}");
            namesToList.Insert(1, "ewa");
            Console.WriteLine($"Lista po wstawieniu elementu na pozycji 1: {String.Join(", ", namesToList)}");
            #endregion


            #region ISet
            Dictionary<string, int> numbers = new Dictionary<string, int>();
            numbers.Add("one", 1);
            numbers.Add("two", 2);
            numbers.Add("three", 3);
            Console.WriteLine("Zawartość słownika – iterowanie foreach:");
            foreach (var item in numbers)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
            Console.WriteLine($"Zbiór kluczy: {String.Join(", ", numbers.Keys)}");
            Console.WriteLine($"Kolekcja wartości: {String.Join(", ", numbers.Values)}");
            Console.WriteLine($"Wartość pod kluczem 'two': {numbers["two"]}");
            numbers.Remove("three");
            Console.WriteLine($"Słownik po usunięciu wartości o kluczu 'three': {String.Join(", ", numbers)}");

            if (numbers.TryGetValue("four", out var value))
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine("Brak wartości o takim kluczu!");
            }
            // to jest to samo co if wyżej =>>>> Console.WriteLine(numbers.TryGetValue("two", out var result) ? $"{result}" : "Brak wartości o takim kluczu!");


            #endregion

            #region IComparer LengthComparer
            List<string> names = new List<string>() { "adam", "ola", "karol" };
            names.Sort(new LengthComparer());
            Console.WriteLine(String.Join(", ", names));
            #endregion

            HashSet<User> users = new HashSet<User>();
            users.Add(new User { Name = "adam", Points = 10 });
            users.Add(new User { Name = "adam", Points = 10 });
            users.Add(new User { Name = "adam", Points = 10 });
            Console.WriteLine(String.Join(", ", users));

        }
    }
    class LengthComparer: IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            if (x.Length == y.Length)
            {
                return string.Compare(x, y);
            }
            else
            {
                return x.Length.CompareTo(y.Length);
            }
        }
    }
    class User
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public override bool Equals(object? obj)
        {
            Console.WriteLine("Calling Equals");
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User)obj);
        }
        public override int GetHashCode()
        {
            var hash = HashCode.Combine(Name, Points);
            Console.WriteLine($"Calling GetHashCode, hashCode = {hash}");
            return hash;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Points: {Points}";
        }
    }
}
