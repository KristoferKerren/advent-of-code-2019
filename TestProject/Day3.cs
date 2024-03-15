using Day3;

[TestFixture]
public class TestsDay3
{
    [Test]
    public void ToLines_1()
    {
        // Arrange
        var input = "R8,U5,L5,D3";

        // Act
        var lastLine = Functions.ToLines(input).Last();

        // Assert
        Assert.That(lastLine.end.x, Is.EqualTo(3));
        Assert.That(lastLine.end.y, Is.EqualTo(2));
    }

    [Test]
    public void ToLines_2()
    {
        // Arrange
        var input = "U7,R6,D4,L4";

        // Act
        var lastLine = Functions.ToLines(input).Last();

        // Assert
        Assert.That(lastLine.end.x, Is.EqualTo(2));
        Assert.That(lastLine.end.y, Is.EqualTo(3));
    }

    [Test]
    public void LinePoints_1()
    {
        // Arrange
        var line = new Line(new Coord(2, 2), new Coord(4, 2));

        // Act
        var points = line.Points;

        // Assert
        Assert.That(points.Count, Is.EqualTo(3));
        Assert.That(points.ElementAt(0).x, Is.EqualTo(2));
        Assert.That(points.ElementAt(0).y, Is.EqualTo(2));
        Assert.That(points.ElementAt(1).x, Is.EqualTo(3));
        Assert.That(points.ElementAt(1).y, Is.EqualTo(2));
        Assert.That(points.ElementAt(2).x, Is.EqualTo(4));
        Assert.That(points.ElementAt(2).y, Is.EqualTo(2));
    }

    [Test]
    public void LinePoints_2()
    {
        // Arrange
        var line = new Line(new Coord(20, 22), new Coord(20, 20));

        // Act
        var points = line.Points;

        // Assert
        Assert.That(points.Count, Is.EqualTo(3));
        Assert.That(points.ElementAt(0).x, Is.EqualTo(20));
        Assert.That(points.ElementAt(0).y, Is.EqualTo(22));
        Assert.That(points.ElementAt(1).x, Is.EqualTo(20));
        Assert.That(points.ElementAt(1).y, Is.EqualTo(21));
        Assert.That(points.ElementAt(2).x, Is.EqualTo(20));
        Assert.That(points.ElementAt(2).y, Is.EqualTo(20));
    }

    [Test]
    public void LineIsInLine_2()
    {
        // Arrange
        var line = new Line(new Coord(20, 22), new Coord(20, 20));

        // Act
        var isInLine = new List<Coord> {
            new Coord(20, 20),
            new Coord(20, 21),
            new Coord(20, 22),
        };
        var isNotInLine = new List<Coord> {
            new Coord(20, 19),
            new Coord(20, 23),
            new Coord(19, 20),
            new Coord(19, 21),
            new Coord(19, 22),
            new Coord(21, 20),
            new Coord(21, 21),
            new Coord(21, 22),
        };

        // Assert
        isInLine.ForEach(coord =>
        {
            Assert.That(line.IsInLine(coord), Is.EqualTo(true));
        });
        isNotInLine.ForEach(coord =>
        {
            Assert.That(line.IsInLine(coord), Is.EqualTo(false));
        });
    }

    [Test]
    public void LineGetCrossing_1()
    {
        // Arrange
        var line1 = new Line(new Coord(1, 1), new Coord(10, 1));
        var line2 = new Line(new Coord(-10, 2), new Coord(20, 2));

        // Act
        var crossing1 = line1.GetCrossing(line2);
        var crossing2 = line2.GetCrossing(line1);

        // Assert
        Assert.That(crossing1, Is.Null);
        Assert.That(crossing2, Is.Null);
    }

    [Test]
    public void LineGetCrossing_2()
    {
        // Arrange
        var line1 = new Line(new Coord(1, 1), new Coord(10, 1));
        var line2 = new Line(new Coord(5, -10), new Coord(5, 10));
        var expectedCrossing = new Coord(5, 1);

        // Act
        var crossing1 = line1.GetCrossing(line2);
        var crossing2 = line2.GetCrossing(line1);

        // Assert
        Assert.That(crossing1, Is.Not.Null);
        Assert.That(crossing2, Is.Not.Null);
        Assert.That(crossing1.x, Is.EqualTo(crossing2.x));
        Assert.That(crossing1.y, Is.EqualTo(crossing2.y));
        Assert.That(crossing1.x, Is.EqualTo(expectedCrossing.x));
        Assert.That(crossing1.y, Is.EqualTo(expectedCrossing.y));
    }

    [Test]
    public void LineGetSteps_1()
    {
        // Arrange
        var line = new Line(new Coord(20, 25), new Coord(20, 20));
        var coord1 = new Coord(20, 24);
        var coord2 = new Coord(20, 23);
        var coord3 = new Coord(20, 22);
        var coord4 = new Coord(20, 21);
        var coord5 = new Coord(20, 20);

        // Act
        var steps1 = line.GetSteps(coord1);
        var steps2 = line.GetSteps(coord2);
        var steps3 = line.GetSteps(coord3);
        var steps4 = line.GetSteps(coord4);
        var steps5 = line.GetSteps(coord5);

        // Assert
        Assert.That(steps1, Is.EqualTo(1));
        Assert.That(steps2, Is.EqualTo(2));
        Assert.That(steps3, Is.EqualTo(3));
        Assert.That(steps4, Is.EqualTo(4));
        Assert.That(steps5, Is.EqualTo(5));
    }

    [Test]
    public void GetMinDistance_1()
    {
        // Arrange
        var lines1 = Functions.ToLines("R8,U5,L5,D3");
        var lines2 = Functions.ToLines("U7,R6,D4,L4");

        // Act
        var distance = Functions.GetMinDistance(lines1, lines2);

        // Assert
        Assert.That(distance, Is.EqualTo(6));
    }

    [Test]
    public void GetMinDistance_2()
    {
        // Arrange
        var lines1 = Functions.ToLines("R75,D30,R83,U83,L12,D49,R71,U7,L72");
        var lines2 = Functions.ToLines("U62,R66,U55,R34,D71,R55,D58,R83");

        // Act
        var distance = Functions.GetMinDistance(lines1, lines2);

        // Assert
        Assert.That(distance, Is.EqualTo(159));
    }

    [Test]
    public void GetMinDistance_3()
    {
        // Arrange
        var lines1 = Functions.ToLines("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51");
        var lines2 = Functions.ToLines("U98,R91,D20,R16,D67,R40,U7,R15,U6,R7");

        // Act
        var distance = Functions.GetMinDistance(lines1, lines2);

        // Assert
        Assert.That(distance, Is.EqualTo(135));
    }

    [Test]
    public void GetMinSteps_1()
    {
        // Arrange
        var lines1 = Functions.ToLines("R8,U5,L5,D3");
        var lines2 = Functions.ToLines("U7,R6,D4,L4");

        // Act
        var steps = Functions.GetMinSteps(lines1, lines2);

        // Assert
        Assert.That(steps, Is.EqualTo(30));
    }

    [Test]
    public void GetMinSteps_2()
    {
        // Arrange
        var lines1 = Functions.ToLines("R75,D30,R83,U83,L12,D49,R71,U7,L72");
        var lines2 = Functions.ToLines("U62,R66,U55,R34,D71,R55,D58,R83");

        // Act
        var steps = Functions.GetMinSteps(lines1, lines2);

        // Assert
        Assert.That(steps, Is.EqualTo(610));
    }

    [Test]
    public void GetMinSteps_3()
    {
        // Arrange
        var lines1 = Functions.ToLines("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51");
        var lines2 = Functions.ToLines("U98,R91,D20,R16,D67,R40,U7,R15,U6,R7");

        // Act
        var steps = Functions.GetMinSteps(lines1, lines2);

        // Assert
        Assert.That(steps, Is.EqualTo(410));
    }

}