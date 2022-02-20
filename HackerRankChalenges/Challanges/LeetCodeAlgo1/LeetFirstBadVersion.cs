using System.Collections.Generic;

namespace HackerRankChalenges.Challanges.LeetCodeAlgo1
{
    internal class LeetFirstBadVersion : Chalange
    {
        /*
         https://leetcode.com/problems/first-bad-version/
        */
        public override void SetParameters()
        {
            this.ChalangeParameters = new List<ChalengeParameter>() { new ChalengeParameter("length", "5"),
            new ChalengeParameter("BadStart", "4")};
            base.SetParameters();
        }
        int length;
        int badStart;
        public override string Run(string[] parameters)
        {
            length = int.Parse(parameters[0]);
            badStart = int.Parse(parameters[1]);
            return FirstBadVersion(length).ToString();
        }

        public int FirstBadVersion(int n)
        {

            return FirstBadVersion(1, n);

        }

        public int FirstBadVersion(int start, int end)
        {


            if (!(start < end))
            {
                return IsBadVersion(start) ? start : start + 1;
            }

            int mid = start + (end - start) / 2;

            if (IsBadVersion(mid))
                return FirstBadVersion(start, mid - 1);

            return FirstBadVersion(mid + 1, end);

        }

        private bool IsBadVersion(int mid)
        {
            return mid >= badStart;
        }
    }
}
