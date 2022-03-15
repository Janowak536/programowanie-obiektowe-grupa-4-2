using System;

namespace lab_1_praca_domowa
{
    public enum Unit
    {
        meter = 1,
        squaremeter = 2
    }
  
    public class Length
    {

        private readonly decimal _value;
        private readonly Unit _unit;
        private Length(decimal value, Unit unit)
        {
            _value = value;
            _unit = unit;
        }
        public static Length OfWithException(decimal value, Unit unit)
        {

            if (value < 0)
            {
                throw new ArgumentException("Liczba mniejsza od zera");
            }
            else
            {
                return new Length(value, unit);

            }
        }
        public decimal Value
        {
            get { return _value; }
        }
        public Unit Unit
        {
            get
            {
                return Unit;
            }
        }
        private static void IsSameUnit(Length a, Length b)
        {
            if (a.Unit != b.Unit)
            {
                throw new ArgumentException("Inne jednostki!");
            }

        }
        public static Length operator +(Length a, Length b)
        {
            IsSameUnit(a, b);
            return new Length(a._value + b.Value, a.Unit);
        }
        public static Length operator *(Length length, int a)
        {
            return Length.OfWithException(length.Value * a, length.Unit);
        }
        public static Length operator *(Length length1, Length length2)
        {
            return Length.OfWithException(length1.Value * length2.Value, Unit.squaremeter);
        }
        public static Length operator /(Length length, int a)
        {
            return Length.OfWithException(length.Value / a, length.Unit);
        }
        public override string ToString()
        {
            return $"Value: {_value}, Unit: {_unit}";
        }
        public static Length Function(Length a, decimal x)
        {
            return new Length((a.Value + x), Unit.meter);
        }
        /// <summary>
        /// Methods that allow us to perform operations with lenght numbers
        /// </summary>
    }
    public class BagOfMoney
    {
        public readonly int Money;//Pojemność worka
        private int _level;//aktualny stan
        public BagOfMoney(int money)
        {
            Money = money;
        }
        public int Level
        {  
            get
            {
                return _level;
            }
            private set
            {
                if (value < 0 || value > Money)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _level = value;
            }
        }
        public int givingMoney(int giving)
        {
            if (giving < 0 || _level == Money)
            {
                return 0;
            }
            if (_level + giving > Money)
            {
                int result = (_level + giving) - Money;
                _level = Money;
                if (result > 0)
                {
                    BagOfMoney bagOfMoney = new BagOfMoney(100);
                    bagOfMoney.givingMoney(result);
                    Console.WriteLine("tank 2 = " + bagOfMoney.Level);
                }
                return result;
            }

            _level += giving;
            return giving;
        }
        public int takingMoney(int taking)
        {
            for (int i = 0; i <= _level; i++)
            {
                if (i+5<=_level)
                {
                    Console.WriteLine("5");
                    
                    i += 4;

                }
                else if(i + 2 <= _level)
                {
                    Console.WriteLine("2");
                    i += 1;
                }
                else if(i + 1 <= _level)
                {
                    Console.WriteLine("1");
                    i += 0; 
                }
                else
                {
                    Console.WriteLine("Worek został rozłożony");

                }
            }return _level = 0;
            
            
        }

    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Length length = Length.OfWithException(5, Unit.meter);
            Console.WriteLine(length.ToString());
            Length length2 = Length.OfWithException(6, Unit.meter);
           
            Length result = Length.OfWithException((length.Value + length2.Value), Unit.meter);
            Console.WriteLine(result.ToString());
            Length result1 = Length.OfWithException((length.Value /2), Unit.meter);
            Console.WriteLine(result1.ToString());
            Length result2 = Length.OfWithException((length.Value * 2), Unit.meter);
            Console.WriteLine(result2.ToString());
            Length result3 = Length.OfWithException((length.Value * length2.Value), Unit.squaremeter);
            Console.WriteLine(result3.ToString());
            Length result4 = Length.Function(length,99);
            Console.WriteLine(result4);

            BagOfMoney bagOfMoney = new BagOfMoney(40);
            Console.WriteLine("pojemność " + bagOfMoney.Money);
            bagOfMoney.givingMoney(39);
            Console.WriteLine("aktualny stan " + bagOfMoney.Level);
            bagOfMoney.takingMoney(bagOfMoney.Level);
            Console.WriteLine("aktualny stan " + bagOfMoney.Level);


        }
    }
}
