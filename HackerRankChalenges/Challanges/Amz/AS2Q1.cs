using System;
using System.Collections.Generic;

namespace HackerRankChalenges.Challanges.Amazon
{
    internal class AS2Q1 : Chalange
    {
        public override void SetParameters()
        {
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter("packets", "1,2,3,4,5,6,7"),
            new ChalengeParameter("chanel", "4")};

            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {

            var packets = Utility.StringToIntagerList(parameters[0]);
            var chanels = int.Parse(parameters[1]);

            return maximumQuality(packets, chanels).ToString();
        }


        public static long maximumQuality(List<int> packets, int chanels)
        {
            return Convert.ToInt64(Math.Round(maximumQuality(packets, chanels, 0, packets.Count - 1)));
        }


        public static double maximumQuality(List<int> list, int ch, int start, int end)
        {
            int length = end - start + 1;

            list.Sort();

            if (ch == 1)
            {
                return CalculateMedium(list, start, end);
            }

            // n-ch+1 (not adding 1 because index is zero based)
            int traverseTill = (length - ch);

            double curMedian = CalculateMedium(list, 0, traverseTill);

            while (++traverseTill < length)
            {
                curMedian += list[traverseTill];
            }
            return curMedian;
        }

        private static double CalculateMedium(List<int> list, int start, int end)
        {
            int length = end - start + 1;
            int mid = (start + end) / 2;

            if (length % 2 == 0)
            {
                return ((double)list[mid] + list[mid + 1]) / 2;
            }
            return list[mid];
        }
    }
}
