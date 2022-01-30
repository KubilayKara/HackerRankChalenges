using System;
using System.Collections.Generic;
using System.Linq;
namespace HackerRankChalenges.Challanges.LeetCode75
{
    public class ProductExceptSelf : Chalange
    {
        public override void SetParameters()
        {
            this.url = "https://leetcode.com/problems/product-of-array-except-self/";
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter { Label = "Array", DefaultValue = "-1,1,0,-3,3" } };
            this.ButtonText = typeof(ProductExceptSelf).Name;
        }
        public override string Run(string[] parameters)
        {

            int[] nums = Utility.StringToIntagerList(parameters[0]).ToArray();

            //var result = ProductExceptSelf_solution2(nums);
            //return Utility.IntagerArrayToString(result);

            //var result = MaxSubArray(nums);
            var result = ProductExceptSelf_solution(nums);
            return result.ToString();


        }


        public int MaxProfit(int[] prices)
        {
            int? minPrice = null;
            int maxProfit = 0;

            foreach (var currentPrice in prices)
            {
                if (minPrice == null || currentPrice < minPrice.Value)
                {
                    minPrice = currentPrice;
                    continue;
                }

                int currentProfit = currentPrice - minPrice.Value;
                if (currentProfit > maxProfit)
                    maxProfit = currentProfit;
            }
            return maxProfit;
        }

        public bool ContainsDuplicate(int[] nums)
        {
            Dictionary<int, int> numberDic = new Dictionary<int, int>();

            foreach (var currentNum in nums)
            {
                if (numberDic.ContainsKey(currentNum))
                    return true;
                else
                    numberDic[currentNum] = 1;
            }
            return false;

        }

        public int[] ProductExceptSelf_solution(int[] nums)
        {
            int[] result = new int[nums.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = 1;
            }

            int zeroIndex = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (zeroIndex >= 0)
                {
                    result[zeroIndex] = result[zeroIndex] * nums[i];
                }
                else
                {
                    for (int j = 0; j < result.Length && zeroIndex < 0; j++)
                    {
                        if (i == j)
                            continue;

                        result[j] = result[j] * nums[i];
                    }
                }
                if (nums[i] == 0)
                {
                    if (zeroIndex > 0) //has allready an other zero
                    {
                        return result;
                    }
                    zeroIndex = i;
                }
            }
            return result;

        }

        public int[] ProductExceptSelf_solution2(int[] nums)
        {
            //num , indexes
            Dictionary<int, List<int>> numIndextDict = new Dictionary<int, List<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                if (!numIndextDict.ContainsKey(num))
                    numIndextDict[num] = new List<int>();

                numIndextDict[num].Add(i);
            }

            int[] result = new int[nums.Length];

            if (numIndextDict.ContainsKey(0))
            {
                if (numIndextDict[0].Count() > 1)
                    return result;

                //there is only on zero
                int zeroIndex = numIndextDict[0].First();
                result[zeroIndex] = (int)CalculatePrduct(numIndextDict, false);
                return result;
            }
            double totalProduct = CalculatePrduct(numIndextDict, true);
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = (int)(totalProduct / nums[i]);
            }
            return result;
        }

        private double CalculatePrduct(Dictionary<int, List<int>> numIndextDict, bool computeZero)
        {
            double result = 1;
            foreach (var item in numIndextDict)
            {

                int currentNumber = item.Key;
                int count = item.Value.Count();
                if (currentNumber == 0)
                {
                    if (computeZero)
                        return 0;

                    continue;
                }
                if (currentNumber == 1)
                    continue;
                if (currentNumber == -1)
                {
                    if (count % 2 == 1)
                        result = result * -1;
                    continue;
                }
                result = result * (Math.Pow(currentNumber, count));
            }
            return result;
        }




    }
}

