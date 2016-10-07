using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testapi.Engine
{
    public class BT
    {
        private Node root;
        private int count;

        public BT()
        {
            root = null;
            count = 0;
        }
        public bool isEmpty()
        {
            return root == null;
        }

        public void insert(data d)
        {
            if (isEmpty())
            {
                root = new Node(d);
            }
            else
            {
                root.insertData(ref root, d);
            }

            count++;
        }

        public bool search(data s)
        {
            return root.search(root, s);
        }

        public bool isLeaf()
        {
            if (!isEmpty())
                return root.isLeaf(ref root);

            return true;
        }

        public void display()
        {
            if (!isEmpty())
                root.display(root);
        }

        public int Count()
        {
            return count;
        }
    }
}