using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static List<Tuple<string, string>> ReadFile(string path)
    {
        var ranges = new List<Tuple<string, string>>();
        string line;

        using (StreamReader file = File.OpenText(path))
        {
            line = file.ReadLine().Trim();
        }
        foreach (var range in line.Split(','))
        {
            ranges.Add(new Tuple<string, string>(
                range.Split('-')[0],
                range.Split('-')[1]
            ));
        }

        return ranges;
    }

    static void Part1(string path, bool debug = false)
    {
        List<Tuple<string, string>> ranges = ReadFile(path);

        long invalid = 0;

        foreach (Tuple<string, string> range in ranges)
        {
            var places = new List<int>();

            var num1 = Convert.ToInt64(range.Item1);
            var num2 = Convert.ToInt64(range.Item2);

            for (var i = range.Item1.Length; i <= range.Item2.Length; i++)
                if (i % 2 == 0) places.Add(i);
            if (places.Count == 0) continue;

            bool lowerBoundValid = range.Item1.Count() == places.First();
            var half1 = lowerBoundValid ?
                Convert.ToInt64(range.Item1[0..(range.Item1.Length / 2)]) :
                Convert.ToInt64("1" + new String('0', places[0] / 2 - 1));

            bool upperBoundValid = range.Item2.Count() == places.Last();
            var half2 = upperBoundValid ?
                Convert.ToInt64(range.Item2[0..(range.Item2.Length / 2)]) :
                Convert.ToInt64(new String('9', places[0] / 2));

            for (var i = half1; i <= half2; i++)
            {
                var sequence = Convert.ToInt64($"{i}{i}");
                if (sequence >= num1 && sequence <= num2) invalid += sequence;
            }
        }

        Console.WriteLine($"Adding up all the invalid IDs in this input produces {invalid}");
    }

    static void Main()
    {
        Part1("input.txt", true);
    }
}
