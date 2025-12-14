using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<string> ReadFile(string path)
    {
        var banks = new List<string>();

        foreach (var line in File.ReadLines(path)) banks.Add(line.Trim());

        return banks;
    }

    static void Part1(string path, bool debug = false)
    {
        var joltage = 0;
        List<string> banks = ReadFile(path);

        foreach (string bank in banks)
        {
            char[] batteries = bank.ToCharArray();
            Array.Sort(batteries);
            Array.Reverse(batteries);
            joltage += Convert.ToInt32($"{batteries[0]}{batteries[1]}");
        }

        Console.WriteLine($"The total joltage output for part 1 is {joltage}");
    }

    static void Main()
    {
        Part1("example.txt", true);
    }
}
