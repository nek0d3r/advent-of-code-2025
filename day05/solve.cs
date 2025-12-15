class Program
{
    struct IngredientInventory
    {
        public List<Tuple<long, long>> Fresh;
        public List<long> Available;
    }

    static IngredientInventory ReadFile(string path)
    {
        var inventory = new IngredientInventory()
        {
            Fresh = new List<Tuple<long, long>>(),
            Available = new List<long>()
        };
        var readAvailable = false;

        foreach (string line in File.ReadLines(path))
        {
            string trimmed = line.Trim();

            if (!readAvailable)
            {
                if (trimmed == "")
                {
                    readAvailable = true;
                    continue;
                }

                var range = trimmed.Split('-');
                inventory.Fresh.Add(new Tuple<long, long>(
                    Convert.ToInt64(range[0]),
                    Convert.ToInt64(range[1])
                ));
            }
            else
            {
                inventory.Available.Add(Convert.ToInt64(trimmed));
            }
        }

        return inventory;
    }

    static void Part1(string path, bool debug = false)
    {
        var test = ReadFile(path);
        foreach (var fresh in test.Fresh)
            if (debug) Console.WriteLine($"{fresh.Item1}-{fresh.Item2}");
        if (debug) Console.WriteLine();
        foreach (var available in test.Available)
            if (debug) Console.WriteLine(available);
    }

    static void Main()
    {
        Part1("example.txt", true);
    }
}
