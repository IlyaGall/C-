using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

static void ShowStringBuilder()
{
    var stopwatch = new Stopwatch();
    var times = 200000;
    var s = "";
    Console.WriteLine("Concat with += ");
    stopwatch.Start();
    for (var i = 0; i < times; i++)
    {
        s = s + 's';
    }
    stopwatch.Stop();

    Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds}");




    Console.WriteLine("Concat with stringBuilder ");

    stopwatch.Reset();
    stopwatch.Start();
    var sb = new StringBuilder();

    for (var i = 0; i < times; i++)
    {
        sb.Append('s');
    }
    var s11 = sb.ToString();
    stopwatch.Stop();


    Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds}");




    Console.WriteLine("Concat with Concat ");


    s = string.Empty;
    stopwatch.Reset();
    stopwatch.Start();
    for (var i = 0; i < times; i++)
    {
        s = String.Concat(s, 's');
    }

    stopwatch.Stop();



    Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds}");

}


static string FormatBytes(byte[] b)
{
    return string.Join(' ', b.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
}

//Console.WriteLine("Прив");

#region UTF-8

// Кодируем запятую

var c = ",";
var emAr = Encoding.GetEncoding("UTF-8").GetBytes(c);
Console.WriteLine($"1. , = {FormatBytes(emAr)}");

// 00101100


// Кодируем букву Б
c = "Б";
emAr = Encoding.GetEncoding("UTF-8").GetBytes(c);
Console.WriteLine($"2. Б = {FormatBytes(emAr)}");
// 110   10000 10   010001
// 10000010001

//// 110  10000 10  010001
//// 10000010001


// Кодируем эмоджи

c = "🤖";
emAr = Encoding.GetEncoding("UTF-8").GetBytes(c);
Console.WriteLine($"3. 🤖 = {FormatBytes(emAr)}");

// 11110  000 10  011111 10  100100 10  010110
// 000011111100100010110


#endregion

#region UTF-16

c = "Б";
var emAr1 = Encoding.GetEncoding("UTF-16").GetBytes(c);
Console.WriteLine($"4. Б = {FormatBytes(emAr1)}");
// 00010001 00000100
// 00000100 00010001

//// 11110000 10011111 10100100 10010110
//// 000011111100100010110


c = "🤖";
emAr1 = Encoding.GetEncoding("UTF-16").GetBytes(c);
Console.WriteLine($"5. 🤖 = {FormatBytes(emAr1)}");

//  00111110 11011000    00010110 11011101
// 110110 0000111110     110111 0100010110
// 00001111100100010110
// 63766 + 65536
// 129302

// 00111110 11011000         00010110 11011101
// 1101100000111110          1101110100010110
// 110110    0000111110          110111     0100010110
// 00001111100100010110

// 63766 + (0x10000)65536

#endregion


#region base-64

var p = "Привет";

var pUtf16 = Encoding.GetEncoding("UTF-16").GetBytes(p);

//// Encoding.GetEncoding("UTF-8")
var pUtf8 = Encoding.UTF8.GetBytes(p);


Console.WriteLine($"UFT8 - {FormatBytes(pUtf8)}");
Console.WriteLine($"UFT16 - {FormatBytes(pUtf16)}");


var pb64Utf16 = Convert.ToBase64String(pUtf16);
var pb64Utf8 = Convert.ToBase64String(pUtf8);

Console.WriteLine("UTF16base64: "+pb64Utf16);

Console.WriteLine("UTF8base64: "+pb64Utf8);

var backUtf16 = Convert.FromBase64String(pb64Utf16);
var backUtf8 = Convert.FromBase64String(pb64Utf8);
Console.WriteLine("backUtf16 " + FormatBytes(backUtf16));
Console.WriteLine("backUtf8 " + FormatBytes(backUtf8));

var backstring = Encoding.GetEncoding("UTF-16").GetString(backUtf16);

#endregion

#region char

var ch1 = '2';
Console.WriteLine(char.IsWhiteSpace('r'));
Console.WriteLine(char.ToUpper('r'));
Console.WriteLine(char.IsPunctuation('.'));
//// var emojiC = '🤖'; // Будет ошибка

#endregion

#region string

Console.WriteLine("C:\\Windows \" ");

Console.WriteLine(@"C:\\Windows""");
Console.WriteLine("""
    {  
    }
    """);

var pr = 12414.61264;

Console.WriteLine(pr + " Otus");
var s = "fancy";
Console.WriteLine($"Todays is a lesson, and i {s} say {pr} otus");
Console.WriteLine(string.Format("1. Todays is a lesson, and i say {0} otus {1} {0} {2}", pr, 2142, true));
Console.WriteLine($"Today is a {DateTime.Now:dd'/'MM'/'yyyy}, and i say |{pr,20:C}| |{s,-10}| otus");

#endregion

#region StringBuilder

var name = "Lusparon";
var sb = new StringBuilder("Start ");
sb.Append("Privet");
sb.Append(" Otus, ");
sb.AppendFormat("My name is {0}", name);
sb.AppendFormat($"My interpolation name is {name}");
sb.AppendLine("With newline");
sb.Append("KAVYCHKI");
sb.AppendJoin(",", "raz", "dva", "tri", "chetyre");
sb.Append("\r\n");
sb.Append("Finish");
sb.Replace()

//var finalString = sb.ToString();
Console.WriteLine(sb);

//ShowStringBuilder();

#endregion

var plus = "plus";

Console.WriteLine("Privet"[2]);

var pp = "Privet";

Console.WriteLine("Privet".Length);

Console.WriteLine("🤖".Length);

var si = new StringInfo(c);
Console.WriteLine(si.LengthInTextElements);


for (var i = 0; i < sb.Length; i++)
{
    Console.WriteLine($"'{sb[i]}'");
}


var privetStable = "Privet";


var poka = privetStable.Replace("rivet", "poka");

Console.Write($"{privetStable} {poka}");
