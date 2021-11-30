using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges.Interview_Preparation_Kit
{
    class DavisStairCase : Chalange
    {

        public override void SetParameters()
        {
            this.url = "https://www.hackerrank.com/challenges/ctci-recursive-staircase/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=recursion-backtracking";
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter { Label = "index", DefaultValue = "5" } };
            this.ButtonText = typeof(DavisStairCase).Name;
        }
        public override string Run(string[] parameters)
        {
            int index = int.Parse(parameters[0]);

            return stepPerms(index).ToString();
        }

        public static int stepPerms(int n)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            return takeStep(dic, n);

        }

        public static int takeStep(Dictionary<int, int> stepPermDic, int n)
        {
            if (stepPermDic.ContainsKey(n))
                return stepPermDic[n];

            if (n == 0)
            {                
                return 1;
            }

            int result = 0;
            if (n >= 1)
                result += takeStep(stepPermDic, n - 1);

            if (n >= 2)
                result += takeStep(stepPermDic, n - 2);


            if (n >= 3)
                result += takeStep(stepPermDic, n - 3);
            stepPermDic[n] = result;
            return result;
        }

    }
}
