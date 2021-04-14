using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges
{
    public static class StringOperations
    {
        //https://www.hackerrank.com/challenges/two-strings/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps


        public static string GetLargestSubString(string s1, string s2)
        {
            string smallStr, largeStr;

            if (s1.Length < s2.Length)
            {
                smallStr = s1;
                largeStr = s2;
            }
            else
            {
                smallStr = s2;
                largeStr = s1;
            }

            for (int charCount = smallStr.Length; charCount > 0; charCount--)
            {
                for (int i = 0; i <= smallStr.Length - charCount; i++)
                {
                    string s = smallStr.Substring(i, charCount);
                    if (largeStr.Contains(s))
                        return s;
                }
            }
            return string.Empty;
        }

        internal static bool CheckCommonSubString(string text1, string text2)
        {
            Dictionary<string, bool> alreadySearched = new Dictionary<string, bool>();

            for (int i = 0; i < text1.Length-1; i++)
            {
                string str = text1.Substring(i, 1);
                if (alreadySearched.ContainsKey(str))
                    continue;

                if (text2.Contains(str))
                    return true;

                alreadySearched[str] = false;
            }

            //for (int charCount = 1; charCount <= text1.Length; charCount++)
            //{
            //    for (int j = 0; j <= text1.Length - charCount; j++)
            //    {
            //        string str = text1.Substring(j, charCount);
            //        if (alreadySearched.ContainsKey(str))
            //            continue;

            //        if (text2.Contains(str))
            //            return true;

            //        alreadySearched[str] = false;
            //    }
            //}

            return false;
        }


        public static long CountSpecialStrings(string s)
        {
            long result = 0;
            string currentStr = string.Empty;
            foreach (char c in s)
            {
                currentStr += c;
                int lastCharCount = LastCharCount(currentStr, c);
                result += lastCharCount;
                if (CheckMiddle(currentStr, c, lastCharCount))
                    result++;
            }
            return result;

        }

        private static bool CheckMiddle(string s, char c, int lastCharCount)
        {
            int middleIndex = s.Length - lastCharCount - 1;

            if (middleIndex <= 0)
                return false;

            for (int i = 1; i <= lastCharCount; i++)
            {
                int indexToCheck = middleIndex - i;
                if (indexToCheck < 0)
                    return false;
                if (s[indexToCheck] != c)
                    return false;
            }

            return true;

        }

        private static int LastCharCount(string s, char c)
        {
            int result = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == c)
                    result++;
                else
                    return result;
            }
            return result;
        }
    }
}
