using System.Collections.Generic;

namespace HackerRankChalenges.Challanges.CrackingTheCodeInterview.LinkedLists
{
    internal class SumLists : Chalange
    {
        /*
            Sum Lists: You have two numbers represented by a linked list, where each node contains a single
            digit. The digits are stored in reverse order, such that the 1 's digit is at the head of the list. Write a
            function that adds the two numbers and returns the sum as a linked list.
            EXAMPLE
            Input: (7-> 1 -> 6) + (5 -> 9 -> 2).That is,617 + 295.
            Output: 2 -> 1 -> 9. That is, 912.
            FOLLOW UP
            Suppose the digits are stored in forward order. Repeat the above problem.
            EXAMPLE
            lnput:(6 -> 1 -> 7) + (2 -> 9 -> 5).That is,617 + 295.
            Output: 9 - > 1 -> 2. That is, 912.

         */






        public override void SetParameters()
        {
            this.ChalangeParameters = new List<ChalengeParameter> { new ChalengeParameter("List1", "7 1 6"), new ChalengeParameter("List2", "5 9 2") };
            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {
            KubLinkedList<int> list1 = Utility.ArrayToLinkedList(Utility.StringToIntagerList(parameters[0], ' ').ToArray());
            KubLinkedList<int> list2 = Utility.ArrayToLinkedList(Utility.StringToIntagerList(parameters[1], ' ').ToArray());

            var result = sollution(list1, list2);
            var result2 = sollution_2(list1, list2);
            return $"result1:{result}\nresult2:{result2}";


        }

        private KubLinkedList<int> sollution(KubLinkedList<int> list1, KubLinkedList<int> list2)
        {
            //digit numbers of lists can be different

            var list1Current = list1.Head;
            var list2Current = list2.Head;
            KubLinkedList<int> result = null;
            KubLinkedListNode<int> resultTail = null;
            int numberToAdd = 0;
            while (list1Current != null || list2Current != null)
            {
                int total = 0;
                if (list1Current != null)
                {
                    total += list1Current.PayLoad;
                    list1Current = list1Current.NextNode;
                }

                if (list2Current != null)
                {
                    total += list2Current.PayLoad;
                    list2Current = list2Current.NextNode;
                }

                total += numberToAdd;
                numberToAdd = total / 10;

                int r = total % 10;
                if (result == null)
                {
                    result = new KubLinkedList<int>(r);
                    resultTail = result.Head;
                }
                else
                {
                    var newNode = new KubLinkedListNode<int>(r);
                    resultTail.NextNode = newNode;
                    resultTail = newNode;
                }
            }
            if (numberToAdd > 0)
                resultTail.NextNode = new KubLinkedListNode<int>(numberToAdd);

            return result;

        }

        private KubLinkedList<int> sollution_2(KubLinkedList<int> list1, KubLinkedList<int> list2)
        {
            Stack<int> s1 = new Stack<int>();
            AddValuesToStack(list1.Head, s1);

            Stack<int> s2 = new Stack<int>();
            AddValuesToStack(list2.Head, s2);

            int numberToAdd = 0;
            KubLinkedListNode<int> resultHead = null;
            while (true)
            {
                s1.TryPop(out int n1);
                s2.TryPop(out int n2);
                if (n1 == 0 && n2 == 0)
                {
                    if (numberToAdd > 0)
                    {
                        var newNode = new KubLinkedListNode<int>(numberToAdd);
                        newNode.NextNode = resultHead;
                        resultHead = newNode;
                    }
                    break;
                }
                else
                {
                    int total = n1 + n2 + numberToAdd;
                    numberToAdd = total / 10;
                    var newNode = new KubLinkedListNode<int>(total % 10);
                    newNode.NextNode = resultHead;
                    resultHead = newNode;
                }
            }
            return new KubLinkedList<int>() { Head = resultHead };
        }

        private void AddValuesToStack<T>(KubLinkedListNode<T> node, Stack<T> stack)
        {
            if (node == null)
                return;
            stack.Push(node.PayLoad);
            AddValuesToStack(node.NextNode, stack);
        }
    }

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
                            NextNode  = new KubLinkedListNode<int>(4)
                            {
                                NextNode =  new KubLinkedListNode<int>(5)
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

