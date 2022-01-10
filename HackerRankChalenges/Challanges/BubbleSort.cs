using System;
using System.Diagnostics;

//https://www.hackerrank.com/challenges/mark-and-toys/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=sorting
namespace HackerRankChalenges.Challanges
{
    public static class BubbleSort
    {
        //https://www.hackerrank.com/challenges/ctci-bubble-sort/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=sorting

        //Array is sorted in numSwaps swaps., where  is the number of swaps that took place.
        //First Element: firstElement, where  is the first element in the sorted array.
        //Last Element: lastElement, where  is the last element in the sorted array.
        public static void CountSwaps(int[] a)
        {
        
            int swapCount = 0;

            for (int i = 0; i < a.Length; i++)
            {
                bool isChanged = false;
                for (int j = 0; j < a.Length - 1; j++)
                {
                    // Swap adjacent elements if they are in decreasing order
                    if (a[j] > a[j + 1])
                    {
                  

                        swapCount++;
                        Swap(a, j, j + 1);
                        isChanged = true;
                    }
                }
                if (!isChanged)
                    break;

            }



            Trace.WriteLine($"Array is sorted in {swapCount} swaps.");
            Trace.WriteLine($"First Element: {a[0]}");
            Trace.WriteLine($"Last Element: {a[a.Length-1]}");

        }
        private static void Swap(int[] a, int index1, int index2)
        {
            var tmp = a[index1];
            a[index1] = a[index2];
            a[index2] = tmp;

        }

    }


}
