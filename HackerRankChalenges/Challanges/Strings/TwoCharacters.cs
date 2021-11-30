using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges.Strings
{
    public class TwoCharacters : Chalange
    {
        public override void SetParameters()
        {
            this.url = "https://www.hackerrank.com/challenges/two-characters/problem";
            this.ButtonText = typeof(TwoCharacters).Name;
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter { Label = "string", DefaultValue = "beabeefeab" } };
        }
        public override string Run(string[] prms)
        {
            return alternate(prms[0]).ToString();
        }


        public static int alternate(string s)
        {
            Dictionary<char, LetterCombination> letterDictionary = new Dictionary<char, LetterCombination>();

            foreach (var currentLetter in s)
            {
                if (!letterDictionary.ContainsKey(currentLetter))
                {
                    letterDictionary[currentLetter] = new LetterCombination();
                }
                if (!letterDictionary[currentLetter].IsStillValid())
                    continue;
                foreach (var l in letterDictionary)
                {
                    if (l.Key == currentLetter)
                        l.Value.Increment();
                    else
                        l.Value.LetterOccured(currentLetter);
                }
            }
            int max = 0;
            foreach (var item in letterDictionary)
            {
                foreach (var validLetterCombination in item.Value.ValidLetters)
                {
                    //checked if this letter is olso valid for second letter
                    if (letterDictionary[validLetterCombination.Key].ValidLetters.ContainsKey(item.Key))
                    {
                        //couple is valid.
                        int currentSize = item.Value.Count + letterDictionary[validLetterCombination.Key].Count;
                        if (currentSize > max)
                            max = currentSize;

                        //don't check same couple 2th time
                        letterDictionary[validLetterCombination.Key].ValidLetters.Remove(item.Key);
                    }
                    else if (max < 1 && item.Value.Count == 1 && letterDictionary[validLetterCombination.Key].Count == 1)
                    {
                        max = 1;
                    }
                }
            }
            return max;
        }

    }

    public class LetterCombination
    {
        public int Count { get; private set; }

        //bool==> has occured
        public Dictionary<char, bool> ValidLetters { get; private set; }


        public LetterCombination()
        {
            this.Count = 0;
            this.ValidLetters = new Dictionary<char, bool>();
        }
        internal void Increment()
        {
            Count++;

            //don't check first time
            if (Count <= 1)
            {
                return;
            }


            //eliminate invalid letters            
            var newValidLetters = new Dictionary<char, bool>();
            foreach (var letter in ValidLetters)
            {
                if (letter.Value)
                    newValidLetters[letter.Key] = false;
            }
            this.ValidLetters = newValidLetters;

        }

        internal void LetterOccured(char letter)
        {
            if (ValidLetters.ContainsKey(letter))
            {
                if (ValidLetters[letter])
                {
                    //same letter 2th time
                    ValidLetters.Remove(letter);
                }
                else
                    ValidLetters[letter] = true;
            }
            else if (Count == 1)
            {
                //we can add a valid letter
                ValidLetters[letter] = true;
            }
        }

        internal bool IsStillValid()
        {
            return Count <= 1 || ValidLetters.Count > 0;
        }


    }
}
