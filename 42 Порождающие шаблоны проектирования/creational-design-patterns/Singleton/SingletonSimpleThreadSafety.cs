namespace Singleton
{
    internal class SingletonSimpleThreadSafety
    {
        private static SingletonSimpleThreadSafety instance = null;
        private static readonly object padlock = new object();

        SingletonSimpleThreadSafety()
        {
        }

        public static SingletonSimpleThreadSafety Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SingletonSimpleThreadSafety();
                    }
                    return instance;
                }
            }
        }

    }
}
