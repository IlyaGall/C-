using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    /// <summary>
    /// Bad example never use it realcode
    /// </summary>
    internal class SingletonBad
    {
        public sealed class Singleton
        {
            private static Singleton instance = null;

            private Singleton()
            {
            }

            public static Singleton Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }
    }
}
