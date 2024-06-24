## IF
![Image alt](https://github.com/IlyaGall/C-/blob/main/03%20%D1%86%D0%B8%D0%BA%D0%BB%D1%8B/img/1.PNG)


```C#
var a = -101;
Console.WriteLine("Start of program");

if (a < 10)
{
    Console.WriteLine("a is greater than 10");

    Console.WriteLine("Also, Hi");
}
if (DividableBy10(a))
{
    Console.WriteLine("Also a is dividable by 10");
}
Console.WriteLine("End of program");
```



## if else

![Image alt](https://github.com/IlyaGall/C-/blob/main/03%20%D1%86%D0%B8%D0%BA%D0%BB%D1%8B/img/2.PNG)

```c#
var aa = 17;

if (!DividableBy3(aa))
{
     Console.WriteLine($"aa = {aa} is dividable by 3");
}
else
{
    Console.WriteLine($"aa = {aa} is NOT dividable by 3 i chto delat'");
}
Console.WriteLine("OTUS_POCUS");
aa = 15;
if (!DividableBy3(aa))
{
     Console.WriteLine($"aa = {aa} is dividable by 3");
}
    else
{
    Console.WriteLine($"aa = {aa} is NOT dividable by 3 i chto delat'");
}
aa = 30;

if (DividableBy3(aa) && DividableBy10(aa))
{
    Console.WriteLine($"aa = {aa} is dividable both by 3 and 10");
}
else
{
     Console.WriteLine($"aa = {aa} is NOT dividable both by 3 and 10");
}
aa = 10;
            // && - аналог AND =  (a && b) - должны быть истинны оба a и b

            // || - аналог OR =  (a || b) - должны быть истинны либо a либо b


var by3and10 = DividableBy3(aa) && DividableBy10(aa);
if (by3and10)
{
    Console.WriteLine($"aa = {aa} is dividable  by 3 OR 10");
}
else
{
    Console.WriteLine($"aa = {aa} is NOT dividable both by 3 and 10");
}

// 100 & 010
Console.WriteLine(8 | 4);
// 100
// 010 
```


## ELSE IF

![Image alt](https://github.com/IlyaGall/C-/blob/main/03%20%D1%86%D0%B8%D0%BA%D0%BB%D1%8B/img/3.PNG)

```c#
var bbb=17*17*3;
if(DividableBy3(bbb))
{
    Console.WriteLine($"bbb={bbb}isdividableby3!!!!");
}
elseif(DividableBy17(bbb))
{
    Console.WriteLine($"bbb={bbb}isdividableby17!!!!!!!!!!!");
}

elseif(DividableBy10(bbb))
{
    Console.WriteLine($"bbb={bbb}isdividableby10!!!!!!!!!!!");
}
```

## ternar Знак вопроса

```c#
string epoch;
var year=1993;

if(year>0)
{
    epoch="AC";
}
else
{
    epoch="BC";
}


//упроститьдо
var epoch1 = year > 0 
    ? "AC"; // выполняется if
    : "BC"; // else выполняется

var epoch1 = year > 0 
    ? SuperMegaTipaRandomStroka() // выполняется if
    : "BC"; // else выполняется


Console.WriteLine($"'{year}'is{epoch1}");
 string SuperMegaTipaRandomStroka()
 {
     Console.WriteLine("1");

     Console.WriteLine("1");

     Console.WriteLine("1");
     Console.WriteLine("1");
     Console.WriteLine("1");
     Console.WriteLine("1");
     Console.WriteLine("1");
     Console.WriteLine("1");
     Console.WriteLine("1");
     Console.WriteLine("1");
     Console.WriteLine("1");
     return "asl;kf al;skdfs;aldfka;sldfkas;lfkal;fasl;fasl;fkasl;";
 }

```

## switch (простой пример)

```c#
Console.WriteLine("Number1");
PrintColorv1(1);

Console.WriteLine("Number2");
PrintColorv1(2);


Console.WriteLine("Number2000");
PrintColorv1(2000);


Console.WriteLine();


Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();


PrintLength("aksl;fkasl;fkas;lfkas;lfka;lsfkasl;f");

PrintLength("a");

PrintLength("abcabcabcabc");



Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();


PrintCentury(2024);

PrintCentury(2000);

PrintCentury(1999);

PrintCentury(999);

voidPrintColorv1(intcolor)
{
    switch(color)
    {
        case1:
            onsole.WriteLine("Red");
        break;
        case2:
            Console.WriteLine("BLUE");
        break;
        default:
            Console.WriteLine("OTHERCOLOR");
        break;
    }
}

```

## switch метод с возращением значений
```c#
   string PrintColorv2(int color)
   {
       switch (color)
       {
           case (1):
               return "Red";
           case 2:
               return "BLUE";

           default:
               return "OTHER COLOR";
       }
   }
```

## switch с условием в case (<>. >=, <=, ==)
```c#
 void PrintLength(string s)
 {
     Console.WriteLine($"|{s}|");
     switch (s.Length)
     {
         case > 15:
             Console.WriteLine("Ochen' dlinnaya stroka");
             break;
         case > 10:
             Console.WriteLine("dlinnaya stroka");
             break;
         case <= 10:
             Console.WriteLine("korotkay stroka");
             break;


     }


 }

```

## swithc с еще более ложным условием (when &&)
```c#
  void PrintCentury(int year)
  {
      Console.WriteLine(year);
      switch (year)
      {
          case > 2000:
              Console.WriteLine("Current century");
              break;
          case int nnn when year > 1900 && year <= 2000 && true && true && true && true && true && true && true && true && true && true && true && true && true && true && true && true && true && true && true && true:
              Console.WriteLine("20th century");
              break;
          case int nnn when nnn > 19100 && nnn <= 2000:
              Console.WriteLine("20th century");
              break;
          default:
              Console.WriteLine("Before 20th century");
              break;
      }
  }
```


##  while, for

```c#

            var i = 0;

            while (i < 10)
            {
                Console.WriteLine($"i is {i}");

                i++;
            }


            int[] ar = [1, 2, 3, 4, 2225, 6, 7];

            for (var i = 0; i < ar.Length && ar[i] < 10; i++)
            {
                Console.WriteLine($"ar[{i}] = {ar[i]}");
            }


            var j = 0;
            for (; j < ar.Length && ar[j] < 10;)
            {
                Console.WriteLine($"!ar[{j}] = {ar[j]}");
                j++;
            }


            var jj = 0;

            do
            {
                Console.WriteLine("Kakoy-to code");
            } while (jj > 10);



            while (jj > 10)
            {
                Console.WriteLine("Kakoy-to code1");
            }


            foreach (var a in ar)
            {
                Console.WriteLine("AAAAA " + a);
            }

            var d = new List<int>() { 1, 2, 3, 4 };


            foreach (var ddd in d)
            {
                d.Add(1);
            }

            for (var i = 0; i < d.Count; i++)
            {
                d.Add(i);
                Console.WriteLine(d.Count);
            }



            for (var i = 0; i < 20; i++)
            {
                if (i == 13)
                {
                    Console.WriteLine("TRINADZAT'!!!!!");
                    continue;
                }


                Console.WriteLine($"{i} * {i} = {i * i}");

                Console.WriteLine("-----");
            }



            Console.WriteLine("-----"); Console.WriteLine("-----"); Console.WriteLine("-----"); Console.WriteLine("-----");

            for (var i = 0; i < 20; i++)
            {
                if (i == 13)
                {
                    Console.WriteLine("TRINADZAT'!!!!!");
                    break;
                }

                Console.WriteLine($"{i} * {i} = {i * i}");

                Console.WriteLine("-----");
            }

```