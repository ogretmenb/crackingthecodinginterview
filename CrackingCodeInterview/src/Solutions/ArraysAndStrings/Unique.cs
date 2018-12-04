using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackingCodeInterview.Solutions.ArraysAndStrings
{
    public class Unique
    {
        public static bool IsUnique(string aS)
        {
            Dictionary<char, int> _histogram = new Dictionary<char, int>();
            foreach (var c in aS)
            {

                if (_histogram.ContainsKey(c))
                    return false;
                else
                {
                    _histogram.Add(c, 1);
                }
            }
            return true;
        }
        public static bool IsUnique(string aS, string a = "N^2")
        {
            for (int i = 0; i < aS.Length; i++)
            {
                for (int j = 0; j < aS.Length; j++)
                {
                    if (i == j) continue;
                    if (aS[i] == aS[j]) return false;

                }
            }
            return true;
        }
    }

}