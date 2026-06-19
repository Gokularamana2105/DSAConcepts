using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStringAlgorithms
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string text = "ABABDABACDABABCABAB";
            string pattern = "ABABCABAB";
            KMP(text, pattern);

            string textTwo = "abcabcabcabc";
            bool result = RepeatedSubString(textTwo);
            Console.WriteLine(result);

            string patternTwo = "ababab";
            string output = LongestPrefix(patternTwo);
            Console.WriteLine(output);

            string s = "abcd";
            Console.WriteLine(ShortestPalindrome(s));

            string a = "abcd";
            string b = "cdabcdab";
            int resultThree = RepeatedStringMatch(a, b);
            Console.WriteLine(resultThree);
            Console.ReadLine();
        }

        //Knuth-Morris-Pratt
        public static void KMP(string text,string pattern)
        {
            int[] lps=BuildLps(pattern);
            int i = 0;
            int j = 0;
            while (i < text.Length)
            {
                if (text[i] == pattern[j])
                {
                    i++;
                    j++;
                }
                if (j == pattern.Length)
                {
                    Console.WriteLine(i - j);
                    j = lps[j-1];   
                }
                else if(i<text.Length && text[i] != pattern[j])
                {
                    if (j != 0)
                    {
                        j = lps[j-1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        public static int[] BuildLps(string pattern)
        {
            int length = 0;
            int[] lps= new int[pattern.Length];
            int i = 1;
            while(i < pattern.Length)
            {
                if (pattern[i] == pattern[length])
                {
                    length++;
                    lps[i] = length;
                    i++;
                }
                else
                {
                    if (length != 0)
                    {
                        length = lps[length - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }
            return lps;
        }

        public static bool RepeatedSubString(string text)
        {
            int n=text.Length;
            int[] lps = buildLpsTwo(text);
            int lastLen = lps[n - 1];
            return (lastLen > 0 && n % (n - lastLen) == 0);
        }

        public static int[] buildLpsTwo(string pattern)
        {
            int[] lps=new int[pattern.Length];
            int i = 1, length = 0;
            while(i < pattern.Length)
            {
                if ((pattern[i] == pattern[length])){
                    length++;
                    lps[i] = length;
                    i++;

                }
                else
                {
                    if (length != 0)
                    {
                        length = lps[length - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
             

            }
            return lps;
        }
        //Longest Happy Prefix
        public static string LongestPrefix(string s)
        {
            int[] lps=buildLpsTwo(s);
            int n=s.Length;

            int lastLen = lps[n-1];
            //  return s.Substring(0, lastLen); 
            char[] result = new char[lastLen];
            for(int i=0;i<lastLen;i++)
            {
                result[i] = s[i];
            }
            return new string(result);
        }

        public static int[] BuildLpsThree(string pattern)
        {
            int n=pattern.Length;
            int[] lps = new int[n];
            int i = 1, length = 0;
            while (i < n)
            {
                if (pattern[i] == pattern[length])
                {
                    length++;
                    lps[i] = length;
                    i++;
                }
                else
                {
                    if (length != 0)
                    {
                        length = lps[length - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }
            return lps;
        }

        //Shortest Palindrome
        public static string ShortestPalindrome(string s)
        {
            string temp = s + "#" + Reverse(s);
            int[] lps=BuildLps(temp);
            int n=temp.Length;
            int lastLen = lps[n-1];
            string suffix = s.Substring(lastLen);
            string prefix=Reverse(suffix);
            return prefix + s;

        }

        public static string Reverse(string s)
        {
            StringBuilder str = new StringBuilder();
            for(int i=s.Length-1; i>=0; i--)
            {
                str.Append(s[i]);
            }
            return str.ToString();
        }

        public static int RepeatedStringMatch(string a,string b)
        {
            string text = a;
            int count = 1;
            while(text.Length<b.Length)
            {
                text += a;
                count++;
            }
            if (KmpSearch(text, b))
            {
                return count;
            }
            text += a;
            count++;
            if(KmpSearch(text, b))
            {
                return count;
            }
            return -1;
        }

        public static bool KmpSearch(string a,string b)
        {
            int i=0;
            int j = 0;
            int n = a.Length;
            int[] lps=BuildLps(b);
            while(i<n)
            {
                if (a[i] == b[j])
                {
                    i++;
                    j++;
                    if (j == b.Length)
                    {
                        return true;
                    }
                }
               
                else
                {
                    if (j != 0)
                    {
                        j = lps[j - 1];

                    }
                    else
                    {
                        i++;
                    }
                }
            }
            return false;
        }
    }
}
