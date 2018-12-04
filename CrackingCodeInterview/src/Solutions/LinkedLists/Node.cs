using System;
using System.Text;

namespace CrackingCodeInterview.Solutions.LinkedLists
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Value { get; set; }

        public Node(T value) => Value = value;

        //public override bool Equals(Node<T> obj)
        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            if (!(obj is Node<T>)) return false;
            if (this == obj) return true;    //bu probleme neden olabilir mi? 20181113
            Node<T> newOne = obj as Node<T>;
            Node<T> thisOne = this;
            do
            {
                if (!thisOne.Value.Equals(newOne.Value)) return false;
                newOne = newOne.Next;
                thisOne = thisOne.Next;

            } while (thisOne != null && newOne != null);

            return thisOne == null && newOne == null;
        }

        public override string ToString()
        {
            Node<T> loopDetected = LoopDetection.DetectLoop(this);
            if (loopDetected != null)
                return "Loop Detected!!!";
            Node<T> currentNode = this;
            StringBuilder sb = new StringBuilder();
            while (currentNode != null)
            {
                sb.Append(currentNode.Value);
                if (currentNode.Next != null)
                    sb.Append("->");
                currentNode = currentNode.Next;
            }
            return sb.ToString().Trim();
        }
        public int Length
        {
            get
            {
                Node<T> loopDetected = LoopDetection.DetectLoop(this);
                if (loopDetected != null)
                    return -1;//loop
                int len = 0;
                Node<T> currentNode = this;
                while (currentNode != null)
                {
                    len++;
                    currentNode = currentNode.Next;
                }
                return len;
            }
        }


        public Node<T> firstXNodes(int numberOfNodes)
        {
            int len = this.Length;
            if (len < numberOfNodes) return null;

            if (len == numberOfNodes) return this;

            Node<T> currentNode = this;
            Node<T> firstXNodesHead = null, firstXNodes = null;
            for (int i = 0; i < numberOfNodes; i++)
            {
                if (firstXNodes == null)
                {
                    firstXNodesHead = new Node<T>(currentNode.Value);
                    firstXNodes = firstXNodesHead;
                }
                else
                {
                    firstXNodes = new Node<T>(currentNode.Value);
                }

                firstXNodes = firstXNodes.Next;
                currentNode = currentNode.Next;

            }
            return firstXNodesHead;
        }

        public Node<T> lastXNodes(int numberOfNodes)
        {
            int len = this.Length;
            if (len < numberOfNodes) return null;

            if (len == numberOfNodes) return this;

            Node<T> currentNode = this;
            Node<T> lastXNodesHead = null, lastXNodes = null;

            for (int i = 0; i < len; i++)
            {
                if (i < len / 2 + len % 2)
                {
                    currentNode = currentNode.Next;
                    continue;
                }
                if (lastXNodes == null)
                {
                    lastXNodesHead = new Node<T>(currentNode.Value);
                    lastXNodes = lastXNodesHead;
                }
                else
                {
                    lastXNodes = new Node<T>(currentNode.Value);
                }

                lastXNodes = lastXNodes.Next;
                currentNode = currentNode.Next;

            }
            return lastXNodesHead;
        }


        public Node<T> reverseNodes()
        {
            Node<T> reverseNode = null; //always points to header node
            Node<T> currentNode = this;
            while (currentNode != null)
            {
                currentNode.Next = reverseNode;
                reverseNode = currentNode;

                currentNode = currentNode.Next;
            }
            return reverseNode;
        }

    }

}