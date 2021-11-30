using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges.Interview_Preparation_Kit
{
    public class FibonacciNumbers : Chalange
    {
        public override string Run(string[] parameters)
        {
            int index = int.Parse(parameters[0]);

            return Fibonacci(index).ToString();
        }

        //public static int Fibonacci(int n)
        //{
        //    if (n == 0)
        //        return 0;
        //    if (n == 1)
        //        return 1;
        //    int fib = 0;
        //    int fibb = 1;

        //    for (int i = 2; i < n; i++)
        //    {
        //        int cur = fib + fibb;
        //        fib = fibb;
        //        fibb = cur;
        //    }
        //    return fib + fibb;
        //    // Write your code here.

        //}

   

        private static Dictionary<int, int> knowNumber = new Dictionary<int, int>();
        static FibonacciNumbers()
        {
            knowNumber[0] = 0;
            knowNumber[1] = 1;
            knowNumber[2] = 1;
            knowNumber[3] = 2;
            knowNumber[4] = 3;
            knowNumber[5] = 5;
            knowNumber[6] = 8;
        }
        public static int Fibonacci(int n)
        {
            if (knowNumber.ContainsKey(n))
                return knowNumber[n];
            int result = Fibonacci(n - 2) + Fibonacci(n - 1);
            knowNumber[n] = result;
            return result;


        }

        public override void SetParameters()
        {
            this.url = "https://www.hackerrank.com/challenges/ctci-fibonacci-numbers/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=recursion-backtracking";
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter { Label = "index", DefaultValue = "5" } };
            this.ButtonText = typeof(FibonacciNumbers).Name;
        }
    }
}
