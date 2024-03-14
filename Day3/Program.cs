using Global;

namespace Day3
{
    public class Program
    {
        static void Main(string[] args)
        {
            var rootDirectory = Path.GetFullPath(Constants.RootFolder + "Day3");
            var filePath = Path.Combine(rootDirectory, "Input.txt");

            try
            {
                var input = new List<int>();
                using (StreamReader sr = new StreamReader(filePath))
                {
                    var path1 = sr.ReadLine();
                    var path2 = sr.ReadLine();

                    var lines1 = Functions.ToLines(path1);
                    var lines2 = Functions.ToLines(path2);
                    var minDistance = Functions.GetMinDistance(lines1, lines2);
                    Console.WriteLine($"The result of Day3a is {minDistance}");
                    var minSteps = Functions.GetMinSteps(lines1, lines2);
                    Console.WriteLine($"The result of Day3b is {minSteps}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }

    }

    public static class Functions
    {
        public static List<Line> ToLines(this string input)
        {
            var output = new List<Line>();
            var strings = input.Split(',').ToList();
            var currentX = 0;
            var currentY = 0;

            strings.ForEach(s =>
            {
                var start = new Coord(currentX, currentY);
                var dir = s.Substring(0, 1);
                var length = int.Parse(s.Substring(1));
                switch (dir)
                {
                    case "U": currentY += length; break;
                    case "R": currentX += length; break;
                    case "D": currentY -= length; break;
                    case "L": currentX -= length; break;
                    default: break;
                }
                var end = new Coord(currentX, currentY);
                output.Add(new Line(start, end));

            });

            return output;
        }

        public static List<Coord> GetCrossings(List<Line> path1, List<Line> path2)
        {
            var crossings = path1.SelectMany(l1 => path2.Select(l2 => l1.GetCrossing(l2)))
                                 .Where(c => c != null)
                                 .Where(c => Math.Abs(c.x) + Math.Abs(c.y) > 0)
                                 .ToList();
            return crossings;
        }

        public static int GetMinDistance(List<Line> path1, List<Line> path2)
        {
            var crossings = GetCrossings(path1, path2);
            var distances = crossings.Select(c => Math.Abs(c.x) + Math.Abs(c.y)).ToList();
            return distances.Min();
        }

        public static int GetMinSteps(List<Line> path1, List<Line> path2)
        {
            var crossings = GetCrossings(path1, path2);
            var minSteps = int.MaxValue;
            crossings.ForEach(crossing =>
            {
                var steps1 = 0;
                var index1 = 0;
                var foundCrossing1 = false;
                while(!foundCrossing1)
                {
                    steps1 += path1.ElementAt(index1).GetSteps(crossing);
                    foundCrossing1 = path1.ElementAt(index1).IsInLine(crossing);
                    index1++;
                }
                var steps2 = 0;
                var index2 = 0;
                var foundCrossing2 = false;
                while (!foundCrossing2)
                {
                    steps2 += path2.ElementAt(index2).GetSteps(crossing);
                    foundCrossing2 = path2.ElementAt(index2).IsInLine(crossing);
                    index2++;
                }
                minSteps = Math.Min(minSteps, steps1 + steps2);
            });
            return minSteps;
        }
    }

    public class Coord
    {
        public int x { get; set; }
        public int y { get; set; }

        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Line
    {
        public Coord start { get; set; }
        public Coord end { get; set; }

        public Line(Coord start, Coord end)
        {
            this.start = start;
            this.end = end;
        }

        public List<Coord> Points
        {
            get
            {
                var output = new List<Coord>
                {
                    new Coord(start.x, start.y)
                };
                for (var i = 0; i < length; i++)
                {
                    var currentX = output.Last().x;
                    var currentY = output.Last().y;
                    switch (dir)
                    {
                        case "U": currentY++; break;
                        case "R": currentX++; break;
                        case "D": currentY--; break;
                        case "L": currentX--; break;
                    }
                    output.Add(new Coord(currentX, currentY));
                }
                return output;
            }
        }

        public bool IsInLine(Coord coord)
        {
            return Points.Any(c => c.x == coord.x && c.y == coord.y);
        }

        public int GetSteps(Coord stopAt)
        {
            if (IsInLine(stopAt))
            {
                return Math.Max(Math.Abs(start.x - stopAt.x), Math.Abs(start.y - stopAt.y));
            }
            return length;
        }

        public Coord? GetCrossing(Line line)
        {
            var x1min = Math.Min(start.x, end.x);
            var x1max = Math.Max(start.x, end.x);
            var y1min = Math.Min(start.y, end.y);
            var y1max = Math.Max(start.y, end.y);
            var x2min = Math.Min(line.start.x, line.end.x);
            var x2max = Math.Max(line.start.x, line.end.x);
            var y2min = Math.Min(line.start.y, line.end.y);
            var y2max = Math.Max(line.start.y, line.end.y);
            var xOverLap = x1min >= x2min && x1min <= x2max || x1max >= x2min && x1max <= x2max || x1min <= x2min && x1max >= x2max;
            var yOverLap = y1min >= y2min && y1min <= y2max || y1max >= y2min && y1max <= y2max || y1min <= y2min && y1max >= y2max;
            if (!xOverLap || !yOverLap)
            {
                return null;
            }
            foreach(var p in Points)
            {
                if (IsInLine(p) && line.IsInLine(p))
                {
                    return p;
                }
            }
            return null;

        }

        private string dir
        {
            get
            {
                if (start.x == end.x)
                {
                    return end.y > start.y ? "U" : "D";
                }
                if (start.y == end.y)
                {
                    return end.x > start.x ? "R" : "L";
                }
                throw new Exception("Something seems wrong with line");
            }
        }

        private int length
        {
            get
            {
                if (start.x == end.x)
                {
                    return Math.Max(start.y, end.y) - Math.Min(start.y, end.y);
                }
                if (start.y == end.y)
                {
                    return Math.Max(start.x, end.x) - Math.Min(start.x, end.x);
                }
                throw new Exception("Something seems wrong with line");
            }
        }
    }
}
