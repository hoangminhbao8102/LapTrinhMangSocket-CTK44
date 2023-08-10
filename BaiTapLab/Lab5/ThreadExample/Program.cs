using System;
using System.Threading;

namespace ThreadExample
{
    class Program
    {
        static void Main(string[] args)
        {
            MyThreadClass mtc1 = new MyThreadClass("Day la tieu trinh thu 1");
            Thread thread1 = new Thread(new ThreadStart(mtc1.RunMyThread));
            thread1.Start();
            MyThreadClass mtc2 = new MyThreadClass("Day la tieu trinh thu 2");
            Thread thread2 = new Thread(new ThreadStart(mtc2.RunMyThread));
            thread2.Start();
            Console.ReadKey();
        }
    }
}
