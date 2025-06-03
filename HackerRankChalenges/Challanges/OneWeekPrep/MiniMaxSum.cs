using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges.OneWeekPrep
{
    public class MiniMaxSum : Chalange
    {
        public override void SetParameters()
        {
            this.url = "https://www.hackerrank.com/challenges/one-week-preparation-kit-mini-max-sum/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=preparation-kits&playlist_slugs%5B%5D=one-week-preparation-kit&playlist_slugs%5B%5D=one-week-day-one";
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter() };
            this.ButtonText = typeof(MiniMaxSum).Name;
        }

        // Implementing the abstract method 'Run' from the base class 'Chalange'
        public override string Run(string[] parameters)
        {
            List<int> ar = new List<int> { -4, 3, -9, 0, 4, 1 };
            return miniMaxSumCalculate(ar).ToString();
        }


        public static void miniMaxSum(List<int> arr)
        {
            var (minSum, maxSum) = miniMaxSumCalculate(arr);
            Console.WriteLine($"{minSum} {maxSum}");
        }
        public static (long minSum, long maxSum) miniMaxSumCalculate(List<int> arr)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            long totalSum = 0;  

            foreach (int num in arr)
            {
                totalSum += num;
                if (num < min) min = num;
                if (num > max) max = num;
            }

            return (totalSum - max, totalSum - min);
        }
    }
}
