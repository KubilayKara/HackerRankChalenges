using System;
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
            Action a1 = () => Rotate(nums, k);
            var r1 = Utility.RunAndReturnDuration(a1);

            nums = Utility.StringToIntagerList(parameters[0]).ToArray();
            k = int.Parse(parameters[1]);
            Action a2 = () => Rotate_2(nums, k);
            var r2 = Utility.RunAndReturnDuration(a2);

            nums = Utility.StringToIntagerList(parameters[0]).ToArray();
            k = int.Parse(parameters[1]);
            Action a3 = () => Rotate_3(nums, k);
            var r3 = Utility.RunAndReturnDuration(a3);

            nums = Utility.StringToIntagerList(parameters[0]).ToArray();
            k = int.Parse(parameters[1]);
            Action a4 = () => Rotate_4(nums, k);
            var r4 = Utility.RunAndReturnDuration(a4);
            return $"r1:{r1.TotalMilliseconds} \nr2:{r2.TotalMilliseconds} \nr3:{r3.TotalMilliseconds} \nr4:{r4.TotalMilliseconds}";
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
                nums[nextNum] = tmp[i].HasValue ? tmp[i].Value : nums[i];
            }
        }

        public void Rotate_3(int[] nums, int k)
        {
            int rotateNum = k % nums.Length;
            if (rotateNum == 0)
                return;

            int[] tmp = new int[rotateNum];
            int borderIndex = nums.Length - rotateNum;
            for (int i = borderIndex; i < nums.Length; i++)
            {
                tmp[i - borderIndex] = nums[i];
            }

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (i >= rotateNum)
                    nums[i] = nums[i - rotateNum];
                else
                    nums[i] = tmp[i];
            

            }
        }

        public void Rotate_4(int[] nums, int k)
        {
            int count = nums.Length;
            int fromBack = k % count;
            int fromStart = count - fromBack;

            reverse(nums, 0, count - 1);
            reverse(nums, 0, fromBack - 1);
            reverse(nums, fromBack, count - 1);
        }

        void reverse(int[] nums, int i, int j)
        {
            while (i < j)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
                i++;
                j--;
            }
        }
    }
}


