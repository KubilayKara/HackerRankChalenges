using System;
using System.Collections.Generic;

namespace HackerRankChalenges.Challanges.Amazon
{
    internal class AS2Q2 : Chalange
    {
        public override void SetParameters()
        {
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter("list", "2,0,1") };

            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {

            var list = Utility.StringToIntagerList(parameters[0]);

            return getMexCount(list).ToString();
        }


        public static List<long> getMexCount(List<int> arr)
        {
            //for
            long[] result = new long[arr.Count + 1];
            for (int i = 0; i < arr.Count; i++)
            {


                if (arr[i] > 0)
                    result[0]++;
                else
                    result[1]++;

                bool[] tmp = new bool[arr.Count];
                tmp[arr[i]] = true;

                for (int j = 1; i + j < arr.Count; j++)
                {
                    int curr = arr[i + j];
                    tmp[curr] = true;
                    bool found = false;
                    for (int t = 0; t < tmp.Length; t++)
                    {
                        if (!tmp[t])
                        {
                            result[t]++;
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                        result[result.Length - 1]++;
                }
            }
            return new List<long>(result);

        }

        /* 4, 0, 2, 1, 3
        4
        4, 0
        4, 0, 2
        4, 0, 2, 1
        4, 0, 2, 1, 3
        0
        0, 2,
        0, 2, 1
        0, 2, 1, 3
        */
        private static int GetMex(List<int> arr)
        {
            int cur = 0;
            while (true)
            {
                if (!arr.Contains(cur))
                    return cur;
                cur++;
            }

        }

        //static void maxMEX(int[] arr, int N, int K)
        //{
        //    // Stores element from
        //    // 1 to N + 1 is nor
        //    // present in subarray
        //    HashSet<int> s = new HashSet<int>();

        //    // Store number 1 to
        //    // N + 1 in set s
        //    for (int i = 1; i <= N + 1; i++)
        //        s.Add(i);

        //    // Find the MEX of K length
        //    // subarray starting from index 0
        //    for (int i = 0; i < K; i++)
        //        s.Remove(arr[i]);

        //    List<int> v = new List<int>();
        //    foreach (int i in s) { v.Add(i); }
        //    int mex = v[0];

        //    // Find the MEX of all subarray of
        //    // length K by erasing arr[i]
        //    // and inserting arr[i-K]
        //    for (int i = K; i < N; i++)
        //    {
        //        v.Remove(arr[i]);
        //        v.Add(arr[i - K]);

        //        // Store first element
        //        // of set
        //        int firstElem = v[0];

        //        // Updating mex
        //        mex = Math.Max(mex, firstElem);
        //    }

        //    // Print maximum MEX of all K
        //    // length subarray
        //    Console.Write(mex - 2 + " ");
        //}

        //// Driver Code
        //public static void Main(String[] args)
        //{
        //    // Given array
        //    int[] arr = { 3, 2, 1, 4 };

        //    // Given length of subarray
        //    int K = 2;

        //    // Size of the array
        //    int N = arr.Length;

        //    // Function Call
        //    maxMEX(arr, N, K);
        //}

    }
}
