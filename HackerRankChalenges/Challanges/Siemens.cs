using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges
{
    public partial class Siemens : Chalange
    {
        public override void SetParameters()
        {
            this.url = "";
            this.ChalangeParameters = new List<ChalengeParameter>();
            this.ButtonText = typeof(Siemens).Name;
        }
        public override string Run(string[] parameters)
        {

            int[] test_ = new int[] { 0, 1, 2, 3, 3 };
            int[] test = new int[] { 1, 2, 3, 3, 4 };
            var result = solution(test, 4);



            var result_2 = solution2_Edip("011100");
            var result_2_1 = solution_2("");

            string manyOnes = string.Empty;
            for (int i = 0; i < 400000; i++)
            {
                manyOnes += "1";
            }
            var result_2_2 = solution_2(manyOnes);


            return result.ToString();

        }

        public bool solution(int[] A, int K)
        {
            int n = A.Length;
            for (int i = 0; i < n - 1; i++)
            {
                if (A[i] + 1 < A[i + 1])
                    return false;
            }
            if (A[0] != 1 || A[n - 1] != K)
                return false;
            else
                return true;
        }
        //public int solution2(string S)
        //{
        //    // write your code in C# 6.0 with .NET 4.5 (Mono)

        //    if (S.Last() == '1')//odd
        //    {
        //        //1 çıakr
        //        return S.Substring(0, S.Length - 1) + "0";
        //    }
        //    else//even
        //    { }


        //}

        public int solution_2(string s)
        {
            //1111111111111111111111111= 1111111111111111111111110
            //1111111111111111111111110

            //1010 => 10
            //0010 =>2
            //101





            int stepCount = 0;
            while (s.Contains("1"))
            {
                stepCount += 1;
                if (s[s.Length - 1] == '1')//odd
                {
                    //1 cıkar 00000
                    s = s.Remove(s.Length - 1) + "0";

                }
                else//even
                {
                    s = s.Remove(s.Length - 1);
                }
            }
            return stepCount;
        }



        public int solution2_Edip(string s)
        {
            s = s.TrimStart('0');
            int countOfOnes = 0;
            foreach (var item in s)
            {
                if (item == '1')
                    countOfOnes++;
            }

            if (countOfOnes == 0)
                return 0;
            else
            {
                return countOfOnes * 2 + (s.Length - countOfOnes - 1);
            }
        }




        public static int solution_3(String s)
        {
            int total = 0, count = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                total += s[i] - 48;
            }
            if (total % 3 == 0) ++count;
            for (int i = 0; i < s.Length; ++i)
            {
                int remTot = total - (s[i] - 48);

                for (int k = 0; k <= 9; ++k)
                {
                    if ((remTot + k) % 3 == 0
                            && k != s[i] - 48)
                    {
                        ++count;
                    }
                }
            }
            return count;
        }

    }
}

