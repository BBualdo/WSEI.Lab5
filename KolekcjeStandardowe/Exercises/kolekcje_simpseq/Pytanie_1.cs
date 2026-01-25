using System;
using System.Collections.Generic;

namespace KolekcjeStandardowe.Exercises.kolekcje_simpseq;

public class Pytanie_1 {
    public static void Print(int[] a, int[] b) {
        List<int> listA = new List<int>(a);
        List<int> listB = new List<int>(b);

        List<int> result = listA.FindAll(x => !listB.Contains(x));
        
        // Using loops and LINQ is prohibited, so this is the way
        HashSet<int> hashSet = new HashSet<int>(result);
        result = new List<int>(hashSet);

        if (result.Count == 0) 
            Console.WriteLine("empty");
        else
            Console.WriteLine(string.Join(' ', result));
    }
}
