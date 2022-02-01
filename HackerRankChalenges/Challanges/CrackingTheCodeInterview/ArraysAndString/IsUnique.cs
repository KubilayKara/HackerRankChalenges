using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges.CrackingTheCodeInterview.ArraysAndString
{


    internal class IsUnique : Chalange
    {
        /*
          Is Unique: Implement an algorithm to determine if a string has all unique characters. 
          What if you cannot use additional data structures?
          */

        public override void SetParameters()
        {
            this.url = "";
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter { Label = "String", DefaultValue = "abcdefa" } };
            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {


            var result = IsUniqueSollution(parameters[0]);
            var result2 = IsUniqueManuelSollution(parameters[0]);
            return result.ToString();


        }

        private bool IsUniqueSollution(string v)
        {
            Dictionary<Char, int> charDict = new Dictionary<char, int>();
            foreach (char c in v)
            {

                if (charDict.ContainsKey(c))
                    return false;

                charDict[c] = 1;
            }
            return true;
        }
        private bool IsUniqueManuelSollution(string v)
        {
            bool[] charFlags = new bool[128];
            foreach (char c in v)
            {
                int charIndex = (int)c;
                if (charFlags[charIndex])
                    return false;

                charFlags[charIndex] = true;
            }
            return true;
        }
    }
}
