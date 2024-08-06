using System;

namespace AnonTypes
{
    internal class AnonType
    {
        public void ExampleAnonymousType()
        {
            var card = new PatientCard("Иван", "Петров", 45, new DateTime(2019, 09, 15));

            var cardAnon = new
            {
                FirstName = "Иван",
                LastName = "Петров",
                Age = 45,//card.Age,
                CreatedAt = new DateTime(2019, 09, 15),
            };

            var cardAnon2 = new
            {
                FirstName = "Иван",
                LastName = "Петров",
                Age = 45,//card.Age,
                CreatedAt = new DateTime(2019, 09, 15),
                //TraditionalCard = card
            };
            
            //Console.WriteLine("cardAnon2.GetType(): " + cardAnon2.GetType());
            
            Console.WriteLine("Equals = " + cardAnon.Equals(cardAnon2));
            Console.WriteLine("Равенство ссылок = " + (cardAnon == cardAnon2));
            Console.WriteLine("Hashcodes: " + cardAnon.GetHashCode() + ", " + cardAnon2.GetHashCode());
        }

        public void ExampleRegularClass()
        {
            var card1 = new PatientCard("Иван", "Петров", 45, new DateTime(2019, 09, 15));
            var card2 = new PatientCard("Иван", "Петров", 45, new DateTime(2019, 09, 15));
            
            Console.WriteLine("Equals: " + card1.Equals(card2)); // false

            Console.WriteLine("Обычный класс: " + card1);
            Console.WriteLine("Поле из обычного класса: " + card1.Age);
        }
        
        private class PatientCard
        {
            public PatientCard(string firstName, string lastName, int age, DateTime createdAt)
            {
                FirstName = firstName;
                LastName = lastName;
                Age = age;
                CreatedAt = createdAt;
            }

            public int Age { get; set; }
            public DateTime CreatedAt { get; }
            public string FirstName { get; }
            public string LastName { get; }

            public void Test()
            {

            }

        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var cl = new AnonType();
            cl.ExampleRegularClass();
            Console.WriteLine("---");
            Console.WriteLine();

            cl.ExampleAnonymousType();
            Console.WriteLine("---");
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}