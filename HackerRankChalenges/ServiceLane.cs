using HackerRankChalenges.Challanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges
{
    internal class ServiceLane : Chalange
    {
        public override void SetParameters()
        {
            this.url = "https://www.hackerrank.com/challenges/service-lane/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=30-day-campaign";
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter("packets", "1,2,3,4,5,6,7"),
            new ChalengeParameter("chanel", "4")};

            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {

            var packets = Utility.StringToIntagerList(parameters[0]);
            var chanels = int.Parse(parameters[1]);

            return serviceLane(packets, chanels).ToString();
        }

        /*
          * Complete the 'serviceLane' function below.
          *
          * The function is expected to return an INTEGER_ARRAY.
          * The function accepts following parameters:
          *  1. INTEGER n
          *  2. 2D_INTEGER_ARRAY cases
          */

        public static List<int> serviceLane(List<int> width, List<List<int>> cases)
        {
            List<int> result = new List<int>();
            foreach (var item in cases)
            {
                result.Add(GetWidestPossibleVehicle(width,item[0],item[1]));
            }
            return result;
        }

        private static int GetWidestPossibleVehicle(List<int> width, int start, int end)
        {
        
            int min = -1;
            for (int i = start; i <= end; i++)
            {
                var current = width[i];
           
                if (min == -1 || current < min)
                    min = current;
            }
            return min;
        }
    }
}
