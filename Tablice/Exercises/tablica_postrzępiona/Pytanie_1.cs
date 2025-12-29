using System;

namespace Tablice.Exercises.tablica_postrzępiona;

public class Pytanie_1 {
    public static char[][] ReadJaggedArrayFromStdInput() {
        int rows = int.Parse(Console.ReadLine());

        char[][] jagged = new char[rows][];
        
        for (var i = 0; i < rows; i++) {
            jagged[i] = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToChar);
        }

        return jagged;
    }

    public static void PrintJaggedArrayToStdOutput(char[][] arr) {
        for (var i = 0; i < arr.Length; i++) {
            string rowResult = "";
            
            for (var j = 0; j < arr[i].Length; j++) {
                if (arr[i][j] != '\0') {
                    rowResult += $"{arr[i][j]} ";
                } else {
                    rowResult += "  ";
                }
            }
            
            Console.WriteLine(rowResult.TrimEnd());
        }
    }

    public static char[][] TransposeJaggedArray(char[][] arr) {
        var longestRow = FindLongestRow(arr);
        var originalRows = arr.Length;
        
        char[][] transposed = new char[longestRow][];

        for (var i = 0; i < longestRow; i++) {
            char[] row = new char[originalRows];
            for (var j = 0; j < originalRows; j++) {
                if (i < arr[j].Length) {
                    row[j] = arr[j][i];
                }
            }

            transposed[i] = row;
        }
        
        return transposed;
    }

    private static int FindLongestRow(char[][] arr) {
        int max = 0;
        
        for (var i = 0; i < arr.Length; i++) {
            var count = 0;
            foreach (var _ in arr[i]) {
                count++;
            }

            if (count > max) {
                max = count;
            }
        }

        return max;
    }
}