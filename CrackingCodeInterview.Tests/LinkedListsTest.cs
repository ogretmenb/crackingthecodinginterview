using System;
using Xunit;

using Xunit.Extensions;
using Xunit.Sdk;
using CrackingCodeInterview.Solutions.LinkedLists;
using System.Collections.Generic;

namespace CrackingCodeInterview.Tests
{
    public class LinkedListsTest
    {
        [Theory]
        [MemberData(nameof(duplicateLinkedList))]
        public void DuplicateRemoval(Node<int> input, Node<int> expected)
        {
            RemoveDups.DuplicateRemoval(input);
            Assert.Equal(expected, input);
        }
        [Theory]
        [MemberData(nameof(duplicateLinkedList))]
        public void DuplicateRemovalNoSpace(Node<int> input, Node<int> expected)
        {
            RemoveDups.DuplicateRemovalNoSpace(input);
            Assert.Equal(expected, input);
        }
        public static IEnumerable<object[]> duplicateLinkedList
        {
            get
            {
                Node<int> node = new Node<int>(10);
                node.Next = new Node<int>(9);
                node.Next.Next = new Node<int>(9);
                node.Next.Next.Next = new Node<int>(8);
                node.Next.Next.Next.Next = new Node<int>(8);
                node.Next.Next.Next.Next.Next = new Node<int>(8);
                node.Next.Next.Next.Next.Next.Next = new Node<int>(1);
                node.Next.Next.Next.Next.Next.Next.Next = new Node<int>(0);
                node.Next.Next.Next.Next.Next.Next.Next.Next = new Node<int>(0);


                Node<int> nodeExpected = new Node<int>(10);
                nodeExpected.Next = new Node<int>(9);
                nodeExpected.Next.Next = new Node<int>(8);
                nodeExpected.Next.Next.Next = new Node<int>(1);
                nodeExpected.Next.Next.Next.Next = new Node<int>(0);
                //nodeExpected.Next.Next.Next.Next.Next = new Node<int>(0);

                return new List<object[]>
                {
                new object[] { node, nodeExpected  }

                };
            }
        }


        [Theory]
        [MemberData(nameof(KthToLastDataListReal))]
        public void ReturnKthToLastRecursiveTest(Node<int> input, Node<int> expected, int indexNumber)
        {
            int index = 0;
            Node<int> KtoLast = ReturnKthToLast.KthToLastListRecursive(input, indexNumber, ref index);
            Assert.Equal(expected, KtoLast);
        }
        [Theory]
        [MemberData(nameof(KthToLastDataListReal))]
        public void nthTolastTest(Node<int> input, Node<int> expected, int indexNumber)
        {
            Node<int> KtoLast = ReturnKthToLast.nthTolast(input, indexNumber);
            Assert.Equal(expected, KtoLast);
        }

        public static IEnumerable<object[]> KthToLastDataList
        {
            get
            {
                Node<int> node = new Node<int>(10);
                node.Next = new Node<int>(9);
                node.Next.Next = new Node<int>(9);
                node.Next.Next.Next = new Node<int>(8);
                node.Next.Next.Next.Next = new Node<int>(8);
                node.Next.Next.Next.Next.Next = new Node<int>(8);
                node.Next.Next.Next.Next.Next.Next = new Node<int>(1);
                node.Next.Next.Next.Next.Next.Next.Next = new Node<int>(0);
                node.Next.Next.Next.Next.Next.Next.Next.Next = new Node<int>(0);


                Node<int> nodeExpected = new Node<int>(8);
                nodeExpected.Next = new Node<int>(1);
                nodeExpected.Next.Next = new Node<int>(0);
                nodeExpected.Next.Next.Next = new Node<int>(0);

                return new List<object[]>
                {
                new object[] { node, nodeExpected, 6  }

                };
            }
        }

        public static IEnumerable<object[]> KthToLastDataListReal
        {
            get
            {
                Node<int> node = new Node<int>(10);
                node.Next = new Node<int>(9);
                node.Next.Next = new Node<int>(9);
                node.Next.Next.Next = new Node<int>(8);
                node.Next.Next.Next.Next = new Node<int>(8);
                node.Next.Next.Next.Next.Next = new Node<int>(8);
                node.Next.Next.Next.Next.Next.Next = new Node<int>(1);
                node.Next.Next.Next.Next.Next.Next.Next = new Node<int>(0);
                node.Next.Next.Next.Next.Next.Next.Next.Next = new Node<int>(0);


                Node<int> nodeExpected = new Node<int>(8);
                nodeExpected.Next = new Node<int>(1);
                nodeExpected.Next.Next = new Node<int>(0);
                nodeExpected.Next.Next.Next = new Node<int>(0);

                return new List<object[]>
                {
                new object[] { node, nodeExpected, 4  }

                };
            }
        }

        [Theory]
        [MemberData(nameof(DeleteMiddleNodeData))]
        public void DeleteMiddleNodeTest(Node<int> input, Node<int> expected)
        {
            Node<int> newList = DeleteMiddleNode.Delete(input);
            Assert.Equal(expected, newList);
        }
        public static IEnumerable<object[]> DeleteMiddleNodeData
        {
            get
            {
                Node<int> node = new Node<int>(10);
                node.Next = new Node<int>(9);
                node.Next.Next = new Node<int>(8);
                node.Next.Next.Next = new Node<int>(7);
                node.Next.Next.Next.Next = new Node<int>(6);

                Node<int> nodeExpected = new Node<int>(7);
                nodeExpected.Next = new Node<int>(6);


                Node<int> node1 = new Node<int>(10);
                node1.Next = new Node<int>(9);
                node1.Next.Next = new Node<int>(8);

                Node<int> nodeExpected1 = new Node<int>(9);
                nodeExpected1.Next = new Node<int>(8);


                Node<int> node2 = new Node<int>(10);
                node2.Next = new Node<int>(9);

                Node<int> nodeExpected2 = new Node<int>(9);

                return new List<object[]>
                {
                 new object[] { node.Next.Next, nodeExpected} ,
                new object[] { node1, nodeExpected1} ,
                new object[] { node2, nodeExpected2}
                };
            }
        }

        [Theory]
        [MemberData(nameof(PartitionData))]
        public void PartitionTest(Node<int> input, int item, Node<int> expected)
        {
            Node<int> newList = Partition.doPartition(input, item);
            Assert.Equal(expected, newList);
        }
        public static IEnumerable<object[]> PartitionData
        {
            get
            {
                //3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1

                Node<int> node = new Node<int>(3);
                node.Next = new Node<int>(5);
                node.Next.Next = new Node<int>(8);
                node.Next.Next.Next = new Node<int>(5);
                node.Next.Next.Next.Next = new Node<int>(10);
                node.Next.Next.Next.Next.Next = new Node<int>(2);
                node.Next.Next.Next.Next.Next.Next = new Node<int>(1);

                //1->2->3->10->5->8->5
                Node<int> nodeExpected = new Node<int>(1);
                nodeExpected.Next = new Node<int>(2);
                nodeExpected.Next.Next = new Node<int>(3);
                nodeExpected.Next.Next.Next = new Node<int>(10);
                nodeExpected.Next.Next.Next.Next = new Node<int>(5);
                nodeExpected.Next.Next.Next.Next.Next = new Node<int>(8);
                nodeExpected.Next.Next.Next.Next.Next.Next = new Node<int>(5);





                return new List<object[]>
                {
                 new object[] { node, 5 ,nodeExpected}


                };
            }
        }

        [Theory]
        [MemberData(nameof(SumData))]
        public void SumListTest(Node<int> input1, Node<int> input2, Node<int> expected)
        {
            Node<int> sumList = SumList.Sum(input1, input2);
            Assert.Equal(expected, sumList);
        }
        [Theory]
        [MemberData(nameof(SumData))]
        public void SumListRecursiveTest(Node<int> input1, Node<int> input2, Node<int> expected)
        {
            Node<int> sumList = SumList.SumRecursive(input1, input2, 0);
            Assert.Equal(expected, sumList);
        }

        public static IEnumerable<object[]> SumData
        {
            get
            {
                //first number             
                Node<int> number1 = new Node<int>(9);
                number1.Next = new Node<int>(7);
                number1.Next.Next = new Node<int>(8);


                //second number             
                Node<int> number2 = new Node<int>(6);
                number2.Next = new Node<int>(8);
                number2.Next.Next = new Node<int>(5);

                //result number(sum)
                Node<int> sum = new Node<int>(5);
                sum.Next = new Node<int>(6);
                sum.Next.Next = new Node<int>(4);
                sum.Next.Next.Next = new Node<int>(1);



                return new List<object[]>
                {
                 new object[] { number1, number2 ,sum}


                };
            }
        }

        [Theory]
        [MemberData(nameof(SumDataReverse))]
        public void SumListReverseRecursiveTest(Node<int> input1, Node<int> input2, Node<int> expected)
        {            
            Node<int> totalResult = null;         
            totalResult = SumList.SumReverse(input1, input2);
            Assert.Equal(expected, totalResult);
        }

        public static IEnumerable<object[]> SumDataReverse
        {
            get
            {
                //first number             
                Node<int> number1 = new Node<int>(8);
                number1.Next = new Node<int>(7);
                number1.Next.Next = new Node<int>(9);


                //second number             
                Node<int> number2 = new Node<int>(5);
                number2.Next = new Node<int>(8);
                number2.Next.Next = new Node<int>(6);

                //result number(sum)
                Node<int> sum = new Node<int>(1);
                sum.Next = new Node<int>(4);
                sum.Next.Next = new Node<int>(6);
                sum.Next.Next.Next = new Node<int>(5);

                return new List<object[]>
                {
                 new object[] { number1, number2 ,sum}


                };
            }
        }

        [Theory]
        [MemberData(nameof(PalindromeTestData))]
        public void PalindromeTest<T>(Node<T> input, bool expected)
        {
            bool testResult = Palindrome.IsPalindrome(input);
            Assert.Equal(expected, testResult);
        }
        [Theory]
        [MemberData(nameof(PalindromeTestData))]
        public void PalindromeWithStackTest<T>(Node<T> input, bool expected)
        {
            bool testResult = Palindrome.IsPalindromeWithStack(input);
            Assert.Equal(expected, testResult);
        }

        [Theory]
        [MemberData(nameof(PalindromeTestData))]
        public void PalindromeRecursiveTest<T>(Node<T> input, bool expected)
        {
            bool testResult = Palindrome.isPalindrome_(input);
            Assert.Equal(expected, testResult);
        }
        public static IEnumerable<object[]> PalindromeTestData
        {
            get
            {
                //first number             
                Node<int> number1 = new Node<int>(8);
                number1.Next = new Node<int>(7);
                number1.Next.Next = new Node<int>(8);


                //second number             
                Node<int> number2 = new Node<int>(5);
                number2.Next = new Node<int>(5);


                //result number(sum)
                Node<int> number3 = new Node<int>(1);
                number3.Next = new Node<int>(3);
                number3.Next.Next = new Node<int>(6);
                number3.Next.Next.Next = new Node<int>(3);
                number3.Next.Next.Next.Next = new Node<int>(1);

                Node<int> number4 = new Node<int>(9);
                number4.Next = new Node<int>(9);
                number4.Next.Next = new Node<int>(6);
                number4.Next.Next.Next = new Node<int>(9);
                number4.Next.Next.Next.Next = new Node<int>(8);

                Node<char> number5 = new Node<char>('C');
                number5.Next = new Node<char>('a');
                number5.Next.Next = new Node<char>('C');


                return new List<object[]>
                {
                 new object[] { number1, true}
                ,new object[] { number2, true}
                ,new object[] { number3, true}
                ,new object[] { number4, false}
                , new object[] { number5, true}
                };
            }
        }


        [Theory]
        [MemberData(nameof(InstersectionTestData))]
        public void IntersectionTest<T>(Node<T> input1, Node<T> input2, Node<T> intersection)
        {
            Node<T> intersectionNode = Intersection.getIntersectionNode(input1, input2);
            Assert.Equal(intersection, intersectionNode);
        }

        [Theory]
        [MemberData(nameof(InstersectionTestData))]
        public void IntersectionSolutionTest<T>(Node<T> input1, Node<T> input2, Node<T> intersection)
        {
            Node<T> intersectionNode = Intersection.getIntersection(input1, input2);
            Assert.Equal(intersection, intersectionNode);
        }

        public static IEnumerable<object[]> InstersectionTestData
        {
            get
            {
                //first number             
                Node<int> number1 = new Node<int>(1);
                number1.Next = new Node<int>(2);
                number1.Next.Next = new Node<int>(5);
                number1.Next.Next.Next = new Node<int>(4);
                number1.Next.Next.Next.Next = new Node<int>(5);
                //second number             
                Node<int> number2 = new Node<int>(0);
                number2.Next = number1.Next.Next.Next.Next;
                number2.Next.Next = new Node<int>(9);



                return new List<object[]>
                {
                 new object[] { number1, number2, number2.Next}
                };
            }
        }

        [Theory]
        [MemberData(nameof(LoopDetectionTestData))]
        public void LoopDetectionTest<T>(Node<T> input, Node<T> loopStartNodeExpected)
        {
            Node<T> loopStartNode = LoopDetection.DetectLoop(input);
            Assert.Equal(loopStartNodeExpected, loopStartNode);
        }

        public static IEnumerable<object[]> LoopDetectionTestData
        {
            get
            {
                //first number             
                Node<int> number1 = new Node<int>(1);
                number1.Next = new Node<int>(2);
                number1.Next.Next = new Node<int>(3);
                number1.Next.Next.Next = new Node<int>(4);
                number1.Next.Next.Next.Next = new Node<int>(5);
                number1.Next.Next.Next.Next.Next = number1.Next;
                

                return new List<object[]>
                {
                 new object[] { number1, number1.Next}
                };
            }
        }

    }
}