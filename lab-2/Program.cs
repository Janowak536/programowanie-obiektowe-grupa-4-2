using System;

namespace lab_2
{
    #region
    interface IDriveable
    {
        int Drive(int distance);
    }
    interface ISwimmingable
    {
        int Swim(int distance);
    }
    interface IFlyable
    {
        void TakeOff();
        int Fly(int disntance);
        void Land();
    }
    public class Duck : ISwimmingable, IFlyable
    {
        void IFlyable.TakeOff()
        {
            Console.WriteLine("IFlyable TAKE OFF");
        }

        int IFlyable.Fly(int disntance)
        {
            Console.WriteLine("IFlyable FLY");
            return 0;
        }

        void IFlyable.Land()
        {
            Console.WriteLine("IFlyable Land");
        }

        int ISwimmingable.Swim(int distance)
        {
            Console.WriteLine("ISwimmingable SWIM");
            return 0;
        }
    }
    public class Wasp : IFlyable
    {
        void IFlyable.TakeOff()
        {
            Console.WriteLine("IFlyable TAKE OFF");
        }

        int IFlyable.Fly(int disntance)
        {
            Console.WriteLine("IFlyable FLY");
            return 0;
        }

        void IFlyable.Land()
        {
            Console.WriteLine("IFlyable Land");
        }
    }
    public class Truck : Vehicle, IDriveable
    {
        public override decimal Drive(int distance)
        {
            Console.WriteLine("DRIVE");
            return 0;
        }

        int IDriveable.Drive(int distance)
        {
            Console.WriteLine("IDriveable DRIVE");
            return 0;
        }
    }
    public class Amphibian : Vehicle, IDriveable, ISwimmingable
    {
        public override decimal Drive(int distance)
        {
            Console.WriteLine("DRIVE");
            return 0;
        }
        public decimal Swim(int distance)
        {
            Console.WriteLine("SWIM");
            return 0;
        }

        int IDriveable.Drive(int distance)
        {
            Console.WriteLine("IDriveable DRIVE");
            return 0;
        }

        int ISwimmingable.Swim(int distance)
        {
            Console.WriteLine("ISwimmingable SWIM");
            return 0;
        }
    }
    public class Hydroplane : Vehicle, IFlyable, ISwimmingable
    {
        public override decimal Drive(int distance)
        {
            Console.WriteLine("DRIVE");
            return 0;
        }
        public decimal Swim(int distance)
        {
            Console.WriteLine("SWIM");
            return 0;
        }
        public bool TakeOff()
        {
            Console.WriteLine("TAKE OFF");
            return true;
        }
        public decimal Fly(int distance)
        {
            Console.WriteLine("FLY");
            return 0;
        }
        public bool Land()
        {
            Console.WriteLine("LAND");
            return true;
        }

        void IFlyable.TakeOff()
        {
            Console.WriteLine("IFlyable TAKE OFF");
        }

        int IFlyable.Fly(int disntance)
        {
            Console.WriteLine("IFlyable FLY");
            return 0;
        }

        void IFlyable.Land()
        {
            Console.WriteLine("IFlyable Land");
        }

        int ISwimmingable.Swim(int distance)
        {
            Console.WriteLine("ISwimmingable SWIM");
            return 0;
        }
    }

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
        public int Batteries { get; internal set; }// aktualny stan
        public int MaxRange { get; internal set; }// max range ale tylko do wpisania w main i sprawdzenia w drive
        public int ChargeBatteries(int howMany)
        {
            if (Batteries <100 && Batteries >=0)
            {
                return Batteries += howMany;
            }
            else
            {
                throw new ArgumentException("błąd");
            }
        }
        public override decimal Drive(int distance)
        {
            if (Batteries>0 && MaxRange > distance)
            {
                _mileage += distance;
                for (int i = 0; i <= _mileage; i+=10)
                {
                    Batteries -= 1;
                }
                return (decimal)(distance / (double)MaxSpeed);
            }
            return -1;
        }
        public override string ToString()
        {
            return $"Vehicle{{ Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage}, Batteries:={Batteries }, Max Range: {MaxRange}";
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
        public abstract int GetNext();
        public abstract bool HasNext();
    }
    public class ArrayIntAggregate : Aggregate
    {
        internal int[] array = { 1, 2, 3, 4, 5 };

        public override Iterator CreateIterator()
        {
            return new ArrayIntIterator(this);
        }
    }
    public sealed class ArrayIntIterator : Iterator
    {
        private int _index = 0;
        private ArrayIntAggregate _aggregate;
        public ArrayIntIterator(ArrayIntAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        public override int GetNext()
        {
            return _aggregate.array[_index++];
        }
        public override bool HasNext()
        {
            return _index < _aggregate.array.Length;
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            #region
            Vehicle[] vehicles =
            {
                new Bicycle(){Weight = 15, MaxSpeed = 30, isDriver = true},
                new Car(){Weight = 900, MaxSpeed = 120, isFuel = true, isEngineWorking = true},
                new Bicycle(){Weight = 21, MaxSpeed = 40, isDriver = true},
                new Bicycle(){Weight = 19, MaxSpeed = 35, isDriver = true},
                new Car(){Weight = 1200, MaxSpeed = 130, isFuel = true, isEngineWorking = true},
                new ElectricScooter(){Weight = 1200, MaxSpeed = 130, Batteries = 33}
            };
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine("Time for distance: " + vehicle.Drive(45));
            }
            int bicycleCounter = 0;
            int carCounter = 0;
            int electricScooterCounter = 0;
            foreach (var vehicle in vehicles)
            {
                if (vehicle is Bicycle)
                {
                    bicycleCounter++;
                    Bicycle bicycle = (Bicycle)vehicle;
                    Console.WriteLine("Czy rower ma kierowcę: " + bicycle.isDriver);
                }
                if (vehicle is Car)
                {
                    carCounter++;
                }
                if (vehicle is ElectricScooter)
                {
                    electricScooterCounter++;
                }
            }
            ElectricScooter[] electricScooters =
            {
                new ElectricScooter(){Weight = 1200, MaxSpeed = 130, Batteries = 33, MaxRange = 500}
            };
            foreach (var electricScooter in electricScooters)
            {
                if (electricScooter is ElectricScooter)
                {
                    electricScooter.ChargeBatteries(2);
                    electricScooter.Drive(20);
                    Console.WriteLine($"Vehicle{{ Weight: {electricScooter.Weight}, MaxSpeed: {electricScooter.MaxSpeed}, Batteries:={electricScooter.Batteries }, Max Range: {electricScooter.MaxRange}");
                }
            }
            Console.WriteLine($"Liczba rowerów: {bicycleCounter}, liczba samochodów: {carCounter}, liczba elektrycznych skuterów: {electricScooterCounter}");

            Vehicle[] army =
            {
                new Amphibian(){MaxSpeed = 20},
                new Hydroplane(){MaxSpeed = 800},
                new Truck() {MaxSpeed = 100}
            };
            foreach (var vehicle in army)
            {
                if (vehicle is Hydroplane)
                {
                    Console.WriteLine("Hydroplane");
                    Hydroplane hydroplane = (Hydroplane)vehicle;
                    hydroplane.TakeOff();
                    hydroplane.Fly(100);
                    hydroplane.Land();
                }
            }
            
            IFlyable[] flyables =
            {
                new Duck(){},
                new Wasp(){ },
                new Hydroplane(){},
            };
            ISwimmingable[] swimmingables =
            {
                new Hydroplane(){},
                new Amphibian(){}
            };
            int flyAndSwimCounter = 0;
            foreach (var flyable in flyables)
            {
                foreach (var swimingable in swimmingables)
                {
                    if (flyable.GetType() == swimingable.GetType())
                    {
                        flyAndSwimCounter++;
                    }
                }
                
            }
            Console.WriteLine(flyAndSwimCounter);
            #endregion
            Aggregate aggregate = new ArrayIntAggregate();
            for (var iterator = aggregate.CreateIterator(); iterator.HasNext();)
            {
                Console.WriteLine(iterator.GetNext());
            }
        }
    }
}
