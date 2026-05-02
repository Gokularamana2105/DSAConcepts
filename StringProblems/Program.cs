using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringProblems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsIsomorphic("egg", "add"));   // true
            Console.WriteLine(IsIsomorphic("foo", "bar"));  
            Console.WriteLine(IsIsomorphic("paper", "title"));
            Console.WriteLine(BackSpaceCompare("ab##", "c#d#"));
            Console.ReadLine();
        }
        //Isomorphic String
        public static bool IsIsomorphic(string s,string t)
        {
            if(s.Length!=t.Length) return false;

            //var mapS=new Dictionary<char,char>();
            //var mapT=new Dictionary<char,char>();

            //for(int i = 0; i < s.Length; i++)
            //{
            //    char c = s[i];
            //    char c2 = t[i];
            //    if (mapS.ContainsKey(c))
            //    {
            //        if (mapS[c] != c2)
            //        {
            //            return false;
            //        }
            //    }
            //    else
            //    {
            //        mapS[c] = c2;
            //    }

            //    if (mapT.ContainsKey(c2))
            //    {
            //        if (mapT[c2] != c)
            //        {
            //            return false;
            //        }
            //    }
            //    else
            //    {
            //        mapT[c2] = c;
            //    }
            //}
            //return true;
            //int[] mapS = new int[256];
            //int[] mapT = new int[256];

            //for(int i = 0; i < s.Length; i++)
            //{
            //    if (mapS[s[i]] != mapT[t[i]])
            //    {
            //        return false;
            //    }
            //    mapS[s[i]] = i + 1;
            //    mapT[t[i]] = i + 1;
            //}
            //return true;

            //using IndexOf
            //for(int i=0;i<s.Length; i++)
            //{
            //    if (s.IndexOf(s[i]) != t.IndexOf(t[i]))
            //    {
            //        return false;
            //    }
            //}
            //return true;

            var pattern1 = s.Select((c, i) => s.IndexOf(c));
            var pattern2=t.Select((c,i)=>t.IndexOf(c));
            return pattern1.SequenceEqual(pattern2);
        }

        //Backspace string compare
        public static bool BackSpaceCompare(string s,string t)
        {
            //int i = s.Length - 1;
            //int j= t.Length - 1;

            //int skipS = 0, skipT = 0;
            //while(i>=0 || j >= 0)
            //{
            //    while (i >= 0)
            //    {
            //        if (s[i] == '#')
            //        {
            //            skipS++;
            //            i--;
            //        }
            //        else if(skipS>0)
            //        {
            //            skipS--;
            //            i--;
            //        }
            //        else { break; }
            //    }

            //    while (j >= 0)
            //    {
            //        if (t[j] == '#')
            //        {
            //            skipT++;
            //            j--;
            //        }
            //        else if (skipT > 0)
            //        {
            //            skipT--;
            //            j--;
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //    if(i>=0 && j >= 0)
            //    {
            //        if (s[i] != t[j])
            //        {
            //            return false;
            //        }
            //    }
            //    else
            //    {
            //        if(i>=0 || j >= 0)
            //        {
            //            return false;
            //        }
            //    }
            //    i--;
            //    j--;
                
            //}
            //return true;

            Stack<char> s1=new Stack<char>();
            Stack<char> t1=new Stack<char>();
            foreach(char c in s)
            {
                if (c != '#')
                {
                    s1.Push(c);
                }
                else 
                {
                    if (s1.Count > 0)
                    {
                        s1.Pop();
                    }
                      
                }
            }

            foreach(char c in t)
            {
                if(c != '#')
                {
                    t1.Push(c);
                }
                else
                {
                    if (t1.Count > 0)
                    {
                        t1.Pop();
                    }
                }
            }
            while(s1.Count>0 && t1.Count > 0)
            {
                if(s1.Pop() != t1.Pop())
                {
                    return false;
                }
            }
            return s1.Count == t1.Count;
        }
    }
}
