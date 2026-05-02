using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 1, 2, 3, 4, 5, 6, 7 };
            int k = 3;
            Rotate(input, k);
            Console.ReadLine();
        }

        public static void Rotate(int[] nums, int k)
        {
            int n=nums.Length;
            k = k%n;
            var left = 0;var  right = n - 1;
            while (left < right)
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
                right--;
            }
            left = 0;right = k - 1;
            while (left < right)
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
                right--;
            }
            left = k;right= n - 1;
            while (left < right)
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
                right--;
            }
            //ReverseArray(nums, 0, n - 1);
            //ReverseArray(nums, 0, k-1);
            //ReverseArray(nums,k,n-1);   
            Console.WriteLine(string.Join(",", nums));
        }
        public static void ReverseArray(int[] nums,int left,int right)
        {
            while (left < right)
            {
               (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
                right--;
            }
          
        }
    }
}
