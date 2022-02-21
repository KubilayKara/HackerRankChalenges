using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges.LeetCodeAlgo1
{

    internal class BinarySearch : Chalange
    {
        /*
         https://leetcode.com/problems/binary-search/
        */
        public override void SetParameters()
        {
            this.ChalangeParameters = new List<ChalengeParameter>() { new ChalengeParameter("List", "-1,0,3,5,9,12"),
            new ChalengeParameter("Target", "9")};
            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {
            int target = int.Parse(parameters[1]);
            int[] nums = Utility.StringToIntagerList(parameters[0]).ToArray();
            return Search(nums, target).ToString();
        }

        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return -1;
            return Search(nums, target, 0, nums.Length - 1);
        }

        public int Search(int[] nums, int target, int start, int end)
        {
            if (start > end || start < 0 || end > nums.Length - 1)
                return -1;

            int mid = (end == start) ? end : start + (end - start) / 2;
            if (nums[mid] == target)
                return mid;
            if (nums[mid] < target)
                return Search(nums, target, mid + 1, end);

            return Search(nums, target, start, mid - 1);

        }

       

    }
}
