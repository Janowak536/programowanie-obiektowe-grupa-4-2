using System;
using System.Collections.Generic;

namespace lab_6
{
    class Student:IComparable<Student>
    {
        public string Name { get; set; }
        public int Ects { get; set; }

        public int CompareTo(Student other)
        {
            if (Name.CompareTo(other.Name) == 0)
            {
                return Ects.CompareTo(other.Ects);

            }
            return Name.CompareTo(other.Name);
        }

        public override bool Equals(object obj)
        {
            Console.WriteLine("Student Equals");

            return obj is Student student &&
                   Name == student.Name &&
                   Ects == student.Ects;
        }

        public override int GetHashCode()
        {
            Console.WriteLine("Student HashCode");
            return HashCode.Combine(Name, Ects);
        }

        public override string ToString()
        {
            return $"Name = {Name}, Ects= {Ects}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ICollection<string> names = new List<string>();
            names.Add("Ewa");
            names.Add("Karol");
            names.Add("Adam");
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(names.Contains("Adam"));
            Console.WriteLine("----------------------ICollection----------------------");
            ICollection<Student> students = new List<Student>();
            students.Add(new Student() { Name = "Ewa1", Ects = 24 });
            students.Add(new Student() { Name = "Ewa2", Ects = 25 });
            students.Add(new Student() { Name = "Ewa3", Ects = 26 });
            Console.WriteLine();
            foreach (var item in students)
            {
                Console.WriteLine($"{item.Name} , {item.Ects}");
            }

            students.Remove(new Student() { Name = "Ewa3", Ects = 26 });

            foreach (var item in students)
            {
                Console.WriteLine($"{item.Name} , {item.Ects}");
            }
            Console.WriteLine(students.Contains(new Student() { Name= "Ewa1", Ects=25}));
            List<Student> list = (List<Student>)students;
            Console.WriteLine();
            Console.WriteLine(list[0]);
            Console.WriteLine();
            list.Insert(1,new Student() { Name="Ewa4",Ects=45});
            foreach (var item in students)
            {
                Console.WriteLine($"{item.Name} , {item.Ects}");
            }
            Console.WriteLine();
            int index = list.IndexOf(new Student() { Name = "Ewa4", Ects = 45 });
            Console.WriteLine(index);
            list.RemoveAt(0);
            foreach (var item in students)
            {
                Console.WriteLine($"{item.Name} , {item.Ects}");
            }
            Console.WriteLine("----------------------HashSet----------------------");
            ISet<string> set = new HashSet<string>();
            set.Add("Ewa");
            set.Add("Karol");
            set.Add("Adam");
            set.Add("Adam");
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            ISet<Student> studentGroup = new HashSet<Student>();
            studentGroup.Add(new Student() { Name = "Ewa1", Ects = 24 });
            studentGroup.Add(new Student() { Name = "Ewa2", Ects = 25 });
            studentGroup.Add(new Student() { Name = "Ewa3", Ects = 26 });
            studentGroup.Add(new Student() { Name = "Ewa1", Ects = 24 });
            foreach (var item in studentGroup)
            {
                Console.WriteLine($"{item.Name} , {item.Ects}");
            }
            studentGroup.Contains(new Student() { Name="Ewa1",Ects=24});
            
            //studentGroup.Remove(new Student() { Name = "Ewa2", Ects = 25 });

            studentGroup = new SortedSet<Student>(studentGroup);


            foreach (var item in studentGroup)
            {
                Console.WriteLine($"{item.Name} , {item.Ects}");
            }
            studentGroup.Add(new Student() { Name = "Ewa1", Ects = 288 });
            studentGroup.Add(new Student() { Name = "Ewa2", Ects = 2999 });
            Console.WriteLine();
            foreach (var item in studentGroup)
            {
                Console.WriteLine($"{item.Name} , {item.Ects}");
            }
            studentGroup.Contains(new Student() { Name = "Ewa2", Ects = 2999 });

            Console.WriteLine("----------------------Dictionary----------------------");

            Dictionary<Student,string> phoneBook = new Dictionary<Student,string>();
            phoneBook[list[0]] = "234243243";
            phoneBook[list[1]] = "244444444";
            phoneBook[new Student() { Name="Ewa66",Ects=66}] = "255555555";
            Console.WriteLine(phoneBook.Keys);
            if (phoneBook.ContainsKey(new Student() { Name = "Ewa66", Ects = 66 }))
            {
                Console.WriteLine("Jest telefon");
            }else
            {
                Console.WriteLine("Brak telefonu");
            }
            foreach (var item in phoneBook)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
            string[] arr = { "adam", "ewa", "karol", "ewa", "ania", "karol", "adam", "adam", "ewa" };
            Dictionary<string, int>counters = new Dictionary<string, int>();
            foreach (var name in arr)
            {
                if (counters.ContainsKey(name))
                {
                    counters[name]++;
                }
                else
                {
                    counters[name] = 1;
                    counters.Add(name, 1);
                }
            }
            foreach (var item in counters)
            {
                Console.WriteLine(item.Key + " występuje" + item.Value);
            }
            
        }
    }
}
