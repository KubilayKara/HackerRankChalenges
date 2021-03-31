using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://www.hackerrank.com/challenges/mark-and-toys/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=sorting
namespace HackerRankChalenges.Challanges
{
    public static class MarkAndToys
    {
        public static int MaximumToys(int[] prices, int k)
        {
            int toyCount = 0;
            int remMoney = k;
            bool shifted = false;
            int iterationCount = 0;
            while (remMoney > 0 && shifted)
            {
                shifted = false;
                for (int i = 0; i < prices.Length - 1 - iterationCount; i++)
                {
                    if (prices[i] < prices[i + 1])
                    {
                        int tmp = prices[i + 1];
                        prices[i + 1] = prices[i];
                        prices[i] = tmp;
                        shifted = true;
                    }
                }

                int last = prices[prices.Length - iterationCount];
                remMoney -= last;
                if (remMoney > 0)
                    toyCount++;

            }
            return toyCount;
            //List<int> sortedList = new List<int>();
            //for (int i = 0; i < prices.Length; i++)
            //{
            //    int currentValue = prices[i];

            //    if (currentValue > k)
            //        continue;
            //    InsertValueToSortedList(sortedList, currentValue);
            //}

            //return FindMaxToys(k, sortedList);

        }

        private static int FindMaxToys(int k, List<int> sortedList)
        {
            int remainingMoney = k;
            int numberOfToys = 0;
            while (remainingMoney > 0 && numberOfToys < sortedList.Count)
            {
                if (sortedList[numberOfToys] <= remainingMoney)
                {
                    remainingMoney -= sortedList[numberOfToys];
                    numberOfToys++;
                }
                else
                    break;
            }
            return numberOfToys;
        }

        private static void InsertValueToSortedList(List<int> sortedList, int currentValue)
        {
            if (sortedList.Count == 0)
                sortedList.Add(currentValue);
            else
            {
                bool isInserted = false;
                for (int j = 0; j < sortedList.Count; j++)
                {

                    if (currentValue < sortedList[j])
                    {
                        sortedList.Insert(j, currentValue);
                        isInserted = true;
                        break;
                    }
                }
                if (!isInserted)
                    sortedList.Add(currentValue);
            }
        }
    }


}
