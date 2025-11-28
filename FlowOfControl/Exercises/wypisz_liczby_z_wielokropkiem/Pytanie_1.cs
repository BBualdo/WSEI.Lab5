using System;

namespace FlowOfControl.Exercises.wypisz_liczby_z_wielokropkiem;

public class Pytanie_1 {
    public static void Main() {
        var input = Console.ReadLine();
        var data = Array.ConvertAll(input.Split(" "), int.Parse);

        int first;
        int last;

        if (data[0] > data[1]) {
            first = data[1];
            last = data[0];
        } else {
            first = data[0];
            last = data[1];
        }

        var difference = last - first;

        if (difference - 1 <= 0) {
            Console.WriteLine("empty");
            return;
        }

        if (difference - 1 > 10) {
            for (var i = 1; i <= 3; i++) Console.Write($"{first + i}, ");

            Console.Write("..., ");

            for (var i = difference - 2; i <= difference - 1; i++)
                if (i == difference - 1)
                    Console.Write($"{first + i}");
                else
                    Console.Write($"{first + i}, ");
        } else {
            for (var i = 1; i <= difference - 1; i++)
                if (i == difference - 1)
                    Console.Write($"{first + i}");
                else
                    Console.Write($"{first + i}, ");
        }
    }
}