using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSetValue();
            Console.ReadLine();
        }

        public static void HashSetValue()
        {
            var hash=new HashSet<int>();
            hash.Add(1);
            hash.Add(2);
            hash.Add(3);
            hash.Add(4);
            hash.Add(4);

            Console.WriteLine(hash.Count);
            Console.WriteLine(hash.Contains(3));
            Console.WriteLine(hash.Contains(5));

            //HashSet example — detect duplicate
            var seen=new HashSet<int>();
            int[] nums = { 1, 2, 3, 1 };
            foreach(int i in nums)
            {
                if (!seen.Add(i))
                {
                    Console.WriteLine("Duplicate : "+i);
                }
            }

            //HashSet operations

            var setA = new HashSet<int> { 1, 2, 3, 4, 5 };
            var setB = new HashSet<int> { 3, 4, 5, 6, 7 };

            setA.Add(10);
            foreach(int i in setA)
            {
                Console.WriteLine(i);
            }

            setA.Remove(1);
            foreach (int i in setA)
            {
                Console.WriteLine(i);
            }

            //Set Operations
            var result= setA.Intersect(setB);
            Console.WriteLine(string.Join(",",result));

           setA.UnionWith(setB);
            Console.WriteLine(string.Join(",", setA));

            setA.ExceptWith(setB);
            Console.WriteLine(string.Join(",", setA));
        }

    }
}
