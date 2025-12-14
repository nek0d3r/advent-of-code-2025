using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    struct Rotation
    {
        public char direction;
        public int value;
    }

    static List<Rotation> ReadFile(string path)
    {
        var rotations = new List<Rotation>();

        foreach(var line in File.ReadLines(path))
        {
            var rotation = line.Trim();
            rotations.Add(new Rotation
            {
                direction = rotation[0],
                value = Convert.ToInt32(rotation[1..])
            });
        }

        return rotations;
    }

    static void Part1(string path, bool debug = false)
    {
        int position = 50;
        int zeroes = 0;

        if (debug) Console.WriteLine($"The dial starts by pointing at {position}");
        List<Rotation> rotations = ReadFile(path);
        foreach (Rotation rotation in rotations)
        {
            if (rotation.direction == 'L') position -= rotation.value;
            if (rotation.direction == 'R') position += rotation.value;

            while (position < 0) position += 100;
            position %= 100;

            if (debug) Console.WriteLine($"The dial is rotated {rotation.direction}{rotation.value} to point at {position}");
            if (position == 0) zeroes++;
        }

        Console.WriteLine($"The password is {zeroes} for part 1");
    }

    static void UghhhhhPart2(string path, bool debug = false)
    {
        int position = 50;
        int zeroes = 0;

        if (debug) Console.WriteLine($"The dial starts by pointing at {position}");
        List<Rotation> rotations = ReadFile(path);
        foreach (Rotation rotation in rotations)
        {
            for (var i = 0; i < rotation.value; i++)
            {
                position += rotation.direction == 'L' ? -1 : 1;
                while (position < 0) position += 100;
                position %= 100;
                if (position == 0) zeroes++;
            }
        }

        Console.WriteLine($"The password is {zeroes} for part 2");
    }

    static void Part2(string path, bool debug = false)
    {
        int position = 50;
        int prevPosition = 50;
        int zeroes = 0;

        if (debug) Console.WriteLine($"The dial starts by pointing at {position}");
        List<Rotation> rotations = ReadFile(path);
        foreach (Rotation rotation in rotations)
        {
            int clicked = 0;
            
            prevPosition = position;
            if (rotation.direction == 'L') position -= rotation.value;
            if (rotation.direction == 'R') position += rotation.value;

            if (prevPosition != 0 && (position < 0 || position > 100)) {
                clicked += Convert.ToInt32(Math.Abs(Math.Floor(position / 100f)));
                zeroes += clicked;
            }
            while (position < 0) position += 100;
            position %= 100;
            if (position == 0) zeroes++;

            if (debug) Console.Write($"The dial is rotated {rotation.direction}{rotation.value} to point at {position}");
            if (debug && clicked > 0) Console.Write($"; during this rotation, it points at zero {clicked} time(s).");
            if (debug) Console.WriteLine();
        }

        Console.WriteLine($"The password is {zeroes} for part 2");
    }

    static void Main()
    {
        UghhhhhPart2("input.txt", true);
    }
}
