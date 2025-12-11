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

    static void Part1(string path)
    {
        int position = 50;
        int zeroes = 0;

        Console.WriteLine($"The dial starts by pointing at {position}.");
        List<Rotation> rotations = ReadFile(path);
        foreach (Rotation rotation in rotations)
        {
            if (rotation.direction == 'L') position -= rotation.value;
            if (rotation.direction == 'R') position += rotation.value;
            while (position < 0) position += 100;
            position %= 100;

            Console.WriteLine($"The dial is rotated {rotation.direction}{rotation.value} to point at {position}");
            if (position == 0)
            {
                zeroes++;
            }
        }

        Console.WriteLine($"The password is {zeroes} for part 1");
    }

    static void Main()
    {
        Part1("example.txt");
    }
}
