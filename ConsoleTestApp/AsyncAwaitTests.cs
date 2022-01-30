using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTestApp
{
    internal class AsyncAwaitTests
    {
        public void Start()
        {
            Console.WriteLine("AsyncAwaitTests Started");
            DateTime t1 = DateTime.Now;
            Job1();
            Job2();
            Job1();
            Job2();


            Console.WriteLine($"AsyncAwaitTests Ended  in { (DateTime.Now - t1).TotalMilliseconds} ms.");
        }
        public  async Task StartAsync()
        {
            Console.WriteLine("AsyncAwaitTests Async Started");
            DateTime t1 = DateTime.Now;

            Task t = Task.Run(() => Job1());
            Task t2 = Task.Run(() => Job2());
            Task t3= Task.Run(() => Job1());
            Task t4 = Task.Run(() => Job2());



            Task.WaitAll(new Task[] { t, t2,t3,t4});
            Console.WriteLine($"AsyncAwaitTests Async Ended  in { (DateTime.Now - t1).TotalMilliseconds} ms.");

        }

        public void Job1()
        {
            DateTime t1 = DateTime.Now;
            Console.WriteLine("Job1 Started");
            Thread.Sleep(2000);
            Console.WriteLine($"Job1 Ended in { (DateTime.Now - t1).TotalMilliseconds} ms.");

        }

        public void Job2()
        {
            DateTime t1 = DateTime.Now;
            Console.WriteLine("Job2 Started");

            Thread.Sleep(3000);
            Console.WriteLine($"Job2 Ended in { (DateTime.Now - t1).TotalMilliseconds} ms.");
        }

    }


}

