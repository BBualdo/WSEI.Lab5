using System;

namespace Funkcje_Procedury_Metody_Wyjątki.Exercises.objetosc_stozka;

public class Pytanie_1
{
    public static void Main(string[] args)
    {
        long[] input = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
        long R = input[0];
        long L = input[1];

        if (R < 0 || L < 0)
        {
            Console.WriteLine("ujemny argument");
            return;
        }

        if (L < R)
        {
            Console.WriteLine("obiekt nie istnieje");
            return;
        }
        
        decimal H = (decimal)Math.Sqrt(L * L - R * R);
        decimal PI = 3.1415926535897932384626433833m;
        decimal V = (PI * R * R * H) / 3m;

        long a = (long)Math.Floor(V);
        long b = (long)Math.Ceiling(V);
        Console.WriteLine($"{a} {b}");
    }
}