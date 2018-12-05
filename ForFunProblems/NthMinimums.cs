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

            private Node head = null;

            public BST (int[] input)
            {
                Console.WriteLine("Building tree");
                Node current;
                foreach(int element in input)
                {
                    if(head == null)
                    {
                        head = new Node(element);
                        continue;
                    }

                    current = head;
                    while (true)
                    {
                        if(element <= current.Data)
                        {
                            if(current.Left == null)
                            {
                                current.Left = new Node(element);
                                break;
                            }
                            else
                            {
                                current = current.Left;
                            }
                        }
                        else // element > current.Data
                        {
                            if (current.Right == null)
                            {
                                current.Right = new Node(element);
                                break;
                            }
                            else
                            {
                                current = current.Right;
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            public BST(int[] input, int n) //for nth min. will only construct a partial tree
            {
                Console.WriteLine("Building tree");
                Node current;
                foreach (int element in input)
                {
                    if (head == null)
                    {
                        head = new Node(element);
                        continue;
                    }

                    current = head;
                    int leftCount = 0;
                    int rightCount = 0;
                    while (true)
                    {
                        if (element <= current.Data)
                        {
                            if (current.Left == null)
                            {
                                current.Left = new Node(element);
                                break;
                            }
                            else
                            {
                                current = current.Left;
                            }
                        }
                        else // element > current.Data
                        {
                            if (current.Right == null)
                            {
                                current.Right = new Node(element);
                                break;
                            }
                            else
                            {
                                current = current.Right;
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
            private void PrintTree(Node start)
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
                Console.WriteLine("Printing tree (data/left/right)");
                PrintTree(head);
                Console.WriteLine();
            }
        }
        //Dependency on BST class
        public static int FindNthMinimum(int[] input, int n)
        {
            int output = 0;

            BST tree = new BST(input);
            tree.PrintTree();

            return output;
        }
    }
}
