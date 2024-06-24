


#region IF

//var a = -101;


//Console.WriteLine("Start of program");

//if (a < 10)
//{
//    Console.WriteLine("a is greater than 10");

//    Console.WriteLine("Also, Hi");
//}


//if (DividableBy10(a))
//{
//    Console.WriteLine("Also a is dividable by 10");
//}

//Console.WriteLine("End of program"); 
#endregion




using System.ComponentModel.Design;

#region ELSE
//var aa = 17;


//if (!DividableBy3(aa))
//{
//    Console.WriteLine($"aa = {aa} is dividable by 3");
//}
//else
//{
//    Console.WriteLine($"aa = {aa} is NOT dividable by 3 i chto delat'");
//}

//Console.WriteLine("OTUS_POCUS");
//aa = 15;


//if (!DividableBy3(aa))
//{
//    Console.WriteLine($"aa = {aa} is dividable by 3");
//}
//else
//{
//    Console.WriteLine($"aa = {aa} is NOT dividable by 3 i chto delat'");
//}
//aa = 30;

//if (DividableBy3(aa) && DividableBy10(aa))
//{
//    Console.WriteLine($"aa = {aa} is dividable both by 3 and 10");
//}
//else
//{
//    Console.WriteLine($"aa = {aa} is NOT dividable both by 3 and 10");
//}

//aa = 10;
//// && - аналог AND =  (a && b) - должны быть истинны оба a и b

//// || - аналог OR =  (a || b) - должны быть истинны либо a либо b


//var by3and10 = DividableBy3(aa) && DividableBy10(aa);
//if (by3and10)
//{
//    Console.WriteLine($"aa = {aa} is dividable  by 3 OR 10");
//}
//else
//{
//    Console.WriteLine($"aa = {aa} is NOT dividable both by 3 and 10");
//}

//// 100 & 010
//Console.WriteLine(8 | 4);

//// 100
//// 010 
#endregion
#region ELSE IF




//var bbb = 17*17*3;


//if (DividableBy3(bbb))
//{

//    Console.WriteLine($"bbb = {bbb} is dividable by 3!!!! ");
//}
//else if (DividableBy17(bbb))
//{
//    Console.WriteLine($"bbb = {bbb} is dividable by 17!!!!!!!!!!! ");
//} 


//else if (DividableBy10(bbb))
//{
//    Console.WriteLine($"bbb = {bbb} is dividable by 10!!!!!!!!!!! ");
//}
#endregion

#region ternar
//string epoch;

//var year = 1993;

//if (year > 0)
//{
//    epoch = "AC";
//}
//else
//{
//    epoch = "BC";
//}


//// упростить до

//var epoch1 = year > 0
//    ? SuperMegaTipaRandomStroka()
//    : "BC";

//Console.WriteLine($"'{year}' is {epoch1}"); 
#endregion

#region switch

//Console.WriteLine("Number 1");
//PrintColorv1(1);


//Console.WriteLine("Number 2");
//PrintColorv1(2);


//Console.WriteLine("Number 2000");
//PrintColorv1(2000);


//Console.WriteLine();


//Console.WriteLine();
//Console.WriteLine();
//Console.WriteLine();
//Console.WriteLine();


//PrintLength("aksl;fkasl;fkas;lfkas;lfka;lsfkasl;f");

//PrintLength("a");

//PrintLength("abcabcabcabc");



//Console.WriteLine();
//Console.WriteLine();
//Console.WriteLine();
//Console.WriteLine();


//PrintCentury(2024);

//PrintCentury(2000);

//PrintCentury(1999);

//PrintCentury(999);

//void PrintColorv1(int color)
//{
//    switch (color)
//    {
//        case 1:
//            Console.WriteLine("Red");
//            break;
//        case 2:
//            Console.WriteLine("BLUE");
//            break;

//        default:
//            Console.WriteLine("OTHER COLOR");
//            break;
//    }
//} 
#endregion

#region MyRegion


//var i = 0;

//while (i < 10)
//{
//    Console.WriteLine($"i is {i}");

//    i++;
//}


//int[] ar = [1, 2, 3, 4, 2225, 6, 7];

//for (var i = 0; i < ar.Length && ar[i] < 10; i++)
//{
//    Console.WriteLine($"ar[{i}] = {ar[i]}");
//}


//var j = 0;
//for (; j < ar.Length && ar[j] < 10;)
//{
//    Console.WriteLine($"!ar[{j}] = {ar[j]}");
//    j++;
//}


//var jj = 0;

//do
//{
//    Console.WriteLine("Kakoy-to code");
//} while (jj > 10);



//while (jj > 10)
//{
//    Console.WriteLine("Kakoy-to code1");
//}


//foreach (var a in ar)
//{
//    Console.WriteLine("AAAAA " + a);
//}

//var d = new List<int>() { 1, 2, 3, 4 };


//foreach (var ddd in d)
//{
//    d.Add(1);
//}

//for (var i = 0; i < d.Count; i++)
//{
//    d.Add(i);
//    Console.WriteLine(d.Count);
//}



//for (var i = 0; i < 20; i++)
//{
//    if (i == 13)
//    {
//        Console.WriteLine("TRINADZAT'!!!!!");
//        continue;
//    }


//    Console.WriteLine($"{i} * {i} = {i * i}");

//    Console.WriteLine("-----");
//}



//Console.WriteLine("-----"); Console.WriteLine("-----"); Console.WriteLine("-----"); Console.WriteLine("-----");

//for (var i = 0; i < 20; i++)
//{
//    if (i == 13)
//    {
//        Console.WriteLine("TRINADZAT'!!!!!");
//        break;
//    }

//    Console.WriteLine($"{i} * {i} = {i * i}");

//    Console.WriteLine("-----");
//}

#endregion


Console.WriteLine("Delay raz");

goto RANDOM_METKA;

Console.WriteLine("Delay dva");

RANDOM_METKA:
Console.WriteLine("Delay tri");

/**
 * 
 * 
 * if(a==1){
 * }else if(a==2){
}
else if (a==3){
}
 * 
 * 
 */

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

bool DividableBy10(int b)
{
    Console.WriteLine("Dividable by 10");
    return b % 10 == 0;
}


bool DividableBy17(int b)
{
    return b % 17 == 0;
}
bool DividableBy3(int b)
{

    return b % 3 == 0;
}