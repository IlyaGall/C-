# Системы контроля версий

## Форматирование

* Отступы
* Одно выражение в строке
* Одно объявление в строке
* Разделять объявления методов и полей
* Использовать ( ) для большей очевидности
## Комментирование
* Комментарии пишутся на отдельной строке
* Не после кода
* Между // и комментарием ставится пробел
* XML comments
## XML Комментарии
* Начинаются с ///
* Используют теги
* Например <summary>Описание</summary>

![Image alt](https://github.com/IlyaGall/C-/blob/main/17%20Code%20style%20%D0%BE%D1%82%20%D0%9C%D0%B0%D0%B9%D0%BA%D1%80%D0%BE%D1%81%D0%BE%D1%84%D1%82%2C%20DRYDIE%2C%20Yagni%2C%20KISS/img/1.PNG)

## Именование

* Pascal Case
Первая буква слова - заглавная.
Пример: DataService, Enumerable
* Camel Case
Как Pascal, но самая первая буква - маленькая.
Пример: countRecords, firstName.
* Snake Case
В C# не используется.
Примеры: first_name, count_records

### Pascal case:
* class
* record
* struct
* interface
* public members
### Camel case:
* private\internal поля
(_fieldName)
* static private\static internal
* method parameters

## Переменные

* Имя - осмысленное
* Отражающее назначение переменной
* Не слишком длинное
* i, j, k
* birthday
* countRecords


## Переменные - типизация

* var - когда тип ясен по правой части
* Конкретный тип для неочевидных случаев

![Image alt](https://github.com/IlyaGall/C-/blob/main/17%20Code%20style%20%D0%BE%D1%82%20%D0%9C%D0%B0%D0%B9%D0%BA%D1%80%D0%BE%D1%81%D0%BE%D1%84%D1%82%2C%20DRYDIE%2C%20Yagni%2C%20KISS/img/2.PNG)



## Строки
* Интерполяция для небольших объемов
* Для большого объема - StringBuilder

![Image alt](https://github.com/IlyaGall/C-/blob/main/17%20Code%20style%20%D0%BE%D1%82%20%D0%9C%D0%B0%D0%B9%D0%BA%D1%80%D0%BE%D1%81%D0%BE%D1%84%D1%82%2C%20DRYDIE%2C%20Yagni%2C%20KISS/img/3.PNG)

## DRY - Don`t repeat yourself
Принцип призывает не повторяться принаписании кода.
Все что вы пишете в проекте, должно бытьопределено только один раз.

## DIE - Duplication is evil
Этот принцип заключается в том, что нужно избегать повторений одного и того же кода.

## DRY \ DIE пример
```c#
private static void DoSomething(string name, string description, int age, string address =
"Stockholm, Sweden", string format = "{0} is {1}, lives in {2}, age {3}")
{
    Console.WriteLine(format, name, description, address, age);
}
```

## KISS - keep it short simple *

Делайте вещи проще.
Порой наиболее правильное решение – это наиболее простая реализация задачи, в которой нет ничего лишнего.

## YAGNI — You ain’t gonna need it

Вам это не понадобится.
Все что не предусмотрено техническим заданием проекта, не должно быть в нем.

## Оверинжиниринг

Чрезмерное усложнение кодовой базы из-за:
* Желания применить шаблон\подход\технологию
* Ориентации на переиспользование кода (пишем свой фреймворк)