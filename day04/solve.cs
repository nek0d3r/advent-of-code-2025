class Program
{
    static List<List<string>> ReadFile(string path)
    {
        var map = new List<List<string>>();

        foreach (string line in File.ReadLines(path))
        {
            var row = new List<string>();
            foreach (char tile in line.Trim()) row.Add(new String(tile, 1));
            map.Add(row);
        }

        return map;
    }

    static void Part1(string path, bool debug = false)
    {
        var rolls = 0;
        List<List<string>> map = ReadFile(path);

        for (var row = 0; row < map.Count(); row++)
        {
            for (var col = 0; col < map[row].Count(); col++)
            {
                if (map[row][col] != "@") continue;

                var adjacent = 0;
                if (row > 0)
                {
                    if (col > 0 && map[row - 1][col - 1] == "@") adjacent++;
                    if (map[row - 1][col] == "@") adjacent++;
                    if (col < map[row].Count() - 1 && map[row - 1][col + 1] == "@") adjacent++;
                }
                if (col > 0 && map[row][col - 1] == "@") adjacent++;
                if (col < map[row].Count() - 1 && map[row][col + 1] == "@") adjacent++;
                if (row < map.Count() - 1)
                {
                    if (col > 0 && map[row + 1][col - 1] == "@") adjacent++;
                    if (map[row + 1][col] == "@") adjacent++;
                    if (col < map[row].Count() - 1 && map[row + 1][col + 1] == "@") adjacent++;
                }

                if (adjacent < 4) rolls++;
            }
        }

        Console.WriteLine($"In part 1 there are {rolls} rolls of paper that can be accessed by a forklift");
    }

    static void Part2(string path, bool debug = false)
    {
        var rolls = 0;
        List<Tuple<int, int>> accessible;
        List<List<string>> map = ReadFile(path);

        do
        {
            accessible = new List<Tuple<int, int>>();

            for (var row = 0; row < map.Count(); row++)
            {
                for (var col = 0; col < map[row].Count(); col++)
                {
                    if (map[row][col] != "@") continue;

                    var adjacent = 0;
                    if (row > 0)
                    {
                        if (col > 0 && map[row - 1][col - 1] == "@") adjacent++;
                        if (map[row - 1][col] == "@") adjacent++;
                        if (col < map[row].Count() - 1 && map[row - 1][col + 1] == "@") adjacent++;
                    }
                    if (col > 0 && map[row][col - 1] == "@") adjacent++;
                    if (col < map[row].Count() - 1 && map[row][col + 1] == "@") adjacent++;
                    if (row < map.Count() - 1)
                    {
                        if (col > 0 && map[row + 1][col - 1] == "@") adjacent++;
                        if (map[row + 1][col] == "@") adjacent++;
                        if (col < map[row].Count() - 1 && map[row + 1][col + 1] == "@") adjacent++;
                    }

                    if (adjacent < 4) accessible.Add(new Tuple<int, int>(row, col));
                }
            }

            rolls += accessible.Count();
            foreach (Tuple<int, int> roll in accessible)
                map[roll.Item1][roll.Item2] = ".";
        }
        while (accessible.Count() > 0);

        Console.WriteLine($"In part 2 there are {rolls} rolls of paper that can be accessed by a forklift");
    }

    static void Main()
    {
        Part2("input.txt", true);
    }
}
