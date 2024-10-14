//All
using System.Linq;

string[] words = ["the", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog"];

bool allElementMoreThan = words.All(item => 
                                            item.Length > 0
                                            //item.Length > 3
                                            );


//Any
bool anyElementMoreThan = words.Any(item =>                 /*Аргумент не обязателен, если мы хотим узнать есть ли элементы в коллекции*/
                                            item.Length > 0
                                            //item.Length > 3
                                            );


//Contains
bool wordExsist = words.Contains("quick");  /*Есть перегрузка с компаратором*/