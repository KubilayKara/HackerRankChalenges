using System.Collections.Generic;

namespace HackerRankChalenges.Challanges.LeetCodeAlgo1
{
    internal class LeetSortedSquares : Chalange
    {
        /*
         https://leetcode.com/problems/squares-of-a-sorted-array/
        */
        public override void SetParameters()
        {
            this.ChalangeParameters = new List<ChalengeParameter>() { new ChalengeParameter("List", "-4,-1,0,3,10") };
            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {
            int[] nums = Utility.StringToIntagerList(parameters[0]).ToArray();
            return Utility.ArrayToString(SortedSquares(nums));
        }


        public int[] SortedSquares(int[] nums)
        {

            int[] result = new int[nums.Length];
            Stack<int> negativeSquares = new Stack<int>();
            int index = 0;
            foreach (var i in nums)
            {
                if (i < 0)
                {
                    negativeSquares.Push(i * i);
                    continue;
                }
                int cur = i * i;

                int smallestNegativeSquare;
                while (negativeSquares.TryPop(out smallestNegativeSquare))
                {
                    if (smallestNegativeSquare <= cur)
                        result[index++] = smallestNegativeSquare;
                    else
                    {
                        negativeSquares.Push(smallestNegativeSquare);
                        break;
                    }
                }

                result[index++] = cur;
            }

            while (negativeSquares.TryPop(out int nextNegativeSquare))
            {
                result[index++] = nextNegativeSquare;

            }
            return result;

        }


        public void MoveZeroes(int[] nums)
        {
            int insertIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i];
                if (val != 0)
                    nums[insertIndex++] = val;
            }
            for (int i = insertIndex; i < nums.Length; i++)
            {
                nums[insertIndex++] = 0;
            }
        }
    }
}

