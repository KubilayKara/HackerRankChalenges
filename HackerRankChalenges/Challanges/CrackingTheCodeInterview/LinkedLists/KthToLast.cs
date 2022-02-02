using System.Collections.Generic;

namespace HackerRankChalenges.Challanges.CrackingTheCodeInterview.LinkedLists
{
    internal class KthToLast : Chalange
    {
        /*
    Return Kth to Last: Implement an algorithm to find the kth to last element of a singly linked list.
         * 
    */
        public override void SetParameters()
        {
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter("List", "a b c d a c c c e h"), new ChalengeParameter("K", "3") };
            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {
            string[] list = parameters[0].Split(' ');
            if (list.Length <= 0)
                return "empthy list";

            KubLinkedList<string> linkedlist = Utility.ArrayToLinkedList(list);

            if (int.TryParse(parameters[1], out int k))
            {
                return kthToLast_sollution(linkedlist, k);
            }
            return "parameter error";
        }

        private T kthToLast_sollution<T>(KubLinkedList<T> linkedlist, int k)
        {
            //what if k> list.length?
            // should we think k as zero based?

            if (linkedlist.Head == null)
                return default(T);

            var currentNode = linkedlist.Head;

            KubLinkedListNode<T> behindNode = linkedlist.Head; ;

            while (currentNode != null && currentNode.NextNode != null)
            {

                if (k != 0)
                    k--;
                else
                    behindNode = behindNode.NextNode;

                currentNode = currentNode.NextNode;
            }
            if (k == 0)
                return behindNode.PayLoad;

            return default(T);
        }

    }
}
