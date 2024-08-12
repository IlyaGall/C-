# Взаимосвязь циклов и рекурсии

## Циклы
![Image alt](https://github.com/IlyaGall/C-/blob/main/14%20%D0%92%D0%B7%D0%B0%D0%B8%D0%BC%D0%BE%D1%81%D0%B2%D1%8F%D0%B7%D1%8C%20%D1%86%D0%B8%D0%BA%D0%BB%D0%BE%D0%B2%20%D0%B8%20%D1%80%D0%B5%D0%BA%D1%83%D1%80%D1%81%D0%B8%D0%B8/img/1.PNG)

* for 
• foreach 
• while 
• do-while

Типы циклов
• Безусловные
• С предусловием
• С постусловием
• С выходом из середины
• Со счётчиком
• Совместный

## Оптимизация циклов
• Убрать из входного набора ненужные данные
• В теле цикла в условиях ставить слева легко проверяемое условие
• Помнить\знать про кеш процессора

```C#
// arrayLength = 5000;
for (int i = 0; i < arrayLength; i++) 
{
    if (array[i] % 2 == 0) 
    {
     // do something
    }
}
```

# Рекурсия
![Image alt](https://github.com/IlyaGall/C-/blob/main/14%20%D0%92%D0%B7%D0%B0%D0%B8%D0%BC%D0%BE%D1%81%D0%B2%D1%8F%D0%B7%D1%8C%20%D1%86%D0%B8%D0%BA%D0%BB%D0%BE%D0%B2%20%D0%B8%20%D1%80%D0%B5%D0%BA%D1%83%D1%80%D1%81%D0%B8%D0%B8/img/2.PNG)

![Image alt](https://github.com/IlyaGall/C-/blob/main/14%20%D0%92%D0%B7%D0%B0%D0%B8%D0%BC%D0%BE%D1%81%D0%B2%D1%8F%D0%B7%D1%8C%20%D1%86%D0%B8%D0%BA%D0%BB%D0%BE%D0%B2%20%D0%B8%20%D1%80%D0%B5%D0%BA%D1%83%D1%80%D1%81%D0%B8%D0%B8/img/3.PNG)

Рекурсия и стек вызовов:

![Image alt](https://github.com/IlyaGall/C-/blob/main/14%20%D0%92%D0%B7%D0%B0%D0%B8%D0%BC%D0%BE%D1%81%D0%B2%D1%8F%D0%B7%D1%8C%20%D1%86%D0%B8%D0%BA%D0%BB%D0%BE%D0%B2%20%D0%B8%20%D1%80%D0%B5%D0%BA%D1%83%D1%80%D1%81%D0%B8%D0%B8/img/4.PNG)


## Что сломается раньше

```c#
int wi = 0;
while(true)
{
    checked
    {
        wi= wi + 100;
    }
}
```
тут будут переполнение стека

```C#
int wi =0;
while (true)
{
    wi = wi + 1000;
}
```
тут в теории не будет переполнение стека, так как при переполнении два варианта 1 ошибка, 2 отчёт сначала с нуля

```C#
static void MyFunction()
{

    MyFunction();
}
```
```c#
while(true)
{
      MyFunction();
}
```
тут память закончится!

## Хвостовая рекурсия


```c#
static int MyFunction(int x)
{
    int result =0;
    if(x > 0)
    {
        result += MyFunction(x-1);
        if(result % 2 == 0)
        {
            result = result/2;
        }
        else
        {
            result = result*2;
        }
    }
    return result;
}
```


```c#
static int MyFunction(int x)
{
    int result =0;
    if(x % 2==0)
    {
        result = 1;

    }
    return result +  MyFunction(x-1)
}
```

Хвостовая рекурсия - частный случай рекурсии, когда последним выполняется рекурсивный вызов.
Такие вызовы можно заменить на цикл.

## Рекурсия - резюме

Плюсы:
• Естественность представления алгоритмов
• Читабельность*
• …
Минусы:
• Использование стека вызовов
• Отладка

**Можно встретить мнение, что любой рекурсивный алгоритм может быть заменен на цикл.**