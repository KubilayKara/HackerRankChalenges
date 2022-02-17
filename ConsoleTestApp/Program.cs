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

            //string s = "deneme";
            //string s2 = string.Copy(s);

            //IncraseDelegate d = delegate (int i)
            //{
            //    return i + 1;
            //};
            //int result = d.Invoke(5);
            //var m = new Class { Name = "Math" };
            //Student s1 = new Student("Ahmet", 1, m);
            //Student s2 = new Student("Ahmet", 1, new Class { Name = "Math" });
            //Student s3 = new Student("Ahmet", 1, m);

            //// s1.Name = "haydar";

            //var r1 = s1 == s2;
            //var r2 = s1.Equals(s2);

            //Student s4 = s2 with { Number = 4 };


            ClassB  B=new ClassB();
            B.DoSomething();

            InterfaceA A = new ClassB();
            A.DoSomething();
            
            InterfaceB interfaceB = new ClassB();
            interfaceB.DoSomething();

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
            return;
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

    public record Student(string Name, int Number, Class Class)
    {


    }

    public record MathStudent(string Name, Class Class) : Student(Name, 6, Class);
    public class Class
    {
        public string Name { get; set; }
    }


    public abstract class ClassA
    {
        public abstract void DoSomething();
    }

    public class ClassB :  InterfaceA, InterfaceB
    {
        public  void DoSomething()
        {
            Console.WriteLine("ClassB");
        }

        void InterfaceA.DoSomething()
        {
            Console.WriteLine("InterfaceA");
        }

        void InterfaceA.DoSomething2()
        {
            Console.WriteLine("InterfaceA");

        }

        void InterfaceB.DoSomething()
        {
            Console.WriteLine("InterfaceB");

        }
    }

    interface InterfaceA
    {
        public void DoSomething();
        public void DoSomething2();
    }
    interface InterfaceB
    {
        public void DoSomething();
    }
}

