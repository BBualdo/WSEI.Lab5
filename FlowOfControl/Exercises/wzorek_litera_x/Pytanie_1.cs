using System;

namespace FlowOfControl.Exercises.wzorek_litera_x;

public class Pytanie_1
{
    public static void Wzorek(int n)
    {
        if (n < 3) return;
        if (n % 2 == 0) n--;

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (col == row || col == n - 1 - row)
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write(' ');
                }
                
            }
            Console.WriteLine();
        }
    }
}