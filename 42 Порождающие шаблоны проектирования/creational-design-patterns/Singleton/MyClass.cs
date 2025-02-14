using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class MyClass
    {
        static MyClass()
        {
            Console.WriteLine("Static constructor called.");
        }

        public static int Value = 42;
    }
}
