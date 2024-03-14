namespace Day3
{
    static class Functions
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
                while (!foundCrossing1)
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
}
