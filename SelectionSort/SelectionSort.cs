using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    internal class SelectionSort
    {
        static void Main(string[] args)
        {
            int[] nums = { 64, 25, 12, 22, 11 };

            int n= nums.Length;

            for (int i = 0; i < n - 1; i++)
            {
                // find the index of the smallest value from i to end
                int midIdx = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (nums[midIdx] > nums[j])
                    {
                        midIdx = j; // found a smaller one
                    }
                }
                // swap smallest into position i mean current position
                int temp = nums[i];
                nums[i] = nums[midIdx];
                nums[midIdx] = temp;
            }

            var result = nums.Select(x => x).ToArray();
            Console.WriteLine($"[{string.Join(",", result)}]");
            Console.ReadLine();
        }
    }
}
