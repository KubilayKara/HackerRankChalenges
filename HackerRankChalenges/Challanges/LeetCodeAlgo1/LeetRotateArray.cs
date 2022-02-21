using System.Collections.Generic;

namespace HackerRankChalenges.Challanges.LeetCodeAlgo1
{
    internal class LeetRotateArray : Chalange
    {
        /*
         https://leetcode.com/problems/rotate-array/
        */
        public override void SetParameters()
        {
            this.ChalangeParameters = new List<ChalengeParameter>() { new ChalengeParameter("List", "1,2,3,4,5,6,7"),
                new ChalengeParameter("k","3") };
            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {
            int[] nums = Utility.StringToIntagerList(parameters[0]).ToArray();
            int k = int.Parse(parameters[1]);
            Rotate(nums, k);
            return Utility.ArrayToString(nums);
        }


        public void Rotate(int[] nums, int k)
        {
            int rotateNum = k % nums.Length;
            if (rotateNum == 0)
                return;

            int tmp = nums[0];
            int currentNum = 0;
            int nextNum = -1;
            while (true)
            {
                nextNum = currentNum - rotateNum;
                if (nextNum < 0)
                    nextNum += nums.Length;
                if (nextNum == 0)
                    break;
                nums[currentNum] = nums[nextNum];
                currentNum = nextNum;
            }
            nums[currentNum] = tmp;
        }
        public void Rotate_2(int[] nums, int k)
        {
            int rotateNum = k % nums.Length;
            if (rotateNum == 0)
                return;

            int?[] tmp = new int?[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {


                int nextNum = i + rotateNum;
                if (nextNum > nums.Length - 1)
                    nextNum -= nums.Length;
                tmp[nextNum] = nums[nextNum];
                nums[nextNum] = tmp[i].HasValue? tmp[i].Value : nums[i];
            }
        }


    }
}

