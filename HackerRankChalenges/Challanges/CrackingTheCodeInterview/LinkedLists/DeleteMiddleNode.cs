using System.Collections.Generic;

namespace HackerRankChalenges.Challanges.CrackingTheCodeInterview.LinkedLists
{
    internal class DeleteMiddleNode : Chalange
    {
        /*
        Delete Middle Node: Implement an algorithm to delete a node in the middle (i.e., any node but
        the first and last node, not necessarily the exact middle) of a singly linked list, given only access to
        that node.
        EXAMPLE
        lnput:the node c from the linked list a->b->c->d->e->f
        Result: nothing is returned, but the new linked list looks like a->b->d->e- >f
        */


        public override void SetParameters()
        {
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter("List", "a b c d e f") };
            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {
            string[] list = parameters[0].Trim().Split(' ');
            if (list.Length <= 0)
                return "empthy list";

            KubLinkedList<string> linkedlist = Utility.ArrayToLinkedList(list);


            sollution(linkedlist);
            return linkedlist.ToString();


        }

        private void sollution<T>(KubLinkedList<T> linkedlist)
        {
            //what if list has 1 member?


            if (linkedlist.Head == null)
                return;

            if (linkedlist.Head.NextNode == null)
            {
                linkedlist.Head = null;
                return;
            }
            var currentNode = linkedlist.Head.NextNode;

            KubLinkedListNode<T> nodeBeforeMiddleNode = linkedlist.Head;

            bool passThisTime = true;

            while (currentNode != null && currentNode.NextNode != null)
            {

                if (passThisTime)
                    passThisTime = false;
                else
                {
                    nodeBeforeMiddleNode = nodeBeforeMiddleNode.NextNode;
                    passThisTime = true;
                }

                currentNode = currentNode.NextNode;
            }


            nodeBeforeMiddleNode.NextNode = nodeBeforeMiddleNode.NextNode.NextNode;
        }

    }
}
