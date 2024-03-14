using Day1;

[TestFixture]
public class TestDay1
{
    [Test]
    public void ParseToFuel_1()
    {
        // Arrange
        int input = 12;

        // Act
        int fuel = Program.ParseToFuel(input);

        // Assert
        Assert.That(fuel, Is.EqualTo(2));
    }

    [Test]
    public void ParseToFuel_2()
    {
        // Arrange
        int input = 14;

        // Act
        int fuel = Program.ParseToFuel(input);

        // Assert
        Assert.That(fuel, Is.EqualTo(2));
    }

    [Test]
    public void ParseToFuel_3()
    {
        // Arrange
        int input = 1969;

        // Act
        int fuel = Program.ParseToFuel(input);

        // Assert
        Assert.That(fuel, Is.EqualTo(654));
    }

    [Test]
    public void ParseToFuel_4()
    {
        // Arrange
        int input = 100756;

        // Act
        int fuel = Program.ParseToFuel(input);

        // Assert
        Assert.That(fuel, Is.EqualTo(33583));
    }

    [Test]
    public void ParseToFuels_1()
    {
        // Arrange
        var input = new List<int>() { 12, 14, 1969, 100756 };

        // Act
        var fuels = Program.ParseToFuels(input);
        var expected = new List<int>() { 2, 2, 654, 33583 };

        // Assert
        Assert.That(fuels, Is.EqualTo(expected));
    }
}