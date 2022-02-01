using System.Collections.Generic;

namespace HackerRankChalenges.Challanges.CrackingTheCodeInterview.ArraysAndString
{
    internal class PalindromePermutation : Chalange
    {
        /*
               Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palindrome.
                A palindrome is a word or phrase that is the same forwards and backwards. A permutation
                is a rearrangement of letters. The palindrome does not need to be limited to just dictionary words.
               
                EXAMPLE
                Input: Tact Coa
                Output: True (permutations: "taco cat", "atco eta", etc.)
     
          */

        public override void SetParameters()
        {
            this.url = "";
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter { Label = "String", DefaultValue = "Tact Coa " } };
            base.SetParameters();

        }
        public override string Run(string[] parameters)
        {

            //is case sensitive?
            var result = PalindromePermutation_solution(parameters[0]);
            return result.ToString();


        }

        private bool PalindromePermutation_solution(string s)
        {
            //empth spaces are not important
            Dictionary<char, bool> charDict = new Dictionary<char, bool>();

            //bool[] 

            foreach (var c in s)
            {
                if (c == ' ')
                    continue;

                if (!charDict.ContainsKey(c))
                    charDict[c] = true;
                else
                    charDict.Remove(c);
            }

            return charDict.Count <= 1; ;

        }


    }
}
