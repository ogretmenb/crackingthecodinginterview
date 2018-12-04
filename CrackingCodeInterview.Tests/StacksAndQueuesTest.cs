using System;
using Xunit;

using Xunit.Extensions;
using Xunit.Sdk;
using CrackingCodeInterview.Solutions.StacksAndQueues;
using System.Collections.Generic;

namespace CrackingCodeInterview.Tests
{
    public class StacksAndQueuesTest
    {
        [Theory]
        [MemberData(nameof(stackList))]
        public void StackMinTest(StackNode<int>[] list, int expected)
        {
            //StackMin.DuplicateRemoval(input);
            StackMin<int> smin = new StackMin<int>();
            foreach (var item in list)
            {
                smin.Push(item);
            }
            var min = smin.Min();

            Assert.Equal(expected, min.smallest);
        }

        public static IEnumerable<object[]> stackList
        {
            get
            {
                List<StackNode<int>> snlist = new List<StackNode<int>>();
                snlist.Add(new StackNode<int>(1));
                snlist.Add(new StackNode<int>(2));
                snlist.Add(new StackNode<int>(3));
                snlist.Add(new StackNode<int>(4));
                snlist.Add(new StackNode<int>(0));
                snlist.Add(new StackNode<int>(5));
                snlist.Add(new StackNode<int>(6));



                return new List<object[]>
                {
                new object[] { snlist.ToArray(),0  }

                };
            }
        }
    }
}