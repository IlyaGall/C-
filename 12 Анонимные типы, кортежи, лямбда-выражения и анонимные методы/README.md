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


## дз
* [дз] (https://github.com/IlyaGall/C-/tree/main/%D0%94%D0%97/06%20HomeWork)
# Программа 1.
Создать четыре объекта анонимного типа для описания планет Солнечной системы со свойствами "Название", "Порядковый номер от Солнца", "Длина экватора", "Предыдущая планета" (ссылка на объект - предыдущую планету):

* Венера
* Земля
* Марс
* Венера (снова)
Данные по планетам взять из открытых источников.
Вывести в консоль информацию обо всех созданных "планетах". Рядом с информацией по каждой планете вывести эквивалентна ли она Венере.
# Программа 2.
Написать обычный класс "Планета" со свойствами "Название", "Порядковый номер от Солнца", "Длина экватора", "Предыдущая планета" (ссылка на предыдущую Планету).
Написать класс "Каталог планет". В нем должен быть список планет - при создании экземпляра класса сразу заполнять его тремя планетами: Венера, Земля, Марс.
Добавить в класс "Каталог планет" метод "получить планету", который на вход принимает название планеты, а на выходе дает три поля: первые два поля порядковый номер планеты от Солнца и длину ее экватора, когда планета найдена, а последнее поле - для ошибки. В случае, если планету по названию найти не удалось, то этот метод должен возвращать строку "Не удалось найти планету" (именно строку, не Exception). На каждый третий вызов метод "получить планету" должен возвращать строку "Вы спрашиваете слишком часто".
В main-методе Вашей программы создать экземпляр "Каталога планет". У этого каталога вызвать метод "получить планету", передав туда последовательно названия Земля, Лимония, Марс. Для найденных планет в консоль выводить их название, порядковый номер и длину экватора. А для ненайденных выводить строку ошибки, которую вернул метод "получить планету".
# Программа 3.
Скопировать решение из программы 2, но переделать метод "получить планету" так, чтобы он на вход принимал еще один параметр, описывающий способ защиты от слишком частых вызовов - делегат PlanetValidator (можно вместо него использовать Func), который на вход принимает название планеты, а на выходе дает строку с ошибкой. Метод "получить планету" теперь не должен проверять сколько вызовов делалось ранее. Вместо этого он должен просто вызвать PlanetValidator и передать в него название планеты, поиск которой производится. И если PlanetValidator вернул ошибку - передать ее на выход из метода третьим полем.
Из main-метода при вызове "получить планету" в качестве нового параметра передавать лямбду, которая делает всё ту же проверку, которая была и ранее - на каждый третий вызов она возвращает строку "Вы спрашиваете слишком часто" (в остальных случаях возвращает null). Результат исполнения программы должен получиться идентичный программе 2.

# Программа 3_1 (*) лежет в том же решение, что и программа 3.
(*) Дописать main-метод так, чтобы еще раз проверять планеты "Земля", "Лимония" и "Марс", но передавать другую лямбду так, чтобы она для названия "Лимония" возвращала ошибку "Это запретная планета", а для остальных названий - null. Убедиться, что в этой серии проверок ошибка появляется только для Лимонии.
Таким образом, вы делегировали логику проверки допустимости найденной планеты от метода "получить планету" к вызывающему этот метод коду.
В чат напишите также время, которое вам потребовалось для реализации домашнего задания.
