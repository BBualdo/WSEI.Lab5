using System;

namespace Tablice.Exercises.przetwarzanie_tablic_1d;

public class Pytanie_2 {
    public static void Print(int[] a, int[] b) {
        int[] result = new int[a.Length];
        int count = 0;

        for (var i = 0; i < a.Length; i++) {
            for (var j = 0; j < b.Length; j++) {
                if (a[i] == b[j]) {
                    bool exists = false;

                    for (var k = 0; k < count; k++) {
                        if (result[k] == a[i]) {
                            exists = true;
                            break;
                        }
                    }

                    if (!exists) {
                        result[count] = a[i];
                        count++;
                    }
                    break;
                }
            }
        }

        int[] finalResult = new int[count];
        for (int i = 0; i < count; i++) {
            finalResult[i] = result[i];
        }
        
        if (finalResult.Length == 0) 
            Console.WriteLine("empty");
        else 
            Console.WriteLine(string.Join(' ', finalResult));
    }
}