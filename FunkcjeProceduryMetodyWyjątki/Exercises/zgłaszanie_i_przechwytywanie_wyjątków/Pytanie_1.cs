namespace Funkcje_Procedury_Metody_Wyjątki.Exercises.zgłaszanie_i_przechwytywanie_wyjątków;

public class Pytanie_1
{
    public static double TrianglePerimeter(int a, int b, int c, int precision = 2)
    {
        if (precision < 2 || precision > 8 || a < 0 || b < 0 || c < 0) 
            throw new ArgumentOutOfRangeException("wrong arguments");

        if (a + b < c || b + c < a || a + c < b)
            throw new ArgumentException("object not exist");

        var perimeter = a + b + c;
        return Math.Round((double)perimeter, precision);
    }
}