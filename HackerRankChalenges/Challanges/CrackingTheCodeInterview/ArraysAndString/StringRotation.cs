using System.Collections.Generic;

namespace HackerRankChalenges.Challanges.CrackingTheCodeInterview.ArraysAndString
{
    internal class StringRotation : Chalange
    {
        /*
            String Rotation:Assumeyou have a method isSubstringwhich checks if one word is a substring
            of another.Given two strings, sl and s2, write code to check if s2 is a rotation of sl using only one
            call to isSubstring(e.g., "waterbottle" is a rotation of"erbottlewat").

        waterbottlewaterbottle
          */

        public override void SetParameters()
        {
            this.url = "";
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter("s1", "waterbottle"), new ChalengeParameter("s2", "erbottlewat") };
            base.SetParameters();

        }
        public override string Run(string[] parameters)
        {



            var result = StringRotation_solution(parameters[0], parameters[1]);

            return result.ToString();

        }

        private bool StringRotation_solution(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            return (s1 + s1).Contains(s2);
        }
    }
}

