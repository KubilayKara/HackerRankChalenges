using System.Collections.Generic;

namespace HackerRankChalenges.Challanges.CrackingTheCodeInterview.LinkedLists
{
    internal class LinkedListIntersection : Chalange
    {
        /*
            Intersection: Given two (singly) linked lists, determine if the two lists intersect. Return the intersecting
            node. Note that the intersection is defined based on reference, not value. That is, if the kth
            node of the first linked list is the exact same node (by reference) as the jth node of the second
            linked list, then they are intersecting.
            Hints:#20, #45, #55, #65, #76, #93, #111, #120, #129
         */
        public override void SetParameters()
        {
            this.ChalangeParameters = new List<ChalengeParameter> { };
            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {
            KubLinkedListNode<int> commonNode = new KubLinkedListNode<int>(10)
            {
                NextNode = new KubLinkedListNode<int>(11)
                {
                    NextNode = new KubLinkedListNode<int>(12) { }
                }
            };
            KubLinkedList<int> list1 = new KubLinkedList<int>
            {
                Head = new KubLinkedListNode<int>(1)
                {
                    NextNode = new KubLinkedListNode<int>(2)
                    {
                        NextNode = new KubLinkedListNode<int>(3)
                        {
                            NextNode = new KubLinkedListNode<int>(4)
                            {
                                NextNode = new KubLinkedListNode<int>(5)
                                {
                                    NextNode = new KubLinkedListNode<int>(6)
                                    {
                                        NextNode = new KubLinkedListNode<int>(7)
                                        {
                                            NextNode = new KubLinkedListNode<int>(8)
                                            {
                                                NextNode = commonNode
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            KubLinkedList<int> list2 = new KubLinkedList<int>
            {
                Head = new KubLinkedListNode<int>(21)
                {
                    NextNode = new KubLinkedListNode<int>(22)
                    {
                        NextNode = new KubLinkedListNode<int>(23)
                        {
                            NextNode = commonNode
                        }
                    }
                }
            };

            var result1 = Utility.RunAndReturnDuration(() => sollution(list1, list2));
            var result2 = Utility.RunAndReturnDuration(() => sollution_2(list1, list2));
            return $"\nresult1:{result1.functionResult} {result1.duration.TotalMilliseconds}ms\nresult2:{result2.functionResult} {result2.duration.TotalMilliseconds}ms";


        }

        private bool sollution<T>(KubLinkedList<T> list1, KubLinkedList<T> list2)
        {
            //using dictionary
            Dictionary<KubLinkedListNode<T>, bool> nodeDic = new Dictionary<LinkedLists.KubLinkedListNode<T>, bool>();

            var currentNode1 = list1.Head;
            while (currentNode1 != null)
            {
                nodeDic[currentNode1] = true;
                currentNode1 = currentNode1.NextNode;
            }

            var currentNode2 = list2.Head;
            while (currentNode2 != null)
            {
                if (nodeDic.ContainsKey(currentNode2))
                    return true;
                currentNode2 = currentNode2.NextNode;
            }
            return false;
        }

        private bool sollution_2<T>(KubLinkedList<T> list1, KubLinkedList<T> list2)
        {
            return GetTail(list1) == GetTail(list2);
        }

        private static KubLinkedListNode<T> GetTail<T>(KubLinkedList<T> list)
        {
            KubLinkedListNode<T> currentNode = list.Head;
            while (currentNode != null)
            {
                if (currentNode.NextNode == null)
                    return currentNode;
                currentNode = currentNode.NextNode;
            }
            return null;
        }
    }

}

