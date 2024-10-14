string[] words = ["the", "quick", "brown", "fox", "jumps", "do"];


//Skip
List<string> skip = words.Skip(1).ToList();

//SkipWhile
List<string> skipWhile = words.SkipWhile(
    item => !item.StartsWith("q")
    ).ToList();

//Take
List<string> take = words.Take(3).ToList();

//TakeWhile
List<string> takeWhile = words.TakeWhile(
    item => item.Length > 2
    ).ToList();

//Chunk
List<string[]> chunks = words.Chunk(2).ToList();

;