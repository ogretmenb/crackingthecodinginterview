using System;
using Xunit;

using Xunit.Extensions;
using Xunit.Sdk;

using CrackingCodeInterview.Solutions.ArraysAndStrings;
using System.Collections;
using System.Collections.Generic;
namespace CrackingCodeInterview.Tests
{
    public class ArraysAndStringsTest
    {

        [Theory]
        [InlineData("abcdefghijklmnoprsx", true)]
        public void IsUnique(string s, bool expected)
        {
            Assert.Equal(expected, Unique.IsUnique(s));
        }

        [Theory]
        [InlineData("abcdefghijklmnoprsxa", false)]
        public void IsUnique_V2(string s, bool expected)
        {
            Assert.Equal(expected, Unique.IsUnique(s, "v2"));
        }

        [Theory]
        [InlineData("aaa", "aab", false)]
        [InlineData("abcdefgh", "hgdefcba", true)]
        public void CheckPermutation(string s1, string s2, bool expected)
        {
            Assert.Equal(expected, Permutation.CheckPermutation(s1, s2));
        }

        [Theory]
        [InlineData(" a aa       ", 5, "%20a%20aa")]
        [InlineData("Mr John Smith      ", 13, "Mr%20John%20Smith")]
        public void ToUrlStartFromEnd(string s, int len, string expected)
        {
            Assert.Equal(expected, URLify.ToUrlStartFromEnd(s, len));
        }

        [Theory]
        [InlineData("TactzxCoa", false)]
        [InlineData("Tact _ ?Coa", true)]
        public void IsPermutationOfPalindrome(string s, bool expected)
        {
            Assert.Equal(expected, Palindrome.IsPermutationOfPalindrome(s));
        }

        [Theory]
        [InlineData("pale", "ple", true)]
        [InlineData("pales", "pale", true)]
        [InlineData("pale", "bale", true)]
        [InlineData("pale", "bake", false)]
        [InlineData("ab", "cab", true)]
        [InlineData("ab", "cba", false)]
        public void TestOneWay(string s1, string s2, bool expected)
        {
            Assert.Equal(expected, OneWay.oneEditAway(s1, s2));
        }


        [Theory]
        [InlineData("aabcccccaaa", "a2b1c5a3")]
        [InlineData("abcd", "abcd")]
        [InlineData("aaa", "a3")]
        public void Compress(string input, string expected)
        {
            Assert.Equal(expected, StringCompression.Compress(input));
        }

        [Theory]
        [MemberData(nameof(rotateMatrixData))]
        public void rotate90Degree(int[,] input, int[,] expected)
        {
            int[,] rotated = RotateMatrix.rotate90Degree(input);
            Assert.Equal(expected, rotated);
        }
        
        [Theory]
        [MemberData(nameof(rotateMatrixData))]
        public void rotate90DegreeLayer(int[,] input, int[,] expected)
        {
            RotateMatrix.rotate90DegreeLayer(input);
            Assert.Equal(expected, input);
        }
        public static IEnumerable<object[]> rotateMatrixData
        {
            get
            {
                // Or this could read from a file. :)
                return new List<object[]>
                {
                new object[] { new int[,]{{1,2,3}, {4,5,6},{7,8,9}}, new int[,]{{7,4,1}, {8,5,2},{9,6,3}}  },
                 new object[] { new int[,]{{1,2,3,4}, {5,6,7,8},{9,10,11,12},{13,14,15,16}}, new int[,]{{13,9,5,1}, {14,10,6,2},{15,11,7,3}, {16,12,8,4}}  }
                };                
            }
        }


        [Theory]
        [MemberData(nameof(zeromatrix))]
        public void Zero(int[,] input, int[,] expected)
        {
            ZeroMatrix.Zero(input);
            Assert.Equal(expected, input);
        }

        public static IEnumerable<object[]> zeromatrix
        {
            get
            {
                // Or this could read from a file. :)
                return new List<object[]>
                {
                new object[] { new int[,]{{1,0,3}, {4,5,6},{7,8,9}}, new int[,]{{0,0,0}, {4,0,6},{7,0,9}}  },
                 new object[] { new int[,]{{0,2,3,4}, {5,6,7,8},{9,10,11,12},{13,14,15,0}}, new int[,]{{0,0,0,0}, {0,6,7,0},{0,10,11,0},{0,0,0,0}}  }
                };                
            }
        }


        
        [Theory]
        [InlineData("waterbottle", "erbottlewat", true)]        
        public void StringRotationTest(string s1, string s2, bool expected)
        {
            Assert.Equal(expected, StringRotation.IsRotation(s1,s2));
        }

    }
}