using System;
using System.IO;

namespace ConsoleTestApp
{
    internal class Program
    {
        public delegate int IncraseDelegate(int i);
        static void Main(string[] args)
        {
            //AsyncAwaitTests t = new AsyncAwaitTests();
            //t.Start();
            //t.StartAsync().GetAwaiter().GetResult();

            string s = "deneme";
            string s2 = string.Copy(s);

            IncraseDelegate d = delegate (int i)
            {
                return i + 1;
            };
            int result = d.Invoke(5);

            Console.ReadLine();

            //File f = new File();

            (int a, string b) = DoSomething();
            Console.WriteLine($"{a}-{b}");
        }


        public static (int age, string name) DoSomething()
        {
            (int age, string name) t = (15, "haydar");

            return (t);
            //return (5, "hamze");
        }
        public static void DoSomething(out int age, out string name)
        {
            //(int age, string name) t = (15, "haydar");
            age = 5;
            name = "haydar";
            return ;
            //return (5, "hamze");
        }
    }

    struct Point
    {
        public int X;
        public int Y { get; set; }
    }

    class Processor<T>
    { }
    class Printer
    {
        public virtual void Install()
        {
            Console.WriteLine("Printer Install");
        }
    }

    class LaserPrinter : Printer
    {
        public void Install()
        {
            Console.WriteLine("Laser Printer Install");

        }
    }

    interface IBelivable
    {

        void Belive();
    }

    struct OhMyGod : IBelivable
    {
        public void Belive()
        {
            throw new NotImplementedException();
        }



    }
}

