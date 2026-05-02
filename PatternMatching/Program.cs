using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== C# Pattern Matching ===");

            int result= NaivePatternMatching("saebutsad", "sad");
            Console.WriteLine(result);
            bool resultTwo = IsPalindrome("A man, a plan, a canal: Panama");
            Console.WriteLine(resultTwo);

            bool resultThree = RepeatedSubStringPattern("abab");
            Console.WriteLine(resultThree);

            //DNA Sequence
            string s = "AAAAAAAAAAA";
            IList<string> list=FindRepeatedDnaSequences(s);
            Console.WriteLine(string.Join(" ", list));

            //Find All Anagrams in a String
            string inputTwo = "cbaebabacd";
            string p = "abc";
            IList<int> listTwo = FindAnagrams(inputTwo,p);
            Console.WriteLine(string.Join(" ",listTwo));

            var resultFour = FindOcurrences("banana", 'a');
            Console.WriteLine(string.Join(" ",resultFour));
            Console.ReadLine();
        }

        static string CheckInput(object input)
        {
            switch (input)
            {
                case int n when n > 10:
                    return "Integer > 10";

                case int n:
                    return "Integer <= 10: " + n;

                case string s when s == "admin":
                    return "Admin user";

                case string s:
                    return "String input: " + s;

                default:  
                    return "Unknown type";
            }
        }
        //1.naive pattern matching

        static int NaivePatternMatching(string text,string pattern)
        {
            if(text.Length < pattern.Length)
            {
                return -1;
            }
            int n=text.Length;
            int m=pattern.Length;
         
            for(int i = 0; i <= n - m; i++)
            {
                int j;
                for (j=0; j<m; j++)
                {
                    if (text[i + j]!= pattern[j])
                    {
                        break;
                    }
                }
                if (j == m)
                {
                    return i;
                }
            }
            return -1;
        }

        //valid palindrome
        static bool IsPalindrome(string s)
        {
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                while(left<right && !char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }
                while(left<right && !char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }
                if (char.ToLower(s[left]) != char.ToUpper(s[right]))
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
           
        }

        // Repeated Substring Pattern
        public static bool RepeatedSubStringPattern(string s)
        {
            int n = s.Length;
            for (int len = 1; len <= n / 2; len++)
            {
                if (n % len != 0)
                {
                    continue;
                }

                bool match = true;
                for (int i = len; i < n; i++)
                {
                    if (s[i % len] != s[i])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    return true;
                }

                //string pattern = s.Substring(0, len);
                //int repeatedCount = n / len;
                //string constructed = "";
                //for (int i = 0; i < repeatedCount; i++)
                //{
                //    constructed += pattern;
                //}
                //if (constructed == s)
                //{
                //    return true;
                //}
            }
            return false;

            //string t = s + s;
            //string result = t.Substring(1, t.Length - 2);
            //return result.Contains(s);
        }

        //Repeated DNA Sequences

        public static IList<string> FindRepeatedDnaSequences(string s)
        {
            List<string> result = new List<string>();   
            int n = s.Length;

            //Pure Naive Approach Without List and HashSet
            //for(int i = 0; i <= n - 10; i++)
            //{
            //    string substring = s.Substring(i, 10);

            //    // Step 1: Check if appears later
            //    bool foundLater =false;

            //    for(int j=i+1;j<=n-10;j++) { 
            //        if(s.Substring(j, 10) == substring)
            //        {
            //            foundLater = true;
            //            break;
            //        }
            //    }
            //    if (!foundLater)
            //    {
            //        continue;
            //    }
            //    // Step 2: Check if already appeared before
            //    bool seenBefore =false;
            //    for(int k = 0; k < i; k++)
            //    {
            //        if(s.Substring(k,10)== substring) { 
            //            seenBefore = true;
            //            break;
            //        }
            //    }
            //    // Step 3: Print only once
            //    if (!seenBefore)
            //    {
            //        result.Add(substring);
            //    }
            //}
            //return result;

            //using list

            //for(int i = 0; i <= n - 10; i++)
            //{
            //    string substring=s.Substring(i, 10);

            //    for(int j = i + 1; j <= n - 10; j++)
            //    {
            //        string subStringJ=s.Substring(j, 10);
            //        if(subStringJ == substring)
            //        {
            //            if (!result.Contains(substring))
            //            {
            //                result.Add(substring);
            //            }
            //            break;
            //        }
            //    }
            //}
            //return result;


            //HashSet
            HashSet<string> seen = new HashSet<string>();   
            HashSet<string> repeated= new HashSet<string>();
            for(int i = 0; i <= n - 10; i++)
            {
                string substring=s.Substring(i,10);

                if (seen.Contains(substring))
                {
                    repeated.Add(substring);
                }
                else
                {
                    seen.Add(substring);
                }
            }
            return new List<string>(repeated);
        }

        //Find All Anagrams in a String
        public static IList<int> FindAnagrams(string s,string p)
        {
            int n = s.Length;
            int m=p.Length;
            List<int> result = new List<int>();
            for(int i = 0; i <= n - m; i++)
            {
                int[] count = new int[26];
                for (int j = 0; j < m; j++)
                {
                    count[s[i + j] - 'a']++;
                    count[p[j] - 'a']--;
                }
                bool isAnagram=true;
                for(int x = 0; x < 26; x++)
                {
                    if (count[x] != 0)
                    {
                        isAnagram = false;
                        break;
                    }
                }
                if (isAnagram)
                {
                    result.Add(i);
                }
            }
            return result;
        }

       // Finding all occurrences of a character
        public static IList<int> FindOcurrences(string s, char target)
        {
            List<int> result = new List<int>();
            Dictionary<char, List<int>> keyValuePairs = new Dictionary<char, List<int>>();
            for (int i = 0; i < s.Length; i++)
            {
                if ( !keyValuePairs.ContainsKey(s[i]))
                {
                    keyValuePairs[s[i]] = new List<int>();
                }
                keyValuePairs[s[i]].Add(i);
            }

            if (keyValuePairs.ContainsKey(target))
            {
                return keyValuePairs[target];
            }
            return new List<int>();
        }
    }

}
