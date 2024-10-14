using LinqUndeclarativeExamples;
using System.Collections;


//Cast
IEnumerable peoples = new List<IPerson>()
{
    new Child {  }
    , new Child {  }
    , new Parent { }
};

List<Child> onlyChilds = peoples
    //.OfType<Child>()          //Раскомментировать, чтобы убрать Exception
    .Cast<Child>().ToList();

//В декларативном синтаксисе
List<Child> query = (
            from Child child in peoples
            select child
            ).ToList();

//ToList
List<Child> onlyChild = onlyChilds.ToList<Child>();

;