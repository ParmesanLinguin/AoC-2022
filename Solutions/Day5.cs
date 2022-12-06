// I would just like to emphasize that I wrote this code as quickly as possible.
// this would ABSOLUTELY not be my final solution but it works so... hey?

static class Day5
{
    public static string Part1()
    {
        var lines = File.ReadAllLines("./Inputs/day5-1.txt");

        List<Stack<char>>? stacks = null;
        int lc = 0;

        foreach (var line in lines)
        {
            if (stacks is null)
            {
                stacks = new List<Stack<char>>();
                for (int i = 0; i < (line.Length + 1) / 4; i++)
                {
                    stacks.Add(new Stack<char>());
                }
            }
            if (line == "") break;
            lc++;
        }

        for (int i = lc - 2; i >= 0; i--)
        {
            for (int j = 0; j < stacks.Count; j++)
            {
                if (lines[i][j * 4 + 1] != ' ')
                {
                    stacks[j].Push(lines[i][j * 4 + 1]);
                }
            }
        }

        foreach (var line in lines.Skip(lc + 1))
        {
            var vals = line.Split(new string[] { "move ", "from ", "to " }, StringSplitOptions.TrimEntries);

            var values = vals.Skip(1).Select(n => int.Parse(n)).ToArray();


            for (int i = 0; i < values[0]; i++)
            {
                var val = stacks[values[1] - 1].Pop();
                stacks[values[2] - 1].Push(val);
            }
        }

        string output = "";

        foreach (var s in stacks)
        {
            output += s.Peek();
        }

        return output;
    }

    public static string Part2()
    {
        var lines = File.ReadAllLines("./Inputs/day5-1.txt");

        List<Stack<char>>? stacks = null;
        int lc = 0;

        foreach (var line in lines)
        {
            if (stacks is null)
            {
                stacks = new List<Stack<char>>();
                for (int i = 0; i < (line.Length + 1) / 4; i++)
                {
                    stacks.Add(new Stack<char>());
                }
            }
            if (line == "") break;
            lc++;
        }

        for (int i = lc - 2; i >= 0; i--)
        {
            for (int j = 0; j < stacks.Count; j++)
            {
                if (lines[i][j * 4 + 1] != ' ')
                {
                    stacks[j].Push(lines[i][j * 4 + 1]);
                }
            }
        }

        foreach (var line in lines.Skip(lc + 1))
        {
            var vals = line.Split(new string[] { "move ", "from ", "to " }, StringSplitOptions.TrimEntries);

            var values = vals.Skip(1).Select(n => int.Parse(n)).ToArray();

            List<char> boxes = new();

            for (int i = 0; i < values[0]; i++)
            {
                var val = stacks[values[1] - 1].Pop();
                boxes.Add(val);
            }

            boxes.Reverse();

            for (int i = 0; i < boxes.Count; i++)
            {
                stacks[values[2] - 1].Push(boxes[i]);
            }
            
        }

        string output = "";

        foreach (var s in stacks)
        {
            output += s.Peek();
        }

        return output;
    }
}