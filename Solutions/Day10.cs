static class Day10
{
    public static int Part1()
    {
        var lines = File.ReadAllLines("./Inputs/day10-1.txt");

        Dictionary<int, int> queuedChanges = new Dictionary<int, int>();
        
        int sum = 0;
        int clock = 1;

        foreach (var l in lines)
        {
            var opts = l.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var cmd = opts[0];
            switch (cmd)
            {
                case "addx":
                    queuedChanges[clock + 2] = int.Parse(opts[1]);
                    clock += 2;
                    break;
                case "noop":
                    clock++;
                    break;
            }
        }

        for (int i = 20; i <= 220; i += 40)
        {
            int val = (queuedChanges.Where(change => change.Key <= i).Select(kvp => kvp.Value).Aggregate((a, b) => a + b) + 1) * i;
            sum += val;
        }

        return sum;
    }

    public static string Part2()
    {
        var lines = File.ReadAllLines("./Inputs/day10-1.txt");

        Dictionary<int, int> queuedChanges = new Dictionary<int, int>();

        int clock = 1;

        foreach (var l in lines)
        {
            var opts = l.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var cmd = opts[0];
            switch (cmd)
            {
                case "addx":
                    queuedChanges[clock + 2] = int.Parse(opts[1]);
                    clock += 2;
                    break;
                case "noop":
                    clock++;
                    break;
            }
        }

        char[] chars = new char[6 * 40];
        Array.Fill(chars, '.');
        int register = 1;

        for (int i = 1; i < 241; i++)
        {
            if (queuedChanges.TryGetValue(i, out int v))
            {
                register += v;
            }

            if ((i - 1) % 40 == register - 1 || (i - 1) % 40 == register || (i - 1) % 40 == register + 1) { chars[i - 1] = '#'; }
        }

        return string.Join('\n', chars.Chunk(40).Select(row => string.Join('\0', row)));
    }
}
