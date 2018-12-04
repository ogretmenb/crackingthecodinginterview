using System;
using System.Collections.Generic;
namespace CrackingCodeInterview
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            string s = "abc";        
            string b = "abca";

            Console.WriteLine("Number of permutations: " + FindPermutationsRecursive(s, b));
        }

        public static int FindPermutations(string s, string b)
        {
            int numOfPermutations = 0;
            if(s.Length > b.Length)
                return numOfPermutations;
            
            /*if(IsPermutation(s, b.Substring(0, s.Length)))
            {
                Console.WriteLine(s + " is included as a permuation in " + b);
                numOfPermutations++;
            }*/

            for (int i = 0; i <= b.Length-s.Length; i++)
            {
                if(IsPermutation(s, b.Substring(i, s.Length)))
                {
                    Console.WriteLine(s + " is included as a permuation in " + b);
                    numOfPermutations++;
                }
            }
            return numOfPermutations;
        
        }

        public static int FindPermutationsRecursive(string s, string b)
        {
            int numOfPermutations = 0;
            if(s.Length > b.Length)
                return numOfPermutations;
            
            if(IsPermutation(s, b.Substring(0, s.Length)))
            {
                Console.WriteLine(s + " is included as a permuation in " + b);
                numOfPermutations++;
            }
            return numOfPermutations + FindPermutationsRecursive(s, b.Substring(1));
        
        }

        public static bool IsPermutation(string s1, string s2)
        {
        
            Dictionary<char, int> d1 = ToDictionary(s1);
            Dictionary<char, int> d2 = ToDictionary(s2);
            if(d1.Count == d2.Count)
            {
                foreach(var kvp in d1)
                {

                    if(d2.ContainsKey(kvp.Key) && kvp.Value == d2[kvp.Key])
                    {
                        continue;
                    }
                    else{
                        return false;
                    }

                }
            }
            return true;
        }

        public static Dictionary<char,int> ToDictionary(string s)
        {
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            foreach(char c in s)
            {
                if(dictionary.ContainsKey(c))
                {

                    dictionary[c]++;
                }
                else{
                    dictionary.Add(c, 1);
                }
            }
            return dictionary;
        }


    }
}
