using System;
using System.Collections.Generic;
using System.Text;

namespace Tablice.Exercises.DIGNUM_SPOJ; // Remove it before submission

public class Program
{
    public static void Main()
    {
        Dictionary<string, char> patterns = new Dictionary<string, char>()
        {
            { " _ | ||_|", '0' },
            { "     |  |", '1' },
            { " _  _||_ ", '2' },
            { " _  _| _|", '3' },
            { "   |_|  |", '4' },
            { " _ |_  _|", '5' },
            { " _ |_ |_|", '6' },
            { " _   |  |", '7' },
            { " _ |_||_|", '8' },
            { " _ |_|  |", '9' }
        };

        string line1;
        while ((line1 = Console.ReadLine()) != null)
        {
            string line2 = Console.ReadLine();
            string line3 = Console.ReadLine();

            if (line1 == null || line2 == null || line3 == null) break;

            StringBuilder result = new StringBuilder();
            
            int length = line1.Length;
            
            for (int i = 0; i < length; i += 3)
            {
                string s1 = (i + 3 <= line1.Length) ? line1.Substring(i, 3) : line1.Substring(i);
                string s2 = (i + 3 <= line2.Length) ? line2.Substring(i, 3) : line2.Substring(i);
                string s3 = (i + 3 <= line3.Length) ? line3.Substring(i, 3) : line3.Substring(i);

                string key = s1 + s2 + s3;

                if (patterns.ContainsKey(key))
                {
                    result.Append(patterns[key]);
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}