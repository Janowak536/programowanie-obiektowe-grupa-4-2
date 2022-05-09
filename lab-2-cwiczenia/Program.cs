using System;

namespace lab_2_cwiczenia
{
    #region
    public abstract class Vehicle
    {
        public double Weight { get; init; }
        public int MaxSpeed { get; init; }
        protected int _mileage;
        public int Mealeage
        {
            get { return _mileage; }
        }
        public abstract decimal Drive(int distance);
        public override string ToString()
        {
            return $"Vehicle{{ Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage} }}";
        }
    }
    public abstract class Scooter : Vehicle
    {

    }
    public class ElectricScooter : Scooter
    {
        private int maxRange;
        private int batteriesLevel;
        public int BatteriesLevel
        {
            get
            {
                return batteriesLevel;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    batteriesLevel= value; ;
                }
            }
        }
        public int MaxRange
        {
            get
            {
                if (batteriesLevel == 100)
                {
                    return maxRange;
                }
                else { return -1; }
            }
            set { }
        }
        public int ChargeBatteries()
        {
            if (batteriesLevel <100 )
            {
                return batteriesLevel = 100;
            }
            else
            {
                return batteriesLevel;
            }
        }
        public override decimal Drive(int distance)
        {
            if (batteriesLevel>0)
            {
                _mileage += distance;
                return (distance / MaxRange);
            }
            return -1;
        }
        public override string ToString()
        {
            return $"ElectricScooter{{Weight: {Weight}, MaxSpeed: {MaxSpeed}, {batteriesLevel}}}";
        }
    }
    public class KickScooter : Scooter
    {
        public override decimal Drive(int distance)
        {
            throw new NotImplementedException();
        }
    }
    public class Car : Vehicle
    {
        public bool isFuel { get; set; }
        public bool isEngineWorking { get; set; }
        public override decimal Drive(int distance)
        {
            if (isFuel && isEngineWorking)
            {
                _mileage += distance;
                return (decimal)(distance / (double)MaxSpeed);
            }
            return -1;
        }
        public override string ToString()
        {
            return $"Car{{Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage}}}";
        }
    }
    public class Bicycle : Vehicle
    {
        public bool isDriver { get; set; }
        public override decimal Drive(int distance)
        {
            if (isDriver)
            {
                _mileage += distance;
                return (decimal)(distance / (double)MaxSpeed);
            }
            return -1;
        }
        public override string ToString()
        {
            return $"Bicycle{{Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage}}}"; ;
        }
    }
    #endregion

    public abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }
    public abstract class Iterator
    {
        public abstract  int GetNext();
        public abstract bool HasNext();
    }
    public class ArrayIntAggregate : Aggregate
    {
        internal int[,] array = { 
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 } 
        };
        public override Iterator CreateIterator()
        {
            return new ArrayIntIterator(this);
        }  
    }
    public class ArrayIntIterator : Iterator
    {
        
        private int x = 0;
        private int y = 0;
        private ArrayIntAggregate _aggregate;
        public ArrayIntIterator(ArrayIntAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        public override int GetNext()
        {
            if (y==2)
            {
                y = 0;
                return _aggregate.array[x++,2 ];
                
            }
            else if (y==1||y==0)
            {
                return _aggregate.array[x, y++];
            }
            else
            {
                y = 0;
                return _aggregate.array[x, y];
            }
        }

        public override bool HasNext()
        {
            return x < _aggregate.array.Length;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region
            /*
            ElectricScooter e = new ElectricScooter()  { BatteriesLevel = 100, MaxSpeed = 120, Weight = 200 };
            ElectricScooter e2 = new ElectricScooter() { BatteriesLevel = 3, MaxSpeed = 32, Weight = 21 };
            Console.WriteLine(e.ToString());
            Console.WriteLine(e2.ToString());
            e2.ChargeBatteries();
            Console.WriteLine(e2.ToString());
            */
            #endregion
            ArrayIntAggregate aggregate = new ArrayIntAggregate();
            for (var iterator = aggregate.CreateIterator();iterator.HasNext();)
            {
                Console.WriteLine(iterator.GetNext()) ;
            }

        }
    }
}
