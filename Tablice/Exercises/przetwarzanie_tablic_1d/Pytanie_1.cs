namespace Tablice.Exercises.przetwarzanie_tablic_1d;

public class Pytanie_1 {
    public static void Print(int[] a, int[] b) {
        string result = "";

        for (var i = 0; i < a.Length; i++) {
            for (var j = 0; j < b.Length; j++) {
                if (a[i] == b[j]) 
                    break;
                if (j == b.Length - 1)
                    if (!result.Contains(a[i].ToString())) {
                        result += $"{a[i]} ";
                    }
            }
        }
        
        if (string.IsNullOrEmpty(result)) 
            Console.WriteLine("empty");
        else 
            Console.WriteLine(result.TrimEnd());
    }
}