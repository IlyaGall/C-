# Про Generics (далее – дженерики)

Generics (обобщения, дженерики) – механизм реализаøии переисполþзованиā кода, позволāĀûий
разрабатýватþ алгоритмý без привāзки к типу даннýх.
Преимуûества
• Лакониùнýй код
• Вýúе производителþностþ
• Типобезопасностþ

```C#
public class Intro<T>
{
 private T val;
 public Intro(T v) => val = v;

 public void PrintMe() => Console.WriteLine($"I'm '{val}' and my type is '{typeof(T)}’”);
 public void PrintMeType<K>(K v) => Console.WriteLine($"2. I'm '{v}' and my type is '{v.GetType()}'");
 }

```


```C#
var intIntro = new Intro<int>(2);
intIntro.PrintMe();
var stringIntro = new Intro<string>("hello");
stringIntro.PrintMe();

stringIntro.PrintMeType(2.0f);
stringIntro.PrintMeType(false);
stringIntro.PrintMeType<bool>(false);
```

![Image alt](https://github.com/IlyaGall/C-/blob/main/22%20%D0%9E%D1%81%D0%BD%D0%BE%D0%B2%D0%BD%D1%8B%D0%B5%20%D0%BA%D0%BE%D0%BB%D0%BB%D0%B5%D0%BA%D1%86%D0%B8%D0%B8%20%D0%BE%D1%87%D0%B5%D1%80%D0%B5%D0%B4%D1%8C%2C%20%D1%81%D1%82%D0%B5%D0%BA%2C%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%D1%80%D1%8C%2C%20%D1%85%D0%B5%D1%88%D1%81%D0%B5%D1%82%20%20%D0%94%D0%97/img/1.JPG)
