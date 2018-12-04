using System;
using System.Collections.Generic;
using System.Linq;

namespace CrackingCodeInterview.Solutions.TreesAndGraphs
{
    public class BuildOrder
    {
        public static List<T> calculateBuildOrder<T>(List<T> aProjects, Dictionary<T, List<T>> aProjectDepedencyList)
        {

            Graph<T> graph = buildGraph(aProjects, aProjectDepedencyList);

            //Solution1: find node that don't have inbound edge, add it to return list and remove from Graph, 
            List<T> buildOrderList = new List<T>();


            while (graph.nodes.Count > 0)
            {
                List<T> nodes = new List<T>(), nodesHavingInboundEdge = new List<T>();
                foreach (var node in graph.nodes)
                {
                    nodes.Add(node.item);
                    foreach (var child in node.children)
                    {
                        if (!nodesHavingInboundEdge.Contains(child.item))
                            nodesHavingInboundEdge.Add(child.item);
                    }
                }

                var except = nodes.Except(nodesHavingInboundEdge).ToList();
                buildOrderList.AddRange(except);
                graph.nodes.RemoveAll(node => except.Contains(node.item));

            }
            return buildOrderList;
        }


        private static Graph<T> buildGraph<T>(List<T> aProjects, Dictionary<T, List<T>> aProjectDepedencyList)
        {
            Graph<T> graph = new Graph<T>();
            foreach (var item in aProjects)
            {
                graph.nodes.Add(new GraphNode<T>(item));
            }

            foreach (var node in graph.nodes)
            {
                if (aProjectDepedencyList.ContainsKey(node.item))
                {
                    List<T> adjacents = aProjectDepedencyList[node.item];
                    foreach (var item in adjacents)
                    {
                        node.children.Add(graph.getElement(item));
                    }
                }
            }
            return graph;
        }


        public static List<T> calculateBuildOrder2<T>(List<T> aProjects, Dictionary<T, List<T>> aProjectDepedencyList)
        {
            Graph<T> graph = buildGraph(aProjects, aProjectDepedencyList);
            Stack<T> stack = new Stack<T>();

            while (graph.nodes.Exists(node => !node.visited))
            {
                recursiveBuildOrder(/* graph,*/ graph.nodes.First(node => node.visited == false), stack);
            }
            return stack.ToList();
            //return null;
        }

        private static void recursiveBuildOrder<T>(/* Graph<T> aGraph,  */GraphNode<T> aArbitraryNode, Stack<T> aStack)
        {
            if (aArbitraryNode.children.Count == 0)
            {
                aStack.Push(aArbitraryNode.item);
                aArbitraryNode.visited = true;
                return;
            }

            foreach (var child in aArbitraryNode.children)
            {
                if (child.visited == false)
                {
                    recursiveBuildOrder(child, aStack);
                }
            }
            if (aArbitraryNode.children.Count > 0)
            {
                aStack.Push(aArbitraryNode.item);
                aArbitraryNode.visited = true;
            }
        }

    }
}