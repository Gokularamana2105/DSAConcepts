using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringComparison
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ManualCompare("apple", "banana")); // Negative (apple < banana)
            Console.WriteLine(ManualCompare("zebra", "apple"));  // Positive (zebra > apple)
            Console.WriteLine(ManualCompare("cat", "catalog"));  // Negative (cat < catalog)
            Console.WriteLine(ManualCompare("Hello", "hello"));  // Negative ('H' < 'h' in ASCII)

            Console.WriteLine(IsEqualIgnoreCase("apple", "banana")); // Negative (apple < banana)
            Console.WriteLine(IsEqualIgnoreCase("zebra", "apple"));  // Positive (zebra > apple)
            Console.WriteLine(IsEqualIgnoreCase("cat", "catalog"));  // Negative (cat < catalog)
            Console.WriteLine(IsEqualIgnoreCase("Hello", "hello"));

            List<string> words = new List<string> { "banana", "pie", "Washington", "book", "a" };
            SortStrings(words);

            Console.WriteLine("\n");
            string a = "hello";
            string b = "hellos";
            string c = "Hello";
            Console.WriteLine(a == b);
            Console.WriteLine(a == c);

            //Case Sensitive comparison
            bool same = string.Equals(a, c, System.StringComparison.OrdinalIgnoreCase);
            Console.WriteLine(same);

            int result=string.Compare(a,b, System.StringComparison.OrdinalIgnoreCase);
            Console.WriteLine(result);
            Console.ReadLine();
        }


        //1. Manual Comparsion
        public static int ManualCompare(string s1,string s2)
        {
            int len1= s1.Length;
            int len2= s2.Length;

            int min=Math.Min(len1,len2);
            for(int i = 0; i < min; i++)
            {
                if (s1[i] != s2[i])
                {
                    return s1[i] - s2[i];
                }
            }
            if (len1 == len2) return 0;
            return len1 < len2 ? -1 : 1;
        }

        //2.Case-Insensitive Comparison

        public static bool IsEqualIgnoreCase(string s1,string s2)
        {
            if(s1.Length != s2.Length) return false;
            for(int i=0;i<s1.Length; i++)
            {
                if (char.ToLower(s1[i]) != char.ToLower(s2[i])) return false;
            }
            return true;
        }

        //3.Custom Sorting (Using Comparer)
        public static void SortStrings(List<string> list)
        {
            list.Sort((a, b) =>
            {
                if(a.Length != b.Length)
                {
                    return a.Length - b.Length;
                }

                return string.Compare(a,b,System.StringComparison.Ordinal);
            });
        }
    }
}
