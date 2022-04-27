using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_8_zajecia
{
    internal class Program
    {
        record Student(int Id, string Name, int Ects);

        static void Main(string[] args)
        {
            int[] ints = { 4, 6, 7, 3, 2, 8, 9 };

            IEnumerable<int> evenNumbers =
            from n in ints
            where n % 2 == 0
            orderby n
            select n;

            Console.WriteLine(String.Join(", ", evenNumbers));

            IEnumerable<int> higherThanFive =
                from x in ints
                where x > 5
                select x;
            Console.WriteLine(String.Join(", ", higherThanFive));

            Predicate<int> intPredicate = n =>
            {
                Console.WriteLine("wywołanie predykatu dla " + n);
                return n % 2 == 0;
            };

            evenNumbers = from n in ints
                          where intPredicate.Invoke(n)
                          select n;
            evenNumbers = from n in evenNumbers
                          where n > 5
                          select n * 2;

            Console.WriteLine("Wywołanie ewaluacji wyrażenia LINQ");

            Console.WriteLine(String.Join(", ", evenNumbers));

            Console.WriteLine(evenNumbers.Sum());
            Console.WriteLine();

            Console.WriteLine("================");
            Console.WriteLine(evenNumbers.Count());
            Console.WriteLine("================");
            Console.WriteLine(evenNumbers.Max());
            Console.WriteLine("================");
            Console.WriteLine(evenNumbers.Min());
            Console.WriteLine();
            Student[] students =
            {
                new Student(1,"Ewa",67),
                new Student(2,"Karol",67),
                new Student(4,"Ewa",63),
                new Student(7,"Ania",67),
                new Student(5,"Karol",37),
            };

            IEnumerable<string> enumerable =
                from s in students
                orderby s.Ects
                orderby s.Name descending
                select s.Name + " " + s.Ects;
            Console.WriteLine(string.Join("\n", enumerable));


            IEnumerable<int> descending =
                from y in ints
                orderby y descending
                select y;
            Console.WriteLine(string.Join(", ", descending));

            Console.WriteLine(string.Join(", ", ints.OrderByDescending(i => i)));
            Console.WriteLine(string.Join(", ", students.OrderBy(s => s.Name).ThenBy(s => s.Ects)));
            Console.WriteLine();

            IEnumerable<IGrouping<string, Student>> studentNameGroup =
                from s in students
                group s by s.Name;

            foreach (var item in studentNameGroup)
            {
                Console.WriteLine(item.Key + " " + string.Join(", ", item));
            }

            Console.WriteLine();

            IEnumerable<(string Key, int)> NameCounters =
                from s in students
                group s by s.Name into groupItem
                select (groupItem.Key, groupItem.Count());
            Console.WriteLine(string.Join(", ", NameCounters));

            string str = "ala ma kota ala lubi koty karol lubi psy";

            IEnumerable<(string Key, int)> texts =
                from u in str.Split(" ")
                group str by u into groupItem
                select (groupItem.Key, groupItem.Count());

            Console.WriteLine(string.Join(", ", texts));
            Console.WriteLine();

            evenNumbers = ints.Where(i=>i%2==0).Select(i=>i+2);
            Console.WriteLine(string.Join(", ",evenNumbers));
            Console.WriteLine();

            students.Where(s=>s.Ects > 20).OrderBy(s=>s.Id).Select(s=>(s.Id, s.Name)).ToList().ForEach(s=>Console.WriteLine(s));

            (int Id, string Name) p = students
                .Where(s => s.Ects > 20)
                .OrderBy(s => s.Id)
                .Select(s => (s.Id, s.Name))
                .FirstOrDefault(s => s.Name.StartsWith("A"));
            Console.WriteLine("---------------");
            Console.WriteLine(p);

            int[] powerInts = Enumerable
                .Range(0, ints.Length)
                .Select(i => ints[i] * ints[i])
                .ToArray();
            Console.WriteLine(String.Join(", ",powerInts));
            Random random = new Random();
            random.Next(5);
            Enumerable.Range(0, 101).Select(i => random.Next(9)).ToList().ForEach(s=>Console.Write(", "+ s));

            int page = 0;
            int size = 3;
            Console.WriteLine();

            List<Student> pageStudent =  students.Skip(page * size).Take(size).ToList();
            Console.WriteLine(string.Join(", ",pageStudent));
        }
    }
}
