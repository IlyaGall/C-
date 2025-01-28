# Асинхронные операции

## Интуитивное понятие асинхронности

Синхронный подход:
1. Поставить чайник
2. Дождаться закипания, выпить чай, начать уборку 

Асинхронный подход:
1. Поставить чайник
2. Начать уборку
3. Когда закипит, выпить чай и продолжить уборку

![img](https://github.com/IlyaGall/C-/blob/main/36%20%D0%90%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8/IMG/1.JPG)

Действия с внешними системами
▪ Запросы в базу данных
▪ Работа с файловой системой
▪ Сетевые запросы

![img](https://github.com/IlyaGall/C-/blob/main/36%20%D0%90%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8/IMG/2.JPG)

### Синхронность и асинхронность в виде временной диаграммы

![img](https://github.com/IlyaGall/C-/blob/main/36%20%D0%90%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8/IMG/3.JPG)

![img](https://github.com/IlyaGall/C-/blob/main/36%20%D0%90%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8/IMG/4.JPG)

#### Терминогогия


Терминология: ''поток простаивает'', ''поток заблокирован'', ''пул потоков истощается''


## Асинхронность

Асинхронность — выполнение программного кода, не блокирующее потоки во время ожидания

### Асинхронность vs многопоточность

* Многопоточность – о увеличении ресурсов
* Асинхронность - о более рациональном использовании ресурсов

![img](https://github.com/IlyaGall/C-/blob/main/36%20%D0%90%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8/IMG/5.JPG)

### Пул потоков

Пул потоков (Thread Pool) – набор уже созданных потоков, готовых к выполнению задач

![img](https://github.com/IlyaGall/C-/blob/main/36%20%D0%90%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8/IMG/6.JPG)

#### История развития реализации асинхронности

Реализация одного и того же метода с помощью APM, EAP и TAP

![img](https://github.com/IlyaGall/C-/blob/main/36%20%D0%90%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8/IMG/7.JPG)

### TAP (Task-based Asynchronous Pattern)

Асинхронные операции в большинстве случаев возвращают Task<Т>

System.Threading.Tasks.Task
Экземпляр таски хранит в себе:
- Метод, который нужно выполнить
- Статус
- Исключения
- ..

![img](https://github.com/IlyaGall/C-/blob/main/36%20%D0%90%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8/IMG/8.JPG)

![img](https://github.com/IlyaGall/C-/blob/main/36%20%D0%90%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8/IMG/9.JPG)

## Виды задач

![img](https://github.com/IlyaGall/C-/blob/main/36%20%D0%90%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8/IMG/10.JPG)

### Delegate Task

Таска, содержащая код, который нужно выполнить

![img](https://github.com/IlyaGall/C-/blob/main/36%20%D0%90%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8/IMG/11.JPG)

### Promise Task

Таска, не содержащая в себе никакого кода, который нужно выполнить

Task.FromResult(true)

Task.CompletedTask.


![img](https://github.com/IlyaGall/C-/blob/main/36%20%D0%90%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8/IMG/12.JPG)


## async - await

![img](https://github.com/IlyaGall/C-/blob/main/36%20%D0%90%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8/IMG/13.JPG)

Async

1. Превращает метод в асинхронную операцию
2. Накладывает ограничения на сигнатуру и возвращаемое значение
3. Позволяет применить await 

Await
1. приостанавливает выполнение метода и возвращает управление вызывающему коду до завершения асинхронной операции, идущей после него
2. Извлекает результат метода асинхронной операции и исключения если они есть

### Что происходит в методе Async

![img](https://github.com/IlyaGall/C-/blob/main/36%20%D0%90%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8/IMG/14.JPG)

### Асинхронная мантра

![img](https://github.com/IlyaGall/C-/blob/main/36%20%D0%90%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8/IMG/15.JPG)

Асинхронная мантра: «async Task await Async»

### Асинхронные методы

Асинхронные методы — методы использующие ключевые слова async/await и имеют специальны тип возращаемого значения. При наименовании метода в конец добавляется суффикс Async.

![img](https://github.com/IlyaGall/C-/blob/main/36%20%D0%90%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8/IMG/16.JPG)


Асинхронный метод, как и обычный, может использовать любое количество параметров или не использовать их вообще.

Однако асинхронный метод не может определять параметры с модификаторами out и ref.

## Цепочки асинхронных операций
### Цепочки вызовов асинхронных методов
Асинхронный метод чаще всего вызывается из асинхронного метода.

Вызывающие друг друга асинхронные методы формируют цепочки.

Важно понимать, где цепочка вызова начинается и где ее конечный вызов

### Синхронное ожидание асинхронной операции

Task.Wait() (Task.Result) (исключения передаются в составе AggregateException)

GetAwaiter.GetResult() (исключения передаются в исходном виде)

Недостатки:
1. Истощение ресурсов пула потоков
2. Возможность дедлока

### Что если делать await только в конце асинхронной операции

1. Async-await распространяются по коду
2. Можно делать цепочки без async – await, но не рекомендуется

[link](https://blog.stephencleary.com/2016/12/eliding-async-await.html)

## Запуск и выполнение тасок

Tипы возращаемых значений
* Task — для асинхронного метода, не возвращающего значение
* Task<TResult> — для асинхронного метода, возвращающего значение
* void — для обработчика событий (event handler)
* IAsyncEnumerable<T>* — для асинхронного метода, который возвращает асинхронный поток.
* - для c# версии 8.0 и выше

### Создание и запуск тасок

* Task.Run
* Task.Factory.StartNew
* (new Task()).Start()
* TaskCreationOptions
* TaskScheduler

* [StartNew опасен](https://blog.stephencleary.com/2013/08/startnew-is-dangerous.html)
* [«Task.Factory.StartNew» против «новой задачи(…).Start»](https://devblogs.microsoft.com/pfxteam/task-factory-startnew-vs-new-task-start/)

### Дочерние таски

Виды:
- Прикрепленные
- Открепленные

![img](https://github.com/IlyaGall/C-/blob/main/36%20%D0%90%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8/IMG/17.JPG)


Стивен Клири:
“TAP обычно не использует AttachedToParent.
AttachedToParent была частью TPL. И TPL, и TAP имеют один и тот же тип Task, но есть много членов TPL, которых следует избегать в коде TAP.

В TAP лучше рассматривать понятия родительских и дочерних асинхронных методов.

### Запуск нескольких Task одновременно

* Task.WhenAll
* Task.WhenAny

## Обработка исключений

### Обработка ошибок в асинхронных методах
Исключения хранятся в таске, в виде AggregateException

### Обработка ошибок в асинхронных методах

Для обработки ошибок выражение await помещается в блок try


![img](https://github.com/IlyaGall/C-/blob/main/36%20%D0%90%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8/IMG/18.JPG)

### Отмена асинхронных операций

Отмена по согласию: нужно не только запросить отмену в вызывающем коде, но и реализовать ее в вызываемом

Виды отмены:
- По событию
- По шедулеру

CancellationToken
CancellationTokenSource.

TaskCancelledException
OperationCancelledException

Для CancellationTokenSource нужно вызывать Dispose

Если метод не поддерживает отмену

![img](https://github.com/IlyaGall/C-/blob/main/36%20%D0%90%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D1%8B%D0%B5%20%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8/IMG/19.JPG)

### Best Practices

Не делай

* Никогда не используй void, если это не обработчик событий(event handler)
* Никогда не блокируй асинхронные операции в асинхронном коде вызовом методов GetResult() или Wait()

Делай

* Всегда используй async и await вместе
* Всегда возвращай Task из асинхронных методов
* Всегда используй await для асинхронных методов

### Список материалов для изучения
* [Github с примерами](https://github.com/davidfowl/AspNetCoreDiagnosticScenarios/blob/master/AsyncGuidance.md)
* [Асинхронная модель программирования](https://learn.microsoft.com/ru-ru/dotnet/csharp/asynchronous-programming/task-asynchronous-programming-model)
* [ExecutionContext против SynchronizationContext](https://devblogs.microsoft.com/pfxteam/executioncontext-vs-synchronizationcontext/)
* [Сбор контекстной информации для логирования](https://habr.com/ru/articles/416751/)
* [AsyncLocal<T> Class](https://learn.microsoft.com/en-us/dotnet/api/system.threading.asynclocal-1?view=netcore-3.1)