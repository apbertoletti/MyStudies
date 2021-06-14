using System;

namespace DS.BinaryTrees
{
    class Tree
    {
        public Node RootNode { get; private set; }

        public Node Find(int value)
        {
            if (RootNode != null)
            {
                return RootNode.Find(value);
            }
            else
            {
                return null;
            }
        }

        public void Insert(int value)
        {
            if (RootNode != null)
            {
                RootNode.InsertNode(value);
            }
            else
            {//if the root is null then we set the root to be a new node based on the data passed in
                RootNode = new Node(value);
            }
        }

        public void ShowPreOrderTraversal()
        {
            if (RootNode != null)
                RootNode.ShowPreOrderTraversal();
        }

        internal void ShowInOrderTraversal()
        {
            if (RootNode != null)
                RootNode.ShowInOrderTraversal();
        }
    }
}
