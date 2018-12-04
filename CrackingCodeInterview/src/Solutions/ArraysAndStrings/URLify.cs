using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackingCodeInterview.Solutions.ArraysAndStrings
{
    public class URLify
    { 
         public static string ToUrlStartFromEnd(string aS, int aLen)
        {
            char[] chars = aS.ToCharArray();
            int numOfSpaces = 0;
            for (int i = 0; i < aLen; i++)
            {
                if (chars[i] == ' ')
                    numOfSpaces++;
            }

            int newTextLen = aLen + numOfSpaces * 2;

            for (int i = aLen - 1; i >= 0; i--)
            {
                if (chars[i] == ' ')
                {
                    chars[newTextLen - 1] = '0';
                    chars[newTextLen - 2] = '2';
                    chars[newTextLen - 3] = '%';
                    newTextLen -= 3;
                }
                else
                {
                    chars[newTextLen - 1] = chars[i];
                    newTextLen--;
                }
            }
            return new string(chars).Trim();
        }
    }
}