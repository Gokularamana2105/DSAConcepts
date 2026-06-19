using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _2D_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating a matrix in C#

            //way-1 (2D-Array -->fixed Size,Clean Syntax)
            int[,] matrix=new int[3,3];
            matrix[0,0] = 1;
            matrix[0,1] = 2;
            matrix[0,2] = 3;
            matrix[1,0] = 2;
            matrix[1,1] = 3;
            matrix[1,2] = 4;
            matrix[2,0] = 3;
            matrix[2,1] = 4;

            int rows=matrix.GetLength(0);
            int cols=matrix.GetLength(1);

            for(int i=0;i<rows; i++)
            {
                Console.Write("[");
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                    if (j < cols - 1)
                    {
                        Console.Write(",");
                    }
                }
                Console.Write("]");
                Console.WriteLine();
            }
            Console.WriteLine(rows);
            Console.WriteLine(cols);

            //way-2—--> Jagged array (array of arrays, more flexible)

            int[][] grid = new int[3][];
            grid[0]=new int[] {1,2,3};
            grid[1]=new int[] {4,5,6};
            grid[2]=new int[] {7,8,9};


            int rowJag=grid.Length;

          
            for(int i=0;i < rowJag; i++)
            {
                Console.Write("[");
                int colJag = grid[i].Length;
                for(int j=0;j < colJag; j++)
                {
                    Console.Write(grid[i][j]);

                    if(j < colJag - 1) 
                    { 
                        Console.Write(",");
                    }
                }
                Console.WriteLine("]");
            }
           

            // Reading and writing cells

            int[][] matrixjag =
            {
                new int[]{1,2,3},
                new int[]{4,5,6},
                new int[]{7,8,9}
            };

            Console.WriteLine(matrixjag[0][1]);
            Console.WriteLine(matrixjag[2][1]);
            Console.WriteLine(matrixjag[0][2]);

            ////write cells
            //matrixjag[0][1] = 99;
            //Console.WriteLine(matrixjag[0][1]);

            //getting size of the matrix
            int rowsmat = matrixjag.Length;
            int colsmat = matrixjag[0].Length;
            Console.WriteLine("\n"+rowsmat);
            Console.WriteLine(colsmat);

            Console.WriteLine(matrixjag[rowsmat-1][colsmat-2]);

            //Looping through a matrix
            for(int i = 0; i < rowsmat; i++)
            {
                Console.Write("[");
                for(int j=0;j < colsmat; j++)
                {
                    Console.Write(matrixjag[i][j].ToString("D2"));
                    if(j< colsmat - 1)
                    {
                        Console.Write(",");
                    }
                }
               Console.WriteLine("]");
            }

            //Sum all elements
            int sum = 0;
            for(int i=0; i < rowsmat; i++)
            {
                for(int j=0;j < colsmat; j++)
                {
                    sum += matrixjag[i][j];
                }
            }
            Console.WriteLine(sum);

            //using linq
            sum = matrixjag.SelectMany(x=>x).Sum();
            Console.WriteLine(sum);

            //Diagonal — a very common pattern (row==column)

            for(int i = 0; i < rowsmat; i++)
            {
                Console.Write(matrixjag[i][i] + " ");
            }
            Console.WriteLine();
            //using linq
            var result=Enumerable.Range(0, rowsmat).Select(x => matrixjag[x][x]).ToList();
            Console.WriteLine(string.Join(",",result));
            //Anti-Diagonal (row+column ==n-1)
            int n = matrixjag.Length;
            for(int i = 0; i < n; i++)
            {
                int j = n - 1 - i;
                Console.Write(matrixjag[i][j] + " ");
            }
            //using linq
            Console.WriteLine() ;

            //Four NeightBours
            int r = 1, c = 1;
            int[] dr = { -1, 1, 0, 0 };
            int[] dc = { 0, 0, -1, 1 };

            for(int i=0;i<4;i++)
            {
                int nr = r + dr[i];
                int nc = c + dc[i];

               if(nr>=0 && nr<rows && nc>=0 && nc < cols)
                {
                    Console.WriteLine(matrixjag[nr][nc]);
                }
            }

            //Transpose Array
            int[][] matrixInput =
            {
                new int[]{1,2,3},
                new int[]{4,5,6},
                new int[]{7,8,9}

            };
            var resultOutput=Transpose(matrixInput);
            var resultGet = Enumerable.Range(0, resultOutput.Length).
                Select(i => $"[{string.Join(",", Enumerable.Range(0, resultOutput[0].Length).Select(j => resultOutput[i][j]))}]").ToList();

            Console.WriteLine(string.Join("\n", resultGet));

           var resultRotate= Rotate(matrixInput);
            var resultRotateGet = Enumerable.Range(0, resultRotate.Length).
                Select(i => $"[{string.Join(",", Enumerable.Range(0, resultRotate[0].Length).Select(j => resultRotate[i][j]))}]").ToList();
            Console.WriteLine(string.Join("\n", resultRotateGet));

            int[][] matrixInputTwo =
            {
                new int[]{ 1, 0, 1 },
                new int[]{ 1, 1, 1 },
                new int[]{ 1, 1, 1 }
            };

            var resultSetMatrix=SetMatrixZero(matrixInputTwo);
            var resultMatrixGet = Enumerable.Range(0, resultSetMatrix.Length).Select(i => $"[{string.Join(",", Enumerable.Range(0, resultSetMatrix[0].Length).Select(j => resultSetMatrix[i][j]))}]").ToList();
            Console.WriteLine(string.Join("\n",resultMatrixGet));

            int[][] matrixInputThree =
            {
                new int[]{1,2},
                new int[]{3,4}
            };
            var resultReshape = ReshapeMatrix(matrixInputThree, 1, 4);
            var resultReshapeGet = Enumerable.Range(0, resultReshape.Length).Select(i => $"[{string.Join(",", Enumerable.Range(0, resultReshape[0].Length).Select(j => resultReshape[i][j]))}]").ToList();
            Console.WriteLine(string.Join("\n", resultReshapeGet));

            int[][] matrixInputFour =
            {
                new int[]{ 1, 2, 3 },
                new int[]{ 4, 5, 6 },
                new int[]{ 7, 8, 9 }
            };
            var resultSpiral=
            Console.ReadLine();
        }

        public static int[][] Transpose(int[][] matrixjag) { 
            int rows=matrixjag.Length;
            int cols = matrixjag[0].Length;

            int[][] result = new int[cols][];
            for(int i=0;i<cols;i++)
            {
                result[i]=new int[rows];
            }

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    result[j][i] = matrixjag[i][j];
                }
            }
            return result;
        }

        public static int[][] Rotate(int[][] matrixjag)
        {
            //int rows = matrixjag.Length;
            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = i + 1; j < rows; j++)
            //    {
            //        int temp = matrixjag[i][j];
            //        matrixjag[i][j] = matrixjag[j][i];
            //        matrixjag[j][i] = temp;
            //    }
            //}

            //foreach (var num in matrixjag)
            //{
            //    int left = 0, right = num.Length - 1;
            //    while (left < right)
            //    {
            //        int temp = num[left];
            //        num[left] = num[right];
            //        num[right] = temp;
            //        left++;
            //        right--;
            //    }

            //}
            //return matrixjag;

            int rows = matrixjag.Length;
            int cols = matrixjag[0].Length;
            int[][] result = new int[cols][];
            for (int i = 0; i < cols; i++)
            {
                result[i] = new int[rows];
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[j][i] = matrixjag[i][j];
                }
            }
         
            for (int i = 0; i < rows; i++)
            {
                Array.Reverse(result[i]);
            }
            return result ;
            //using linq

        }

        public static int[][] SetMatrixZero(int[][] matrix)
        {
            //int rows = matrix.Length;
            //int cols = matrix[0].Length;

            //bool firstRowZero=false;
            //bool firstColumnZero=false;
            //// Check if first column has any zero
            //for (int i=0;i<rows; i++)
            //{
            //    if (matrix[i][0]==0)
            //    {
            //        firstColumnZero = true;
            //        break;
            //    }
            //}
            //// Check if first row has any zero
            //for (int i=0;i<cols;i++)
            //{
            //    if (matrix[0][i]==0)
            //    {
            //        firstRowZero = true;
            //        break;
            //    }
            //}

            ////Use first row and col as markers
            //for(int r=1;r<rows;r++)
            //{
            //    for(int c = 1; c < cols; c++)
            //    {
            //        if (matrix[r][c] == 0)
            //        {
            //            matrix[r][0] = 0;
            //            matrix[0][c] = 0;
            //        }
            //    }
            //}

            //// Set cells to zero based on markers
            //for(int r = 1; r < rows; r++)
            //{
            //    for(int c = 1;c < cols; c++)
            //    {
            //        if (matrix[r][0]==0 || matrix[0][c] == 0)
            //        {
            //            matrix[r][c] = 0;
            //        }
            //    }
            //}

            //if (firstRowZero)
            //{
            //    for (int i = 0; i < cols; i++)
            //    {
            //        matrix[0][i] = 0;
            //    }
            //}

            //if (firstColumnZero)
            //{
            //    for (int i = 0; i < rows; i++)
            //    {
            //        matrix[i][0] = 0;
            //    }
            //}

            //return matrix;

            int rows = matrix.Length;
            int cols= matrix[0].Length;

            int[] row= new int[rows];
            int[] col= new int[cols];

            for(int i=0; i < rows; i++)
            {
                for(int j=0; j < cols; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        row[i] = 1;
                        col[j] = 1;
                    }
                }
            }

            for(int i=0; i < rows; i++)
            {
                for(int j=0; j < cols; j++)
                {
                    if (row[i]==1 || col[j] == 1)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
            return matrix;
        }

        public static int[][] ReshapeMatrix(int[][] matrix,int r,int c)
        {
            

            int rows=matrix.Length;
            int cols = matrix[0].Length;
            if(rows*cols != r * c)
            {
                return matrix;
            }
            int[][] newMatrix = new int[r][];

            for(int i = 0; i < r; i++)
            {
                newMatrix[i] = new int[c];
            }
            
            for(int i=0; i < rows; i++)
            {
                for(int j=0; j < cols; j++)
                {
                 
                    //imagine 1D array -->{1,2,3,4}
                    int index = i * cols + j;  // example i=1,j=0 element =3  index=1*2+0 =2  
                    int newRow = index / c;  //  2/4 --> newRow =0 
                    int newColumn=index% c; // 2 % 4 --> newColumn=2
                    newMatrix[newRow][newColumn] = matrix[i][j];  //newMatrix[0][2]=3
                }
            }
            return newMatrix;
        }

        public static IList<int> SpiralOrder(int[][] matrix)
        {
            List<int> result = new List<int>();
           if(matrix.Length==0 || matrix == null)
           {
                return result;
           }
            int top = 0;
            int bottom=matrix.Length-1;
            int left = 0;
            int right = matrix[0].Length-1;
            while (top <= bottom && left<=right)
            {
                for(int i = left; i <= right; i++)
                {
                    result.Add(matrix[top][i]);
                }

                top++;
                for(int i=top; i <= bottom; i++)
                {
                    result.Add(matrix[i][right]);
                }
                right--;

                if (top <= bottom)
                {
                    for(int i=right;i>=left; i--)
                    {
                        result.Add(matrix[bottom][i]);
                    }
                    bottom--;
                }
                if (left <= right)
                {
                    for(int i=bottom; i>=top; i--)
                    {
                        result.Add(matrix[i][left]);
                    }
                    left++;
                }
            }
            return result;
        }
    }
}
