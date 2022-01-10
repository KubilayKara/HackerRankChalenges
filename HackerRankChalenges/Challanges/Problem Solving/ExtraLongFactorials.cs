using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges.Problem_Solving
{
    class ExtraLongFactorials : Chalange
    {
        public override void SetParameters()
        {
            this.url = "https://www.hackerrank.com/challenges/extra-long-factorials/problem?isFullScreen=true";
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter { Label = "N", DefaultValue = "5" } };

            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {

            Trace.WriteLine($"RUN: {this.GetType().Name}");
            int n = int.Parse(parameters[0]);
            //extraLongFactorials(n);
            return CalculateFactorialsUseBigInt(n).ToString();
        }

        public static void extraLongFactorials(int n)
        {
            Trace.WriteLine(CalculateFactorialsUseBigInt(n));
        }

        public static string CalculateFactorials(int n)
        {
            ulong result = 1;

            uint number = (uint)n;
            int zerocount = 0;
            for (uint i = number; i > 1; i--)
            {
                ulong newResult = result * i;
                string newResultStr = newResult.ToString();
                while (newResultStr.Last() == '0')
                {
                    zerocount++;
                    newResultStr = newResultStr.Substring(0, newResultStr.Length - 1);
                    newResult = ulong.Parse(newResultStr);
                }

                result = newResult;
            }

            string zeros = string.Empty;
            for (int i = 0; i < zerocount; i++)
            {
                zeros += "0";
            }
            return $"{result}{zeros}";
        }

        public static string CalculateFactorialsUseBigInt(int n)
        {
            BigInteger result = 1;

            uint number = (uint)n;
            for (uint i = number; i > 1; i--)
            {
               
                result = result*i;
            }


            return result.ToString();
        }
    }
}
