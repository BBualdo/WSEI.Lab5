using System;

namespace Tablice.Exercises.macierze;

public class Pytanie_1 {
    public static void Main(string[] args) {
        string[] dimensions = Console.ReadLine().Split(' ');
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);
        
        int[,] matrix = GetMatrixFromInput(rows, cols);
        int[,] transposed = TransposeMatrix(cols, rows, matrix);
        
        PrintMatrix(transposed);
    }

    private static int[,] GetMatrixFromInput(int rows, int cols) {
        int[,] matrix = new int[rows, cols];
        
        for (var i = 0; i < rows; i++) {
            string[] line = Console.ReadLine().Split(' ');

            for (var j = 0; j < cols; j++) {
                matrix[i, j] = int.Parse(line[j]);
            }
        }

        return matrix;
    }

    private static int[,] TransposeMatrix(int targetRows, int targetCols, int[,] matrixToTranspose) {
        int[,] transposed = new int[targetRows, targetCols];
        
        for (var i = 0; i < targetRows; i++) {
            for (var j = 0; j < targetCols; j++) {
                transposed[i, j] = matrixToTranspose[j, i];
            }
        }

        return transposed;
    }

    private static void PrintMatrix(int[,] matrix) {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++) {
            string rowToPrint = "";
            for (int j = 0; j < cols; j++) {
                rowToPrint += $"{matrix[i, j]} ";
            }
            Console.WriteLine(rowToPrint.TrimEnd());
        }
    } 
}