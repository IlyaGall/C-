//Distinct
string[] words = ["the", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog"];
List<string> query = words.Distinct().ToList();


//Except
string[] words1 = ["the", "quick", "brown", "fox"];
string[] words2 = ["jumped", "over", "the", "lazy", "dog"];

List<string> query2 = words1.Except(words2).ToList();

query2.ForEach(item => Console.WriteLine(item));


//Intersect
string[] words3 = ["the", "quick", "brown", "fox"];
string[] words4 = ["jumped", "over", "the", "lazy", "dog"];

List<string> query3 = words3.Intersect(words4).ToList();
Console.WriteLine("--------------------");

query3.ForEach(item => Console.WriteLine(item));

//Union
string[] words5 = ["the", "quick", "brown", "fox"];
string[] words6 = ["jumped", "over", "the", "lazy", "dog"];

List<string> query4 = words5.Union(words6).ToList();
Console.WriteLine("--------------------");
query4.ForEach(item => Console.WriteLine(item));
;