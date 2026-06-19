using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    public class InsertionSort
    {
        static void Main(string[] args)
        {
            int[] nums = {5,3,8,1,4 };
            int n= nums.Length;
            
            for(int i = 1; i < n; i++)
            {
                int key= nums[i]; // the card we are inserting
                int j = i - 1;// start comparing from left of key
                // shift larger elements one position to the right
                while (j>=0 && nums[j] > key)
                {
                    nums[j+1] = nums[j];
                    j--;
                }
                nums[j+1] = key; // place key in correct position
            }
            var result = nums.Select(x => x).ToArray();
            Console.WriteLine($"[{string.Join(",", result)}]");
            Console.ReadLine();
        }
    }
}
