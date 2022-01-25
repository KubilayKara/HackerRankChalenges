using System;
using System.Collections.Generic;
namespace HackerRankChalenges.Challanges.LeetCode75
{
    public class MaxSubArray : Chalange
    {
        public override void SetParameters()
        {
            this.url = "https://leetcode.com/problems/maximum-subarray/";
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter { Label = "Array", DefaultValue = "-1,1,0,-3,3" } };
            this.ButtonText = typeof(MaxSubArray).Name;
        }
        public override string Run(string[] parameters)
        {

            int[] nums = Utility.StringToIntagerList(parameters[0]).ToArray();

            //var result = ProductExceptSelf_solution2(nums);
            //return Utility.IntagerArrayToString(result);

            //var result = MaxSubArray(nums);
            var result = MaxSubArray_EdgeDetection(nums);
            return result.ToString();


        }

        //nums = [-2,1,-3,4,-1,2,1,-5,4]
        public int MaxSubArray_sol1(int[] nums)
        {
            //<start<end,total>>
            int max = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                //add current number
                int currentNum = nums[i];
                int totalJ = currentNum;
                if (max < totalJ)
                    max = totalJ;
                //update previous subArrays
                for (int j = i + 1; j < nums.Length; j++)
                {
                    totalJ += nums[j];


                    if (max < totalJ)
                        max = totalJ;
                }

                if (max < totalJ)
                    max = totalJ;
            }
            return max;

        }




        // nums  = [-2,1, -3,4,-1,2,1,-5,4] ==> [4,-1,2,1]
        // nums2 = [-2,-1,-4,0,1,3,4,-1,3]


        //[-5,4,-1,7,8] => 18
        //[5,9,8,15,23] => 60


        //-2, -1
        //


        //-2,1,-1
        //-2,-1,-2

        //-1,0
        public int MaxSubArray_EdgeDetection(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];
            int max = nums[0];
            int maxIndex = 0;
            int min = nums[0];
            int minIndex = 0;
            //
            int[] dif = new int[nums.Length];

            int total = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                total += nums[i];
                dif[i] = total;

                if (min > total)
                {
                    min = total;
                    minIndex = i;
                }

                if (max < total)
                {
                    max = total;
                    maxIndex = i;
                }

            }

            int result = 0;

            if (minIndex > maxIndex)
            {
                var temp = minIndex;
                minIndex = maxIndex;
                maxIndex = temp;
            }

            bool any = false;
            for (int i = minIndex + 1; i <= maxIndex - 1; i++)
            {
                result += nums[i];
                any = true;
            }
            if (nums[minIndex] > 0)
                result += nums[minIndex];
            if (nums[maxIndex] > 0)
                result += nums[maxIndex];

            if (!any && nums[maxIndex] <= 0 && nums[minIndex] <= 0)
            {
                result = Math.Max(nums[maxIndex], nums[minIndex]);
            }

            return result;

        }

    }
}

