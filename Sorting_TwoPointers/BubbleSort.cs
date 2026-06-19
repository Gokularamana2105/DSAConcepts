using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_TwoPointers
{
    internal class BubbleSort
    {
        static void Main(string[] args)
        {
            //Demo
            int[] nums = { 64, 34, 25, 12, 22, 11, 90 };
            int n= nums.Length;
            for(int i=0;i<n-1;i++)
            {
                for(int j=0;j<n-i-1;j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        int temp = nums[j];
                        nums[j]= nums[j + 1];
                        nums[j+1]= temp;
                    }
                }
            }
            var result=nums.Select(x => x).ToArray();
            Console.WriteLine($"[{string.Join(",", result)}]");
            Console.ReadLine();
        }

        

    }
}
