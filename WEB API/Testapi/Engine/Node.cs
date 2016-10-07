using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testapi.Engine
{
    public class Node
    {
        private data number;
        public Node rightLeaf;
        public Node leftLeaf;

        public Node(data value)
        {
            number = value;
            rightLeaf = null;
            leftLeaf = null;
        }

        public bool isLeaf(ref Node node)
        {
            return (node.rightLeaf == null && node.leftLeaf == null);

        }

        public void insertData(ref Node node, data data1)
        {
            if (node == null)
            {
                node = new Node(data1);

            }
            else if (node.number.MW < data1.MW)
            {
                insertData(ref node.rightLeaf, data1);
            }

            else if (node.number.MW > data1.MW)
            {
                insertData(ref node.leftLeaf, data1);
            }
        }

        public bool search(Node node, data s)
        {
            if (node == null)
                return false;

            if (node.number.MW == s.MW)
            {
                return true;
            }
            else if (node.number.MW < s.MW)
            {
                return search(node.rightLeaf, s);
            }
            else if (node.number.MW > s.MW)
            {
                return search(node.leftLeaf, s);
            }

            return false;
        }

        public void display(Node n)
        {
            if (n == null)
                return;

            display(n.leftLeaf);
            Console.Write(" " + n.number.MW);
            display(n.rightLeaf);
        }

    }
}