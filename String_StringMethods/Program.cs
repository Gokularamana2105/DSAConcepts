using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace String_StringMethods
{
    public class Program
    {
        static void Main(string[] args)
        {
            string word = "hello";

            //Category 1: Inspection & Search(The "Where")
            char first = word[0];
            char second = word[1];
            char last = word[4];

            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(last);

            string sentence= "I love programming and interested to learn new programming language";
            bool hasTrue = sentence.Contains("programming");
            bool hasFalse = sentence.Contains("python");
            Console.WriteLine(hasTrue);
            Console.WriteLine(hasFalse);


            int firstIndex = sentence.IndexOf("program");
            int lastIndex = sentence.LastIndexOf("program");
            Console.WriteLine(firstIndex);
            Console.WriteLine(lastIndex);

            bool containTrue = sentence.Split(' ').Any(x => x.StartsWith("programming"));
            bool containFalse = sentence.Split(' ').Any(x => x.EndsWith("ing"));

            Console.WriteLine(containTrue);
            Console.WriteLine(containFalse);

            //Category 2: Extraction & Splitting (The "Slice")

            string subString=sentence.Substring(0,sentence.Length-3);
            Console.WriteLine(subString);
            char[] chars = sentence.ToCharArray();
            Console.WriteLine(string.Join(" ", chars));

            //Category 3: Cleaning & Formatting(The "Fix")
            string s = " hello world ";
            Console.WriteLine(s);
            //Removes whitespace from start/end.
            Console.WriteLine(s.Trim());
            Console.WriteLine(s.ToLower());

            Console.WriteLine(s.ToUpper());

            Console.WriteLine(string.Concat(s.Trim(),sentence));


            //Category 4: Conversion(The "Bridge")
            //Moving between numbers to Text
            string number = "12345";
            int num=int.Parse(number);
            Console.WriteLine(num);
            long l= long.Parse(number);
            Console.WriteLine(l);
            string againString=num.ToString();
            Console.WriteLine(againString);

            char c = '7';
            int valMath = c - '0';
            int valBuiltIn=(int)char.GetNumericValue(c);
            Console.WriteLine($"Using 'c - \'0\'': {valMath}");
            Console.WriteLine($"Using GetNumericValue: {valBuiltIn}");
            char letter = 'A';
            double safeCheck = char.GetNumericValue(letter);
            // Returns -1.0 if not a numeric character

            Console.WriteLine($"Is 'A' a number? {safeCheck >=0}");

            //String Builder
            //Key Methods:
            //    .Append(val): Add to end().
            //    .Insert(index, val): Insert at specific spot.
            //    .Remove(start, len): Delete part.
            //    .ToString(): Convert back to standard string when done.

            StringBuilder sb = new StringBuilder();
            int n = 10;
            for (int i = 0; i < n; i++)
            {
                sb.Append(i);
            }
            string result = sb.ToString();
            Console.WriteLine(result);
            Console.ReadLine();
        }


    }
}
