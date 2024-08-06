# Анонимные типы

## Зачем нужны:
•LINQ
•Десериализаторы
•В других случаях, когда надо «здесь и сейчас» сконструировать временный простой объект
## Ограничения:
•Только свойства, никаких полей и методов
•Только read-only свойства
•Экземпляр такого типа не получится передать куда-то, сохранив информацию о типе в compile-tim

## Пример (создание анонимного типа в классе)

Анонимный тип:

```C#
  public void ExampleAnonymousType()
  {
      //var card = new PatientCard("Иван", "Петров", 45, new DateTime(2019, 09, 15));
      var cardAnon = new
      {
          FirstName = "Сергей",
          LastName = "Лавров",
          Age = 29,//card.Age,
          CreatedAt = new DateTime(2010, 09, 15),
          //TraditionalCard = card
      };
      //Console.WriteLine("cardAnon.GetType(): " + cardAnon.GetType());
      //Console.WriteLine("Анонимный тип: " + cardAnon);

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
      //Console.WriteLine("Равенство ссылок = " + (cardAnon == cardAnon2));
      //Console.WriteLine("Hashcodes: " + cardAnon.GetHashCode() + ", " + cardAnon2.GetHashCode());
  }
```

Реализация без анонимного

```C#
    public void ExampleRegularClass()
    {
        var card1 = new PatientCard("Иван", "Петров", 45, new DateTime(2019, 09, 15));
        var card2 = new PatientCard("Иван", "Петров", 45, new DateTime(2019, 09, 15));
        Console.WriteLine("Equals: " + card1.Equals(card2)); // вернули false
        //Console.WriteLine("Обычный класс: " + card1);
        //Console.WriteLine("Поле из обычного класса: " + card1.Age);
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

        public int Age { get; }
        public DateTime CreatedAt { get; }
        public string FirstName { get; }
        public string LastName { get; }

    }
```

# Кортежи
Используются, когда надо «здесь и сейчас» сконструировать временный простой объект.
Преимущество в сравнении с анонимными типами:

- Созданный объект можно передать куда-нибудь, и информация о типах свойств сохранится в compile-time
- Значения свойств кортежа можно изменять (мутабельные)

синтексис 

```C#
public static (bool, string) TryParseBool(string str)
{
    str = str.ToLower();
    if (str == "ложь")
    {
        return (false, "ru");
    }
    if (str == "истина")
    {
        return (true, "ru");
    }
    if (str == "false")
    {
        return (false, "en");
    }
    if (str == "true")
    {
        return (true, "en");
    }

    return (false, "?");
}

public static Tuple<bool, string> TryParseBoolExplicit(string str)
{
    str = str.ToLower();
    if (str == "ложь")
    {
        return Tuple.Create(false, "ru");
    }
    if (str == "истина")
    {
        return Tuple.Create(true, "ru");
    }
    if (str == "false")
    {
        return Tuple.Create(false, "en");
    }
    if (str == "true")
    {
        return Tuple.Create(true, "en");
    }

    return Tuple.Create(false, "?");
}

  var outputs = new List<Tuple<bool, string>>();
  foreach (var input in inputs)
  {
      Tuple<bool, string> output = TryParseBoolExplicit(input);
      outputs.Add(output);
      Console.WriteLine(output);
  }

  foreach (var (r, l) in outputs)
{
    Console.WriteLine("res: " + r);
    Console.WriteLine("lang: " + l);
}
```

# Анонимные методы и лямбда-выражения

## использованием другого метода

```C#
private static bool CriteriaCustom(int i, int j, int z)
{
    return i + j + z > 0;
}

var x = Filter2(collection1, collection1, CriteriaCustom);

static List<int> Filter2(List<int> collection, List<int> collection2, CustomDelegate2 criteriaDelegate)
{
     var result = new List<int>();

     foreach (var i in collection)
     {
         if (criteriaDelegate(i, i, i))
         {
             result.Add(i);
         }
     }

     return result;
}
```
другой пример
```C#
  private static bool CriteriaEven(int i)
  {
      return i % 2 == 0;
  }

  private static bool CriteriaPositive(int i)
  {
      return i > 0;
  }

  var collection2_2 = Filter(collection1, CriteriaPositive);
  var collection3_2 = Filter(collection1, CriteriaEven);


static List<int> Filter(List<int> collection, Func<int, bool> criteriaDelegate)
{
     var result = new List<int>();

     foreach (var i in collection)
     {
         if (criteriaDelegate(i))
         {
             result.Add(i);
         }
     }

     return result;
}
```


## лямда внутри выражения пример 1

```C#
var collection7 = Filter(collection2, i =>
{
    var isEven = i % 2 == 0;
    if (isEven)
    {
        counter++;
    }
    if (counter > 2)
    {
        return false;
    }
    return isEven;
});

static List<int> Filter(List<int> collection, Func<int, bool> criteriaDelegate)
{
     var result = new List<int>();

     foreach (var i in collection)
     {
         if (criteriaDelegate(i))
         {
             result.Add(i);
         }
     }

     return result;
}
```
## лямда внутри выражения пример 2

```C#
   static void myFunc() 
   {
       var collection1 = new List<int>
       {
           -1, -2, -15, -16, -200, -14
       };

       var collection5 = Filter(collection1, delegate (int i)
       {
           return i != 3;
       });
   }


   static List<int> Filter(List<int> collection, Func<int, bool> criteriaDelegate)
   {
       var result = new List<int>();

       foreach (var i in collection)
       {
           if (criteriaDelegate(i))
           {
               result.Add(i);
           }
       }

       return result;
   }
```