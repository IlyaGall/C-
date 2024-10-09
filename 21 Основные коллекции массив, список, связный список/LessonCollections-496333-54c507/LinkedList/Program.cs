//Связный список
using LinkedList;

//1 Инициализация
//1.1 Пустой св.список
LinkedList<string> empty = new LinkedList<string>();

//1.2 Инициализация св.списка
LinkedList<string> people = new LinkedList<string>(new List<string>{ "Tom", "Sam", "Bob" });

//2 Вывод списка
//2.1 Прямой
Console.WriteLine("Вывод значений свзяного списка(прямой порядок):");
for(LinkedListNode<string> currentNode = people.First; currentNode != null; currentNode = currentNode.Next)
    Console.Write(currentNode.Value + "\t");

//2.2 Обратный
Console.WriteLine("\n\nВывод значений свзяного списка(обратный порядок):");
for (LinkedListNode<string> currentNode = people.Last; currentNode != null; currentNode = currentNode.Previous)
    Console.Write(currentNode.Value + "\t");

//2.3 Вывод элементов с помощью while (просто для разнообразия)
Console.WriteLine("\n\nВывод значений свзяного списка(while):");
LinkedListNode<string> currentNodeW = people.First;
while (currentNodeW != null)
{
    Console.Write(currentNodeW.Value + "\t");
    currentNodeW = currentNodeW.Next;
}


//3 вставка элемента
//3.1 После выбранной ноды
for (LinkedListNode<string> currentNode = people.First; currentNode != null; currentNode = currentNode.Next)
    if (currentNode.Value.Equals("Sam"))
        people.AddAfter(currentNode, "John");

Console.WriteLine("\n\nВставка элемента после выбранной ноды:");
LinkedListViewer.Show(people);

//3.2 До выбранной ноды
for (LinkedListNode<string> currentNode = people.First; currentNode != null; currentNode = currentNode.Next)
    if (currentNode.Value.Equals("Sam"))
        people.AddBefore(currentNode, "James");

Console.WriteLine("\n\nВставка элемента после выбранной ноды:");
LinkedListViewer.Show(people);

//4 Удаление элемента
//4.1 Первого
people.RemoveFirst();
Console.WriteLine("\n\nУдаление первого элемента:");
LinkedListViewer.Show(people);

//4.2 Последнего
people.RemoveLast();
Console.WriteLine("\n\nУдаление последнего элемента:");
LinkedListViewer.Show(people);

//5 Добавление элемента
//5.1 В начало списка
people.AddFirst(new LinkedListNode<string>("Alice"));
Console.WriteLine("\n\nДобавлеение первого элемента:");
LinkedListViewer.Show(people);

//5.1 В начало списка
people.AddLast(new LinkedListNode<string>("Jenifer"));
Console.WriteLine("\n\nДобавлеение последнего элемента:");
LinkedListViewer.Show(people);

//6 Попытка закольцовывания связного список
//LinkedListNode<string> first = people.First;
//people.AddLast(first);
//LinkedListViewer.Show(people);