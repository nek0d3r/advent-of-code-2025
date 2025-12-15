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
        var totalJoltage = 0;
        List<string> banks = ReadFile(path);

        foreach (string bank in banks)
        {
            char[] batteries = bank.ToCharArray();
            int joltage = 0;

            for (var i = 0; i < batteries.Count() - 1; i++)
            {
                var battery1 = Convert.ToInt32(new String(batteries[i], 1));

                for (var j = i + 1; j < batteries.Count(); j++)
                {
                    var battery2 = Convert.ToInt32(new String(batteries[j], 1));
                    var pair = Convert.ToInt32($"{battery1}{battery2}");

                    joltage = pair > joltage ? pair : joltage;
                }
            }

            if (debug) Console.WriteLine($"Bank joltage is {joltage}");

            totalJoltage += joltage;
        }

        Console.WriteLine($"The total joltage output for part 1 is {totalJoltage}");
    }

    static void Main()
    {
        Part1("input.txt", true);
    }
}
