using System.Collections.Generic;

namespace HackerRankChalenges.Challanges.CrackingTheCodeInterview.LinkedLists
{
    internal class LinkedListPalindrome : Chalange
    {
        /*
           Palindrome: Implement a function to check if a linked list is a palindrome.

         */

        public override void SetParameters()
        {
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter("List", "7 1 6 1 7") };
            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {
            KubLinkedList<int> list1 = Utility.ArrayToLinkedList(Utility.StringToIntagerList(parameters[0], ' ').ToArray());

            var result = sollution(list1);
            return result.ToString();


        }

        private bool sollution(KubLinkedList<int> list1)
        {
            return LookDown<int>(list1.Head, list1.Head, 0).result;
        }

        private (bool result, KubLinkedListNode<T> pair, int middleIndex) LookDown<T>(KubLinkedListNode<T> headNode, KubLinkedListNode<T> currentNode, int index)
        {
            if (currentNode.NextNode == null)
            {
                //this is the last node
                return (headNode.PayLoad.Equals(currentNode.PayLoad), headNode.NextNode, index / 2);
            }
            else
            {
                var commingResult = LookDown(headNode, currentNode.NextNode, index + 1);
                bool currentResult = (index <= commingResult.middleIndex) ? commingResult.result : commingResult.result && currentNode.PayLoad.Equals(commingResult.pair.PayLoad);
                return (currentResult, commingResult.pair.NextNode, commingResult.middleIndex);
            }
        }

    }
}
