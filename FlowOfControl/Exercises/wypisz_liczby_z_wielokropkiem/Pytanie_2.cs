using System;
using System.Collections.Generic;

namespace Zadania_petle
{
    class Program
    {
        static void Main() {
            var input = Console.ReadLine();
            var data = Array.ConvertAll(input.Split(" "), int.Parse);
            
            List<int> numbersToPrint = new List<int>();
            
            int min;
            int max;
    
            if (data[0] > data[1]) {
                min = data[1];
                max = data[0];
            } else {
                min = data[0];
                max = data[1];
            }
            
            for (int i = min + 1; i < max; i++) {
                if (i % data[2] == 0) {
                    numbersToPrint.Add(i);
                }
            }
            
            if (numbersToPrint.Count > 10) {
                for (int i = 0; i < numbersToPrint.Count; i++) {
                    if (i == numbersToPrint.Count - 1) {
                        Console.Write($"{numbersToPrint[i]}");
                        break;
                    }
                    
                    if (i == 3) {
                        Console.Write("..., ");
                        continue;
                    }
                    if (i < 3) {
                        Console.Write($"{numbersToPrint[i]}, ");
                        continue;
                    }
                    
                    if (i >= numbersToPrint.Count - 2) {
                        Console.Write($"{numbersToPrint[i]}, ");
                    }
                }
            } else if (numbersToPrint.Count == 0) {
                Console.WriteLine("empty");
            } else {
                for (int i = 0; i < numbersToPrint.Count; i++) {
                    if (i == numbersToPrint.Count - 1) {
                        Console.Write($"{numbersToPrint[i]}");
                        break;
                    } 
                    
                    Console.Write($"{numbersToPrint[i]}, ");
                }   
            }
        }
    }
}