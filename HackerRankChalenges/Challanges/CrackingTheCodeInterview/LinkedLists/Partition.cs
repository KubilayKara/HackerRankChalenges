using System;
using System.Collections.Generic;

namespace HackerRankChalenges.Challanges.CrackingTheCodeInterview.LinkedLists
{
    internal class Partition : Chalange
    {
        /*
            Partition: Write code to partition a linked list around a value x, such that all nodes less than x come
            before all nodes greater than or equal to x. If x is contained within the list, the values of x only need
            to be after the elements less than x (see below). The partition element x can appear anywhere in the
            "right partition"; it does not need to appear between the left and right partitions.
            EXAMPLE
            Input:
            Output:
            3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1 [partition= 5]
            3 -> 1 -> 2 -> 10 -> 5 -> 5 -> 8
         */



        public override void SetParameters()
        {
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter("List", "3 5 8 5 10 2 1"), new ChalengeParameter("x", "5") };
            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {
            KubLinkedList<int> list = Utility.ArrayToLinkedList(Utility.StringToIntagerList(parameters[0], ' ').ToArray());


            sollution(list, int.Parse(parameters[1]));
            return list.ToString();


        }

        private void sollution(KubLinkedList<int> linkedlist, int x)
        {
            //what if list has 1 member?


            if (linkedlist.Head == null)
                return;


            var currentNode = linkedlist.Head;

            KubLinkedListNode<int> rightHead = null;
            KubLinkedListNode<int> rightTail = null;
            KubLinkedListNode<int> leftHead = null;
            KubLinkedListNode<int> leftTail = null;


            while (currentNode != null)
            {
                if (currentNode.PayLoad < x)
                {
                    if (leftHead == null)
                        leftHead = currentNode;

                    if (leftTail == null)
                        leftTail = currentNode;
                    else
                    {
                        leftTail.NextNode = currentNode;
                        leftTail = currentNode;
                    }
                }
                else
                {
                    if (rightHead == null)
                        rightHead = currentNode;
                    if (rightTail == null)
                        rightTail = currentNode;
                    else
                    {
                        rightTail.NextNode = currentNode;
                        rightTail = currentNode;
                    }
                }

                currentNode = currentNode.NextNode;
            }
            if (leftTail != null)
                leftTail.NextNode = rightHead;

            linkedlist.Head = (leftHead != null) ? leftHead : rightHead;

            rightTail.NextNode = null; //prevent circular pointing

        }

    }
}
