using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackingCodeInterview.Solutions.ArraysAndStrings
{
    public class StringRotation
    {
        public static bool IsRotation(string aS1, string aS2)
        {
            string concat = aS2+aS2;
            return concat.Contains(aS1);            
        }
    }
}