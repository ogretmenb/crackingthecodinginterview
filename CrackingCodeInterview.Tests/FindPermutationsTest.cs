using System;
using Xunit;
using CrackingCodeInterview;

namespace CrackingCodeInterview.Tests
{
    public class FindPermutationsTest
    {
        [Fact]
        public void Test1()
        {
                //Console.WriteLine("Hello World!");
            string s = "abc";        
            string b = "abca";

            //Console.WriteLine("Number of permutations: " + Program.FindPermutationsRecursive(s, b));
            Assert.Equal(2,Program.FindPermutationsRecursive(s, b));
            
        }
        [Theory]
        [InlineData("abc", "abca", 2)]
        [InlineData("abc", "abc", 1)]
        public void TestMulti(string s, string b, int expected)
        {
            Assert.Equal(expected,Program.FindPermutationsRecursive(s, b));
        }

        [Theory]
        [InlineData("abc", "abca", 2)]
        [InlineData("abc", "abc", 1)]
        public void TestMulti2(string s, string b, int expected)
        {
            Assert.Equal(expected,Program.FindPermutations(s, b));
        }
    }
}
