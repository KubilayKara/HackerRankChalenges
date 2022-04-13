using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges.Challanges.LeetCode75.Graph
{
    public class LeetCloneGraph : Chalange
    {

        public override void SetParameters()
        {
            this.url = "https://leetcode.com/problems/clone-graph/";
            this.ChalangeParameters = new List<ChalengeParameter>();
            base.SetParameters();
        }
        public override string Run(string[] parameters)
        {
            Node n1 = new Node { val = 1 };
            Node n2 = new Node { val = 2 };
            Node n3 = new Node { val = 3 };
            Node n4 = new Node { val = 4 };
            n1.neighbors = new List<Node> { n2, n4 };
            n2.neighbors = new List<Node> { n3, n1 };
            n3.neighbors = new List<Node> { n4, n2 };
            n4.neighbors = new List<Node> { n1, n3 };

            nodeList = new Dictionary<int, Node>();
            var result = this.CloneGraph(n1);
            return result.ToString();
        }

        Dictionary<int, Node> nodeList = new Dictionary<int, Node>();
        public Node CloneGraph(Node node)
        {
            if (node == null)
                return null;

            if (nodeList.ContainsKey(node.val))
                return nodeList[node.val];

            Node currentNode = new Node { val = node.val, neighbors = new List<Node>() };
            nodeList[node.val] = currentNode;
            foreach (var neigbour in node.neighbors)
            {
                currentNode.neighbors.Add(CloneGraph(neigbour));
            }
            return currentNode;
        }

        // Definition for a Node.
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }



    }
}
