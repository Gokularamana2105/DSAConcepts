using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z_Algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "abcxabcdabcdabcy";
            string pattern = "abcdabcy";

            ZSearch(text, pattern);

            Console.WriteLine(RepeatedStringMatch("abcd", "cdabcdab"));

            string patternTwo = "ababab";
            string output = LongestPrefix(patternTwo);
            Console.WriteLine(output);

            Console.WriteLine(SumScores("babab"));

            string[] words = { "mass", "as", "hero", "superhero" };
            var result = StringMatching(words);
            Console.WriteLine(string.Join(",", result));
            Console.ReadLine();
        }

        public static void ZSearch(string text,string pattern)
        {
            string combined = pattern + "#" + text;
            int[] z=BuildZArray(combined);  
            int m=pattern.Length;
            for(int i = 0; i < z.Length; i++)
            {
                if (z[i] == m)
                {
                    Console.WriteLine(i - m - 1);
                }
            }
        }

        public static int[] BuildZArray(string combined)
        {
            int n=combined.Length;
            int[] z=new int[n];
            int l = 0, r = 0;
            for(int i=1;i<n; i++)
            {
                if (i > r)
                {
                    l = r = i;
                    while(r<n && combined[r] == combined[r - l])
                    {
                        r++;
                    }
                    z[i] = r - l;
                    r--;
                }
                else
                {

                    int k = i - l;
                    if (z[k] < r - i + 1)
                    {
                        z[i] = z[k];
                    }
                    else
                    {
                        l = i;
                        while(r<n && combined[r] == combined[r - l])
                        {
                            r++;
                        }
                        z[i] = r - l;
                        r--;
                    }
                }
            }
            return z ;
        }

        public static int RepeatedStringMatch(string a, string b)
        {
            string text = a;
            int count = 1;
            while(text.Length<b.Length)
            {
                text += a;
                count++;
            }
            if (ZAlgorithm(text, b))
            {
                return count;
            }

            text += a;
            count++;
            if(ZAlgorithm(text, b))
            {
                return count;
            }

            return -1;
        }

        public static bool ZAlgorithm(string a, string b)
        {
            string combined = b + "#" + a;
            int n=b.Length;
            int[] Z = BuildZArrayRepeatString(combined);
            for(int i = 0; i < Z.Length; i++)
            {
                if (Z[i] == n)
                {
                    return true;
                }
            }
            return false;
        }

        public static int[] BuildZArrayRepeatString(string a)
        {
            int n=a.Length;
            int[] Z = new int[n];
            int l = 0, r = 0;
            for(int i=1;i<n; i++) 
            {
                if (i > r)
                {
                    l = r = i;
                    while(r<n && a[r] == a[r - l])
                    {
                        r++;
                    }
                    Z[i] = r - l;
                    r--;
                }
                else
                {
                    int k = i - l;
                    if (Z[k] < r - i + 1)
                    {
                        Z[i] = Z[k];
                    }
                    else
                    {
                        l = i;
                        while (r < n && a[r] == a[r - l])
                        {
                            r++;
                        }
                        Z[i] = r - l;
                        r--;
                    }
                }
            }
            return Z;
        }

        public static string LongestPrefix(string s)
        {
            int[] Z = BuildZArray(s);
            int n=s.Length;
            int max = 0;
            for(int i=0;i<Z.Length; i++)
            {
                if (i + Z[i] == n)
                {
                   max= Math.Max(max,Z[i]);
                }
            }
            return s.Substring(0, max);
        }


        //Sum of Scores of Built Strings

        public static long SumScores(string s)
        {
            int n = s.Length;
            long sum = n;
            int[] Z = BuildTwo(s);

            for (int i = 1; i <Z.Length; i++)
            {
                sum += Z[i];
            }
            return sum;
        }

        public static int[] BuildTwo(string s)
        {
            int n = s.Length;
            int[] Z = new int[n];
            for (int i = 1; i < n; i++)
            {
                int l = 0, r = 0;
                if (i > r)
                {
                    l = r = i;
                    while (r < n && s[r] == s[r - l])
                    {
                        r++;
                    }
                    Z[i] = r - l;
                    r--;
                }
                else
                {
                    int k = i - l;
                    if (Z[k] < r - i + 1)
                    {
                        Z[i] = Z[k];
                    }
                    else
                    {
                        l = i;
                        while (r < n && s[r] == s[r - l])
                        {
                            r++;
                        }
                        Z[i] = r - l;
                        r--;
                    }
                }

            }
            return Z;

        }

        //String Matching in an Array
        public static IList<string> StringMatching(string[] words)
        {
            List<string> list = new List<string>();
            int n = words.Length;
            for(int i=0;i<n; i++)
            {
                for(int j=0;j<n;j++)
                {
                    if(i==j)
                    {
                        continue;
                    }

                    if (IsSubString(words[i], words[j]))
                    {
                        list.Add(words[i]);
                        break;
                    }

                }
            }
            return list;
        }

        public static bool IsSubString(string a,string b)
        {
            string combined = a + "#" + b;
            int[] Z = BuildZArrayStringMatching(combined);
            int n=Z.Length;
            int p=a.Length;
            for(int i = 0; i < n; i++)
            {
                if (Z[i] == p)
                {
                    return true;
                }
            }
            return false;
        }

       

        public static int[] BuildZArrayStringMatching(string combined)
        {
            int n = combined.Length;
            int[] Z = new int[n];
            for(int i = 1; i < n; i++)
            {
                int l = 0, r = 0;
                if (i > r)
                {
                    l = r = i;
                    while(r<n && combined[r] == combined[r-l])
                    {
                        r++;
                    }
                    Z[i] = r - l;
                    r--;
                }
                else
                {
                    int k = i - l;
                    if (Z[k] < r - i + 1)
                    {
                        Z[i] = Z[k];
                    }
                    else
                    {
                        l = i;
                        while (r < n && combined[r] == combined[r - l])
                        {
                            r++;
                        }
                        Z[i] = r - l;
                        r--;
                    }
                }
            }
            return Z ;
        }
    }
}
