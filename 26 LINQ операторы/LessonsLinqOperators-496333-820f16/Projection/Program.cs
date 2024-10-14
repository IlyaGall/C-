//Select 
using System.Linq;

List<string> words = ["an", "apple", "a", "day"];

var query = from word in words
            select word.Substring(0, 1);

query = words.Select(word => word.Substring(0, 1));

foreach (string s in query)
{
    Console.WriteLine(s);
}

//SelectMany
List<string> phrases = ["an apple a day", "the quick brown fox"];

query = from phrase in phrases
            from word in phrase.Split(' ')
            select word;

query = phrases.SelectMany(phrases => phrases.Split(' '));

foreach (string s in query)
{
    Console.WriteLine(s);
}

//Zip
// An int array with 7 elements.
IEnumerable<int> numbers = [1, 2, 3, 4, 5, 6, 7];
// A char array with 6 elements.
IEnumerable<char> letters = ['A', 'B', 'C', 'D', 'E', 'F'];

var zip
 = numbers.Zip(letters
 );

IEnumerable<ZipType> zip2 = numbers.Zip(letters
 , (number, letter) => new ZipType { Num = number, Letter = letter }    
 );


class ZipType
{
    public int Num { get; set; }
    public char Letter { get; set; }
}