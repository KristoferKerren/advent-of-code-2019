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
        foreach (var p in Points)
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