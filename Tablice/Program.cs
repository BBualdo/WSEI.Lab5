using System;
using Tablice.Exercises.tablica_postrzępiona;

char[][] jagged = Pytanie_1.ReadJaggedArrayFromStdInput();
Pytanie_1.PrintJaggedArrayToStdOutput(jagged);
char[][] jaggedTransposed = Pytanie_1.TransposeJaggedArray(jagged);
Console.WriteLine();
Pytanie_1.PrintJaggedArrayToStdOutput(jaggedTransposed);