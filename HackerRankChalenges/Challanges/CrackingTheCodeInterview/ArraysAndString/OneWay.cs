using System;
using System.Collections.Generic;

namespace HackerRankChalenges.Challanges.CrackingTheCodeInterview.ArraysAndString
{
    internal class OneWay : Chalange
    {
        /*
            One Away: There are three types of edits that can be performed on strings: insert a character,
            remove a character, or replace a character. Given two strings, write a function to check if they are
            one edit (or zero edits) away.
            EXAMPLE
            pale, ple -> true
            pales, pale -> true
            pale, bale -> true
            pale, bae -> false
     
          */

        public override void SetParameters()
        {
            this.url = "";
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter { Label = "String 1", DefaultValue = "abcd" },
            new ChalengeParameter { Label = "String 2", DefaultValue = "acd" }};
            base.SetParameters();

        }
        public override string Run(string[] parameters)
        {
            //is case sensitive?
            var result = OneWay_solution(parameters[0], parameters[1]);

            return result.ToString();
        }

        private bool OneWay_solution(string s1, string s2)
        {
            if (Math.Abs(s1.Length - s2.Length) > 1)
                return false;

            string shortStr = s1;
            string longStr = s2;
            if (shortStr.Length > longStr.Length)
            {
                shortStr = s2;
                longStr = s1;
            }

            bool differenceOccured = false;
            for (int i = 0; i < shortStr.Length; i++)
            {
                bool same;
                if (longStr.Length != shortStr.Length)
                {
                    if (differenceOccured)
                        same = shortStr[i] == longStr[i + 1];
                    else
                    {
                        same = shortStr[i] == longStr[i];
                        if (!same && shortStr[i] != longStr[i + 1])
                            return false;
                    }

                }
                else
                    same = shortStr[i] == longStr[i];

                if (same)
                    continue;
                if (differenceOccured)
                    return false;
                differenceOccured = true;
            }
            return true;
        }




    }
}
