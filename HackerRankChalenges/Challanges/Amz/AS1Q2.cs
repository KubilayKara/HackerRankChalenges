using System.Collections.Generic;

namespace HackerRankChalenges.Challanges.Amazon
{
    internal class AS1Q2 : Chalange
    {
        public override void SetParameters()
        {
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter("string", "bbacccabab") };

            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {
            var r1 = GetMaxFragDeviation(parameters[0]);

            return $"r1={r1}";
        }



        long GetMaxFragDeviation(string s)
        {
            long res = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; i + j <= s.Length; j++)
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
            if (string.IsNullOrEmpty(str))
                return 0;

            var l = new Dictionary<char, int>();
            foreach (var c in str)
            {
                if (!l.ContainsKey(c))
                    l.Add(c, 0);
                l[c]++;
                int cur = l[c];
            }

            long? min = null;
            long max = 0;
            foreach (var item in l)
            {
                if (min == null || min > item.Value)
                    min = item.Value;

                if (max < item.Value)
                    max = item.Value;
            }
            var res = max - min.Value;
            return max - min.Value;
        }

    }
}