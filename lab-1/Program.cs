using System;

namespace lab_1
{
    public enum Currency
    {
        PLN = 1,
        USD = 2,
        EUR = 3
    }
    
    public class Money
    {
        private readonly decimal _value;
        private readonly Currency _currency;
        private Money(decimal value, Currency currency)
        {
            _value = value;
            _currency = currency;
        }
        public static Money? OfWithException(decimal value, Currency currency)
        {

            if (value <0)
            {
                throw new ArgumentException("Liczba mniejsza od zera");
            }
            else
            {
                return new Money(value, currency);
                
            }
        }
        public decimal Value
        {
            get { return _value; }
        }
        public Currency Currency
        {
            get
            {
                return _currency;
            }
        }
        public static Money operator *(Money money, decimal factor)
        {
            return Money.OfWithException(money.Value * factor, money.Currency);
        }
        public static Money operator *(decimal factor,Money money)
        {
            return Money.OfWithException(money.Value * factor, money.Currency);
        }

    }

    public class Person
    {
        private string _name;

        private Person(string name)
        {
            _name = name;
        }
        public static Person OfName(String name)
        {
            if (name != null && name.Length >= 2)
            {
                return new Person(name);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Imię zbyt krótkie");
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != null && value.Length >= 2)
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Imię zbyt krótkie");
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person = Person.OfName("Ada");
            Console.WriteLine(person.Name == null ?"null":"person");
            Money money = Money.OfWithException(13,Currency.EUR);
            Console.WriteLine(money.Value);
            Money result = 4*money;
            Console.WriteLine(result.Value);
        }
    }
}
