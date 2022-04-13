using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges.LeetCode75.Binary
{
    internal class LeetSumOfTwoIntagers : Chalange
    {
        public override void SetParameters()
        {
            this.url = "https://leetcode.com/problems/sum-of-two-integers/";
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter { Label = "A", DefaultValue = "2" },
            new ChalengeParameter{Label="B", DefaultValue="3" } };
            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {
            int a = int.Parse(parameters[0]);
            int b = int.Parse(parameters[1]);

            return GetSum(a, b).ToString();
        }

        public int GetSum(int a, int b)
        {
            string strA = System.Convert.ToString(a, 2);
            string strB = System.Convert.ToString(b, 2);
            int length = (strA.Length > strB.Length) ? strA.Length : strB.Length;

            string result = string.Empty;
            bool cariage = false;
            for (int i = 0; i < length; i++)
            {
                bool bA = GetBitEndStr(strA, i);
                bool bB = GetBitEndStr(strB, i);

                string current;
                if (bA && bB)
                {
                    current = cariage ? "1" : "0";
                    cariage = true;
                }
                else if (bA || bB)
                {
                    if (cariage)
                    {
                        current = "0";
                        cariage = true;
                    }
                    else
                    {
                        current = "1";
                        cariage = false;
                    }
                }
                else
                {
                    current = cariage ? "1" : "0";
                    cariage = false;
                }

                result = current + result;

            }
            if (cariage)
                result = "1" + result;
            if (result.Length > 32)
                result = result.Substring(result.Length - 32);

            return Convert.ToInt32(result, 2);

        }

        private bool GetBitEndStr(string s, int index)
        {
            if (index > s.Length-1)
                return false;

            return s.Substring(s.Length - index - 1, 1) == "1";
        }
    }
}
