using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Knuth_Morris_Pratt_PatternMatching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "ABABDABACDABABCABAB";
            string pattern = "ABABCABAB";

            KMPSearch(text, pattern);

            string textTwo= "abcabcabcabc";
            bool result = RepeatedSubString(textTwo);
            Console.WriteLine(result);

            string patternTwo = "ababab";
            string output=LongestPrefix(patternTwo);
            Console.WriteLine(output);

            string s = "abcd";
           Console.WriteLine(ShortestPalindrome(s));

            string a = "abcd";
            string b = "cdabcdab";
            int resultThree= RepeatedStringMatch(a, b);
            Console.WriteLine(resultThree);

            string s2 = "banana";
            string resultFour = LongestDupSubstring(s2);
            Console.WriteLine(resultFour);
            Console.ReadLine();
        }

        public static int[] Buildlps(string pattern)
        {
            int[] lps= new int[pattern.Length];
            int length = 0;
            int i = 1;
            while (i < pattern.Length)
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
                        length = lps[length-1];
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
       

        public static void KMPSearch(string text,string pattern)
        {
           int[] lps=Buildlps(pattern);
            int i = 0;
            int j = 0;
            while (i<text.Length)
            {
                if (text[i] == pattern[j])
                {
                    i++;
                    j++;

                }
                if (j == pattern.Length)
                {
                    Console.WriteLine((i - j));
                    j = lps[j - 1];
                }
                else if (i < text.Length && text[i] != pattern[j]) 
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

        }

        public static bool RepeatedSubString(string text)
        {
            int[] lps= Buildlps(text);
            int n=text.Length;
            int len = lps[n-1];
            return (len>0 && n%(n-len)==0);
        }

        public static int[] BuildLpsTwo(string pattern)
        {
            int p=pattern.Length;
            int[] lps=new int[p];
            int i = 1;
            int l = 0;
            while (i < p)
            {
                if (pattern[i] == pattern[l])
                {
                    l++;
                    lps[i] = l++;
                    i++;
                }
                else
                {
                    if (l != 0)
                    {
                        l = lps[l - 1];
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

        public static string LongestPrefix(string s)
        {
            int[] lps= BuildLps(s);
            int n=s.Length;
            int len = lps[n - 1];
            
            //char[] result= new char[len];
            //for(int i=0;i<len; i++)
            //{
            //    result[i] = s[i];
            //}
            //return new string(result);

            return s.Substring(0, len); 
        }

        public static int[] BuildLps(string pattern)
        { 
            int[] lps= new int[pattern.Length];
            int i = 1;
            int l = 0;
            while(i < pattern.Length)
            {
                if (pattern[i] == pattern[l])
                {
                    l++;
                    lps[i] = l;
                    i++;
                    
                }
                else
                {
                    if(l != 0)
                    {
                        l = lps[l - 1];

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

        public static string ShortestPalindrome(string s)
        {
            string temp = "";
            temp=s+"#"+reverse(s);
            int [] lps=BuildLps(temp);
            int n=temp.Length;
            int len = lps[n - 1];
            string suffix = s.Substring(len);
            string prefixToAdd=reverse(suffix);
            return prefixToAdd + s;
        }

        public static string reverse(string s)
        {
            StringBuilder result = new StringBuilder();
            for(int i=s.Length-1; i>=0; i--)
            {
                result.Append(s[i]);

            }
            return result.ToString();
        }


        //Repeated String Match
        public static int RepeatedStringMatch(string a, string b)
        {
            string text = a;
            int count = 1;
            while (text.Length < b.Length)
            {
                text += a;
                count++;
            }
            if (KMPSearchBool(text, b))
            {
                return count;
            }
            text += a;
            count++;
            if (KMPSearchBool(text, b))
            {
                return count;
            }
            return -1;
        }

        private static bool KMPSearchBool(string text, string pattern)
        {
            int[] lps = BuildLps(pattern);

            int i = 0; 
            int j = 0;

            while (i < text.Length)
            {
                if (text[i] == pattern[j])
                {
                    i++;
                    j++;

                    if (j == pattern.Length)
                        return true;
                }
                else
                {
                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i++;
                }
            }

            return false;
        }


        public static string LongestDupSubstring(string s)
        {
            int n = s.Length;
            string result = "";

            for(int i = 0; i < n; i++)
            {
                string suffix = s.Substring(i);
                int[] lps= BuildLpsSub(suffix);
                for(int j=0;j < lps.Length; j++)
                {
                    if (lps[j] > result.Length)
                    {
                        result= suffix.Substring(0, lps[j]);
                    }
                }
            }
            return result;
        }

        public static int[] BuildLpsSub(string p)
        {
            int[] lps=new int[p.Length];
            int l = 0;
            int i = 1;
            while (i<p.Length)
            {
                if (p[i] == p[l])
                {
                    l++;
                    lps[i] = l;
                    i++;
                }

                else
                {
                     if(l != 0)
                    {
                        l = lps[l-1];
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

    }
}
