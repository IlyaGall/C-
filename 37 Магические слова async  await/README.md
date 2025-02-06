# Магические слова async / await

## Жизненный цикл Task


Что хранит в себе Task
* Метод который нужно выполнить internal object m_action;
* Статус public TaskStatus status;
* Результат internal TResult m_result;
* Список исключений internal volatile TaskExceptionHolder m_exceptionsHolder; // в свойствах ContingentProperties

## Статусы Task


* **Created** – создана, но не запланирована. Таска, созданная через конструктор. До вызова Start пребывает в этом статусе.
* **WaitingForActivation** – ждет активации. В этом статусе создаются таски при использовании метода ContinueWith 
* **WaitingToRun** – таске уже назначен шедулер, но она еще не запущена. Таски, созданные методами Run, TaskFactory.StartNew начинают цикл с этого статуса.
* **Running** – выполняется
* **WaitingForChildrenToComplete** – ожидание окончания дочерних тасок. В этот статус таска попадает после своего завершения
* **RanToCompletion** – успешно завершена
**Cancelled** – отменена
Faulted – выполнение закончилось ошибкой

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/1.JPG)

### ContinueWith

**Продолжение(continuation)** - это задача, созданная в состоянии WaitingForActivation. Она активируется автоматически по завершению предыдущей задачи или предыдущих задач.

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/2.JPG)

### Awaitable Pattern

Awaitable
Чтобы быть awaitable, тип T должен иметь экземплярный метод GetAwaiter() без параметров (или должен быть соответствующий метод расширения).

Метод GetAwaiter() должен возвращать тип awaiter.

Тип awaiter должен:
- реализовывать интерфейс INotifyCompletion, имеющий метод void OnCompleted(Action).
- иметь экземплярное свойство bool IsCompleted.
- иметь экземплярный метод GetResult().

Типы реализующие паттерн Awaitable:
* Task
* Task<TResult>
* ValueTask
* ValueTask<TResult>
* Custom types that implement the pattern

### TaskAwaiter
IsCompleted – делегируется таске

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/3.JPG)

GetResult – если есть исключения, бросает. Если вызвано вручную, ждет синхронно

OnCompleted(Action action) – выполняет заданное действие после завершения ожидания 

### TaskAwaiter - схема работы 

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/4.JPG)

## Асинхронная машина состояний

Стейт машина - реализация паттерна состояние

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/5.JPG)

### Состояние (State)
Паттерн State позволяет объектам менять поведение в зависимости от своего состояния. Извне создается впечатление, что изменился класс объекта.

Условия применимости:

- поведение объекта зависит от его состояния и должно изменяться во время выполнения;

- когда в коде операций встречаются состоящие из многих ветвей условные операторы, в которых выбор ветви зависит от состояния. Обычно в таком случае состояние представлено перечисляемыми константами. Часто одна и та же структура условного оператора повторяется в нескольких операциях. Паттерн состояние предлагает поместить каждую ветвь в отдельный класс. Это позволяет трактовать состояние объекта как самостоятельный объект, который может изменяться независимо от других.

### Состояние (State)

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/6.JPG)

### IAsyncStateMachine  

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/7.JPG)

### Стейт машина - изменения состояний

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/8.JPG)

### Стейт машина - изменение состояний

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/9.JPG)

### Boxing-unboxing и SetStateMachine
Асинхронная стейтмашина – структура, но после первого await она кладется в кучу, чтобы не потерять данные во время ожидания.

Метод SetStateMachine применяется для того чтобы сослаться на сохраненную в кучу копию

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/10.JPG)

### IAsyncStateMachine

Статусы асинхронной стейтмашины:
-2 – финальный статус (или успешное выполнение, или исключение, или
отмена таски)
-1 – обычное состояние, когда нет ожидания await
0 – в первом await
1 – во втором await (если есть)
2 – в третьем await (если есть)
и т.д.(по количеству await в методе)

### Асинхронный метод “под капотом”

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/11.JPG)

### Асинхронная стейтмашина

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/12.JPG)

### StateMachineBuilder
AsyncTaskMethodBuilder
AsyncTaskMethodBuilder<TResult>
AsyncVoidMethodBuilder

* **SetResult** - завершает таску.
* **SetException** – завершает таску, сохраняет исключения в таску
* **AwaitOnCompleted** (AwaitUnsafeOnCompleted) – вызывает OnCompleted у TaskAwaiter, который вызывает SetContinuationForAwait у таски

### OnCompleted vs UnsafeOnCompleted
* **AwaitOnCompleted** передает ExecutionContext,
* **AwaitUnsafeOnCompleted** не передает потому что он передается другим способом


![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/13.JPG)

UnsafeOnCompleted предназначен для вызова только доверенной асинхронной инфраструктурой, такой как AsyncTaskMethodBuilder. AsyncTaskMethodBuilder гарантирует, что он всегда захватывает контекст выполнения. Вот почему он вызывает небезопасный метод, чтобы TaskAwaiter избежал его повторного захвата.


### Что навешивается на колбек

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/14.JPG)

```c#
 /// <summary>
        /// Schedules the specified state machine to be pushed forward when the specified awaiter completes.
        /// </summary>
        /// <typeparam name="TAwaiter">Specifies the type of the awaiter.</typeparam>
        /// <typeparam name="TStateMachine">Specifies the type of the state machine.</typeparam>
        /// <param name="awaiter">The awaiter.</param>
        /// <param name="stateMachine">The state machine.</param>
        public void AwaitOnCompleted<TAwaiter, TStateMachine>(
            ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : INotifyCompletion
            where TStateMachine : IAsyncStateMachine
        {
            try
            {
                var continuation = m_coreState.GetCompletionAction(ref this, ref stateMachine);
                Contract.Assert(continuation != null, "GetCompletionAction should always return a valid action.");
                awaiter.OnCompleted(continuation);
            }
            catch (Exception e)
            {
                AsyncServices.ThrowAsync(e, targetContext: null);
            }
        }
```

### Что навешивается на колбек

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/15.JPG)

```c#
   /// <summary>Provides the ability to invoke a state machine's MoveNext method under a supplied ExecutionContext.</summary>
        private sealed class MoveNextRunner
        {
            /// <summary>The context with which to run MoveNext.</summary>
            private readonly ExecutionContextLightup m_context;
            /// <summary>The state machine whose MoveNext method should be invoked.</summary>
            internal IAsyncStateMachine m_stateMachine;

            /// <summary>Initializes the runner.</summary>
            /// <param name="context">The context with which to run MoveNext.</param>
            internal MoveNextRunner(ExecutionContextLightup context)
            {
                m_context = context;
            }

            /// <summary>Invokes MoveNext under the provided context.</summary>
            internal void Run()
            {
                Contract.Assert(m_stateMachine != null, "The state machine must have been set before calling Run.");

                if (m_context != null)
                {
                    try
                    {
                        // Get the callback, lazily initializing it as necessary
                        Action<object> callback = s_invokeMoveNext;
                        if (callback == null) { s_invokeMoveNext = callback = InvokeMoveNext; }

                        if (m_context == null)
                        {
                            callback(m_stateMachine);
                        }
                        else
                        {
                            // Use the context and callback to invoke m_stateMachine.MoveNext.
                            ExecutionContextLightup.Instance.Run(m_context, callback, m_stateMachine);
                        }
                    }
                    finally { if (m_context != null) m_context.Dispose(); }
                }
                else
                {
                    m_stateMachine.MoveNext();
                }
            }

            /// <summary>Cached delegate used with ExecutionContext.Run.</summary>
            private static Action<object> s_invokeMoveNext; // lazily-initialized due to SecurityCritical attribution

            /// <summary>Invokes the MoveNext method on the supplied IAsyncStateMachine.</summary>
            /// <param name="stateMachine">The IAsyncStateMachine machine instance.</param>
            private static void InvokeMoveNext(object stateMachine)
            {
                ((IAsyncStateMachine)stateMachine).MoveNext();
            }
        }
```

### Основные методы используемые в стейт машине

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/16.JPG)

### Метод MoveNext()

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/17.JPG)

### Контекст синхронизации

В каком потоке выполнится продолжение асинхронного метода после возвращения из await?

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/18.JPG)

### ConfigureAwait(false)

* ConfigureAwait(bool continueOnCapturedContext)
* continueOnCapturedContext = true – исполнять продолжение на исходном потоке
* continueOnCapturedContext = false – не исполнять продолжение на исходном потоке

### SynchronizationContext

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/19.JPG)


За то, в каком потоке может быть выполнено продолжение, отвечает контекст синхронизации SynchronizationContext

Терминология:

“Выполнить продолжение в том же потоке, что его начало” = “Продолжить на захваченном контексте”, “Захватить контекст”

captureContext, continueOnCapturedContext

### SynchronizationContext

Преимущества возврата в исходный контекст:
- В некоторых случаях это необходимо, например для WPF (пример выше)

Преимущества отсутствия возврата в исходный контекст:
- Исключен deadlock
- Работает быстрее


### SynchronizationContext
По-разному используется в разных подплатформах .Net (WPF,winforms, Asp.Net (framework) есть, в
Asp.Net Core, консольные приложения нет ).

По-разному используется в разных подплатформах .Net (WPF,winforms, Asp.Net (framework) есть, в
Asp.Net Core, консольные приложения нет ).

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/20.JPG)

Перед await сохраняется, а при возобновлении после await загружается и колбек после возобновления исполняется уже в нем 

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/21.JPG)

[исходник](https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/Threading/Tasks/Task.cs)

Частью сущности продолжения асинхронного метода является контекст синхронизации, несущий информацию о потоке выполнения

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/22.JPG)

Частью сущности продолжения асинхронного метода является контекст синхронизации, несущий информацию о потоке выполнения

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/23.JPG)


Метод может возобновиться в потоке, отличном от того, где был начат, при выполнении одного из следующих условий:

* если объект Task сконфигурирован так, что при возобновлении исходный поток не используется (ConfigureAwait(false)), при условии существования текущего контекста синхронизации( это WPF или winforms приложение , использующее .net framework или Asp.net framework приложение, также это может быть кастомный контекст синхронизации).
* если в точке, где встретился оператор await, вообще не было текущего контекста синхронизации, как, например, в консольном приложении, ASP.NET CORE;
* если запомненный контекст SynchronizationContext инкапсулирует несколько потоков, например пул потоков;

### Контексты синхронизации
* [Базовый](https://referencesource.microsoft.com/#mscorlib/system/threading/synchronizationcontext.cs)
* [Winforms](https://referencesource.microsoft.com/#System.Windows.Forms/winforms/Managed/System/WinForms/WindowsFormsSynchronizationContext.cs,c7dfb662bbd6227d)
* [WPF - Dispatcher](https://referencesource.microsoft.com/#WindowsBase/Base/System/Windows/Threading/DispatcherSynchronizationContext.cs,f640e296cad20594)
* [WinRT](https://github.com/dotnet/runtime/blob/60d1224ddd68d8ac0320f439bb60ac1f0e9cdb27/src/libraries/System.Runtime.WindowsRuntime/src/System/Threading/WindowsRuntimeSynchronizationContext.cs)

* Default SynchronizationContext (консоль) – асинхронные операции берет на себя ThreadPool
* AspNetSynchronizationContext (ASP.Net) – основная задача – сохранить HttpContext.Current (контекст выполнения HTTP запросов: логины, хедеры,язык и т.д.)

### Что делать с ConfigureAwait(false)
При разработке во фреймворке ConfigureAwait(false) использовать не нужно. Если же вы пишете код внутренней библиотеки, используйте ConfigureAwait(false) 

### Типы возвращаемых значений async методов
* Task — для асинхронного метода, не возвращающего значение
* Task<TResult> — для асинхронного метода, возвращающего значение
* ValueTask
* ValueTask<TResult>
* void — для обработчика событий (event handler)
* IAsyncEnumerable<T>* — для асинхронного метода, который возвращает асинхронный поток

![img](https://github.com/IlyaGall/C-/blob/main/37%20%D0%9C%D0%B0%D0%B3%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D0%B5%20%D1%81%D0%BB%D0%BE%D0%B2%D0%B0%20async%20%20await/IMG/24.JPG)


### Список материалов для изучения
* https://blog.stephencleary.com/2014/04/a-tour-of-task-part-0-overview.html
* https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-8.0
* https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1?view=net-8.0
* https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask?view=net-8.0
* https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1?view=net-8.0
* https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1.getawaiter?view=net-8.0
* https://referencesource.microsoft.com/#mscorlib/system/runtime/compilerservices/TaskAwaiter.cs,be57b6bc41e5c7e4
* https://vkontech.com/exploring-the-async-await-state-machine-the-awaitable-pattern/
* https://refactoring.guru/ru/design-patterns/state
* https://learn.microsoft.com/ru-ru/shows/on-dotnet/diagnosing-thread-pool-exhaustion-issues-in-net-core-apps
* https://metanit.com/sharp/tutorial/12.4.php
* https://devblogs.microsoft.com/dotnet/configureawait-faq/
* https://blog.stephencleary.com/2015/04/a-tour-of-task-part-10-promise-tasks.html
* https://devblogs.microsoft.com/pfxteam/executioncontext-vs-synchronizationcontext/
* https://learn.microsoft.com/en-us/dotnet/api/system.threading.executioncontext?view=net-5.0
* https://learn.microsoft.com/ru-ru/dotnet/api/system.threading.asynclocal-1?view=net-8.0
* https://codeblog.jonskeet.uk/