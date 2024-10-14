using System.Linq;

string[] people = { "Tom", "Bob", "Tim", "Sam" };



//First
string first = people.First();

//First Exception
//first = people.First(item => item.Equals("Kate")); 

//FirstOrDefault
first = people.FirstOrDefault(item=> item.Equals("Kate"));



//signle
string signle = people.Single(item => item.Equals("Tom"));

//signle Exception
//signle = people.Single(item => item.Length == 3); 

//signle
signle = people.SingleOrDefault(item => item.Equals("Kate"));


//Last
string last = people.Last();

//Last Exception
last = people.Last(item => item.Equals("Kate"));

//LastOrDefault
last = people.LastOrDefault(item => item.Equals("Kate"));

;