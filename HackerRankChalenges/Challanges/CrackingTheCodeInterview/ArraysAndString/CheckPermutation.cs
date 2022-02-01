using System.Collections.Generic;

namespace HackerRankChalenges.Challanges.CrackingTheCodeInterview.ArraysAndString
{
    internal class CheckPermutation : Chalange
    {
        /*
           Check Permutation: Given two strings, write a method to decide if one is a permutation of the other.
          */

        public override void SetParameters()
        {
            this.url = "";
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter { Label = "String 1", DefaultValue = "abcdefa" },
                                                                    new ChalengeParameter { Label = "String 2", DefaultValue = "abc" } };
            this.ButtonText = typeof(CheckPermutation).Name;
        }
        public override string Run(string[] parameters)
        {


            var result = IsPermutation_2(parameters[0], parameters[1]);
            return result.ToString();


        }

        private bool IsPermutation(string s1, string s2)
        {

            /* o(n^2)
             * Soruyu yanlış anlamışsın...
             */
            if (s1.Length > s2.Length)
            {
                string tmp = s1;
                s1 = s2;
                s2 = tmp;
            }
            foreach (char c1 in s1)
            {
                bool found = false;
                for (int i = 0; i < s2.Length; i++)
                {
                    char c2 = s2[i];
                    if (c1 == c2)
                    {
                        s2 = s2.Remove(i, 1);
                        found = true;
                        break;
                    }
                }
                if (!found)
                    return false;
            }
            return true;
        }

        private bool IsPermutation_2(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            Dictionary<char, int> charDic = new Dictionary<char, int>();

            for (int i = 0; i < s1.Length; i++)
            {
                char c1 = s1[i];
                if (!charDic.ContainsKey(c1))
                    charDic[c1] = 0;
                charDic[c1]++;
            }
            for (int i = 0; i < s2.Length; i++)
            {
                char c2 = s2[i];
                if (!charDic.ContainsKey(c2) || charDic[c2] == 0)
                    return false;
                charDic[c2]--;
            }
            return true;
        }
        private bool IsPermutation_3(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            Dictionary<char, int> charDic = new Dictionary<char, int>();

            for (int i = 0; i < s1.Length; i++)
            {
                char c1 = s1[i];
                if (!charDic.ContainsKey(c1))
                    charDic[c1] = 0;
                charDic[c1]++;

                char c2 = s2[i];
                if (!charDic.ContainsKey(c1))
                    charDic[c2] = 0;
                charDic[c2]--;
            }

            
            foreach (var item in charDic)
            {
                if (item.Value != 0)
                    return false;
            }
            return true;
        }
    }
}
