using System;
using System.Collections.Generic;

namespace CrackingCodeInterview.Solutions.TreesAndGraphs
{
    public class RouteBetweenNodes
    {

        public static bool IsRouteBetweenNodesBreadthFirst(Graph<int> aGraph, GraphNode<int> node1, GraphNode<int> node2)
        {
            if (node1 == node2)
                return true;

            foreach (var node in aGraph.nodes)
            {
                node.visited = false;
            }
            Queue<GraphNode<int>> queue = new Queue<GraphNode<int>>();

            node1.visited = true;
            queue.Enqueue(node1);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                if (node.item == node2.item) return true;

                foreach (var adjacentItem in node.children)
                {
                    if (adjacentItem.visited == false)
                    {
                        adjacentItem.visited = true;
                        queue.Enqueue(adjacentItem);
                    }
                }
            }

            return false;
        }

        public static bool IsRouteBetweenNodesDepthFirst(GraphNode<int> node1, GraphNode<int> node2)
        {
            bool result = false;
            node1.visited = true;
            if (node1.item == node2.item)
                return true;
            foreach (var item in node1.children)
            {
                if (item.visited == false)
                {
                    result = IsRouteBetweenNodesDepthFirst(item, node2);
                    if (result) return true;
                }
            }

            return result;
        }
    }

}