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
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter { Label = "N", DefaultValue = "4" },          
            new ChalengeParameter { Label = "A", DefaultValue = "1,2,4,4,3" },
            new ChalengeParameter { Label = "B", DefaultValue = "2,3,1,3,1" }};
            this.ButtonText = typeof(Siemens).Name;
        }
        public override string Run(string[] parameters)
        {

            int N = int.Parse(parameters[0]);
            int[] A = Utility.StringToIntagerList(parameters[1]).ToArray();
            int[] B = Utility.StringToIntagerList(parameters[2]).ToArray();

            var r = solution(N, A, B);
            return r.ToString();

        }


        public bool solution(int N, int[] A, int[] B)
        {
            // write your code in Java SE 8


            Dictionary<int, Dictionary<int, bool>> dic = new Dictionary<int, Dictionary<int, bool>>();
            for (int i = 0; i < A.Length; i++)
            {
                var a = A[i];
                var b = B[i];

                if (!dic.ContainsKey(a))
                    dic[a] = new Dictionary<int, bool>();

                var result = dic[a];
                   result [b] = true;

                if (!dic.ContainsKey(b))
                    dic[b] = new Dictionary<int, bool>();

                dic[b][a] = true;
            }

            for (int i = 1; i < N; i++)
            {
                if (!IsReachable(dic, i, i + 1))
                    return false;
            }
            return true;
        }


        private bool IsReachable(Dictionary<int, Dictionary<int, bool>> dic, int source, int target)
        {
            return dic.ContainsKey(source) && dic[source].ContainsKey(target);
        }
        // This code is contributed by Aakash Hasija

        #region Session1
        //public bool Session1solution11(int[] A, int K)
        //{
        //    int n = A.Length;
        //    for (int i = 0; i < n - 1; i++)
        //    {
        //        if (A[i] + 1 < A[i + 1])
        //            return false;
        //    }
        //    if (A[0] != 1 || A[n - 1] != K)
        //        return false;
        //    else
        //        return true;
        //}
        ////public int solution2(string S)
        ////{
        ////    // write your code in C# 6.0 with .NET 4.5 (Mono)

        ////    if (S.Last() == '1')//odd
        ////    {
        ////        //1 çıakr
        ////        return S.Substring(0, S.Length - 1) + "0";
        ////    }
        ////    else//even
        ////    { }


        ////}

        //public int Session1Solution_2(string s)
        //{
        //    //1111111111111111111111111= 1111111111111111111111110
        //    //1111111111111111111111110

        //    //1010 => 10
        //    //0010 =>2
        //    //101





        //    int stepCount = 0;
        //    while (s.Contains("1"))
        //    {
        //        stepCount += 1;
        //        if (s[s.Length - 1] == '1')//odd
        //        {
        //            //1 cıkar 00000
        //            s = s.Remove(s.Length - 1) + "0";

        //        }
        //        else//even
        //        {
        //            s = s.Remove(s.Length - 1);
        //        }
        //    }
        //    return stepCount;
        //}

        //public int Session1Solution2_1(string s)
        //{
        //    s = s.TrimStart('0');
        //    int countOfOnes = 0;
        //    foreach (var item in s)
        //    {
        //        if (item == '1')
        //            countOfOnes++;
        //    }

        //    if (countOfOnes == 0)
        //        return 0;
        //    else
        //    {
        //        return countOfOnes * 2 + (s.Length - countOfOnes - 1);
        //    }
        //}

        //public static int Session1Solution_3(String s)
        //{
        //    int total = 0, count = 0;
        //    for (int i = 0; i < s.Length; ++i)
        //    {
        //        total += s[i] - 48;
        //    }
        //    if (total % 3 == 0)
        //        ++count;
        //    //for (int i = 0; i < s.Length; ++i)
        //    //{

        //    //    int remTot = total - (s[i] - 48);

        //    //    for (int k = 0; k <= 9; ++k)
        //    //    {
        //    //        if ((remTot + k) % 3 == 0
        //    //                && k != s[i] - 48)
        //    //        {
        //    //            ++count;
        //    //        }
        //    //    }
        //    //}
        //    for (int i = 0; i < s.Length; ++i)
        //    {
        //        int cur = s[i] - 48;
        //        int remTot = total - cur;

        //        switch (remTot % 3)
        //        {
        //            case 0:
        //                count += (cur % 3 == 0) ? 3 : 4;
        //                break;
        //            case 1:
        //                count += (cur % 3 == 2) ? 2 : 3;
        //                break;
        //            case 2:
        //                count += (cur % 3 == 1) ? 2 : 3;
        //                break;
        //        }

        //    }
        //    return count;
        //}

        #endregion
    }


}


