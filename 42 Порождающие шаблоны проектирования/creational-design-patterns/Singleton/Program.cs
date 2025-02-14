using System;
using System.Threading;

namespace Singleton
{ 

    class Program
    {
        static void Main(string[] args)
        {
            //var i = MyClass.Value;
            //var j = MyClass.Value;

            // Клиентский код.
            ShowDoubleCheckLockingSingletonExample();


        }

        public static void ShowDoubleCheckLockingSingletonExample() 
        {
            Console.WriteLine(
                "{0}\n{1}\n\n{2}\n",
                "If you see the same value, then singleton was reused (yay!)",
                "If you see different values, then 2 singletons were created (booo!!)",
                "RESULT:"
            );

            Thread process1 = new Thread(() =>
            {
                TestDoubleCheckLockingSingleton("FOO");
            });
            Thread process2 = new Thread(() =>
            {
                TestDoubleCheckLockingSingleton("BAR");
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();

        }

        public static void TestDoubleCheckLockingSingleton(string value)
        {
            DoubleCheckLockingSingleton singleton = DoubleCheckLockingSingleton.GetInstance(value);
            Console.WriteLine(singleton.Value);
        }
    }
}
