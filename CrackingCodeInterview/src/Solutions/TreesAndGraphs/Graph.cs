using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCodeInterview.Solutions.TreesAndGraphs
{
    public class GraphNode<T>
    {
        public T item;
        public List<GraphNode<T>> children = new List<GraphNode<T>>();

        public bool visited;

        public GraphNode(T aItem)
        {
            item = aItem;
        }

        public override string ToString()
        {
            return item.ToString().Trim();
        }
    }
    public class Graph<T>
    {
        public List<GraphNode<T>> nodes = new List<GraphNode<T>>();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < nodes.Count; i++)
            {
                sb.Append(nodes[i].item.ToString());
                sb.Append(i == nodes.Count - 1 ? string.Empty : "-");
            }

            return sb.ToString().Trim();
        }

        public GraphNode<T> getElement(T aItem)
        {
            foreach (var item in nodes)
            {
                if(item.item.Equals(aItem))
                    return item;
            }
            return null;
        }
    }

}