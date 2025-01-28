using System.Threading;
using System.Threading.Tasks;
using Otus.Teaching.Concurrency.Queue.Access;

namespace Otus.Teaching.Concurrency.Queue.Scheduler.Schedulers
{
    public class ThreadPoolSchedulerItem
    {
        public MessageQueueItemType Type { get; private set; }

        public WaitHandle WaitHandle { get; private set; }

        public ThreadPoolSchedulerItem(MessageQueueItemType type)
        {
            Type = type;
            WaitHandle = new AutoResetEvent(false);
        }
    }
}