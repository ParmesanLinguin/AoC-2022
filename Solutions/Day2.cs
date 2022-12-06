static class Day2
{
    const string PlayerRock = "X";
    const string PlayerPaper = "Y";
    const string PlayerScissors = "Z";

    const string ElfRock = "A";
    const string ElfPaper = "B";
    const string ElfScissors = "C";

    public static int Part1()
    {
        var lines = File.ReadAllLines("./Inputs/day2-1.txt");
        int score = 0;

        foreach (var line in lines)
        {
            var moves = line.Split(" ");
            var elf = moves[0];
            var player = moves[1];

            score += GetScore(elf, player);
        }

        return score;
    }

    public static int GetScore(string elfMove, string playerMove)
    {
        int score = 0;
        score += playerMove switch
        {
            PlayerRock => 1,
            PlayerPaper => 2,
            PlayerScissors => 3,
            _ => throw new NotImplementedException(),
        };

        score += elfMove switch
        {
            ElfRock => playerMove switch
            {
                PlayerRock => 3,
                PlayerPaper => 6,
                PlayerScissors => 0,
                _ => throw new NotImplementedException(),
            },
            ElfPaper => playerMove switch
            {
                PlayerRock => 0,
                PlayerPaper => 3,
                PlayerScissors => 6,
                _ => throw new NotImplementedException(),
            },
            ElfScissors => playerMove switch
            {
                PlayerRock => 6,
                PlayerPaper => 0,
                PlayerScissors => 3,
                _ => throw new NotImplementedException(),
            },
            _ => throw new NotImplementedException(),
        };
        return score;
    }
    const string PlayerLose = "X";
    const string PlayerDraw = "Y";
    const string PlayerWin = "Z";

    public static int Part2()
    {
        var lines = File.ReadAllLines("./Inputs/day2-1.txt");
        int score = 0;

        foreach (var line in lines)
        {
            var moves = line.Split(" ");
            var elfMove = moves[0];
            var result = moves[1];
            string playerMove = "";

            if (result == PlayerDraw)
            {
                playerMove = elfMove switch
                {
                    ElfRock => PlayerRock,
                    ElfPaper => PlayerPaper,
                    ElfScissors => PlayerScissors,
                    _ => throw new NotImplementedException()
                };
            } 
            else if (result == PlayerLose)
            {
                playerMove = elfMove switch
                {
                    ElfRock => PlayerScissors,
                    ElfPaper => PlayerRock,
                    ElfScissors => PlayerPaper,
                    _ => throw new NotImplementedException()

                };
            } 
            else if (result == PlayerWin)
            {
                playerMove = elfMove switch
                {
                    ElfRock => PlayerPaper,
                    ElfPaper => PlayerScissors,
                    ElfScissors => PlayerRock,
                    _ => throw new NotImplementedException()
                };
            }

            score += GetScore(elfMove, playerMove);
        }

        return score;
    }
}