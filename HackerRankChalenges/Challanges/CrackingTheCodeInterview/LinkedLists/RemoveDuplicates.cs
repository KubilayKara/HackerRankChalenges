using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges.CrackingTheCodeInterview.LinkedLists
{

    internal class RemoveDuplicates : Chalange
    {
        /*Remove Dups! Write code to remove duplicates from an unsorted linked list.
        FOLLOW UP
        How would you solve this problem if a temporary buffer is not allowed?
    */
        public override void SetParameters()
        {
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter("List", "a b c d a c c c e h") };
            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {
            string[] list = parameters[0].Split(' ');
            if (list.Length <= 0)
                return "empthy list";

            KubLinkedList<string> linkedlist = Utility.ArrayToLinkedList(list);


            RemoveDuplicates_sollution_2(linkedlist);

            return linkedlist.ToString();
        }

        private void RemoveDuplicates_sollution<T>(KubLinkedList<T> l)
        {
            if (l.Head == null)
                return;

            Dictionary<T, bool> controlDic = new Dictionary<T, bool>();

            var previousNode = l.Head;
            controlDic[previousNode.PayLoad] = true;

            var currentNode = previousNode.NextNode;

            while (currentNode != null)
            {
                if (controlDic.ContainsKey(currentNode.PayLoad))
                {
                    //found
                    //remove
                    previousNode.NextNode = currentNode.NextNode;
                }
                else
                {
                    controlDic[currentNode.PayLoad] = true;
                    previousNode = currentNode;
                }

                currentNode = currentNode.NextNode;
            }
        }

        private void RemoveDuplicates_sollution_2<T>(KubLinkedList<T> l)
        {
            var currentNode = l.Head;

            while (currentNode != null)
            {
                RemoveNodes(currentNode, currentNode.PayLoad);
                currentNode = currentNode.NextNode;
            }
        }
        private void RemoveNodes<T>(KubLinkedListNode<T> nodeToStart, T value)
        {
            if (nodeToStart == null)
                return;


            var previousNode = nodeToStart;

            var currentNode = previousNode.NextNode;

            while (currentNode != null)
            {
                if (currentNode.PayLoad.Equals(value))
                {
                    //found
                    //remove
                    previousNode.NextNode = currentNode.NextNode;
                }
                else
                {
                    previousNode = currentNode;
                }

                currentNode = currentNode.NextNode;
            }
        }
    }

}
