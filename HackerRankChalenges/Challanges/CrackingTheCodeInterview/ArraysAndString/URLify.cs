using System.Collections.Generic;
using System.Text;

namespace HackerRankChalenges.Challanges.CrackingTheCodeInterview.ArraysAndString
{
    internal class URLify : Chalange
    {
        /*
               
            URLify: Write a method to replace all spaces in a string with '%20'. You may assume that the string
        has sufficient space at the end to hold the additional characters, and that you are given the "true"
        length of the string. (Note: If implementing in Java, please use a character array so that you can
        perform this operation in place.)
        EXAMPLE
        Input: "Mr John Smith ", 13
        Output: "Mr%20John%20Smith"   

          */

        public override void SetParameters()
        {
            this.url = "";
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter { Label = "String", DefaultValue = "Mr John Smith " },
             new ChalengeParameter { Label = "CharCount", DefaultValue = "13" }};
            base.SetParameters();

        }
        public override string Run(string[] parameters)
        {
            int charCount = int.Parse(parameters[1]);
            var result = URLify_solution(parameters[0], charCount);
            return result.ToString();


        }

        private string URLify_solution(string s, int charCount)
        {
            //what should return multiple consecutive empty spaces?
            //should trim the string?
            s = s.Trim();

            //we should use string builder
            StringBuilder stringBuilder = new StringBuilder();
            int startIndex = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    if (startIndex != i)
                    {
                        stringBuilder.Append(s.Substring(startIndex, i - startIndex));
                        stringBuilder.Append("%20");
                    }
                    startIndex = i + 1;
                }
            }
            stringBuilder.Append(s.Substring(startIndex, s.Length - startIndex));

            return stringBuilder.ToString();

        }


    }
}
