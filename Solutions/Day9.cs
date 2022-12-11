static class Day9
{
    public static int Part1()
    {
        var lines = File.ReadAllLines("./Inputs/day9-1.txt");

        Rope r = new Rope(new Point(0, 0), new Point(0, 0));
        HashSet<Point> uniqueTailPositions = new() { r.Tail };

        foreach (var l in lines)
        {
            var s = l.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            (int X, int Y) direction = s[0] switch
            {
                "U" => (0, 1),
                "R" => (1, 0),
                "D" => (0, -1),
                "L" => (-1, 0),
                _ => throw new NotImplementedException(),
            };
            var count = int.Parse(s[1]);

            for (int i = 0; i < count; i++)
            {
                r = r.MoveRope(direction.X, direction.Y);
                uniqueTailPositions.Add(r.Tail);
            }
        }

        return uniqueTailPositions.Count;
    }

    record struct Point(int X, int Y);

    record struct Rope(Point Head, Point Tail)
    {

        public Rope MoveRope(int dx, int dy)
        {
            Rope r = this with { Head = new(Head.X + dx, Head.Y + dy)};

            r.Tail = (r.Head.X - Tail.X, r.Head.Y - Tail.Y) switch
            {
                (< -1 or > 1, _) or (_, < -1 or > 1) => new (Tail.X + Math.Sign(r.Head.X - Tail.X), Tail.Y + Math.Sign(r.Head.Y - Tail.Y)),
                _ => r.Tail
            };

            return r;
        }
    }
}

static class Day9_Part2
{
    public static int Part2()
    {
        var lines = File.ReadAllLines("./Inputs/day9-1.txt");

        Rope head = new Rope(new Point(0, 0));
        Rope tail = head
            .AddChild(new Rope(new(0, 0)))
            .AddChild(new Rope(new(0, 0)))
            .AddChild(new Rope(new(0, 0)))
            .AddChild(new Rope(new(0, 0)))
            .AddChild(new Rope(new(0, 0)))
            .AddChild(new Rope(new(0, 0)))
            .AddChild(new Rope(new(0, 0)))
            .AddChild(new Rope(new(0, 0)))
            .AddChild(new Rope(new(0, 0)));

        HashSet<Point> uniqueTailPositions = new() { tail.position };

        foreach (var l in lines)
        {
            var s = l.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            (int X, int Y) direction = s[0] switch
            {
                "U" => (0, 1),
                "R" => (1, 0),
                "D" => (0, -1),
                "L" => (-1, 0),
                _ => throw new NotImplementedException(),
            };
            var count = int.Parse(s[1]);

            for (int i = 0; i < count; i++)
            {
                head.MoveRope(direction.X, direction.Y);
                uniqueTailPositions.Add(tail.position);
            }
        }

        return uniqueTailPositions.Count;
    }

    class Rope
    {
        public Point position;
        public Rope? parent = null;
        public Rope? child = null;

        public Rope(Point position)
        {
            this.position = position;
        }

        public Rope AddChild(Rope r)
        {
            child = r;
            r.parent = this;
            return r;
        }

        public void MoveRope(int x, int y)
        {
            position.X += x;
            position.Y += y;

            MoveChild();
        }

        public void MoveChild()
        {
            if (child is null) return;

            int dx = position.X - child.position.X;
            int dy = position.Y - child.position.Y;

            if (dx is < -1 or > 1 || dy is < -1 or > 1)
            {
                child.position = new(child.position.X + Math.Sign(dx), child.position.Y + Math.Sign(dy));
            }

            child.MoveChild();
        }
    }

    record struct Point(int X, int Y);
}