//1. Анонимные типы
var person = new { id = 1, Name = "John" };

//Применение в linq
int i = 1;
string[] names = new string[] { "James", "Alice", "Anna" };
var namesOfanonimous = names.Select(name => new { id = i++, Name = name });


//2. Агрегатные функции
int[] nums = new int[] { 1, 2, 3, 4, 5 };
double[] numm = new double[] { 1, 2, 3, 4, 5 };
int a = nums.Count();
double b = numm.Average();
double c = numm.Max();

/*Демонстрация работы метод расширения*/
Func<int, string> convert = (x) => x.ToString();
IEnumerable<string> converts = nums.Convert(convert);

//3. Как работает селектор
//По сути просто как указатель на поле типа
Func<Student, int> func = (x)  =>  x.GroupId;

class Student
{
    public int id { get; set; }

    public int GroupId { get; set;}
}

class Group
{
    public int GroupId {  get; set; }
}


//4. Методы расширения
public static class Extents
{
    public 
        static                                                  /*Метод должен быть статичным*/
        IEnumerable<TResult>                                    /*Возвращаемый тип*/
        Convert<TSource, TResult>(
            this IEnumerable<TSource> source                    /*Обозначение типа, для которого пишется расширение*/
        , Func<TSource, TResult> selector)                      /*Делегат. Не обязателен для метода расширения.*/
    {
        return source.Select(item => selector.Invoke(item));    /*операция, описывающая бизнес-логику*/
    }
}

