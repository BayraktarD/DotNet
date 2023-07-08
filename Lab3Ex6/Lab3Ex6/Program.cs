using System;

namespace Lab3Ex6
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows1, cols1, rows2, cols2;

            Console.WriteLine("Introduceti dimensiunile matricei 1 (randuri coloane):");
            string[] dimensions1 = Console.ReadLine().Split(' ');
            rows1 = int.Parse(dimensions1[0]);
            cols1 = int.Parse(dimensions1[1]);

            Console.WriteLine("Introduceti dimensiunile matricei 2 (randuri coloane):");
            string[] dimensions2 = Console.ReadLine().Split(' ');
            rows2 = int.Parse(dimensions2[0]);
            cols2 = int.Parse(dimensions2[1]);

            if (cols1 != rows2)
            {
                Console.WriteLine("Dimensiuni invalide pentru multiplicarea matricilor");
                return;
            }

            int[,] matrix1 = ReadMatrix(rows1, cols1, "Matricea 1");
            int[,] matrix2 = ReadMatrix(rows2, cols2, "Matricea 2");

            int[,] result = MultiplyMatrices(matrix1, matrix2);

            Console.WriteLine("Matrix 1:");
            PrintMatrix(matrix1);

            Console.WriteLine("Matrix 2:");
            PrintMatrix(matrix2);

            Console.WriteLine("Result:");
            PrintMatrix(result);
        }

        static int[,] ReadMatrix(int rows, int cols, string matrixName)
        {
            int[,] matrix = new int[rows, cols];

            Console.WriteLine($"Introduceri elementele pentru {matrixName}:");

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"Linia {i+1}");
                string[] elements = Console.ReadLine().Split(' ');

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = int.Parse(elements[j]);
                }
            }

            return matrix;
        }


        static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows1 = matrix1.GetLength(0);
            int cols1 = matrix1.GetLength(1);
            int cols2 = matrix2.GetLength(1);

            int[,] result = new int[rows1, cols2];

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    int sum = 0;

                    for (int k = 0; k < cols1; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }

                    result[i, j] = sum;
                }
            }

            return result;
        }

        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
