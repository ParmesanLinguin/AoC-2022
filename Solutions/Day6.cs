static class Day6
{
    public static int Part1()
    {
        var line = File.ReadAllText("./Inputs/day6-1.txt");

        for (int i = 3; i < line.Length; i++)
        {
            char a = line[i], b = line[i - 1], c = line[i - 2], d = line[i - 3];

            if (a != b && a != c && a != d && b != c && b != d && c != d)
            {
                return i + 1;
            }
        }

        throw new Exception("didn't finish :(");
    }

    public static int Part2()
    {
        var line = File.ReadAllText("./Inputs/day6-1.txt");

        const int BuffSize = 14;
        Dictionary<char, int> chars = new();

        for (int i = 0; i < line.Length; i++)
        {
            chars[line[i]] = i + BuffSize;

            foreach (var (ch, index) in chars)
            {
                if (index <= i) chars.Remove(ch);
            }

            if (chars.Count == BuffSize)
            {
                return i + 1;
            }
        }

        throw new Exception("didn't finish :(");
    }
}