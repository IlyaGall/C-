# C# Professional Синхронизация доступа к общему ресурсу

## Процессы, потоки, синхронизация

Процессы, потоки , разделяемые ресурсы


![img](https://github.com/IlyaGall/C-/blob/main/38%20%D0%A1%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D1%8F%20%D0%B4%D0%BE%D1%81%D1%82%D1%83%D0%BF%D0%B0%20%D0%BA%20%D0%BE%D0%B1%D1%89%D0%B5%D0%BC%D1%83%20%D1%80%D0%B5%D1%81%D1%83%D1%80%D1%81%D1%83/IMG/1.JPG)

### Состояния процесса

![img](https://github.com/IlyaGall/C-/blob/main/38%20%D0%A1%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D1%8F%20%D0%B4%D0%BE%D1%81%D1%82%D1%83%D0%BF%D0%B0%20%D0%BA%20%D0%BE%D0%B1%D1%89%D0%B5%D0%BC%D1%83%20%D1%80%D0%B5%D1%81%D1%83%D1%80%D1%81%D1%83/IMG/2.JPG)

### Состояния потока

![img](https://github.com/IlyaGall/C-/blob/main/38%20%D0%A1%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D1%8F%20%D0%B4%D0%BE%D1%81%D1%82%D1%83%D0%BF%D0%B0%20%D0%BA%20%D0%BE%D0%B1%D1%89%D0%B5%D0%BC%D1%83%20%D1%80%D0%B5%D1%81%D1%83%D1%80%D1%81%D1%83/IMG/3.JPG)


## Блокировка общих ресурсов для (1) потока
* Monitor/lock
* Mutex

### Monitor - блокировка для одного потока

- примитив синхронизации, допускающий одновременное выполнение участка кода только одним потоком

![img](https://github.com/IlyaGall/C-/blob/main/38%20%D0%A1%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D1%8F%20%D0%B4%D0%BE%D1%81%D1%82%D1%83%D0%BF%D0%B0%20%D0%BA%20%D0%BE%D0%B1%D1%89%D0%B5%D0%BC%D1%83%20%D1%80%D0%B5%D1%81%D1%83%D1%80%D1%81%D1%83/IMG/4.JPG)

```C#
namespace SyncObjects
{
    internal class MonitorExample
    {
        /// <summary>
        /// Shared resource
        /// </summary>
        int x = 0;
        /// <summary>
        /// Lock object
        /// </summary>
        private readonly object lockObj = new object();
        /// <summary>
        /// Property for waiting end of show example in Program.cs
        /// </summary>
        public CountdownEvent CountdownForWaitEndShowExample { get; set; } = new CountdownEvent(5);
        /// <summary>
        /// Property for waiting start of trying enter critical section all thread together
        /// </summary>
        public CountdownEvent CountdownForStartTryingEnterCriticalSectionAllThreadTogether { get; set; } = new CountdownEvent(5);

        public void Show()
        {
            // запускаем пять потоков
            for (int i = 1; i < 6; i++)
            {
                Thread myThread = new(Print);
                myThread.Name = $"Поток {i}";
                myThread.Start();
                CountdownForStartTryingEnterCriticalSectionAllThreadTogether.Signal();
            }
        }


        void Print()
        {
            CountdownForStartTryingEnterCriticalSectionAllThreadTogether.Wait();

            Monitor.Enter(lockObj);    // приостанавливаем поток до освобождения монитором lockObject
            x = 0;  // reset shared resource for every new thread
            for (int i = 1; i < 6; i++)
            {                
                x++; //increment x - change shared resource
                Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                Thread.Sleep(100);
            }
            Monitor.Exit(lockObj);    // освобождаем  lockObject


            CountdownForWaitEndShowExample.Signal();
        }


    }
}

```



### lock(object)

![img](https://github.com/IlyaGall/C-/blob/main/38%20%D0%A1%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D1%8F%20%D0%B4%D0%BE%D1%81%D1%82%D1%83%D0%BF%D0%B0%20%D0%BA%20%D0%BE%D0%B1%D1%89%D0%B5%D0%BC%D1%83%20%D1%80%D0%B5%D1%81%D1%83%D1%80%D1%81%D1%83/IMG/5.JPG)
lock

```C#
using System.Collections;
using System.Diagnostics;
using System.Threading;

namespace SyncObjects
{
    class LockExample
    {
        const int threadsAmount = 20;
        public static int numIteration = 100;

        public static TimeSpan timeout = TimeSpan.FromSeconds(500);

        public static Barrier barrier = new Barrier(threadsAmount);

        public static Barrier barrier2 = new Barrier(threadsAmount);

        public static Queue<int> SharedResource = new Queue<int>();


        public void ShowDifferenceBetweenLockAndSpinLOck()
        {

            CountdownEvent countdownEventLock = new CountdownEvent(threadsAmount);

            CountdownEvent countdownEventSlimLock = new CountdownEvent(threadsAmount);

            Object object1 = new Object();

            Stopwatch csLock = Stopwatch.StartNew();
            for (int i = 0; i < threadsAmount; i++)
            {
                var sm = new SummarizerOnLock(i, countdownEventLock);
            }
            countdownEventLock.Wait();
            csLock.Stop();

            Console.WriteLine($"Lock: {csLock.ElapsedMilliseconds} milliseconds");

            

            Stopwatch csMonitor = Stopwatch.StartNew();
            for (int i = 0; i < threadsAmount; i++)
            {
                var sm = new SummarizerOnSpinLock(i, countdownEventSlimLock);
            }
            countdownEventSlimLock.Wait();
            csMonitor.Stop();

            Console.WriteLine($"Monitor.TryEnter: {csMonitor.ElapsedMilliseconds} milliseconds"); ;
        }
    }



    class SummarizerOnLock
    {
        public static int commonResource = 0;

        public static object obj = new object();

        CountdownEvent countdown;

        public SummarizerOnLock(int i, CountdownEvent cntdown)
        {
            countdown = cntdown;
            Thread mythread = new Thread(Run);
            mythread.Name = $"Поток на Lock {i}";            
            mythread.Start();

        }

        public void Run()
        {
            LockExample.barrier.SignalAndWait();
            for (int i = 0; i < LockExample.numIteration; i++)
            {
                //lock (obj)
                //{
                //    LongOperation();
                //}
                Monitor.Enter(obj);
                LongOperation();
                Monitor.Exit(obj);

            }
            countdown.Signal();
        }

        void LongOperation()
        {
            commonResource = 0;
            while (commonResource < 1_000_000)
                commonResource++;
            LockExample.SharedResource.Enqueue(commonResource);

            //Thread.Sleep(1);
        }
    }


    class SummarizerOnSpinLock
    {
        public static int commonResource = 0;

        public static object obj = new object();

        static SpinLock sl = new SpinLock();

        static TimeSpan timeout = TimeSpan.FromMilliseconds(0);

        bool lockTaken;

        CountdownEvent countdown;

        public SummarizerOnSpinLock(int i, CountdownEvent cntdown)
        {
            countdown = cntdown;
            Thread mythread = new Thread(Run);
            mythread.Name = $"Поток на SpinLock {i}";
            mythread.Start();

        }

        public void Run()
        {
            LockExample.barrier2.SignalAndWait();
            for (int i = 0; i < LockExample.numIteration; i++)
            {
                
                bool lockTaken = false;

                try
                {
                    Monitor.TryEnter(obj, LockExample.timeout, ref lockTaken);
                    if (lockTaken)
                        LongOperation();
                    else
                        Console.WriteLine("Timeout had happen");
                }
                finally 
                {
                    if (lockTaken)
                        Monitor.Exit(obj);
                }
                


            }
            countdown.Signal();
        }

        void LongOperation()
        {
            commonResource = 0;
            while (commonResource<1_000_000)
            commonResource++;
            LockExample.SharedResource.Enqueue(commonResource);
            //Thread.Sleep(0);
        }
    }
}


```


### SyncBlockIndex

![img](https://github.com/IlyaGall/C-/blob/main/38%20%D0%A1%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D1%8F%20%D0%B4%D0%BE%D1%81%D1%82%D1%83%D0%BF%D0%B0%20%D0%BA%20%D0%BE%D0%B1%D1%89%D0%B5%D0%BC%D1%83%20%D1%80%D0%B5%D1%81%D1%83%D1%80%D1%81%D1%83/IMG/6.JPG)

### Double-checked locking

![img](https://github.com/IlyaGall/C-/blob/main/38%20%D0%A1%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D1%8F%20%D0%B4%D0%BE%D1%81%D1%82%D1%83%D0%BF%D0%B0%20%D0%BA%20%D0%BE%D0%B1%D1%89%D0%B5%D0%BC%D1%83%20%D1%80%D0%B5%D1%81%D1%83%D1%80%D1%81%D1%83/IMG/7.JPG)

### Mutex
* принцип работы такой же как у Monitor, но он реализован на уровне ОС,
поэтому может быть использован для межпроцессной синхронизации

```c#
namespace SyncObjects;

internal class MutexExample
{
    int x = 0;
    Mutex mutexObj = new();
    public CountdownEvent CountdownForWaitEndShowExample { get; set; } = new CountdownEvent(5);
    public CountdownEvent CountdownForStartTryingEnterCriticalSectionAllThreadTogether { get; set; } = new CountdownEvent(5);

    public void Show()
    {
        // запускаем пять потоков
        for (int i = 1; i < 6; i++)
        {
            Thread myThread = new(Print);
            myThread.Name = $"Поток {i}";
            myThread.Start();
            CountdownForStartTryingEnterCriticalSectionAllThreadTogether.Signal();
        }
    }


    void Print()
    {
        CountdownForStartTryingEnterCriticalSectionAllThreadTogether.Wait();
        mutexObj.WaitOne();     // приостанавливаем поток до получения мьютекса
        x = 0;
        for (int i = 1; i < 6; i++)
        {           
            x++;
            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
            Thread.Sleep(100);
        }
        mutexObj.ReleaseMutex();    // освобождаем мьютекс

        CountdownForWaitEndShowExample.Signal();
    }
}


```

## Блокировка общих ресурсов для нескольких потоков (1+)
* Semaphore
* ReaderWriterLock

### Semaphore (1 и более потоков)
примитив синхронизации, допускающий одновременное выполнение участка кода одним и более потоками

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncObjects
{
    internal class SemaphoreExample
    {
        public CountdownEvent CountdownForWaitEndShowExample { get; set; } = new CountdownEvent(5);

        public void Show()
        {
            // запускаем пять потоков
            for (int i = 1; i < 6; i++)
            {
                Reader reader = new Reader(i, CountdownForWaitEndShowExample);
            }
        }
    }

    /// <summary>
    /// В библиотеке есть место только для трех читателей
    /// </summary>
    class Reader
    {
        // создаем семафор
        static Semaphore sem = new Semaphore(3, 3);
        Thread myThread;
        int count = 3;// количество обязательных посещений библиотеки
        CountdownEvent countdownForServiceEvent;

        public Reader(int i, CountdownEvent countdownEvent)
        {
            countdownForServiceEvent = countdownEvent;
            myThread = new Thread(Read);
            myThread.Name = $"Читатель {i}";
            myThread.Start();
        }

        public void Read()
        {
            while (count > 0)
            {
                sem.WaitOne();  // ожидаем, когда освободиться место

                Console.WriteLine($"{Thread.CurrentThread.Name} входит в библиотеку");

                Console.WriteLine($"{Thread.CurrentThread.Name} читает");
                Thread.Sleep(1000);

                Console.WriteLine($"{Thread.CurrentThread.Name} покидает библиотеку");

                sem.Release();  // освобождаем место

                count--;
                Thread.Sleep(1000);
            }

            countdownForServiceEvent.Signal();
        }
    }

}

```

### ReaderWriterLock

примитив синхронизации, позволяющий организовать множественный доступ на чтение и лишь один доступ на запись в единицу времени.

Используется, например для чтения из файла, запись в который происходит гораздо реже.

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncObjects
{
    public class ReaderWriterLockExample
    {
        static ReaderWriterLock rwl = new ReaderWriterLock();
        // Define the shared resource protected by the ReaderWriterLock.
        static int resource = 0;

        const int numThreads = 26;
        static bool running = true;

        // Statistics.
        static int readerTimeouts = 0;
        static int writerTimeouts = 0;
        static int reads = 0;
        static int writes = 0;

        public static void Show()
        {
            // Start a series of threads to randomly read from and
            // write to the shared resource.
            Thread[] t = new Thread[numThreads];
            for (int i = 0; i < numThreads; i++)
            {
                t[i] = new Thread(new ThreadStart(ThreadProc));
                t[i].Name = new String((char)(i + 65), 1);
                t[i].Start();
                if (i > 10)
                    Thread.Sleep(300);
            }
            

            // Tell the threads to shut down and wait until they all finish.
            running = false;
            for (int i = 0; i < numThreads; i++)
                t[i].Join();

            // Display statistics.
            Console.WriteLine("\n{0} reads, {1} writes, {2} reader time-outs, {3} writer time-outs.",
                  reads, writes, readerTimeouts, writerTimeouts);
            Console.Write("Press ENTER to continue... ");
            Console.ReadLine();
        }

        static void ThreadProc()
        {
            Random rnd = new Random();

            // Randomly select a way for the thread to read and write from the shared
            // resource.
            while (running)
            {
                double action = rnd.NextDouble();
                if (action < .4)
                    ReadFromResource(10);
                else if (action < .81)
                    ReleaseRestore(rnd, 50);
                else if (action < .90)
                    UpgradeDowngrade(rnd, 100);
                else
                    WriteToResource(rnd, 100);
            }
        }

        // Request and release a reader lock, and handle time-outs.
        static void ReadFromResource(int timeOut)
        {
            try
            {
                rwl.AcquireReaderLock(timeOut);
                try
                {
                    // It is safe for this thread to read from the shared resource.
                    Display("reads resource value " + resource);
                    Interlocked.Increment(ref reads);
                }
                finally
                {
                    // Ensure that the lock is released.
                    rwl.ReleaseReaderLock();
                }
            }
            catch (ApplicationException)
            {
                // The reader lock request timed out.
                Interlocked.Increment(ref readerTimeouts);
            }
        }

        // Request and release the writer lock, and handle time-outs.
        static void WriteToResource(Random rnd, int timeOut)
        {
            try
            {
                rwl.AcquireWriterLock(timeOut);
                try
                {
                    // It's safe for this thread to access from the shared resource.
                    resource = rnd.Next(500);
                    Display("writes resource value " + resource);
                    Interlocked.Increment(ref writes);
                }
                finally
                {
                    // Ensure that the lock is released.
                    rwl.ReleaseWriterLock();
                }
            }
            catch (ApplicationException)
            {
                // The writer lock request timed out.
                Interlocked.Increment(ref writerTimeouts);
            }
        }

        // Requests a reader lock, upgrades the reader lock to the writer
        // lock, and downgrades it to a reader lock again.
        static void UpgradeDowngrade(Random rnd, int timeOut)
        {
            try
            {
                rwl.AcquireReaderLock(timeOut);
                try
                {
                    // It's safe for this thread to read from the shared resource.
                    Display("reads resource value " + resource);
                    Interlocked.Increment(ref reads);

                    // To write to the resource, either release the reader lock and
                    // request the writer lock, or upgrade the reader lock. Upgrading
                    // the reader lock puts the thread in the write queue, behind any
                    // other threads that might be waiting for the writer lock.
                    try
                    {
                        LockCookie lc = rwl.UpgradeToWriterLock(timeOut);
                        try
                        {
                            // It's safe for this thread to read or write from the shared resource.
                            resource = rnd.Next(500);
                            Display("writes resource value ----" + resource);
                            Interlocked.Increment(ref writes);
                        }
                        finally
                        {
                            // Ensure that the lock is released.
                            rwl.DowngradeFromWriterLock(ref lc);
                        }
                    }
                    catch (ApplicationException)
                    {
                        // The upgrade request timed out.
                        Interlocked.Increment(ref writerTimeouts);
                    }

                    // If the lock was downgraded, it's still safe to read from the resource.
                    Display("reads resource value ----" + resource);
                    Interlocked.Increment(ref reads);
                }
                finally
                {
                    // Ensure that the lock is released.
                    rwl.ReleaseReaderLock();
                }
            }
            catch (ApplicationException)
            {
                // The reader lock request timed out.
                Interlocked.Increment(ref readerTimeouts);
            }
        }

        // Release all locks and later restores the lock state.
        // Uses sequence numbers to determine whether another thread has
        // obtained a writer lock since this thread last accessed the resource.
        static void ReleaseRestore(Random rnd, int timeOut)
        {
            int lastWriter;

            try
            {
                rwl.AcquireReaderLock(timeOut);
                try
                {
                    // It's safe for this thread to read from the shared resource,
                    // so read and cache the resource value.
                    int resourceValue = resource;     // Cache the resource value.
                    Display("reads resource value " + resourceValue);
                    Interlocked.Increment(ref reads);

                    // Save the current writer sequence number.
                    lastWriter = rwl.WriterSeqNum;

                    // Release the lock and save a cookie so the lock can be restored later.
                    LockCookie lc = rwl.ReleaseLock();

                    // Wait for a random interval and then restore the previous state of the lock.
                    Thread.Sleep(rnd.Next(250));
                    rwl.RestoreLock(ref lc);

                    // Check whether other threads obtained the writer lock in the interval.
                    // If not, then the cached value of the resource is still valid.
                    if (rwl.AnyWritersSince(lastWriter))
                    {
                        resourceValue = resource;
                        Interlocked.Increment(ref reads);
                        Display("resource has changed ----" + resourceValue);
                    }
                    else
                    {
                        Display("resource has not changed ----" + resourceValue);
                    }
                }
                finally
                {
                    // Ensure that the lock is released.
                    rwl.ReleaseReaderLock();
                }
            }
            catch (ApplicationException)
            {
                // The reader lock request timed out.
                Interlocked.Increment(ref readerTimeouts);
            }
        }

        // Helper method briefly displays the most recent thread action.
        static void Display(string msg)
        {
            Console.WriteLine("Thread {0} {1}.       \r", Thread.CurrentThread.Name, msg);
        }
    }
}

```

## Примитивы синхронизации, использующие Spin-wait
* SpinLock
* SemaphoreSlim
* ReaderWriterLockSlim

### SpinLock
это тот же Monitor, только с периодом цикличных проверок на выход изблокировки, схематично это выглядит так:

![img](https://github.com/IlyaGall/C-/blob/main/38%20%D0%A1%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D1%8F%20%D0%B4%D0%BE%D1%81%D1%82%D1%83%D0%BF%D0%B0%20%D0%BA%20%D0%BE%D0%B1%D1%89%D0%B5%D0%BC%D1%83%20%D1%80%D0%B5%D1%81%D1%83%D1%80%D1%81%D1%83/IMG/8.JPG)

```C#
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncObjects
{
    public class SpinLockExample
    {
        const int N = 100_000;
        static Queue<Data> _queue = new Queue<Data>();
        static object _lock = new Object();
        static SpinLock _spinlock = new SpinLock();

        class Data
        {
            public string Name { get; set; }
            public double Number { get; set; }
        }
        public static void Show()
        {

            // First use a standard lock for comparison purposes.
            UseLock();
            _queue.Clear();
            UseSpinLock();

            Console.WriteLine("Press a key");
            Console.ReadKey();
        }

        private static void UpdateWithSpinLock(Data d)
        {
            bool lockTaken = false;
            try
            {
                _spinlock.Enter(ref lockTaken);
                _queue.Enqueue(d);
            }
            finally
            {
                if (lockTaken) _spinlock.Exit(false);
            }
        }

        private static void UseSpinLock()
        {

            Stopwatch sw = Stopwatch.StartNew();

            Parallel.Invoke(
                    () => {
                        for (int i = 0; i < N; i++)
                        {
                            UpdateWithSpinLock(new Data() { Name = i.ToString(), Number = i });
                        }
                    },
                    () => {
                        for (int i = 0; i < N; i++)
                        {
                            UpdateWithSpinLock(new Data() { Name = i.ToString(), Number = i });
                        }
                    }
                );
            sw.Stop();
            Console.WriteLine("elapsed ms with spinlock: {0}", sw.ElapsedMilliseconds);
        }

        static void UpdateWithLock(Data d)
        {
            lock (_lock)
            {
                _queue.Enqueue(d);
            }
        }

        private static void UseLock()
        {
            Stopwatch sw = Stopwatch.StartNew();

            Parallel.Invoke(
                    () => {
                        for (int i = 0; i < N; i++)
                        {
                            UpdateWithLock(new Data() { Name = i.ToString(), Number = i });
                        }
                    },
                    () => {
                        for (int i = 0; i < N; i++)
                        {
                            UpdateWithLock(new Data() { Name = i.ToString(), Number = i });
                        }
                    }
                );
            sw.Stop();
            Console.WriteLine("elapsed ms with lock: {0}", sw.ElapsedMilliseconds);
        }
    }
}

```


```C#
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncObjects
{
    public class SpinLockExamplePlus
    {
        const int N = 1_000_000;
        static Queue<Data> _queue = new Queue<Data>();
        static object _lock = new Object();
        static SpinLock _spinlock = new SpinLock();

        class Data
        {
            public string Name { get; set; }
            public double Number { get; set; }
        }
        public static void Show()
        {

            // First use a standard lock for comparison purposes.
            UseLock();
            _queue.Clear();
            UseSpinLock();

            //Console.WriteLine("Press a key");
            //Console.ReadKey();
        }

        

        private static void UpdateWithSpinLock(Data d)
        {
            bool lockTaken = false;
            
            try
            {
                _spinlock.Enter(ref lockTaken);
                _queue.Enqueue(d);
            }
            finally
            {
                if (lockTaken)
                {
                    //lockTaken = false;
                    _spinlock.Exit(false);
                }
            }
        }

        private static void UseSpinLock()
        {

            Stopwatch sw = Stopwatch.StartNew();

            Parallel.Invoke(
                    () => {
                        for (int i = 0; i < N; i++)
                        {
                            UpdateWithSpinLock(new Data() { Name = i.ToString(), Number = i });
                        }
                    },
                    () => {
                        for (int i = 0; i < N; i++)
                        {
                            UpdateWithSpinLock(new Data() { Name = i.ToString(), Number = i });
                        }
                    }
                );
            sw.Stop();
            Console.WriteLine("elapsed ms with spinlock: {0}", sw.ElapsedMilliseconds);
        }

        static void UpdateWithLock(Data d)
        {
            lock (_lock)
            {
                _queue.Enqueue(d);
            }
        }

        private static void UseLock()
        {
            Stopwatch sw = Stopwatch.StartNew();

            Parallel.Invoke(
                    () => {
                        for (int i = 0; i < N; i++)
                        {
                            UpdateWithLock(new Data() { Name = i.ToString(), Number = i });
                        }
                    },
                    () => {
                        for (int i = 0; i < N; i++)
                        {
                            UpdateWithLock(new Data() { Name = i.ToString(), Number = i });
                        }
                    }
                );
            sw.Stop();
            Console.WriteLine("elapsed ms with lock: {0}", sw.ElapsedMilliseconds);
        }


    }

    public static class SharedResource
    {
        public static Queue<int> intsQ = new Queue<int>();
    }
}

```


### Список материалов для изучения
1. Рихтер Дж. "CLR via C#. Программирование на платформе Microsoft.NET Framework 4.5 на языке C#"
2. Грегори Р. Эндрюс “Основы многопоточного, параллельного и распределенного программирования”
3. Стивен Клири “Конкурентность в C#. Асинхронное, параллельное программирование”
4. https://learn.microsoft.com/ru-ru/dotnet/standard/threading/the-managed-thread-pool
5. https://stackoverflow.com/questions/301160/what-are-the-differences-between-various-threading-synchronization-options-in-c
6. https://learn.microsoft.com/ru-ru/windows/win32/procthread/processes-and-threads
7. https://learn.microsoft.com/en-us/windows/win32/procthread/user-mode-scheduling
8. https://stackoverflow.com/questions/796217/what-is-the-difference-between-a-thread-and-a-fiber
9. https://www.c-sharpcorner.com/UploadFile/1d42da/threading-with-mutex/
10. https://slideplayer.com/slide/13105070/
11. https://learn.microsoft.com/en-us/windows/win32/api/winternl/ns-winternl-teb
12. https://learn.microsoft.com/en-us/windows/win32/api/winternl/ns-winternl-peb
13. https://habr.com/ru/companies/otus/articles/343566/
14. https://yonifedaeli.blogspot.com/2017/03/sync-block-index-sbi-object-header-word.html
15. https://www.c-sharpcorner.com/UploadFile/8911c4/singleton-design-pattern-in-C-Sharp/
16. https://www.c-sharpcorner.com/UploadFile/1d42da/threading-with-mutex/
17. https://www.c-sharpcorner.com/UploadFile/1d42da/readerwriterlock-class-in-C-Sharp-threading/
18. https://referencesource.microsoft.com/#mscorlib/system/threading/SpinLock.cs
19. https://stackoverflow.com/questions/2416793/why-is-lock-much-slower-than-monitor-tryenter
20. https://learn.microsoft.com/en-us/dotnet/standard/threading/how-to-use-spinlock-for-low-level-synchronization
21. How to: Enable Thread-Tracking Mode in SpinLock - .NET | Microsoft Learn
22. https://learn.microsoft.com/en-us/dotnet/api/system.threading.threadstate?view=net-8.0
23. https://stackoverflow.com/questions/17593699/tcp-ip-solving-the-c10k-with-the-thread-per-client-approach
24. https://stackoverflow.com/questions/5983779/catch-exception-that-is-thrown-in-different-thread
25. https://stackoverflow.com/questions/65661244/why-do-locks-require-instances-in-c
26. https://learn.microsoft.com/en-us/visualstudio/debugger/get-started-debugging-multithreaded-apps?view=vs-2022&tabs=csharp
27. https://habr.com/ru/articles/447898/
28. https://gitlab.com/otus-demo/multi-threading-synchronization