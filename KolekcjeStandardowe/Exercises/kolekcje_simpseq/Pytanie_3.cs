using System;
using System.Collections.Generic;

namespace KolekcjeStandardowe.Exercises.kolekcje_simpseq;

public class Pytanie_3 {
    public static void Print(int[] a, int[] b) {
        List<int> listA = new List<int>(a);
        List<int> listB = new List<int>(b);

        List<int> resultA = listA.FindAll(x => !listB.Contains(x));
        List<int> resultB = listB.FindAll(x => !listA.Contains(x));
        resultA.AddRange(resultB);
        
        // Using loops and LINQ is prohibited, so this is the way
        HashSet<int> hashSet = new HashSet<int>(resultA);
        resultA = new List<int>(hashSet);
        
        resultA.Sort();

        if (resultA.Count == 0) 
            Console.WriteLine("empty");
        else
            Console.WriteLine(string.Join(' ', resultA));
    }
}