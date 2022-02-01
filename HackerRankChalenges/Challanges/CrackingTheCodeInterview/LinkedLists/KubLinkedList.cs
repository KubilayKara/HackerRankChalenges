using System.Text;

namespace HackerRankChalenges.Challanges.CrackingTheCodeInterview.LinkedLists
{
    public class KubLinkedList<T1, t2> where t2 : KubLinkedListNode<T1>
    {
        public KubLinkedListNode<T1> Head { get; set; }
        public KubLinkedList()
        {

        }
        public KubLinkedList(T1 headLoad)
        {
            this.Head = new KubLinkedListNode<T1>(headLoad);
        }

        public override string ToString()
        {
            var currentNode = this.Head;
            StringBuilder sb = new StringBuilder();
            while (currentNode != null)
            {
                string s = currentNode.NextNode == null ? currentNode.ToString() : $"{currentNode.ToString()}=>";
                sb.Append(s);
                currentNode = currentNode.NextNode;
            }
            return sb.ToString();
        }
    }

    public class KubLinkedList<T1> : KubLinkedList<T1, KubLinkedListNode<T1>>
    {
        public KubLinkedList(T1 headLoad) : base(headLoad)
        {

        }
    }


    public class DoubleKubLinkedList<T1, T2> : KubLinkedList<T1, T2> where T2 : DoubleKubLinkedListNode<T1>
    {

        public DoubleKubLinkedList(T1 headLoad)
        {
            this.Head = new DoubleKubLinkedListNode<T1>(headLoad);
        }
    }
    public class KubLinkedListNode<T>
    {
        public KubLinkedListNode<T> NextNode { get; set; }
        public T PayLoad { get; set; }
        public KubLinkedListNode(T payload)
        {
            this.PayLoad = payload;
        }

        public override string ToString()
        {
            return this.PayLoad.ToString();
        }
    }

    public class DoubleKubLinkedListNode<T> : KubLinkedListNode<T>
    {
        public DoubleKubLinkedListNode(T payload) : base(payload)
        {
        }

        public KubLinkedListNode<T> PreviousNode { get; set; }
    }
}
