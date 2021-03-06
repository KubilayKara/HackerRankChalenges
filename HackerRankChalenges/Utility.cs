using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRankChalenges.Challanges.CrackingTheCodeInterview.LinkedLists;

namespace HackerRankChalenges
{
    public class Utility
    {

        public static List<int> StringToIntagerList(string s, char seperator = ',')
        {
            string[] testPrm = s.Split(seperator);
            List<int> a = new List<int>();
            foreach (var item in testPrm)
            {
                int i;
                if (int.TryParse(item.Trim(), out i))
                    a.Add(i);
            }
            return a;
        }


        public static string ArrayToString<T>(T[] arr, char seperator = ' ')
        {
            if (arr == null)
                return string.Empty;
            string result = string.Empty;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                T item = arr[i];
                result += item.ToString() + seperator;
            }
            result += arr.LastOrDefault();

            return result;
        }

        public static string MatrixToString<T>(T[,] arr, char seperator = ' ')
        {
            if (arr == null)
                return string.Empty;
            string result = string.Empty;
            int rowCount = arr.GetLength(0);
            int columnCount = arr.GetLength(1);

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    result += arr[rowIndex, columnIndex].ToString();
                    if (columnIndex != columnCount - 1)
                        result += seperator;
                }
                if (rowIndex != rowCount - 1)
                    result += "\n";
            }

            return result;
        }

        public static KubLinkedList<T> ArrayToLinkedList<T>(T[] array)
        {
            if (array.Length == 0)
                return new KubLinkedList<T>(default(T));

            KubLinkedList<T> linkedlist = new KubLinkedList<T>(array[0]);

            KubLinkedListNode<T> currentNode = linkedlist.Head;
            for (int i = 1; i < array.Length; i++)
            {
                var newNode = new KubLinkedListNode<T>(array[i]);
                currentNode.NextNode = newNode;
                currentNode = newNode;
            }
            return linkedlist;
        }

        public static (TimeSpan duration, T functionResult) RunAndReturnDuration<T>(Func<T> func)
        {
            DateTime d = DateTime.Now;
            var fResult = func.Invoke();
            return (DateTime.Now - d, fResult);
        }

        public static TimeSpan RunAndReturnDuration(Action action)
        {
            DateTime d = DateTime.Now;

            action.Invoke();
            return (DateTime.Now - d);
        }


    }
}
