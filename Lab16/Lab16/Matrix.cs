using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab16
{
    class Matrix
    {
        private int[,] arr;
        private int calomn; //рядок
        private int rows; //строка
        
        public Matrix(int[,] matrix)
        {
            arr = matrix;
            calomn = arr.GetUpperBound(1) + 1;
            rows = arr.GetUpperBound(0) + 1;
        }

        public int this[int i, int j]
        {
            get
            {
                return arr[i, j];
            }
            set
            {
                arr[i, j] = value;
            }
        }

        private bool IsMul(int rows, int calomn)
        {
            return rows == calomn ? true : false;
        }

        public Matrix MatrixMul(Matrix rmatrix)
        {
            if (!IsMul(calomn, rmatrix.rows)) throw new Exception("Не совпадают колво строк и столбцов в перемнажаемых матрицах!");

            var newMatrix = new int[rows, rmatrix.calomn];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < rmatrix.calomn; j++)
                {
                    newMatrix[i, j] = 0;

                    for (var k = 0; k < calomn; k++)
                    {
                        newMatrix[i, j] += arr[i, k] * rmatrix.arr[k, j];
                    }
                }
            }

            return new Matrix(newMatrix);
        }

        public void PrintMatrix()
        {
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < calomn; j++)
                {
                    Console.Write(arr[i, j].ToString().PadLeft(4));
                }

                Console.WriteLine();
            }
        }
    }
}
