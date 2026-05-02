using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAllDisappearedNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1,1 };
            IList<int> result=FindDisappearedNumbers(nums);
            Console.WriteLine(string.Join(",", result));
            Console.ReadLine();
        }
        public static IList<int> FindDisappearedNumbers(int[] nums)
        {
            //foreach(int num in nums)
            //{
            //    int idx = Math.Abs(num)-1;
            //    if (nums[idx] > 0)
            //    {
            //        nums[idx] = -nums[idx];
            //    }
            //}

            //var result=new List<int>();
            //for(int i=0;i<nums.Length; i++)
            //{
            //    if (nums[i] > 0)
            //    {
            //        result.Add(i+1);
            //    }
            //}
            //return result;

            //HashSet<int> result=new HashSet<int>();
            //for(int i=1;i<=nums.Length;i++)
            //{
            //    result.Add(i);
            //}
            //for(int i = 0; i < nums.Length; i++)
            //{
            //    result.Remove(nums[i]);
            //}
            //return result.ToList();
            int n=nums.Length;
            var sat = new HashSet<int>(Enumerable.Range(1,n));
            var sat2 = new HashSet<int>();
            for(int i=0;i<n;i++)
            {
                sat2.Add(nums[i]);
            }
            sat.ExceptWith(sat2);
            return sat.ToList();
        }


    }
}
