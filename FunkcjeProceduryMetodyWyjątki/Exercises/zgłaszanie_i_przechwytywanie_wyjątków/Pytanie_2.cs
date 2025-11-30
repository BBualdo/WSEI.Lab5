namespace Funkcje_Procedury_Metody_Wyjątki.Exercises.zgłaszanie_i_przechwytywanie_wyjątków;

public class Pytanie_2
{
    public static void Main(string[] args)
    {
        try
        {
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();
            string input3 = Console.ReadLine();
        
            int a = int.Parse(string.IsNullOrEmpty(input1) ? null : input1);
            int b = int.Parse(string.IsNullOrEmpty(input2) ? null : input2);
            int c = int.Parse(string.IsNullOrEmpty(input3) ? null : input3);
            
            checked
            {
                int result = a * b * c;
                Console.WriteLine(result);
            }
        }
        catch (Exception ex)
        {
            if (ex is FormatException)
                Console.WriteLine("format exception, exit");
            else if (ex is ArgumentException)
                Console.WriteLine("argument exception, exit");
            else if (ex is OverflowException)
                Console.WriteLine("overflow exception, exit");
            else
                Console.WriteLine("non supported exception, exit");
        }
    }
}