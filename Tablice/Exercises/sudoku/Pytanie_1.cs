using System;

namespace Tablice.Exercises.sudoku;

public class Pytanie_1 {
    public static void Main(string[] args) {
        int[,] sudokuBoard = GetSudokuFromInput();

        if (HasUniqueRows(sudokuBoard) && HasUniqueCols(sudokuBoard) && HasUniqueFields(sudokuBoard)) {
            Console.WriteLine("yes");
        } else {
            Console.WriteLine("no");
        }
    }

    private static int[,] GetSudokuFromInput() {
        int rows = 9;
        int cols = 9;
        int[,] sudokuBoard = new int[rows, cols];

        for (int i = 0; i < rows; i++) {
            int[] rowFromInput = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            for (int j = 0; j < rowFromInput.Length; j++) {
                sudokuBoard[i, j] = rowFromInput[j];
            }
        }

        return sudokuBoard;
    }

    private static bool HasUniqueRows(int[,] board) {
        int rows = 9;
        int cols = 9;
        
        for (int i = 0; i < rows; i++) {
            int[] numbersInRow = new int[cols];
            for (int j = 0; j < cols; j++) {
                bool exists = CheckIfExistsInArray(numbersInRow, board[i, j]);
                if (exists) return false;

                numbersInRow[j] = board[i, j];
            }
        }

        return true;
    }

    private static bool HasUniqueCols(int[,] board) {
        int rows = 9;
        int cols = 9;
        
        for (int i = 0; i < cols; i++) {
            int[] numbersInCol = new int[rows];
            for (int j = 0; j < rows; j++) {
                bool exists = CheckIfExistsInArray(numbersInCol, board[j, i]);
                if (exists) return false;

                numbersInCol[j] = board[j, i];
            }
        }

        return true;
    }

    private static bool HasUniqueFields(int[,] board) {
        int rows = 9;
        int cols = 9;

        for (int i = 0; i < rows; i += 3) {
            for (int j = 0; j < cols; j += 3) {
                int[,] currentField = Get3x3Field(board, i, j);
                bool isUnique = IsFieldUnique(currentField);
                if (!isUnique) return false;
            }
        }

        return true;
    }

    private static bool CheckIfExistsInArray(int[] arr, int num) {
        for (int i = 0; i < arr.Length; i++) {
            if (arr[i] == num) return true;
        }

        return false;
    }

    private static bool IsFieldUnique(int[,] field) {
        int[] numbersInField = new int[field.Length];
        int count = 0;
        foreach (int i in field) {
            bool exists = CheckIfExistsInArray(numbersInField, i);
            if (exists) return false;

            numbersInField[count] = i;
            count++;
        }

        return true;
    }

    private static int[,] Get3x3Field(int[,] board, int startRow, int startCol) {
        int[,] currentField = new int[3, 3];

        for (int i = startRow; i < startRow + 3; i++) {
            for (int j = startCol; j < startCol + 3; j++) {
                int currentFieldRow = i % 3;
                int currentFieldCol = j % 3;
                currentField[currentFieldRow, currentFieldCol] = board[i, j];
            }
        }

        return currentField;
    }
}