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
            string[] strs = { "eat", "tea", "tan", "ate", "nat", "bat" };
            IList<IList<string>> list=GroupAnagrams(strs);
            //Console.WriteLine(string.Join(", ", string.Join(",",list)));

            int[] nums = { 100, 4, 200, 1, 3, 2 };
            int maxCount= LongestConsecutive(nums);
            Console.WriteLine(maxCount);
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

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<string> keys= new List<string>();
            List<IList<string>> result= new List<IList<string>>();
            foreach(string str in strs)
            {
                char[] chars= str.ToCharArray();

                for(int i = 0; i < chars.Length - 1; i++)
                {
                    for(int j=0;j<chars.Length-i-1; j++)
                    {
                        if (chars[j] > chars[j + 1])
                        {
                            char temp = chars[j];
                            chars[j]= chars[j + 1];
                            chars[j+1]= temp;
                        }
                    }
                }

                string sortedString = "";
                for(int j=0;j<chars.Length; j++)
                {
                    sortedString += chars[j];
                }

                int foundIndex = -1;

                for(int j=0;j<keys.Count;j++)
                {
                    if (keys[j]==sortedString)
                    {
                        foundIndex = j;
                        break;
                    }
                }


                if(foundIndex==-1)
                {
                    keys.Add(sortedString);
                    List<string> group = new List<string>();
                    group.Add(str);
                    result.Add(group);
                }
                else
                {
                    result[foundIndex].Add(str);
                }
            }
            return result;
        }

        public static int LongestConsecutive(int[] nums)
        {
            //for(int i = 0; i < nums.Length - 1; i++)
            //{
            //    for(int j=0;j<nums.Length-i-1;j++)
            //    {
            //        if (nums[j] > nums[j + 1])
            //        {
            //            int temp = nums[j];
            //            nums[j]= nums[j + 1];
            //            nums[j+1]= temp;
            //        }
            //    }
            //}

            //int currentCount = 1;
            //int maxCount = 1;

            //for(int i=1;i<nums.Length;i++)
            //{
            //    if (nums[i] == nums[i - 1])
            //    {
            //        continue;
            //    }
            //    if (nums[i] == nums[i - 1] + 1)
            //    {
            //        currentCount++;
            //    }
            //    else
            //    {
            //        currentCount = 1;
            //    }
            //    maxCount=Math.Max(maxCount, currentCount);
            //}
            //return maxCount;

            var set=new HashSet<int>(nums);
            int maxLen = 0;
            foreach(int i in set)
            {
                if (!set.Contains(i-1))
                {
                    int curr = i, len = 1;
                    while (set.Contains(curr+1))
                    {
                        curr++;
                        len++;
                    }
                    maxLen=Math.Max(maxLen, len);
                }
            }
            return maxLen;
        }
    }
}
