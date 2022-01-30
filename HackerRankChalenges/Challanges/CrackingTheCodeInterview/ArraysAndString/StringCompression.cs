using System.Collections.Generic;
using System.Text;

namespace HackerRankChalenges.Challanges.CrackingTheCodeInterview.ArraysAndString
{
    internal class StringCompression : Chalange
    {
        /*
            String Compression: Implement a method to perform basic string compression using the counts
            of repeated characters. For example, the string aabcccccaaa would become a2blc5a3. If the
            "compressed" string would not become smaller than the original string, your method should return
            the original string. You can assume the string has only uppercase and lowercase letters (a - z).
          */

        public override void SetParameters()
        {
            this.url = "";
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter { Label = "String 1", DefaultValue = "aabcccccaaa" } };
            base.SetParameters();

        }
        public override string Run(string[] parameters)
        {
            //is case sensitive?
            var result = StringCompression_solution(parameters[0]);

            return result.ToString();

        }

        private string StringCompression_solution(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            StringBuilder resultStringBuilder = new StringBuilder();
            char currentChar = s[0];
            int currentCount = 1;
            for (int i = 1; i < s.Length; i++)
            {
                char c = s[i];
                if (currentChar != c)
                {
                    resultStringBuilder.Append($"{currentChar}{currentCount}");
                    currentChar = c;
                    currentCount = 1;
                }
                else
                {
                    currentCount++;
                }
            }
            resultStringBuilder.Append($"{currentChar}{currentCount}");

            string result = resultStringBuilder.ToString();

            return result.Length < s.Length ? result : s;
        }




    }
}
