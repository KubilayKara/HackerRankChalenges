using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges.LeetCode75
{
    public class TwoSum : Chalange
    {
        public override void SetParameters()
        {
            this.url = "";
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter { Label = "Array", DefaultValue = "2,7,11,15" }, new ChalengeParameter { Label = "number", DefaultValue = "9" } };
            this.ButtonText = typeof(TwoSum).Name;
        }
        public override string Run(string[] parameters)
        {

            int[] nums = Utility.StringToIntagerList(parameters[0]).ToArray();
            int target = int.Parse(parameters[1]);
            var result = Sollution(nums, target);


            return Utility.IntagerArrayToString(result);

        }


        public int[] Sollution(int[] nums, int target)
        {
            //value, index
            Dictionary<int, int> numDict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int currentNumber = nums[i];


                int required = target - currentNumber;
                if (numDict.ContainsKey(required))
                    return new int[] { i, numDict[required] };
                else
                    numDict[currentNumber] = i;

            }

            return null;
        }



    }
}

