static class Day3
{
    static int GetPriority(char letter)
        => letter is >= 'a' and <= 'z' ? letter - 'a' + 1 : 
            letter is >= 'A' and <= 'Z' ? letter - 'A' + 27 :
            0;

    public static int Part1()
    {
        var lines = File.ReadAllLines("./Inputs/day3-1.txt");
        int sum = 0;

        foreach (var line in lines)
        {
            string A = line.Substring(0, line.Length / 2);
            string B = line.Substring(line.Length / 2);

            HashSet<char> values = new();
            foreach (char c in A)
            {
                values.Add(c);
            }

            foreach (char c in B)
            {
                if (values.Contains(c))
                {
                    sum += GetPriority(c);
                    break;
                }
            }
        }

        return sum;
    }

    public static int Part2()
    {
        var lines = File.ReadAllLines("./Inputs/day3-1.txt");
        int sum = 0;

        for (int i = 0; i < lines.Length; i += 3)
        {
            string A = lines[i];
            string B = lines[i + 1];
            string C = lines[i + 2];


            HashSet<char> values = new();
            foreach (char c in A)
            {
                values.Add(c);
            }

            HashSet<char> duplicates = new HashSet<char>();
            foreach (char c in B)
            {
                if (values.Contains(c))
                {
                    duplicates.Add(c);
                }
            }

            foreach (char c in C)
            {
                if (duplicates.Contains(c))
                {
                    sum += GetPriority(c);
                    break;
                }
            }
        }

        return sum;
    }
}