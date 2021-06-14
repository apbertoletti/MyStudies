using System;

namespace DS.BinaryTrees
{
    public class Node
    {
        public int Data { get; set; }

        public Node LeftNode { get; set; }

        public Node RightNode { get; set; }

        public Node(int value)
        {
            Data = value;
        }

        public void InsertNode(int value)
        {
            if (value >= Data)
            {   
                if (RightNode == null)
                {
                    RightNode = new Node(value);
                }
                else
                {
                    RightNode.InsertNode(value);
                }
            }
            else
            {
                if (LeftNode == null)
                {
                    LeftNode = new Node(value);
                }
                else
                {
                    LeftNode.InsertNode(value);
                }
            }
        }

        internal void ShowPreOrderTraversal()
        {
            //First we print the root node 
            Console.Write(Data + " ");

            //Then go to left child its children will be null so we print its data
            if (LeftNode != null)
                LeftNode.ShowPreOrderTraversal();

            //Then we go to the right node which will print itself as both its children are null
            if (RightNode != null)
                RightNode.ShowPreOrderTraversal();
        }

        internal void ShowInOrderTraversal()
        {
            //first go to left child its children will be null so we print its data
            if (LeftNode != null)
                LeftNode.ShowInOrderTraversal();
            
            //Then we print the root node 
            Console.Write(Data + " ");

            //Then we go to the right node which will print itself as both its children are null
            if (RightNode != null)
                RightNode.ShowInOrderTraversal();
        }

        public Node Find(int value)
        {
            if (value == Data)
            {
                return this;
            }
            else if (value < Data && LeftNode != null)
            {
                return LeftNode.Find(value);
            }
            else if (RightNode != null)
            {
                return RightNode.Find(value);
            }
            else
            {
                return null;
            }
        }
    }
}
