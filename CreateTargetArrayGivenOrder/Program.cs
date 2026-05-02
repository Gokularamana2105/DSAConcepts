using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CreateTargetArrayGivenOrder
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 0, 1, 2, 3, 4 };
            int[] index = { 0, 1, 2, 2, 1 };
            var result = CreateTargetArray(nums, index);
            Console.WriteLine(string.Join(",", result));

            int[] numsTwo = { 1, 1, 0, 1, 1, 1 };
            int output= FindMaxConsecutiveOnes(numsTwo);
            Console.WriteLine(output);
            Console.ReadLine();
        }

        public static int[] CreateTargetArray(int[] nums, int[] index)
        {
            //int[] target = new int[nums.Length];
            //int size = 0;

            //for(int i=0;i<nums.Length; i++)
            //{
            //    for(int j = size; j > index[i]; j--)
            //    {
            //        target[j] = target[j-1];
            //    }
            //    target[index[i]] = nums[i];
            //    size++;
            //}

            //return target;

            //using Linq
            return nums.Select((val, i) => new { val, idx = index[i] }).
                Aggregate(new List<int>(), (acc, c) => acc.Take(c.idx).Concat(new[] { c.val }).Concat(acc.Skip(c.idx)).ToList()).ToArray();
        }

        //Max Consecutive Ones
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            return nums.Aggregate(
               new {count=0,max=0},
               (acc,c)=>c==1
                   ? new {count=acc.count+1,max=Math.Max(acc.max,acc.count+1)}
                   : new {count=0,max=acc.max}
            ).max;
        }
    }
}
