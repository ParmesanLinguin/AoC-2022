using System.IO;

static class Day7
{
    record class Node(string Name)
    {
        public List<Node> Children = new();
    }

    record class Directory(string Name) : Node(Name)
    {
    }

    record class File(long Size, string Name) : Node(Name)
    { }

    public static long Part1()
    {
        var lines = System.IO.File.ReadAllLines("./Inputs/day7-1.txt");

        Directory root = new Directory("root");
        Stack<Directory> dirs = new Stack<Directory>();
        dirs.Push(root);

        int line = 0;

        while (true)
        {
            var arguments = lines[line][2..].Split(' ');
            if (arguments[0] == "ls")
            {
                while (true)
                {
                    if (++line >= lines.Length) break;
                    var args = lines[line].Split(' ');
                    if (args[0] == "dir")
                    {
                        dirs.Peek().Children.Add(new Directory(args[1]));
                    }
                    else if (args[0] == "$")
                    {
                        break;
                    } else
                    {
                        dirs.Peek().Children.Add(new File(long.Parse(args[0]), args[1]));
                    }
                }
            } else if (arguments[0] == "cd")
            {
                if (arguments[1] == "..")
                {
                    dirs.Pop();
                } else if (arguments[1] == "/")
                {
                    while (dirs.Count > 1)
                    {
                        dirs.Pop();
                    }
                } else
                {
                    dirs.Push(dirs.Peek().Children.Find(n => n.Name == arguments[1]) as Directory);
                }

                line++;
            } else { throw new NotImplementedException(arguments[0]); };

            if (line >= lines.Length) break;
        }

        dirs.Clear();
        dirs.Push(root);

        List<long> sizes = new();
        GetDirectorySizePart1(root, sizes);

        return sizes.Aggregate((a, b) => a + b);
    }

    public static long Part2()
    {
        var lines = System.IO.File.ReadAllLines("./Inputs/day7-1.txt");

        Directory root = new Directory("root");
        Stack<Directory> dirs = new Stack<Directory>();
        dirs.Push(root);

        int line = 0;

        while (true)
        {
            var arguments = lines[line][2..].Split(' ');
            if (arguments[0] == "ls")
            {
                while (true)
                {
                    if (++line >= lines.Length) break;
                    var args = lines[line].Split(' ');
                    if (args[0] == "dir")
                    {
                        dirs.Peek().Children.Add(new Directory(args[1]));
                    }
                    else if (args[0] == "$")
                    {
                        break;
                    }
                    else
                    {
                        dirs.Peek().Children.Add(new File(long.Parse(args[0]), args[1]));
                    }
                }
            }
            else if (arguments[0] == "cd")
            {
                if (arguments[1] == "..")
                {
                    dirs.Pop();
                }
                else if (arguments[1] == "/")
                {
                    while (dirs.Count > 1)
                    {
                        dirs.Pop();
                    }
                }
                else
                {
                    dirs.Push(dirs.Peek().Children.Find(n => n.Name == arguments[1]) as Directory);
                }

                line++;
            }
            else { throw new NotImplementedException(arguments[0]); };

            if (line >= lines.Length) break;
        }

        dirs.Clear();
        dirs.Push(root);

        List<long> sizes = new();
        long rootSize = GetDirectorySizePart2(root, sizes);
        sizes = sizes.Where(n => n > 30000000 - (70000000 - rootSize)).ToList();
        sizes.Sort();
        return sizes[0];
    }

    static long GetDirectorySizePart1(Directory dir, List<long> sizes)
    {
        long size = 0;
        foreach (var n in dir.Children)
        {
            if (n is File f)
            {
                size += f.Size;
            } else
            {
                size += GetDirectorySizePart1((Directory)n, sizes);
            }
        }

        if (size < 100000) { sizes.Add(size); };
        return size;
    }

    static long GetDirectorySizePart2(Directory dir, List<long> sizes)
    {
        long size = 0;
        foreach (var n in dir.Children)
        {
            if (n is File f)
            {
                size += f.Size;
            }
            else
            {
                size += GetDirectorySizePart2((Directory)n, sizes);
            }
        }

        sizes.Add(size);
        return size;
    }
}



