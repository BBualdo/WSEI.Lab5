using System;

namespace Tablice.Exercises.saper;

public class Pytanie_1 {
    public static void Main(string[] args) {
        char[,] board = GetBoardFromInput();
        char[,] filledBoard = FillBoardWithNumbers(board);
        PrintBoard(filledBoard);
    }

    private static char[,] GetBoardFromInput() {
        string[] firstLine = Console.ReadLine().Split(' ');
        int rows = int.Parse(firstLine[0]);
        int cols = int.Parse(firstLine[1]);

        char[,] board = new char[rows, cols];
        
        for (int i = 0; i < rows; i++) {
            char[] charsRow = Console.ReadLine().ToCharArray();
            for (int j = 0; j < charsRow.Length; j++) {
                board[i, j] = charsRow[j];
            }
        }

        return board;
    }

    private static char[,] FillBoardWithNumbers(char[,] board) {
        int rowsNumber = board.GetLength(0);
        int colsNumber = board.GetLength(1);
        
        char[,] filledBoard = new char[rowsNumber, colsNumber];

        for (int i = 0; i < rowsNumber; i++) {
            for (int j = 0; j < colsNumber; j++) {
                filledBoard[i, j] = SearchForMinesAround(board, i, j);
            }
        }

        return filledBoard;
    }

    private static char SearchForMinesAround(char[,] board, int row, int col) {
        const char mine = '*';
        if (board[row, col] == mine) return mine;
        
        int rowsNumber = board.GetLength(0);
        int colsNumber = board.GetLength(1);
        int counter = 0;
        
        // -1 = left, 0 = center, 1 = right
        for (int i = -1; i <= 1; i++) {
            // -1 = bottom, 0 = center, 1 = right
            for (int j = -1; j <= 1; j++) {
                if (i == 0 && j == 0) continue;
                
                int checkedRow = row + i;
                int checkedCol = col + j;

                if (checkedRow >= 0 && checkedRow < rowsNumber && checkedCol >= 0 && checkedCol < colsNumber) {
                    if (board[checkedRow, checkedCol] == mine) counter++;
                }
            }
        }
        
        return counter == 0 ? '.' : (char)(counter + '0');
    }

    private static void PrintBoard(char[,] board) {
        int rowsNumber = board.GetLength(0);
        int colsNumber = board.GetLength(1);

        for (int i = 0; i < rowsNumber; i++) {
            for (int j = 0; j < colsNumber; j++) {
                Console.Write(board[i, j]);
            }
            
            if (i != rowsNumber - 1) Console.WriteLine();
        }
    }
}