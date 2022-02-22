using System.Collections.Generic;

namespace HackerRankChalenges.Challanges.LeetCodeAlgo1
{
    internal class LeetTwoSum : Chalange
    {
        /*
         https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
        */
        public override void SetParameters()
        {
            this.ChalangeParameters = new List<ChalengeParameter>() { new ChalengeParameter("List", "2,7,11,15"),
            new ChalengeParameter("target", "9")};
            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {
            int[] nums = Utility.StringToIntagerList(parameters[0]).ToArray();
            int target = int.Parse(parameters[1]);
            return Utility.ArrayToString(TwoSum(nums, target));
        }

        public int[] TwoSum(int[] numbers, int target)
        {
            //value,index
            Dictionary<int, int> numDic = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNum = numbers[i];
                if (currentNum >= target)
                    break;
                int otherNum = target - currentNum;

                if (numDic.ContainsKey(otherNum))
                    return (new int[] { numDic[otherNum] + 1, i + 1 });

                numDic[currentNum] = i;
            }
            return null;


        }
    }
}

