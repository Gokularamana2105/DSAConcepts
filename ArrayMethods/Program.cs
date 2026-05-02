using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayMethods
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] prices = { 7, 1, 5, 3, 6, 4 };
            int result=MaxProfit(prices);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        //121. Best Time to Buy and Sell Stock
        public static int MaxProfit(int[] prices)
        {
            //int maxProfit = 0;
            //int minValue = int.MaxValue;
            //foreach (int num in prices)
            //{
            //    //Track the lowest price so far
            //    if (num < minValue)
            //    {
            //        minValue = num;
            //    }
            //    // Calculate profit if selling today
            //    else if (num - minValue > maxProfit)
            //    {
            //        maxProfit = num - minValue;
            //    }
            //}
            //return maxProfit;

            var result = prices.Aggregate((minPrice: int.MaxValue, maxPrice: 0), (acc, c) =>
                (
                  minPrice: Math.Min(acc.minPrice, c),
                  maxPrice: Math.Max(acc.maxPrice, (c - acc.minPrice))
                )
            );

            return result.maxPrice;


        }
    }
}
