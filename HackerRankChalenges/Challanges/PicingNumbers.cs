using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HackerRankChalenges.Challanges
{

    public class PicingNumbers : Chalange
    {
        public override void SetParameters()
        {
            this.url = "";
            this.ChalangeParameters = new List<ChalengeParameter>() { new ChalengeParameter { Label = "Array", DefaultValue = "4 6 5 3 3 1" } };
            this.ButtonText = typeof(PicingNumbers).Name;
        }
        public override string Run(string[] parameters)
        {
            // 4 2 3 4 4 9 98 98 3 3 3 4 2 98 1 98 98 1 1 4 98 2 98 3 9 9 3 1 4 1 98 9 9 2 9 4 2 2 9 98 4 98 1 3 4 9 1 98 98 4 2 3 98 98 1 99 9 98 98 3 98 98 4 98 2 98 4 2 1 1 9 2 4

            var a = Utility.StringToIntagerList(parameters[0], ' ');
            return pickingNumbers(a).ToString();

        }

        public static int pickingNumbers(List<int> a)
        {
            Dictionary<int, int> numberCounts = new Dictionary<int, int>();
            foreach (var item in a)
            {
                if (!numberCounts.ContainsKey(item))
                    numberCounts[item] = 1;
                else
                    numberCounts[item]++;
            }
            int max=0;
            foreach (var item in numberCounts)
            {
                int currentNumber = item.Key;
                int currentValue = item.Value;

                int oneLess = (numberCounts.ContainsKey(currentNumber - 1)) ? numberCounts[currentNumber - 1] + currentValue:currentValue;
                int oneMore = (numberCounts.ContainsKey(currentNumber + 1)) ? numberCounts[currentNumber + 1] + currentValue : currentValue;
                if (max < oneLess)
                    max = oneLess;

                if (max < oneMore)
                    max = oneMore;
            }
            return max;

        }
        public static int pickingNumbers_sequential(List<int> a)
        {
            int longest = 0;

            List<int> numbers = new List<int>();
            List<int> numbersValues = new List<int>();

            for (int i = 0; i < a.Count; i++)
            {
                int currentNumber = a[i];
                int currentValue = LookBackwardsForReleatedNumbers(numbers, numbersValues, currentNumber);

                if (currentValue > longest)
                    longest = currentValue;
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                Trace.WriteLine($"{numbers[i]}\t{numbersValues[i]}");
            }

            return longest;

        }

        private static int LookBackwardsForReleatedNumbers(List<int> numbers, List<int> numbersValues, int currentNumber)
        {
            int? oneDown = null;
            int? oneUp = null;
            int? same = null;

            //look backwars for realated numbers
            for (int j = numbers.Count - 1; j >= 0; j--)
            {
                if (numbers[j] == currentNumber)
                {
                    if (oneDown == null && oneUp == null)
                    {
                        //same number nearest
                        same = numbersValues[j];
                        break;
                    }
                    if (same == null || numbersValues[j] > same)
                        same = numbersValues[j];
                }
                else if (numbers[j] == currentNumber - 1)
                {
                    if (oneDown == null || numbersValues[j] > oneDown)
                        oneDown = numbersValues[j];
                }
                else if (numbers[j] == currentNumber + 1)
                {
                    if (oneUp == null || numbersValues[j] > oneUp)
                        oneUp = numbersValues[j];
                }

                if (oneDown.HasValue && oneUp.HasValue && same.HasValue)
                    break;
            }

            int currentValue = 0;
            currentValue = SetBigestInt(oneDown, currentValue);
            currentValue = SetBigestInt(oneUp, currentValue);
            currentValue = SetBigestInt(same, currentValue);
            currentValue++;
            numbers.Add(currentNumber);
            numbersValues.Add(currentValue);
            return currentValue;
        }

        private static int SetBigestInt(int? value, int currentValue)
        {
            if (value.HasValue && value.Value > currentValue)
                currentValue = value.Value;
            return currentValue;
        }
    }


}

