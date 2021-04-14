using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges
{
    public static class DictionariesAndHashmaps
    {

        public static int FindBeautifulTriplets(int d, int[] arr)
        {
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int index2 = -1;
                int index3 = -1;
                for (int j = i + 1; j < arr.Length; j++)
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

                for (int k = index2 + 1; k < arr.Length; k++)
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

        //https://www.hackerrank.com/challenges/count-triplets-1/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
        public static long CountTriplets(List<long> arr, long r)
        {
            long result = 0;
            Dictionary<long, long> numberCount = new Dictionary<long, long>();
            for (int i = 0; i < arr.Count; i++)
            {
                long currentNumber = arr[i];
                if (!numberCount.ContainsKey(currentNumber))
                    numberCount[currentNumber] = 1;
                else
                    numberCount[currentNumber]++;
            }

            if (r == 1)
            {
                foreach (var item in numberCount)
                {
                    var v = item.Value;
                    if (v > 3)
                        result += v * (v - 1) * (v - 2) / 6;
                    else if (v == 3)
                        result++;
                }

            }
            else
            {
                foreach (var item in numberCount)
                {
                    long currentNumber = item.Key;
                    long secondNumber = currentNumber * r;
                    long thirdNumber = secondNumber * r;

                    if (numberCount.ContainsKey(secondNumber) && numberCount.ContainsKey(thirdNumber))
                    {

                        //2.325.652.489
                        result += item.Value * numberCount[secondNumber] * numberCount[thirdNumber];
                    }
                }
            }
            return result;

        }


    }
}
