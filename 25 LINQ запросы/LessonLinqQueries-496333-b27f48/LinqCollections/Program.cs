List<string> strings = new List<string> { "A", "B", "C", null, "D", "A", "A" };

var stringSet = from s in strings
                where s != null
                select s;
;