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
            int highIndex1 = 0, highIndex2 = 0;
            int highest1 = 0, highest2 = 0;

            for (var i = 0; i < batteries.Count(); i++)
            {
                var battery = Convert.ToInt32(new String(batteries[i], 1));
                if (battery > highest1)
                {
                    highIndex1 = i;
                    highest1 = battery;
                }
            }

            for (var i = 0; i < batteries.Count(); i++)
            {
                if (i == highIndex1) continue;

                var battery = Convert.ToInt32(new String(batteries[i], 1));
                if (battery > highest2)
                {
                    highIndex2 = i;
                    highest2 = battery;
                }
            }

            int joltage = highIndex2 > highIndex1 ? Convert.ToInt32($"{highest1}{highest2}") : Convert.ToInt32($"{highest2}{highest1}");
            totalJoltage += joltage;

            if (debug) Console.WriteLine($"Bank joltage is {joltage}");
        }

        Console.WriteLine($"The total joltage output for part 1 is {totalJoltage}");
    }

    static void Main()
    {
        Part1("example.txt", true);
    }
}
