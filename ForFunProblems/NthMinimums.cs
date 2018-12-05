using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProblems
{
    static class NthMinimums
    {
        public static int FindMinimum(int[] input)
        {
            int minimum = input[0]; // Will throw exceptions on bad input here

            foreach(int number in input)
            {
                if(number < minimum)
                {
                    minimum = number;
                }
            }

            return minimum;
        }


        private static class SecondMinimum
        {
            private class Node
            {
                private int data;
                public int Data { get => data; set => data = value; }

                //private Node previous;
                //public Node Previous { get => previous; set => previous = value; }

                private Node next;
                public Node Next { get => next; set => next = value; }

                public Node (int data)
                {
                    this.data = data;
                }

                public Node (int data, Node next)
                {
                    this.data = data;
                    this.next = next;
                }
                public Node Copy()
                {
                    return new Node(this.data, this.next);
                }
                
            }
            public static int Find2ndMinimum(int[] input)
            {
                Node head;
                //Console.WriteLine("Start: {0}, {1}", input[0], input[1]);
                if(input[0] < input[1])
                {
                    head = new Node(input[0]);
                    head.Next = new Node(input[1]);
                }
                else
                {
                    head = new Node(input[1]);
                    head.Next = new Node(input[0]);
                }

                for(int i = 2; i < input.Length; i++)
                {
                    Console.WriteLine("({0}, {1}), {2}?", head.Data, head.Next.Data, input[i]);
                    if(input[i] < head.Data)
                    {
                        Node newMin = new Node(input[i]);
                        newMin.Next = head.Copy();
                        head = newMin;
                    }
                    else if(input[i] < head.Next.Data)
                    {
                        Node new2ndMin = new Node(input[i], head.Next);
                        head.Next = new2ndMin;
                    }
                    else
                    {
                        Node node = new Node(input[i], head.Next.Next);
                        head.Next.Next = node;
                    }
                }

                //PrintList(head);

                return head.Next.Data;
            }

            private static void PrintList (Node display)
            {
                Console.Write("{ ");
                while (display.Next != null)
                {
                    Console.Write(display.Data);
                    Console.Write(", ");
                    display = display.Next;
                }
                Console.Write(display.Data);
                Console.WriteLine(" } end of list");
            }
        }
        // Dependency on SecondMinimum class
        public static int Find2ndMinimum(int[] input)
        {
            return SecondMinimum.Find2ndMinimum(input);
        }

        private class BST
        {
            private Node head = null;
            private class Node
            {
                private int data;
                public int Data { get => data; set => data = value; }

                private Node left;
                public Node Left { get => left; set => left = value; }

                private Node right;
                public Node Right { get => right; set => right = value; }

                public Node (int data)
                {
                    this.data = data;
                    this.left = null;
                    this.right = null;
                }
                
            }

            

            public BST (int[] input) // builds a tree, nothing special
            {
                Console.WriteLine("Building tree");
               
                foreach(int element in input)
                {
                    if(head == null)
                    {
                        head = new Node(element);
                        continue;
                    }

                    Insert(element);
                    
                }
                Console.WriteLine();
            }

            public void Insert(int input)
            {
                Node current = head;
                while (true)
                {
                    if (input <= current.Data)
                    {
                        if (current.Left == null)
                        {
                            current.Left = new Node(input);
                            break;
                        }
                        else
                        {
                            current = current.Left;
                        }
                    }
                    else // input[i] > current.Data
                    {
                        if (current.Right == null)
                        {
                            current.Right = new Node(input);
                            break;
                        }
                        else
                        {
                            current = current.Right;
                        }
                    }
                }
            }

            private void MakeHead_Left_RightNull()
            {
                if (head.Left.Right != null)
                {
                    //remake the head.Left subtree with the right-most value of it as the head(of the subtree, not the entire tree)
                    //Get the largest node and it's parent
                    Node rightParent = head.Left;
                    Node rightmostChild = head.Left.Right;
                    while (rightmostChild.Right != null)
                    {
                        rightParent = rightmostChild;
                        rightmostChild = rightmostChild.Right;
                    }

                    //Get the largest node's left-most child
                    Node leftmostChildOfLargestNode = rightmostChild.Left;
                    while(leftmostChildOfLargestNode.Left != null)
                    {
                        leftmostChildOfLargestNode = leftmostChildOfLargestNode.Left;
                    }

                    //We have all the references we need. Time to move the sub-sub-tree
                    rightParent.Right = null;
                    leftmostChildOfLargestNode.Left = head.Left;
                    head.Left = rightmostChild;
                }
            }

            public BST(int[] input, int n) //for nth min. will only construct a partial tree
            {
                if(n > input.Length) { throw new Exception("n is larger than the array!"); }
                head = new Node(input[0]);

                // Create a left-weighted BST, thus the head is the nth largest in the subset.
                for (int i = 1; i < n; i++)
                {
                    if (input[i] > head.Data)
                    {
                        Node newHead = new Node(input[i]);
                        newHead.Left = head;
                        head = newHead;
                    }
                    else
                    {
                        Insert(input[i]);
                    }
                    
                }
                
                // Make sure head.Left.Right = null
                

                for(int i = n; i < input.Length; i++)
                {
                    if(input[i] < head.Data)
                    {

                    }
                }
            }
            private void PrintTree(Node start) // in-order traversal
            {
                
                if(start.Left != null)
                {
                    PrintTree(start.Left);
                }
                Console.Write("{0} ", start.Data);
                if (start.Right != null)
                {
                    PrintTree(start.Right);
                }
            }

            public void PrintTree()
            {
                Console.WriteLine("Printing in-order traversal");
                PrintTree(head);
                Console.WriteLine();
            }
        }
        //Dependency on BST class
        public static int FindNthMinimum(int[] input, int n)
        {
            int output = 0;

            BST tree = new BST(input, n);
            tree.PrintTree();

            return output;
        }
    }
}
