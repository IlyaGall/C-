using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    internal class SingletonThreadSafetyWithoutLock
    {
        private static readonly SingletonThreadSafetyWithoutLock instance = new SingletonThreadSafetyWithoutLock();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static SingletonThreadSafetyWithoutLock()
        {
        }

        private SingletonThreadSafetyWithoutLock()
        {
        }

        public static SingletonThreadSafetyWithoutLock Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
