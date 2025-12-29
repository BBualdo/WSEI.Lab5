using System;

namespace Tablice.Exercises.macierze;

public class Pytanie_2 {
    public static void Main(string[] args) {
        string[] dimensionsA = Console.ReadLine().Split(' ');
        int rowsA = int.Parse(dimensionsA[0]);
        int colsA = int.Parse(dimensionsA[1]);
        int[,] matrixA = GetMatrixFromInput(rowsA, colsA);
        
        string[] dimensionsB = Console.ReadLine().Split(' ');
        int rowsB = int.Parse(dimensionsB[0]);
        int colsB = int.Parse(dimensionsB[1]);
        int[,] matrixB = GetMatrixFromInput(rowsB, colsB);

        if (colsA != rowsB) {
            Console.WriteLine("impossible");
            return;
        }

        int[,] result = MultiplyMatrix(matrixA, matrixB);
        PrintMatrix(result);
    }
    
    private static int[,] GetMatrixFromInput(int rows, int cols) {
        int[,] matrix = new int[rows, cols];
        string[] line = Console.ReadLine().Split(' ');
        var count = 0;
        for (var i = 0; i < rows; i++) {
            for (var j = 0; j < cols; j++) {
                matrix[i, j] = int.Parse(line[count]);
                count++;
            }
        }

        return matrix;
    }

    private static int[,] MultiplyMatrix(int[,] matrixA, int[,] matrixB) {
        int rowsA = matrixA.GetLength(0);
        int colsB = matrixB.GetLength(1);
        int[,] result = new int[rowsA, colsB];

        for (var i = 0; i < rowsA; i++) {
            for (var j = 0; j < colsB; j++) {
                result[i, j] = MultiplyRowWithColumn(matrixA, i, matrixB, j);
            }
        }
        
        return result;
    }

    private static int MultiplyRowWithColumn(int[,] matrixA, int rowA, int[,] matrixB, int colB) {
        int commonDimension = matrixA.GetLength(1);
        int result = 0;
        
        for (var i = 0; i < commonDimension; i++) {
            result += matrixA[rowA, i] * matrixB[i, colB];
        }

        return result;
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