using System;

namespace Tablice.Exercises.przetwarzanie_tablic_1d;

public class Pytanie_3 {
    public static void Print(int[] a, int[] b) {
        int[] result = new int[a.Length + b.Length];
        int count = 0;
        
        GetDifferences(a, b, result, ref count);
        GetDifferences(b, a, result, ref count);
        TrimArray(ref result, ref count);
        SortAscending(result);
        
        if (result.Length == 0) 
            Console.WriteLine("empty");
        else
            Console.WriteLine(string.Join(' ', result));
    }

    private static void GetDifferences(int[] a, int[] b, int[] result, ref int count) {
        for (var i = 0; i < a.Length; i++) {
            for (var j = 0; j < b.Length; j++) {
                if (a[i] == b[j]) break;

                if (j == b.Length - 1) {
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
                }
            }
        }
    }

    private static void TrimArray(ref int[] arr, ref int count) {
        int[] finalArr = new int[count];
        
        for (var i = 0; i < count; i++) {
            finalArr[i] = arr[i];
        }

        arr = finalArr;
    }

    private static void SortAscending(int[] arr) {
        for (int i = 0; i < arr.Length - 1; i++) {
            for (int j = 0; j < arr.Length - i - 1; j++) {
                if (arr[j] > arr[j + 1]) {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}