using System;
using System.Collections.Generic;

namespace Tablice.Exercises.macierze;

public class Pytanie_3 {
    public static void Main(string[] args) {
        int[,] matrix = GetMatrixFromInput();
        int[] sums = GetArrayOfSums(matrix);
        int highestSum = GetMaxValue(sums);
        Console.WriteLine(Array.IndexOf(sums, highestSum));
    }

    private static int[,] GetMatrixFromInput() {
        List<int[]> rowsList = new List<int[]>();
        while (true) {
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) {
                break;
            }

            string[] row = input.Split(' ');
            int[] rowOfNumbers = Array.ConvertAll(row, int.Parse);
            rowsList.Add(rowOfNumbers);
        }

        int rows = rowsList.Count;
        int cols = rowsList[0].Length;
        int[,] matrix = new int[rows, cols];

        for (var i = 0; i < rows; i++) {
            for (var j = 0; j < cols; j++) {
                matrix[i, j] = rowsList[i][j];
            }
        }

        return matrix;
    }

    private static int[] GetArrayOfSums(int[,] matrix) {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[] sumsOfColumns = new int[cols];

        for (int i = 0; i < cols; i++) {
            int sum = 0;
            
            for (int j = 0; j < rows; j++) {
                sum += matrix[j, i];
            }
            
            sumsOfColumns[i] = sum;
        }

        return sumsOfColumns;
    }

    private static int GetMaxValue(int[] arr) {
        int max = arr[0];
        
        for (int i = 1; i < arr.Length; i++) {
            if (arr[i] > max) max = arr[i];
        }

        return max;
    }
}