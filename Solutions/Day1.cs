static class Day1
{
    public static int Part1()
    {
        var lines = File.ReadAllLines("./Inputs/day1-1.txt");

        int top = 0, current = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i] == "")
            {
                if (current > top)
                {
                    top = current;
                }

                current = 0;
            } else
            {
                current += int.Parse(lines[i]);

            }
        }

        return top;
    }

    public static int Part2()
    {
        var lines = File.ReadAllLines("./Inputs/day1-1.txt");

        List<int> top = new();
        int current = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i] == "")
            {
                top.Add(current);
                current = 0;
            }
            else
            {
                current += int.Parse(lines[i]);
            }
        }

        top.Sort();
        int sum = top.Reverse<int>().Take(3).Aggregate((a, b) => a += b);

        return sum;
    }
}