string[] words = ["the", "quick", "brown", "fox", "jumps"];

IEnumerable<string> query = from word in words
                            where word.Length == 3
                            select word;

/*IEnumerable<string> query =
    words.Where(word => word.Length == 3);*/

foreach (string str in query)
{
    Console.WriteLine(str);
}

//Пример с OfType в проекте LinqUndeclarativeExamples - 2.'
