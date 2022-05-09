using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;

class App:Exercise2
{
    public static void Main(string[] args)
    {

        //(int, int) point1 = (5, 4);
        //(int, int) screenSize = (5, 5);
        //Direction4 direction = Direction4.DOWN;
        //var point2 = NextPoint(direction, point1, screenSize);
        //Console.WriteLine(point2);
        //int[,] screen =
        //{
        //  {1, 0, 0},
        //  {0, 0, 0},
        //  {0, 0, 0}
        //};
        //(int, int) point = (1, 1);
        //Direction8 direction = DirectionTo(screen, point, 1);
        Car[] _cars = new Car[]
         {
             new Car(),
             new Car(Model: "Fiat", true),
             new Car(),
             new Car(Power: 100),
             new Car(Model: "Fiat", true),
             new Car(Power: 125),
             new Car(),
        };
        Console.WriteLine(Exercise3.CarCounter(_cars));
        //Student[] students = {
        //  new Student("Kowal","Adam", 'A'),
        //  new Student("Nowak","Ewa", 'A')
        //};
        //AssignStudentId(students);
    }
}

enum Direction8
{
    UP,
    DOWN,
    LEFT,
    RIGHT,
    UP_LEFT,
    DOWN_LEFT,
    UP_RIGHT,
    DOWN_RIGHT
}

enum Direction4
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}

//Cwiczenie 1
//Zdefiniuj metodę NextPoint, która powinna zwracać krotkę ze współrzędnymi piksela przesuniętego jednostkowo w danym kierunku względem piksela point.
//Krotka screenSize zawiera rozmiary ekranu (width, height)
//Przyjmij, że początek układu współrzednych (0,0) jest w lewym górnym rogu ekranu, a prawy dolny ma współrzęne (witdh, height) 
//Pzzykład
//dla danych wejściowych 
//(int, int) point1 = (2, 4);
//Direction4 dir = Direction4.UP;
//var point2 = NextPoint(dir, point1);
//w point2 powinny być wartości (2, 3);
//Jeśli nowe położenie jest poza ekranem to metoda powinna zwrócić krotkę z point
class Exercise1
{
    public static (int, int) NextPoint(Direction4 direction, (int, int) point, (int, int) screenSize)
    {
        var Point = point;
        int x = Point.Item1;
        int y = Point.Item2;
        var ScreenSize = screenSize;
        int size1 = ScreenSize.Item1;
        int size2 = ScreenSize.Item2;
        if (direction == Direction4.UP && y == 0)
        {
            return Point;
        }
        else if (direction == Direction4.LEFT && x == 0 && x >= size1 && y >= size2)
        {
            return Point;
        }else if(direction == Direction4.RIGHT &&x>= size1){
            return Point;
        }
        else if (direction == Direction4.DOWN && y >= size2)
        {
            return Point;
        }
        else
        {
           switch(direction)
            {
                case Direction4.UP:
                    return Point = (x, y - 1);
            
                case Direction4.DOWN:
                    return Point = (x, y+1);
            
                case Direction4.LEFT:
                    return Point = (x-1, y);
            
                case Direction4.RIGHT:
                    return Point = (x+1, y);
            
                default:
                    return Point;
                   
        }
            
        }
    }
}
//Cwiczenie 2
//Zdefiniuj metodę DirectionTo, która zwraca kierunek do piksela o wartości value z punktu point. W tablicy screen są wartości
//pikseli. Początek układu współrzędnych (0,0) to lewy górny róg, więc punkt o współrzęnych (1,1) jest powyżej punktu (1,2) 
//Przykład
// Dla danych weejsciowych
// static int[,] screen =
// {
//    {1, 0, 0},
//    {0, 0, 0},
//    {0, 0, 0}
// };
// (int, int) point = (1, 1);
// po wywołaniu - Direction8 direction = DirectionTo(screen, point, 1);
// w direction powinna znaleźć się stała UP_LEFT
class Exercise2
{
    static int[,] screen =
    {
        {1, 0, 0},
        {0, 0, 0},
        {0, 0, 0}
    };

    private static (int, int) point = (1, 1);

    private Direction8 direction = DirectionTo(screen, point, 1);

    public static Direction8 DirectionTo(int[,] screen, (int, int) point, int value)
    {
        int x = point.Item1;
        int y = point.Item2;

        for (int i = 0; i < x; i++)
        {
            for (int z = 0; z < y; z++)
            {
                if (value == screen[i,z])
                {
                    if (y-1 == z && x == i)
                    {
                        Console.WriteLine("UP");
                        return Direction8.UP;
                    }else if(y-1==z && x + 1 == i)
                    {
                        Console.WriteLine("UP_RIGHT");
                        return Direction8.UP_RIGHT;
                    }
                    else if (y== z && x + 1 == i)
                    {
                        Console.WriteLine("RIGHT");
                        return Direction8.RIGHT;
                    }
                    else if (y+1 == z && x + 1 == i)
                    {
                        Console.WriteLine("DOWN_RIGHT");
                        return Direction8.DOWN_RIGHT;
                    }
                    else if (y + 1 == z && x == i)
                    {
                        Console.WriteLine("DOWN");
                        return Direction8.DOWN;
                    }
                    else if (y + 1 == z && x - 1 == i)
                    {
                        Console.WriteLine("DOWN_LEFT");
                        return Direction8.DOWN_LEFT;
                    }
                    else if (y == z && x - 1 == i)
                    {
                        Console.WriteLine("LEFT");
                        return Direction8.LEFT;
                    }
                    else if (y - 1 == z && x - 1 == i)
                    {
                        Console.WriteLine("UP_LEFT");
                        return Direction8.UP_LEFT;
                    }
                    else {
                        return 0;
                    }
                }
            }
        }
        Console.WriteLine("UP");
        return Direction8.UP;
        
    }
}

//Cwiczenie 3
//Zdefiniuj metodę obliczającą liczbę najczęściej występujących aut w tablicy cars
//Przykład
//dla danych wejściowych
// Car[] _cars = new Car[]
// {
//     new Car(),
//     new Car(Model: "Fiat", true),
//     new Car(),
//     new Car(Power: 100),
//     new Car(Model: "Fiat", true),
//     new Car(Power: 125),
//     new Car()
// };
//wywołanie CarCounter(Car[] cars) powinno zwrócić 3
record Car(string Model = "Audi", bool HasPlateNumber = false, int Power = 100);

class Exercise3
{
    public static int CarCounter(Car[] cars)
    {
        var DicOfCars = new Dictionary<object, int>();
        foreach (var item in cars)
        {
            if (DicOfCars.ContainsKey(item))
            {
                DicOfCars[item]++;
            }
            else
            {
                DicOfCars[item] = 1;
            }
        }
        return DicOfCars.Values.Max();
    }
}

record Student(string LastName, string FirstName, char Group, string StudentId = "");
//Cwiczenie 4
//Zdefiniuj metodę AssignStudentId, która każdemu studentowi nadaje pole StudentId wg wzoru znak_grupy-trzycyfrowy-numer.
//Przykład
//dla danych wejściowych
//Student[] students = {
//  new Student("Kowal","Adam", 'A'),
//  new Student("Nowak","Ewa", 'A')
//};
//po wywołaniu metody AssignStudentId(students);
//w tablicy students otrzymamy:
// Kowal Adam 'A' - 'A001'
// Nowal Ewa 'A'  - 'A002'
//Należy przyjąc, że są tylko trzy możliwe grupy: A, B i C
class Exercise4
{
    public static void AssignStudentId(Student[] students)
    {
        int A = 0;
        int B = 0;
        int C = 0;
        foreach (var student in students)
        {
            string Group = student.Group.ToString();
            if (Group == "A")
            {
                A++;
                if (A <= 9 && A>=0)
                { 
                    //student.StudentId = $"{student.Group}00{count}";
                    Console.WriteLine($"{student.LastName} {student.FirstName} '{student.Group}' - '{student.Group}00{A}'");
                }
                else if (A >= 10 && A <= 99)
                {
                    Console.WriteLine($"{student.LastName} {student.FirstName} '{student.Group}' - '{student.Group}0{A}'");
                }
                else
                {
                    Console.WriteLine($"{student.LastName} {student.FirstName} '{student.Group}' - '{student.Group}{A}'");
                }
            }
            else if (Group == "B")
            {
                B++;
                if (B <= 9 && B>=0)
                {
                    Console.WriteLine($"{student.LastName} {student.FirstName} '{student.Group}' - '{student.Group}00{B}'");
                }
                else if (B >= 10 && B <= 99)
                {
                    Console.WriteLine($"{student.LastName} {student.FirstName} '{student.Group}' - '{student.Group}0{B}'");
                }
                else
                {
                    Console.WriteLine($"{student.LastName} {student.FirstName} '{student.Group}' - '{student.Group}{B}'");
                }
            }
            else
            {
                C++;
                if (C <= 9 && C >= 0)
                {
                    Console.WriteLine($"{student.LastName} {student.FirstName} '{student.Group}' - '{student.Group}00{C}'");
                }
                else if (C >= 10 && C <= 99)
                {
                    Console.WriteLine($"{student.LastName} {student.FirstName} '{student.Group}' - '{student.Group}0{C}'");
                }
                else
                {
                    Console.WriteLine($"{student.LastName} {student.FirstName} '{student.Group}' - '{student.Group}{C}'");
                }
            }
        }
    }
}