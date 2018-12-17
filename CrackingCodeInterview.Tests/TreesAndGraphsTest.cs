using System;
using Xunit;

using Xunit.Extensions;
using Xunit.Sdk;
using CrackingCodeInterview.Solutions.TreesAndGraphs;
using CrackingCodeInterview.Solutions.LinkedLists;
using System.Collections.Generic;

namespace CrackingCodeInterview.Tests
{
    public class TreesAndGraphsTest
    {

        [Theory]
        [MemberData(nameof(sampleTree))]
        public void KthSmallestTest(TreeNode<int> treeRoot, int inputIndex, int expected)
        {
            List<int> list = KThSmallest<int>.inOrderTravese(treeRoot);
            Assert.Equal(expected, list[inputIndex - 1]);
        }


        [Theory]
        [MemberData(nameof(sampleTree))]
        public void KthSmallestTest1(TreeNode<int> treeRoot, int inputIndex, int expected)
        {
            KThSmallest<int>.Result result = new KThSmallest<int>.Result();
            KThSmallest<int>.findKThSmallest(treeRoot, inputIndex, result);

            Assert.Equal(expected, result.item);
        }



        public static IEnumerable<object[]> sampleTree
        {
            get
            {

                TreeNode<int> treeRoot = new TreeNode<int>(20);
                treeRoot.children = new TreeNode<int>[] { new TreeNode<int>(8), new TreeNode<int>(22) };
                treeRoot.children[0].children = new TreeNode<int>[] { new TreeNode<int>(4), new TreeNode<int>(12) };
                treeRoot.children[0].children[1].children = new TreeNode<int>[] { new TreeNode<int>(10), new TreeNode<int>(14) };

                return new List<object[]>
                {
                new object[] { treeRoot,3, 10  }
                ,new object[] { treeRoot,5, 14  }
                };
            }
        }




        [Theory]
        [MemberData(nameof(sampleGraphReal))]
        public void RouteBetweenNodesBreadthFirstTest(Graph<int> aGraph, GraphNode<int> node1, GraphNode<int> node2, bool expectedResult)
        {
            bool result = RouteBetweenNodes.IsRouteBetweenNodesBreadthFirst(aGraph, node1, node2);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [MemberData(nameof(sampleGraphReal))]
        public void RouteBetweenNodesDepthFirstTest(Graph<int> aGraph, GraphNode<int> node1, GraphNode<int> node2, bool expectedResult)
        {

            foreach (var node in aGraph.nodes)
            {
                node.visited = false;
            }

            bool result = RouteBetweenNodes.IsRouteBetweenNodesDepthFirst(node1, node2);
            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> sampleGraphReal
        {
            get
            {
                GraphNode<int> node0 = new GraphNode<int>(0)
                , node1 = new GraphNode<int>(1)
                , node2 = new GraphNode<int>(2)
                , node3 = new GraphNode<int>(3);

                node0.children.Add(node1); //0->1
                node1.children.Add(node2); //1->2
                node2.children.Add(node0); //2->0
                node3.children.Add(node2); //3->2


                Graph<int> graph = new Graph<int>();
                graph.nodes.Add(node0);
                graph.nodes.Add(node1);
                graph.nodes.Add(node2);
                graph.nodes.Add(node3);

                return new List<object[]>
                {
                new object[] { graph,node0, node0, true  }
                ,new object[] { graph,node3, node0, true  }
                ,new object[] { graph,node0, node3, false  }
                };
            }
        }

        [Theory]
        [MemberData(nameof(sampleMinimalTree))]
        public void BuildMinimalTreeTest(int[] aArray, TreeNode<int> aExpectedTree)
        {
            TreeNode<int> aTree = null;
            MinimalTree.BuildMinimalTree(aArray, ref aTree);
            Assert.Equal(aExpectedTree, aTree);
        }

        public static IEnumerable<object[]> sampleMinimalTree
        {
            get
            {
                TreeNode<int> tree8 = new TreeNode<int>(8);
                tree8.children = new TreeNode<int>[2];
                TreeNode<int> tree5 = new TreeNode<int>(5);
                TreeNode<int> tree10 = new TreeNode<int>(10);
                tree8.children[0] = tree5;
                tree8.children[1] = tree10;
                TreeNode<int> tree3 = new TreeNode<int>(3);
                TreeNode<int> tree7 = new TreeNode<int>(7);

                tree5.children = new TreeNode<int>[2];
                tree5.children[0] = tree3;
                tree5.children[1] = tree7;

                TreeNode<int> tree1 = new TreeNode<int>(1);

                tree3.children = new TreeNode<int>[1];
                tree3.children[0] = tree1;

                TreeNode<int> tree9 = new TreeNode<int>(9);
                TreeNode<int> tree11 = new TreeNode<int>(11);
                tree10.children = new TreeNode<int>[2];
                tree10.children[0] = tree9;
                tree10.children[1] = tree11;

                int[] array1 = new int[] { 1, 3, 5, 7, 8, 9, 10, 11 };
                return new List<object[]>
                {
                new object[] { array1,tree8}

                };
            }
        }



        [Theory]
        [MemberData(nameof(sampleListOfDepths))]
        public void ListOfDepthsTest(TreeNode<int> root, List<LinkedList<TreeNode<int>>> expectedLinkedList)
        {

            List<LinkedList<TreeNode<int>>> result = ListOfDepths<int>.createLevelLinkedList(root);
            Assert.Equal(expectedLinkedList, result);
        }

        [Theory]
        [MemberData(nameof(sampleListOfDepths))]
        public void ListOfDepthsBFSTest(TreeNode<int> root, List<LinkedList<TreeNode<int>>> expectedLinkedList)
        {

            List<LinkedList<TreeNode<int>>> result = ListOfDepths<int>.createLevelLinkedlistBFS(root);
            Assert.Equal(expectedLinkedList, result);
        }
        public static IEnumerable<object[]> sampleListOfDepths
        {
            get
            {
                TreeNode<int> tree8 = new TreeNode<int>(8);
                tree8.children = new TreeNode<int>[2];
                TreeNode<int> tree5 = new TreeNode<int>(5);
                TreeNode<int> tree10 = new TreeNode<int>(10);
                tree8.children[0] = tree5;
                tree8.children[1] = tree10;
                TreeNode<int> tree3 = new TreeNode<int>(3);
                TreeNode<int> tree7 = new TreeNode<int>(7);

                tree5.children = new TreeNode<int>[2];
                tree5.children[0] = tree3;
                tree5.children[1] = tree7;

                TreeNode<int> tree1 = new TreeNode<int>(1);

                tree3.children = new TreeNode<int>[1];
                tree3.children[0] = tree1;

                TreeNode<int> tree9 = new TreeNode<int>(9);
                TreeNode<int> tree11 = new TreeNode<int>(11);
                tree10.children = new TreeNode<int>[2];
                tree10.children[0] = tree9;
                tree10.children[1] = tree11;

                //int[] array1 = new int[] { 1, 3, 5, 7, 8, 9, 10, 11 };
                List<LinkedList<TreeNode<int>>> expectedLinkedList = new List<LinkedList<TreeNode<int>>>();
                LinkedList<TreeNode<int>> depth0 = new LinkedList<TreeNode<int>>();
                depth0.AddLast(tree8);
                LinkedList<TreeNode<int>> depth1 = new LinkedList<TreeNode<int>>();
                depth1.AddLast(tree5);
                depth1.AddLast(tree10);
                LinkedList<TreeNode<int>> depth2 = new LinkedList<TreeNode<int>>();
                depth2.AddLast(tree3);
                depth2.AddLast(tree7);
                depth2.AddLast(tree9);
                depth2.AddLast(tree11);
                LinkedList<TreeNode<int>> depth3 = new LinkedList<TreeNode<int>>();
                depth3.AddLast(tree1);
                expectedLinkedList.Add(depth0);
                expectedLinkedList.Add(depth1);
                expectedLinkedList.Add(depth2);
                expectedLinkedList.Add(depth3);
                return new List<object[]>
                {
                new object[] { tree8, expectedLinkedList}

                };
            }
        }


        [Theory]
        [MemberData(nameof(sampleListOfCheckBalanced))]
        public void CheckBalancedTest(TreeNode<int> root, bool expected)
        {

            bool result = CheckBalanced<int>.IsBalanced(root);
            Assert.Equal(expected, result);
        }
        public static IEnumerable<object[]> sampleListOfCheckBalanced
        {
            get
            {
                TreeNode<int> tree8 = new TreeNode<int>(8);
                tree8.children = new TreeNode<int>[2];
                TreeNode<int> tree5 = new TreeNode<int>(5);
                TreeNode<int> tree10 = new TreeNode<int>(10);
                tree8.children[0] = tree5;
                tree8.children[1] = tree10;
                TreeNode<int> tree3 = new TreeNode<int>(3);
                TreeNode<int> tree7 = new TreeNode<int>(7);

                tree5.children = new TreeNode<int>[2];
                tree5.children[0] = tree3;
                tree5.children[1] = tree7;

                TreeNode<int> tree1 = new TreeNode<int>(1);

                tree3.children = new TreeNode<int>[1];
                tree3.children[0] = tree1;

                TreeNode<int> tree9 = new TreeNode<int>(9);
                TreeNode<int> tree11 = new TreeNode<int>(11);
                tree10.children = new TreeNode<int>[2];
                tree10.children[0] = tree9;
                tree10.children[1] = tree11;

                //int[] array1 = new int[] { 1, 3, 5, 7, 8, 9, 10, 11 };

                return new List<object[]>
                {
                new object[] { tree8, true}

                };
            }
        }

        //
        [Theory]
        [MemberData(nameof(sampleListOfValidateBST))]
        public void ValidateBSTTest(TreeNode<int> root, bool expected)
        {

            bool result = ValidateBST.IsValidBST(root, int.MinValue, int.MaxValue);
            Assert.Equal(expected, result);
        }
        public static IEnumerable<object[]> sampleListOfValidateBST
        {
            get
            {
                TreeNode<int> tree8 = new TreeNode<int>(8);
                tree8.children = new TreeNode<int>[2];
                TreeNode<int> tree5 = new TreeNode<int>(5);
                TreeNode<int> tree10 = new TreeNode<int>(10);
                tree8.children[0] = tree5;
                tree8.children[1] = tree10;
                TreeNode<int> tree3 = new TreeNode<int>(3);
                TreeNode<int> tree7 = new TreeNode<int>(7);

                tree5.children = new TreeNode<int>[2];
                tree5.children[0] = tree3;
                tree5.children[1] = tree7;

                TreeNode<int> tree1 = new TreeNode<int>(1);

                tree3.children = new TreeNode<int>[1];
                tree3.children[0] = tree1;

                TreeNode<int> tree9 = new TreeNode<int>(9);
                TreeNode<int> tree11 = new TreeNode<int>(11);
                tree10.children = new TreeNode<int>[2];
                tree10.children[0] = tree9;
                tree10.children[1] = tree11;

                //int[] array1 = new int[] { 1, 3, 5, 7, 8, 9, 10, 11 };

                return new List<object[]>
                {
                new object[] { tree8, true}

                };
            }
        }

        // SuccessorTest
        [Theory]
        [MemberData(nameof(sampleListOfSuccessorTest))]
        public void SuccessorTest(SuccessorBSTNode node, SuccessorBSTNode expectedSuccessorNode)
        {

            SuccessorBSTNode result = node.nextNodeInOrder();
            if (expectedSuccessorNode == null)
                Assert.Equal(expectedSuccessorNode, result);
            else
                Assert.Equal(expectedSuccessorNode.value, result.value);
        }
        public static IEnumerable<object[]> sampleListOfSuccessorTest
        {
            get
            {
                SuccessorBSTNode node100 = new SuccessorBSTNode(100), node200 = new SuccessorBSTNode(200), node50 = new SuccessorBSTNode(50),
                node25 = new SuccessorBSTNode(25), node75 = new SuccessorBSTNode(75), node12 = new SuccessorBSTNode(12), node37 = new SuccessorBSTNode(37),
                node62 = new SuccessorBSTNode(62), node87 = new SuccessorBSTNode(87), node80 = new SuccessorBSTNode(80), node90 = new SuccessorBSTNode(90);

                node100.left = node50; node50.parent = node100;
                node100.right = node200; node200.parent = node100;

                node50.left = node25; node25.parent = node50;
                node50.right = node75; node75.parent = node50;

                node25.left = node12; node12.parent = node25;
                node25.right = node37; node37.parent = node25;

                node75.left = node62; node62.parent = node75;
                node75.right = node87; node87.parent = node75;

                node87.left = node80; node80.parent = node87;
                node87.right = node90; node90.parent = node87;

                return new List<object[]>
                {
                new object[] { node200, null},
                new object[] { node37, node50}
                ,
                new object[] { node90, node100}
                ,
                new object[] { node62, node75}
                };
            }
        }


        // [Theory]
        // [MemberData(nameof(sampleBuildOrderTest))]
        // public void BuildOrderTest1(List<char> projectList, /* char[,] */Dictionary<char, List<char>> aProjectDepedencyList, List<char> expectedProjectBuildOrder)
        // {

        //     List<char> buildOrder = BuildOrder.calculateBuildOrder(projectList, aProjectDepedencyList);
        //     Assert.Equal(expectedProjectBuildOrder, buildOrder);
        // }
        [Theory]
        [MemberData(nameof(sampleBuildOrderTest))]
        public void BuildOrderTest2(List<char> projectList, /* char[,] */Dictionary<char, List<char>> aProjectDepedencyList, List<char> expectedProjectBuildOrder)
        {

            List<char> buildOrder = BuildOrder.calculateBuildOrder2(projectList, aProjectDepedencyList);
            Assert.Equal(expectedProjectBuildOrder, buildOrder);
        }


        public static IEnumerable<object[]> sampleBuildOrderTest
        {
            get
            {
                List<char> projectList = new List<char>();
                projectList.AddRange(new char[] { 'f', 'c', 'b', 'a', 'e', 'd', 'g' });


                Dictionary<char, List<char>> aProjectDepedencyList = new Dictionary<char, List<char>>();

                aProjectDepedencyList.Add('f', new List<char>() { 'c', 'b', 'a' });
                aProjectDepedencyList.Add('c', new List<char>() { 'a' });
                aProjectDepedencyList.Add('b', new List<char>() { 'a', 'e' });
                aProjectDepedencyList.Add('a', new List<char>() { 'e' });
                aProjectDepedencyList.Add('d', new List<char>() { 'g' });

                List<char> orderedProjectList = new List<char>();
                /* orderedProjectList.AddRange(new char[] { 'e', 'f', 'a', 'b', 'd', 'c' }); */

                orderedProjectList.AddRange(new char[] { 'd', 'g', 'f', 'b', 'c', 'a', 'e' });

                //return null;
                return new List<object[]>
                {
                    new object[]{projectList, aProjectDepedencyList, orderedProjectList}
                };
            }
        }


        [Theory]
        [MemberData(nameof(sampleListOfFirstCommonAncestor))]
        public void FirstCommonAncestorTest(TreeNode<int> root, TreeNode<int> p, TreeNode<int> q, TreeNode<int> expectedResult)
        {

            TreeNode<int> result = FirstCommonAncestor<int>.firstCommonAncestor(root, p, q);
            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [MemberData(nameof(sampleListOfFirstCommonAncestor))]
        public void FirstCommonAncestorTestMoreEfficient(TreeNode<int> root, TreeNode<int> p, TreeNode<int> q, TreeNode<int> expectedResult)
        {

            TreeNode<int> result = FirstCommonAncestor<int>.commonAncestor(root, p, q);
            Assert.Equal(expectedResult, result);
        }
        public static IEnumerable<object[]> sampleListOfFirstCommonAncestor
        {
            get
            {
                TreeNode<int> tree8 = new TreeNode<int>(8);
                tree8.children = new TreeNode<int>[2];
                TreeNode<int> tree5 = new TreeNode<int>(5);
                TreeNode<int> tree10 = new TreeNode<int>(10);
                tree8.children[0] = tree5;
                tree8.children[1] = tree10;
                TreeNode<int> tree3 = new TreeNode<int>(3);
                TreeNode<int> tree7 = new TreeNode<int>(7);

                tree5.children = new TreeNode<int>[2];
                tree5.children[0] = tree3;
                tree5.children[1] = tree7;

                TreeNode<int> tree1 = new TreeNode<int>(1);

                tree3.children = new TreeNode<int>[1];
                tree3.children[0] = tree1;

                TreeNode<int> tree9 = new TreeNode<int>(9);
                TreeNode<int> tree11 = new TreeNode<int>(11);
                tree10.children = new TreeNode<int>[2];
                tree10.children[0] = tree9;
                tree10.children[1] = tree11;

                TreeNode<int> tree12 = new TreeNode<int>(12);
                //int[] array1 = new int[] { 1, 3, 5, 7, 8, 9, 10, 11 };

                return new List<object[]>
                {
                new object[] { tree8, tree3, tree7, tree5}
                ,new object[] { tree8, tree1, tree5, tree5}
                ,new object[] { tree8, tree1, tree11, tree8}
                };
            }
        }

        //allSequences
        [Theory]
        [MemberData(nameof(sampleListOfBSTSequences))]
        public void BSTSequencesTest(TreeNode<int> root, List<LinkedList<int>> expectedResult)
        {

            List<LinkedList<int>> result = BSTSequences<int>.allSequences(root);
            Assert.Equal(expectedResult, result);
        }
        public static IEnumerable<object[]> sampleListOfBSTSequences
        {
            get
            {
                 TreeNode<int> tree2 = new TreeNode<int>(2);
                tree2.children = new TreeNode<int>[2];
                TreeNode<int> tree1 = new TreeNode<int>(1);
                TreeNode<int> tree3 = new TreeNode<int>(3);
                tree2.children[0] = tree1;
                tree2.children[1] = tree3;
                
                
                List<LinkedList<int>> expectedResult = new List<LinkedList<int>>();
                LinkedList<int> l1=new LinkedList<int>(), l2 = new LinkedList<int>();
                l1.AddLast(2); l1.AddLast(1); l1.AddLast(3);
                expectedResult.Add(l1);

                l2.AddLast(2); l2.AddLast(3); l2.AddLast(1);
                expectedResult.Add(l2);
                return new List<object[]>
                {
                new object[] { tree2, expectedResult}                
                };
            }
        }

    }
}