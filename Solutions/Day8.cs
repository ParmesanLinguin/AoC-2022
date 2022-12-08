public static class Day8
{
    public static int Part1()
    {
        var lines = File.ReadAllLines("./Inputs/day8-1.txt");
        HashSet<Point> visible = new();

        
        // Check from left and right
        foreach (var (y, line) in lines.Select((item, i) => (i, item)))
        {
            char tallest = (char)('0' - 1);

            for (int x = 0; x < line.Length; x++)
            {
                if (line[x] > tallest)
                {
                    visible.Add(new Point(x, y));
                    tallest = line[x];
                }
            }

            tallest = (char)('0' - 1);

            for (int x = line.Length - 1; x >= 0; x--)
            {

                if (line[x] > tallest)
                {
                    visible.Add(new Point(x, y));
                    tallest = line[x];
                }
            }
        }

        // Now from top and bottom
        for (int x = 0; x < lines[0].Length; x++)
        {
            char tallest = (char)('0' - 1);

            for (int y = 0; y < lines.Length; y++)
            {

                if (lines[y][x] > tallest)
                {
                    visible.Add(new Point(x, y));
                    tallest = lines[y][x];

                }
            }

            tallest = (char)('0' - 1);

            for (int y = lines.Length - 1; y >= 0; y--)
            {
                if (lines[y][x] > tallest)
                {
                    visible.Add(new Point(x, y));
                    tallest = lines[y][x];
                }
            }
        }

        return visible.Count;
    }

    public static int Part2()
    {
        var lines = File.ReadAllLines("./Inputs/day8-1.txt");
        int score = 0;
        Point[] offsets = new Point[]
        {
            new(-1, 0), new (1, 0),
            new(0, -1), new (0, 1)
        };

        for (int x = 0; x < lines[0].Length; x++)
        {
            for (int y = 0; y < lines.Length; y++)
            {
                int cellScore = 1;
                char tallest = lines[y][x];

                foreach (var offset in offsets)
                {
                    int d = 0;
                    while (TryGetPoint(lines, x + offset.X * (d + 1), y + offset.Y * (d + 1), out char c))
                    {
                        d++;

                        if (c >= tallest)
                        {
                            break;
                        }
                    }
                    
                    cellScore *= d;
                }

                if (cellScore > score)
                {
                    score = cellScore;
                }
            }
        }

        return score;
    }

    static bool TryGetPoint(string[] lines, int x, int y, out char c)
    {
        if (x < 0 || x >= lines.Length || y < 0 || y >= lines[0].Length) 
        { 
            c = '\0'; 
            return false; 
        }
        c = lines[y][x];
        return true;
    }

    record struct Point(int X, int Y);
}