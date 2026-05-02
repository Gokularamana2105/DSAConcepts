using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ContainerWithMostWater
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] height = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            int result=MaxArea(height);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static int MaxArea(int[] height)
        {
            //water =width*height
            //1.width = distance between the two lines → (right index - left index)
            //2.height = smaller of the two heights → min(height[left], height[right])
            int left = 0, right = height.Length - 1;
            int maxWater = 0;
            while (left < right)
            {
                int width=right-left;
                int h = Math.Min(height[left], height[right]);
                maxWater = Math.Max(maxWater, width * h);
                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                   right--;
                }
            }
            return maxWater;


        }
    }
}
