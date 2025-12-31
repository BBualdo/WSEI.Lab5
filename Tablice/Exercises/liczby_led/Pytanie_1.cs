using System;
using System.Collections.Generic;

namespace Tablice.Exercises.liczby_led;

public class Pytanie_1 {
    public static void Main(string[] args) {
        char[] digits = Console.ReadLine().ToCharArray();
        List<char[,]> digitalNumber = ConvertToDigitalNumber(digits);
        PrintDigitalNumber(digitalNumber);
    }
    
    private static List<char[,]> ConvertToDigitalNumber(char[] digits) {
        List<char[,]> number = new List<char[,]>();

        foreach (char c in digits) {
            int digit = int.Parse(c.ToString());
            number.Add(GetDigitalDigit(digit));
        }

        return number;
    }

    private static char[,] GetDigitalDigit(int number) {
        char[][][] patterns = new char[][][]
        {
            // 0
            new char[][] {
                new char[] { ' ', '_', ' ' },
                new char[] { '|', ' ', '|' },
                new char[] { '|', '_', '|' }
            },
            // 1
            new char[][] {
                new char[] { ' ', ' ', ' ' },
                new char[] { ' ', ' ', '|' },
                new char[] { ' ', ' ', '|' }
            },
            // 2
            new char[][] {
                new char[] { ' ', '_', ' ' },
                new char[] { ' ', '_', '|' },
                new char[] { '|', '_', ' ' }
            },
            // 3
            new char[][] {
                new char[] { ' ', '_', ' ' },
                new char[] { ' ', '_', '|' },
                new char[] { ' ', '_', '|' }
            },
            // 4
            new char[][] {
                new char[] { ' ', ' ', ' ' },
                new char[] { '|', '_', '|' },
                new char[] { ' ', ' ', '|' }
            },
            // 5
            new char[][] {
                new char[] { ' ', '_', ' ' },
                new char[] { '|', '_', ' ' },
                new char[] { ' ', '_', '|' }
            },
            // 6
            new char[][] {
                new char[] { ' ', '_', ' ' },
                new char[] { '|', '_', ' ' },
                new char[] { '|', '_', '|' }
            },
            // 7
            new char[][] {
                new char[] { ' ', '_', ' ' },
                new char[] { ' ', ' ', '|' },
                new char[] { ' ', ' ', '|' }
            },
            // 8
            new char[][] {
                new char[] { ' ', '_', ' ' },
                new char[] { '|', '_', '|' },
                new char[] { '|', '_', '|' }
            },
            // 9
            new char[][] {
                new char[] { ' ', '_', ' ' },
                new char[] { '|', '_', '|' },
                new char[] { ' ', ' ', '|' }
            }
        };
        
        int rows = 3;
        int cols = 3;
        char[,] digitalDigit = new char[rows, cols];

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                digitalDigit[i, j] = patterns[number][i][j];
            }
        }
        
        return digitalDigit;
    }
    
    private static void PrintDigitalNumber(List<char[,]> digitalNumber) {
        int rowsNumber = 3;
        int colsNumber = 3;

        for (int row = 0; row < rowsNumber; row++) {
            for (int index = 0; index < digitalNumber.Count; index++) {
                for (int col = 0; col < colsNumber; col++) {
                    Console.Write(digitalNumber[index][row, col]);
                }
            }
            
            if (row != rowsNumber - 1) Console.WriteLine();
        }
    }
}