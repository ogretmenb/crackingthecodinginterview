using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackingCodeInterview.Solutions.ArraysAndStrings
{
    public class StringCompression
    {
        public static string Compress(string aStr)
        {
            StringBuilder compressed = new StringBuilder();
            int previousIndex=0 ;
            
            for (int i = 0; i < aStr.Length; i++)
            {
                if(aStr.ElementAt(i) != aStr.ElementAt(previousIndex))
                {
                    compressed.Append(aStr.ElementAt(previousIndex) + (i-previousIndex).ToString());
                    previousIndex = i;
                }
            }
            compressed.Append(aStr.ElementAt(previousIndex) + (aStr.Length-previousIndex).ToString());
            return compressed.ToString().Length > aStr.Length? aStr:compressed.ToString();
        }

    }
}