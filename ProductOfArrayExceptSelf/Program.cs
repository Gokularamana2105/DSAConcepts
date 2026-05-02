using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOfArrayExceptSelf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 1, 2, 3, 4 };
            int[] result = ProductExceptSelf(input);
            Console.WriteLine(string.Join(",",result));
            Console.ReadLine();
        }
        public static int[] ProductExceptSelf(int[] nums)
        {

            int n = nums.Length;
            int[] result = new int[n];
            int left = 1;
            //left 
            for (int i = 0; i < n; i++)
            {
                result[i] = left;
                left *= nums[i];
            }
            //right
            int right = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                result[i] *= right;
                right *= nums[i];
            }
            return result;

            //brute force
            //int n=nums.Length;
            //int [] result = new int[n];
            //for(int i = 0; i < n; i++)
            //{
            //    int counter = 1;
            //    for (int j = 0; j < n; j++)
            //    {

            //        if (j != i)
            //        {
            //           counter *= nums[j];
            //        }
            //    }
            //    result[i] = counter;
            //}
            //return result;
        }
    }
}
