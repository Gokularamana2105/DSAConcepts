using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Built_In_Sort
{
    internal class Built_In_Sort
    {
        static void Main(string[] args)
        {
            int[] nums = { 64, 34, 25, 12, 22, 11, 90 };

            Array.Sort(nums);
            var result=nums.Select(x => x).ToList();
            Console.WriteLine($"[{string.Join(",", result)}]");

            Array.Sort(nums);
            var resultTwo = nums.Select(x => x).ToList();
            Console.WriteLine($"[{string.Join(",", resultTwo)}]");
            Array.Reverse(nums);
            var resultThree = nums.Select(x => x).ToList();
            Console.WriteLine($"[{string.Join(",", resultThree)}]");

            Array.Sort(nums,(a,b)=>b-a); //descending
            var resultFour = nums.Select(x => x).ToList();
            Console.WriteLine($"[{string.Join(",", resultFour)}]");

            Array.Sort(nums,(a,b)=>a-b); //ascending
            var resultFive=nums.Select(x => x).ToList();
            Console.WriteLine($"[{string.Join(",",resultFive)}]");


            //Sorting strings and arrays of arrays

            string[] words = { "banana", "apple", "cherr" };
            Array.Sort(words);
            var resultString=words.Select(x => x).ToList();
            Console.WriteLine($"[{string.Join(",",resultString)}]");

            // Sort array of pairs by first element
            int[][] pairs =
            {
                new int[]{3,1},
                new int[]{1,5},
                new int[]{2,3}
            };
            Array.Sort(pairs, (a, b) => a[0] - b[0]);
            var resultPair = Enumerable.Range(0, pairs.Length).
                Select(i => $"[{string.Join(",", Enumerable.Range(0, pairs[0].Length).Select(j =>  pairs[i][j]))}]").ToList();

            Console.WriteLine($"[{string.Join(", ", resultPair)}]");

            //Sort by string Length
            Array.Sort(words, (a, b) => a.Length - b.Length);
            var resultStrLen=words.Select(x=>x).ToList();
            Console.WriteLine($"[{string.Join(",", resultStrLen)}]");
            Console.ReadLine();
        }
    }
}
