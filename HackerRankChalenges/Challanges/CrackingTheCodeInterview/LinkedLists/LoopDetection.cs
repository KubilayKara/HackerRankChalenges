using System.Collections.Generic;

namespace HackerRankChalenges.Challanges.CrackingTheCodeInterview.LinkedLists
{
    internal class LoopDetection : Chalange
    {
        /*
            Loop Detection: Given a circular linked list, implement an algorithm that returns the node at the
            beginning of the loop.
            DEFINITION
            Circular linked list: A (corrupt) linked list in which a node's next pointer points to an earlier node, so
            as to make a loop in the linked list.
            EXAMPLE
            Input: A -> B -> C - > D -> E -> C [the same C as earlier]
            Output: C
         */
        public override void SetParameters()
        {
            this.ChalangeParameters = new List<ChalengeParameter> { };
            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {
            KubLinkedListNode<string> nodeC = new KubLinkedListNode<string>("C")
            {
            };
            KubLinkedListNode<string> nodeD = new KubLinkedListNode<string>("D")
            {
            };
            nodeC.NextNode = nodeD;
            KubLinkedListNode<string> NodeE = new KubLinkedListNode<string>("D")
            {
            };
            nodeD.NextNode = NodeE;
            NodeE.NextNode = nodeC;
            KubLinkedList<string> list1 = new KubLinkedList<string>
            {
                Head = new KubLinkedListNode<string>("A")
                {
                    NextNode = new KubLinkedListNode<string>("B")
                    {
                        NextNode = nodeC

                    }
                }
            };



            var result1 = Utility.RunAndReturnDuration(() => sollution(list1));
            return $"\nresult1:{result1.functionResult} {result1.duration.TotalMilliseconds}ms";


        }

        private KubLinkedListNode<T> sollution<T>(KubLinkedList<T> list)
        {
            //using dictionary
            Dictionary<KubLinkedListNode<T>, bool> nodeDic = new Dictionary<LinkedLists.KubLinkedListNode<T>, bool>();

            var currentNode = list.Head;
            while (currentNode != null)
            {
                if (nodeDic.ContainsKey(currentNode))
                    return currentNode;
                nodeDic[currentNode] = true;

                currentNode = currentNode.NextNode;
            }

            return null;
        }


    }

}

