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
        foreach(var test in ranges)
        {
            Console.WriteLine($"{test.Item1}-{test.Item2}");
        }

        return ranges;
    }

    static void Main()
    {
        ReadFile("example.txt");
    }
}
