using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges
{
    public static class BeatifulTriplets
    {

        public static int FindBeautifulTriplets(int d, int[] arr)
        {
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int index2 = -1;
                int index3 = -1;
                for (int j = i+1; j < arr.Length; j++)
                {
                    int curDif = arr[j] - arr[i];
                    if (curDif < d)
                        continue;
                    else if (curDif == d)
                    {
                        index2 = j;
                        break;
                    }
                    else break;                    
                }

                if (index2 < 0)
                    continue;

                for (int k = index2+1; k < arr.Length; k++)
                {
                    int curDif = arr[k] - arr[index2];
                    if (curDif < d)
                        continue;
                    else if (curDif == d)
                    {
                        index3 = k;
                        break;
                    }
                    else break;
                }
                if (index3 > 0)
                    result++;
            }
            return result;
        }
    }
}
