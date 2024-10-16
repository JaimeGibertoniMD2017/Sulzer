using System;
using System.Collections.Generic;

namespace FlightBestRoutePlanner.Data
{
    public class FibonacciHeap<T> where T : IComparable<T>
    {
        private class Node
        {
            public T Key { get; set; }
            public int Degree { get; set; }
            public Node Parent { get; set; }
            public Node Child { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public bool Mark { get; set; }
            public int VertexIndex { get; set; }

            public Node(T key, int vertexIndex)
            {
                Key = key;
                VertexIndex = vertexIndex;
                Left = Right = this;
            }
        }

        private Node min;
        private int size;
        private Dictionary<int, Node> nodes;

        public FibonacciHeap() => nodes = [];

        public void Insert(T key, int vertexIndex)
        {
            Node node = new Node(key, vertexIndex);
            nodes[vertexIndex] = node;
            if (min == null)
            {
                min = node;
            }
            else
            {
                InsertNode(node);
                if (node.Key.CompareTo(min.Key) < 0)
                {
                    min = node;
                }
            }
            size++;
        }

        private void InsertNode(Node node)
        {
            node.Left = min;
            node.Right = min.Right;
            min.Right = node;
            node.Right.Left = node;
        }

        public int ExtractMin()
        {
            Node z = min;
            if (z != null)
            {
                if (z.Child != null)
                {
                    Node child = z.Child;
                    do
                    {
                        Node next = child.Right;
                        InsertNode(child);
                        child.Parent = null;
                        child = next;
                    } while (child != z.Child);
                }
                z.Left.Right = z.Right;
                z.Right.Left = z.Left;
                if (z == z.Right)
                {
                    min = null;
                }
                else
                {
                    min = z.Right;
                    Consolidate();
                }
                size--;
                nodes.Remove(z.VertexIndex);
            }
            return z != null ? z.VertexIndex : -1;
        }

        private void Consolidate()
        {
            double phi = (1 + Math.Sqrt(5)) / 2;
            int maxDegree = (int)Math.Floor(Math.Log(size) / Math.Log(phi));
            Node[] A = new Node[maxDegree + 1];

            List<Node> rootList = new List<Node>();
            Node current = min;
            do
            {
                rootList.Add(current);
                current = current.Right;
            } while (current != min);

            foreach (Node w in rootList)
            {
                Node x = w;
                int d = x.Degree;
                while (A[d] != null)
                {
                    Node y = A[d];
                    if (x.Key.CompareTo(y.Key) > 0)
                    {
                        Node temp = x;
                        x = y;
                        y = temp;
                    }
                    Link(y, x);
                    A[d] = null;
                    d++;
                }
                A[d] = x;
            }

            min = null;
            for (int i = 0; i <= maxDegree; i++)
            {
                if (A[i] != null)
                {
                    if (min == null)
                    {
                        min = A[i];
                    }
                    else
                    {
                        InsertNode(A[i]);
                        if (A[i].Key.CompareTo(min.Key) < 0)
                        {
                            min = A[i];
                        }
                    }
                }
            }
        }

        private void Link(Node y, Node x)
        {
            y.Left.Right = y.Right;
            y.Right.Left = y.Left;
            y.Parent = x;
            if (x.Child == null)
            {
                x.Child = y;
                y.Right = y;
                y.Left = y;
            }
            else
            {
                y.Left = x.Child;
                y.Right = x.Child.Right;
                x.Child.Right = y;
                y.Right.Left = y;
            }
            x.Degree++;
            y.Mark = false;
        }

        public void DecreaseKey(int vertexIndex, T newKey)
        {
            Node x = nodes[vertexIndex];
            if (newKey.CompareTo(x.Key) > 0)
                throw new ArgumentException("New key is greater than current key");

            x.Key = newKey;
            Node y = x.Parent;
            if (y != null && x.Key.CompareTo(y.Key) < 0)
            {
                Cut(x, y);
                CascadingCut(y);
            }
            if (x.Key.CompareTo(min.Key) < 0)
                min = x;
        }

        private void Cut(Node x, Node y)
        {
            x.Left.Right = x.Right;
            x.Right.Left = x.Left;
            y.Degree--;
            if (y.Child == x)
                y.Child = x.Right;
            if (y.Degree == 0)
                y.Child = null;
            x.Left = min;
            x.Right = min.Right;
            min.Right = x;
            x.Right.Left = x;
            x.Parent = null;
            x.Mark = false;
        }

        private void CascadingCut(Node y)
        {
            Node z = y.Parent;
            if (z != null)
            {
                if (!y.Mark)
                {
                    y.Mark = true;
                }
                else
                {
                    Cut(y, z);
                    CascadingCut(z);
                }
            }
        }

        public bool IsEmpty() => min == null;
    }
}
