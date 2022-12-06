static class Day4
{
    public static int Part1()
    {
        var lines = File.ReadAllLines("./Inputs/day4-1.txt");
        int count = 0;

        foreach (var line in lines)
        {
            // 6-8,3-2 -> [6, 8, 3, 2]
            var nums = line.Split(',', '-').Select(n => int.Parse(n)).ToArray();
            int a1 = nums[0];
            int a2 = nums[1];
            int b1 = nums[2];
            int b2 = nums[3];

            // Check if A in B || B in A
            if (b1 >= a1 && b2 <= a2 || a1 >= b1 && a2 <= b2)
            {
                count += 1;
            }
        }

        return count;
    }

    public static int Part2()
    {
        var lines = File.ReadAllLines("./Inputs/day4-1.txt");
        int count = 0;

        foreach (var line in lines)
        {
            // 6-8,3-2 -> [6, 8, 3, 2]
            var nums = line.Split(',', '-').Select(n => int.Parse(n)).ToArray();
            int a1 = nums[0];
            int a2 = nums[1];
            int b1 = nums[2];
            int b2 = nums[3];

            // Check if A1 or B1 is in range of B or A
            // A1 ≤ B1 ≤ A2 || B1 ≤ A1 ≤ B2
            if ((a1 <= b1 && b1 <= a2) || (b1 <= a1 && a1 <= b2))
            {
                count += 1;
            }
        }

        return count;
    }
}