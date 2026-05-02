using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Learning
{
    internal class ArrayManipulations
    {
        static void Main(string[] args)
        {
            //1. Creating Arrays
                int[] nums = new int[5];                    // Fixed size, default values
                Console.WriteLine(string.Join(" ", nums));
                int[] numsTwo = { 1, 2, 3, 4, 5 };             // Inline initialization
                int[] numsThree = new int[] { 1, 2, 3 };         // Explicit type
                var numsFour = new[] { 1, 2, 3 };   // Type inference


                //Multi-dimensional arrays
                int[,] matrix = new int[3, 3]; //2D array
                int[,,] cube = new int[2, 2, 2]; //3D array

                // Jagged arrays (array of arrays)
                int[][] jagged = new int[3][];
                jagged[0] = new int[] { 1, 2 };
                jagged[1] = new int[] { 1, 23, 3 };
                jagged[2] = new int[] { 6 };
                var result=jagged.Select(x=>$"[{string.Join(",",x)}]").ToList();
                Console.WriteLine(string.Join(",", result));

            //2. Accessing Elements
                int[] numsFive = { 10, 20, 30, 40, 50 };
                int first = numsFive[0];
                int last=numsFive[numsFive.Length-1];
                Console.WriteLine(first + "," + last);

                // 2D array access
                int[,] matrixTwo = { { 1, 2 }, { 3, 4 } };
                int val = matrixTwo[1, 0];
                Console.WriteLine(val);

                // Jagged array access
                int[][] jaggedTwo = { new[] { 1, 2 }, new[] { 3, 4, 5 }, new[] { 6 } };
                int valTwo = jaggedTwo[0][1];
                Console.WriteLine(valTwo);


            //3D array
            int[,,] cubeTwo = new int[2, 3, 4]
            {
                {{1,2,3,4},{4,5,6,7},{8,9,10,11} },
                {{2,3,4,5},{ 5,7,8,9},{ 9,10,11,12} }
            };

            int valCube = cubeTwo[0, 1, 3];
            Console.WriteLine(valCube);

            //3.Modifying Elements
                int[] numsSix = { 1, 2, 3, 4, 5 };
                numsSix[0] = 10;
                numsSix[2] *=2;
                Console.WriteLine(string.Join(",",numsSix));

                int[,] matrixThree = new int[2, 2]
                {
                    {1,2 },{2,3 }
                };
                matrixThree[1, 0] = 10;
                matrixThree[1, 1] *= 2;


                //forloop
                for(int i = 0; i < matrixThree.GetLength(0); i++)
                {
                    Console.Write("[");
                    for (int j=0; j < matrixThree.GetLength(1); j++)
                    {
                      Console.Write(matrixThree[i, j]);
                        if (j < matrixThree.GetLength(1) - 1)
                        {
                            Console.Write(",");
                        }
                    }
                    Console.Write("]");
                }
                Console.WriteLine();
                //Linq
              

              //4.Iterating Through Arrays
                    foreach(var (value,index) in numsSix.Select((v, i) => (v, i)))
                    {
                        Console.WriteLine($"{index} : {value}");
                    }

                    //Linq
                    var resultThree = numsSix.Select((v, i) => $"{i} : {v}").ToList();
                    Console.WriteLine(string.Join(", ", resultThree));

                    var resultTwo = Enumerable.Range(0, matrixThree.GetLength(0)).
                    Select(i => $"[{string.Join(",", Enumerable.Range(0, matrixThree.GetLength(1)).Select(j => matrixThree[i, j]))}]").ToList();

                    Console.WriteLine(string.Join(",", resultTwo));

                  //Iterate 3D Array
                    for(int i = 0; i < cubeTwo.GetLength(0); i++)
                    {
                       Console.Write("[");
                        for(int j=0;j < cubeTwo.GetLength(1); j++)
                        {
                            Console.Write("[");
                            for (int k=0;k< cubeTwo.GetLength(2); k++)
                            {
                                Console.Write(cubeTwo[i, j, k]);

                               if(k < cubeTwo.GetLength(2) - 1)
                               {
                                    Console.Write(",");
                               }
                            }
                            Console.Write("]");
                        }
                      Console.Write("]"+"\n");
                    }

            //5.Searching Arrays
                int idxTwo = Array.IndexOf(numsSix, 10);
                bool Exists = Array.Exists(numsSix, x => x > 25);
                int find=Array.Find(numsSix,x=> x > 25); int[] all=Array.FindAll(numsSix,x=>x > 25);
                Console.WriteLine(idxTwo);
                Console.WriteLine(Exists);
                Console.WriteLine(find);
                Console.WriteLine(string.Join(",", all));

              Array.Sort(numsSix);
            int bindIdx = Array.BinarySearch(numsSix, 10);
            Console.WriteLine(bindIdx);

            //6. Sorting
                int[] numsSeven = { 5, 2, 8, 1, 9 };
                Array.Sort(numsSeven);
                Console.WriteLine(string.Join(",", numsSeven));
                Array.Reverse(numsSeven);
                Console.WriteLine(string.Join(",", numsSeven));
                Array.Sort(numsSeven, 0, 3);
                Console.WriteLine(string.Join(",", numsSeven));
                Array.Reverse(numsSeven, 0, 3);
                Console.WriteLine(string.Join(",", numsSeven));

                //Custom Sorting
                Array.Sort(numsSeven,(a,b)=>b.CompareTo(a)); //Descending
                Console.WriteLine(string.Join(",", numsSeven));

                // Sort with another array (parallel sort)
                string[] names = { "Alice", "Bob", "Charlie" };
                int[] ages = { 25, 30, 20 };
                Array.Sort(ages, names);
                Console.WriteLine(string.Join(",", names));   // Sort names by ages

            //7. Copying Arrays
                int[] numsEight= { 1, 2, 3, 4, 5 };
                int[] clone = (int[])numsEight.Clone();
                Console.WriteLine(string.Join(",",clone));
                //Copy
                int[] copy=new int[numsEight.Length];
                Array.Copy(numsEight,copy,numsEight.Length);
                Console.WriteLine(string.Join(",",copy));
                //Copy with offsets 
                Array.Copy(numsEight, 1, copy, 0, 3);
                Console.WriteLine(string.Join(",", copy));


                // CopyTo
                nums.CopyTo(copy, 0);
                // Deep copy for multi-dimensional
                int[,] original = { { 1, 2 }, { 3, 4 } };
                int[,] deepCopy = (int[,])original.Clone();
                var resultFour = Enumerable.Range(0, deepCopy.GetLength(0)).
                    Select(i => $"[{string.Join(",", Enumerable.Range(0, deepCopy.GetLength(1)).Select(j => deepCopy[i, j]))}]").ToList();
                Console.WriteLine("DeepCopy "+string.Join(",", resultFour));

            //9.Common Array Methods
            Console.WriteLine();
                int[] numsNine = { 1, 2, 3, 4, 5 };
                int length=numsNine.Length;
                Console.WriteLine(length);
                int rank=numsNine.Rank;  // 1 (dimensions)
                Console.WriteLine(length);
                Array.Clear(numsNine, 0, length); // Set all to 0
                Console.WriteLine(string.Join(",",numsNine));
                Array.Empty<int>();
                int[] range = Enumerable.Range(1, 5).ToArray();

            //10. LINQ Operations on Arrays
                Console.WriteLine();
                int[] numsTen= { 1, 2, 3, 4, 5 };
                var filtered = numsTen.Where(n => n > 2).ToList();
                var select = numsTen.Select(x => x*2).ToList();
                var sum=numsTen.Sum();
                var max=numsTen.Max();
                var min=numsTen.Min();
                var avg=(int)numsTen.Average();
                bool any = nums.Any(n => n > 3);                         // True
                bool allNums = nums.All(n => n > 0);                         // True
                int count = nums.Count(n => n % 2 == 0);                 // 2
                var distinct = nums.Distinct().ToArray();
                var ordered = nums.OrderBy(n => n).ToArray();
                var reversed = nums.Reverse().ToArray();
                var first3 = nums.Take(3).ToArray();
                var skip2 = nums.Skip(2).ToArray();

                Console.WriteLine(string.Join(",", filtered));
                Console.WriteLine(string.Join(",", select));
                Console.WriteLine(string.Join(",", distinct));
                Console.WriteLine(string.Join(",", ordered));
                Console.WriteLine(string.Join(",", reversed));
                Console.WriteLine(string.Join(",", first3));
                Console.WriteLine(string.Join(",", skip2));
                Console.WriteLine(sum);
                Console.WriteLine(max);
                Console.WriteLine(min);
                Console.WriteLine(avg);
                Console.WriteLine(allNums);
                Console.WriteLine(count);

            //11. Multi-Dimensional Arrays
                Console.WriteLine();
                int[,] matrixEleven = new int[3, 3];
                matrixEleven[0, 0] = 1;

                int rows = matrixEleven.GetLength(0);  // 3
                int cols = matrixEleven.GetLength(1);  // 3

                // Iterate
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write(matrixEleven[i, j] + " ");
                    }
                    Console.WriteLine();
                }

            //12.Jagged Arrays
                Console.WriteLine();
                int[][] jaggedTwelve=new int[3][];
                jaggedTwelve[0] = new[] { 1, 2, 3 };
                jaggedTwelve[1] = new[] {3,4, 5 };
                jaggedTwelve[2]= new[] {5,6,7};

                int valTwelve = jaggedTwelve[0][1];
                for(int i = 0; i < jaggedTwelve.Length; i++)
                {
                   for(int j = 0; j < jaggedTwelve[i].Length; j++)
                   {

                    Console.Write(jaggedTwelve[i][j] + " ");
                   }
                    Console.WriteLine();
                }

       
            Console.ReadLine(); 
        }
    }
}
