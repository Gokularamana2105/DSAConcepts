using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StringManipulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            string program = "Programming";
            string str = "A man, a plan, a canal: Panama";
            Console.WriteLine(Normalize(str));
            Console.WriteLine(ReverseStringInPlace(program));
            Console.WriteLine(program);
            Console.WriteLine(RemoveVowels(program));
            string input = "Learn Programming Is My Breath";
            Console.WriteLine(ReverseWords(input));
            string s = "silent";
            string t = "listen";
            Console.WriteLine(IsAnagram(s, t));

            string compression = "aaabbcccc";
            Console.WriteLine(StringCompression(compression));
            Console.ReadLine();
        }

        // 1.The "Mutable" Pattern (Using char[] or StringBuilder)
            //When: You need to swap characters, reverse in-place, or modify specific indices.
            //Why: You cannot do s[0] = 'A' on a standard string.
            //How: Convert to char[], manipulate, then convert back.
        public static string ReverseStringInPlace(string str)
        {
            char[] chars = str.ToCharArray();
            int left = 0, right = chars.Length - 1;
            while (left < right)
            {
               char temp = chars[left];
                chars[left] = chars[right];
                chars[right] = temp;
                left++;
                right--;
            }
            return new string(chars).ToLower();
        }

        // 2.The "Builder" Pattern (Constructing New Strings)
            //When: You are building a result string inside a loop(e.g., compression, filtering, formatting).
            //Why: Using result += char inside a loop creates a new string object every iteration(). StringBuilder avoids this.

        public static string RemoveVowels(string str)
        {
            StringBuilder sb = new StringBuilder();

            foreach(char c in str)
            {
                if (!IsVowel(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        private static bool IsVowel(char c)
        {
            return "aeiouAEIOU".IndexOf(c) >= 0;
        }


        // 3. The "Normalization" Pattern(Cleaning Input)
            //When: The problem involves case-insensitivity, ignoring spaces, or handling punctuation(common in Palindrome problems).
            //Why: Real-world data is messy.Algorithms work best on clean, uniform data.
       public static string Normalize(string str)
        {
            StringBuilder sb=new StringBuilder();
            foreach(char c in str)
            {
                if (char.IsLetterOrDigit(c))
                {
                    sb.Append(char.ToLower(c));
                }
            }
            return sb.ToString();
        }

        // 4.The "Split & Join" Pattern(Word Processing)
         //  When: You need to reverse word order, count words, or rearrange sentence structure.
         //How: Split by delimiter -> Process Array -> Join back.
       public static string ReverseWords(string s)
        {
            //string[] words = s.Split(' ');
            //Array.Reverse(words);
            //return string.Join(" ",words);

            //without inbuilt method
            char[] c= s.ToCharArray();
            //int left = 0, right = c.Length - 1;
            //while (left < right)
            //{
            //    char temp = c[left];
            //    c[left] = c[right];
            //    c[right] = temp;
            //    left++; right--;

            //}

            //reverse each word
            int start = 0;
            for(int i = 0; i < c.Length; i++)
            {
                if(i==c.Length || c[i]==' ')
                {
                    int l=start,r=i-1;
                    while(l<r)
                    {
                        char temp = c[l];
                        c[l] = c[r];
                        c[r] = temp;
                        l++; r--;

                    }
                    start = i + 1;
                }
                
            }
            return new string(c);
        }

        // 5. The "Frequency Map" Pattern(Anagrams & Counts)
            //When: Checking if two strings are anagrams, finding unique characters, or counting occurrences.
            //How: Use an int[26] array (for lowercase English letters) or a Dictionary<char, int>.
        public static bool IsAnagram(string s,string t)
        {
            //if (s.Length != t.Length) return false;

            //int[] count = new int[26]; // Assuming only lowercase a-z
            //foreach( char c in s)
            //{
            //    count[c - 'a']++;
            //}
            //foreach(char c in t)
            //{
            //    count[c - 'a']--;
            //    if (count[c - 'a'] < 0)
            //    {
            //        return false;
            //    }
            //}
            //return true;


            //Dictionary
            //Dictionary<char,int> dic = new Dictionary<char,int>();

            //foreach(char c in s)
            //{
            //    if (dic.ContainsKey(c))
            //    {
            //        dic[c]++;
            //    }
            //    else
            //    {
            //        dic[c] = 1;
            //    }
            //}

            //foreach(char c in t)
            //{
            //    if (!dic.ContainsKey(c) || dic[c]==0)
            //    {
            //        return false;
            //    }
            //    dic[c]--;
            //}
            //return true;


            //brute force
            //int[] count = new int[26];
            //int n=s.Length;
            //for(int i = 0; i < n; i++)
            //{
            //    count[s[i] - 'a']++;
            //    count[t[i] - 'a']--;
            //}
            //for(int i = 0; i < 26; i++)
            //{
            //    if (count[i] != 0)
            //    {
            //        return false;
            //    }
            //}
            //return true;

            //without count 26
            char[] arrS=new char[s.Length];
            char[] arrT=new char[t.Length];

            for(int i=0;i<s.Length; i++)
            {
                arrS[i] = s[i];
                arrT[i] = t[i];
            }

            //sort
            for(int i = 0; i < arrS.Length - 1; i++)
            {
                for(int j = 0; j < arrS.Length - i - 1; j++)
                {
                    if (arrS[j] > arrS[j + 1])
                    {
                        char temp = arrS[j];
                        arrS[j]= arrS[j + 1];
                        arrS[j+1] = temp;   
                    }
                }
            }

            for (int i = 0; i < arrT.Length - 1; i++)
            {
                for (int j = 0; j < arrT.Length - i - 1; j++)
                {
                    if (arrT[j] > arrT[j + 1])
                    {
                        char temp = arrT[j];
                        arrT[j] = arrT[j + 1];
                        arrT[j + 1] = temp;
                    }
                }
            }
            for(int i = 0; i < arrS.Length; i++)
            {
                if (arrS[i] != arrT[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static string StringCompression(string s)
        {
            //StringBuilder sb = new StringBuilder();
            //int count = 1;
            //for(int i=0;i<s.Length-1; i++)
            //{

            //    if (s[i] == s[i + 1])
            //    {
            //        count++;
            //    }
            //    else
            //    {
            //        sb.Append(s[i]);
            //        sb.Append(count);
            //        count = 1;
            //    }
            //}

            //sb.Append(s[s.Length - 1]);
            //sb.Append(count);
            //return sb.ToString();

            var compressed = string.Concat(s
                                   .Select((c, i) => new { Char = c, Index = i }).GroupBy(x => new
                                   {
                                       x.Char,
                                       Group = x.Index - s.Take(x.Index).Count(y => y == x.Char)
                                   }).Select(x=>$"{x.Key.Char}{x.Count()}")
                             ); 
            return compressed;
        }
    }
}
