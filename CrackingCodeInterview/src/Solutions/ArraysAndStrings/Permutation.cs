using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackingCodeInterview.Solutions.ArraysAndStrings
{
    public class Permutation
    {
        public static bool CheckPermutation(string aS1, string aS2)
        {
            char[] firstArray = aS1.ToCharArray();
            char[] secondArray = aS2.ToCharArray();
            Array.Sort(firstArray);
            Array.Sort(secondArray);
            string s1 = new String(firstArray);
            string s2 = new String(secondArray);
            return s1.Equals(s2);

        }
    }
}