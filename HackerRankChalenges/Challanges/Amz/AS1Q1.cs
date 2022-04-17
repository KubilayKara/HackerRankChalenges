using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges.Amazon
{
    internal class AS1Q1 : Chalange
    {
        public override void SetParameters()
        {
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter("List", "2 9 10 3 7 ") };

            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {
            int[] l = Utility.StringToIntagerList(parameters[0], ' ').ToArray();

            var r1 = getHeaviestPackage(l);
            var r2 = getHeaviestPackage2(l);

            return $"r1={r1} r2={r2}";
        }

        private static int getHeaviestPackage(int[] weights)
        {
            int[] dp = new int[weights.Length];
            dp[0] = weights[0];
            int max = weights[0];
            for (int i = 1; i < weights.Length; i++)
            {
                if (weights[i] > weights[i - 1])
                {
                    int s = Math.Max(weights[i] + dp[i - 1], weights[i]);
                    dp[i] = s;
                    max = Math.Max(max, s);
                }
                else
                {
                    dp[i] = weights[i];
                }
            }
            return max;
        }

        private static int getHeaviestPackage2(int[] weights)
        {
            int size = weights.Length;
            int currWt = weights[size - 1];
            int heaviestPackage = currWt;
            for (int i = size - 1; i >= 1; i--)
            {
                if (currWt > weights[i - 1])
                {
                    currWt = currWt + weights[i - 1];
                }
                else
                {
                    currWt = weights[i - 1];
                }
                heaviestPackage = Math.Max(heaviestPackage, currWt);
            }

            return heaviestPackage;
        }

        long GetMaxFragDeviation(string s)
        {
            long res = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i = 0; j < s.Length; j = i++)
                {
                    var cur = GetMaxFragDeviationSub(s.Substring(i, j));
                    if (cur > res)
                        res = cur;
                }
            }
            return res;
        }

        long GetMaxFragDeviationSub(string str)
        {
            long min = 0;
            long max = 0;
            var l = new Dictionary<char, int>();
            foreach (var c in str)
            {
                if (!l.ContainsKey(c))
                    l.Add(c, 0);
                l[c]++;
                int cur = l[c];

                if (min > cur)
                    min = cur;
                if (max < cur)
                    max = cur;

            }
            return max - min;
        }
    }

}
