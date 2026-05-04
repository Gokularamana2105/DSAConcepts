using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public static class DictionaryExtensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(
            this Dictionary<TKey, TValue> dict,
            TKey key,
            TValue defaultValue)
        {
            return dict.TryGetValue(key, out TValue value) ? value : defaultValue;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DictionaryValue();
            Console.ReadLine();
        }
        public static void DictionaryValue()
        {
            var map = new Dictionary<string, int>();
            map["one"] = 1;
            map["two"] = 2;
            map["three"] = 3;
            map["four"] = 4;

            Console.WriteLine(map["one"]);
            Console.WriteLine(map["two"]);
            map["two"] = 10;
            Console.WriteLine(map["two"]);
            //safe way 1
            if (map.ContainsKey("five"))
            {
                Console.WriteLine(map["five"]);
            }
            //safe way 2
            if (map.TryGetValue("five",out int val))
            {
                Console.WriteLine(map["five"]);
            }
            else
            {
                Console.WriteLine("Not Found");
            }

            //Safe way 3
            int count = map.GetValueOrDefault("five",0);
            Console.WriteLine(count);

            //Looping through Dictionary

            foreach(var pair in map)
            {
                Console.WriteLine(pair.Key+":"+pair.Value);
            }

            //Loop only key
            foreach(string key in map.Keys)
            {
                Console.WriteLine(key);
            }

            //loop only values
            foreach(int value in map.Values)
            {
                Console.WriteLine(value);
            }

            //Most Common Dictionary Pattern
            int[] nums = { 1, 2, 2, 3, 3, 3 };
            var freq=new Dictionary<int, int>();

            //foreach(int i in nums)
            //{
            //    if (freq.ContainsKey(i))
            //    {
            //        freq[i]++;
            //    }
            //    else
            //    {
            //        freq[i] = 1;
            //    }
            //}

            //easy way
            foreach(int i in nums)
            {
                freq[i] = freq.GetValueOrDefault(i,0) + 1;
            }

            foreach(var pair in freq)
            {
                Console.WriteLine(pair.Key+":"+pair.Value);
            }


            //Remove and Count
            map.Remove("two");
            Console.WriteLine(map.ContainsKey("two"));
            Console.WriteLine(map.Count);
            map.Clear();
            Console.WriteLine(map.Count);

        }
    }
}
