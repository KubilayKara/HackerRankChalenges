using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges.OneWeekPrep
{
    internal class PlusMinus : Chalange
    {
        public override void SetParameters()
        {
            this.url = "https://www.hackerrank.com/challenges/one-week-preparation-kit-plus-minus/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=preparation-kits&playlist_slugs%5B%5D=one-week-preparation-kit&playlist_slugs%5B%5D=one-week-day-one";
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter() };
            this.ButtonText = typeof(PlusMinus).Name;
        }
        public override string Run(string[] parameters)
        {
            List<int> ar = new List<int> { -4, 3, -9, 0, 4, 1 };
            return plusMinus(ar).ToString();
        }
        public static string plusMinus(List<int> arr)
        {
            int positiveCount = 0, negativeCount = 0, zeroCount = 0;


            foreach (int i in arr)
            {
                if (i > 0)
                {
                    positiveCount++;
                }
                else if (i < 0)
                {
                    negativeCount++;
                }
                else
                {
                    zeroCount++;
                }
            }



            double totalCount = arr.Count;

            string result = $"{(positiveCount / totalCount):F6}" +
                $"\n{(negativeCount / totalCount):F6}" +
                $"\n{(zeroCount / totalCount):F6}";
            return result;

        }
    }


}
