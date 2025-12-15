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

    static List<string> GetDigitCombos()
    {
        var combos = new List<string>();
        var mask = 0b000111111111111;

        while (mask <= 0b111111111111000)
        {
            var combo = Convert.ToString(mask, toBase: 2);
            while (combo.Length < 15) combo = "0" + combo;

            var zeroes = 0;
            foreach (char c in combo) if (c == '0') zeroes++;
            if (zeroes == 3) combos.Add(combo);
            mask++;
        }

        return combos;
    }

    static void Part2(string path, bool debug = false)
    {
        long totalJoltage = 0;
        List<string> banks = ReadFile(path);
        List<string> digitCombos = GetDigitCombos();

        foreach (string bank in banks)
        {
            char[] batteries = bank.ToCharArray();
            long joltage = 0;

            foreach (string digitCombo in digitCombos)
            {
                var combo = "";
                for (var i = 0; i < digitCombo.Length; i++)
                    combo += digitCombo[i] == '1' ? batteries[i] : "";

                joltage = Math.Max(joltage, Convert.ToInt64(combo));
            }

            totalJoltage += joltage;
        }

        Console.WriteLine($"The total joltage output for part 2 is {totalJoltage}");
    }

    static void Main()
    {
        Part2("input.txt", true);
    }
}
