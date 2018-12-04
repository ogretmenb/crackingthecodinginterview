using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackingCodeInterview.Solutions.ArraysAndStrings
{
    public class Palindrome
    { 
        public static bool IsPermutationOfPalindrome(string aStr)
        {
            string aStr_ = aStr.ToUpper();
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char c in aStr_)
            {
                if (!char.IsLetter(c))
                    continue;

                if (dic.ContainsKey(c))
                {
                    dic[c]++;
                }
                else
                {
                    dic.Add(c, 1);
                }
            }

            bool foundOdd = false;
            foreach (var k in dic.Keys)
            {
                if (dic[k] % 2 == 1)
                {
                    if (foundOdd)
                        return false;
                    foundOdd = true;
                }

            }
            return true;
        }
    }
}