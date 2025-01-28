using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Otus.Teaching.Concurrency.Queue.Access;

namespace Otus.Teaching.Concurrency.Queue.Scheduler.Schedulers
{
    public class ProcessesScheduler
        : IScheduler
    {
        private const string HandlerProcessFileName = "Otus.Teaching.Concurrency.Queue.Handler.Process.exe";
        private const string HandlerProcessDirectory = @"C:\GitProjects\otus.teaching.concurrency.queue\Otus.Teaching.Concurrency.Queue.Handler.Process\publish";
        readonly List<Process> _queueHandlerProcesses = new List<Process>();

        public void ProcessQueue()
        {
            var stopWatch = new Stopwatch();
            
            Console.WriteLine("Process scheduler...");
            Console.WriteLine("Handling queue...");
            stopWatch.Start();

            _queueHandlerProcesses.Add(StartHandlerProcess(MessageQueueItemType.Email));
            _queueHandlerProcesses.Add(StartHandlerProcess(MessageQueueItemType.Sms));
            _queueHandlerProcesses.Add(StartHandlerProcess(MessageQueueItemType.Push));
            
            _queueHandlerProcesses.ForEach(x => x.WaitForExit());
            
            stopWatch.Stop();
            
            Console.WriteLine($"Handled queue in {stopWatch.Elapsed}...");
        }

        private Process StartHandlerProcess(MessageQueueItemType type)
        {
            var startInfo = new ProcessStartInfo()
            {
                ArgumentList = {type.ToString()},
                FileName = GetPathToHandlerProcess(),
            };
            
            var process = Process.Start(startInfo);

            return process;
        }

        private string GetPathToHandlerProcess()
        {
            return Path.Combine(HandlerProcessDirectory, HandlerProcessFileName);
        }
    }
}