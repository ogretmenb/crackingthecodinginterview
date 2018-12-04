using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackingCodeInterview.Solutions.ArraysAndStrings
{
    public class OneWay
    { 
        public static bool oneEditAway(string aS1, string aS2)
        {   
            if(aS1.Length == aS2.Length)
                return oneEditReplace(aS1, aS2);
            else if(aS1.Length +1 == aS2.Length){
                return oneEditInsert(aS1, aS2);
            }
            else if(aS1.Length -1 == aS2.Length){
                return oneEditInsert(aS2, aS1);
            }
                
            return false;
        }

        private static bool oneEditReplace(string aS1, string aS2)
        {
            bool oneReplace = false;
            for (int i = 0; i < aS1.Length; i++)
            {
                if(aS1[i] != aS2[i] )
                {
                    if(oneReplace)  //a previous difference exists
                    {
                        return false;
                    }
                    oneReplace = true;
                }
            }
            return true;
        }
        private static bool oneEditInsert(string aS1, string aS2)
        {
            bool oneInsert = false;
            for (int i = 0, j=0; i < aS1.Length && j<aS2.Length; i++, j++)
            {
                if(aS1.ElementAt(i) != aS2.ElementAt(j))
                {
                    if(oneInsert)
                        return false;
                    else{
                        oneInsert = true;
                        i--;
                    }
                }

            }
            return true;
        }
    }
}