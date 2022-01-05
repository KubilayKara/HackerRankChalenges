using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges.Problem_Solving
{
    class DivisibleSumPairs : Chalange
    {
        public override void SetParameters()
        {
            this.url = "https://www.hackerrank.com/challenges/divisible-sum-pairs/problem?isFullScreen=true";
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter { Label = "index", DefaultValue = "5" } };
            this.ButtonText = typeof(DivisibleSumPairs).Name;
        }
        public override string Run(string[] parameters)
        {
            List<int> ar = new List<int> { 1, 3, 2, 6, 1, 2 };
            return divisibleSumPairs(ar.Count, 3, ar).ToString();
        }


        public static int divisibleSumPairs(int n, int k, List<int> ar)
        {

            int[] remainderCounts = new int[k];

            foreach (var item in ar)
            {
                int remainder = item % k;


                remainderCounts[remainder]++;
            }

            int result = ComputeResult(k, remainderCounts);

            return result;
        }

        private static int ComputeResult(int k, int[] remainderCounts)
        {
            int result = 0;
            for (int i = 0; i < remainderCounts.Length; i++)
            {

                int currentValue = remainderCounts[i];

                if (currentValue == 0)
                    continue;

                int needed = k - i;

                if (i == 0 || needed == i)
                {
                    if (currentValue >= 2)
                        result += currentValue * (currentValue - 1);
                }
                else
                {
                    result += currentValue * remainderCounts[needed];
                }

            }

            return result / 2;
        }

    }
}
