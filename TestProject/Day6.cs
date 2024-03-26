using Day6;
using Global;

[TestFixture]
public class TestsDay6
{
    private string filePath = Path.Combine(Path.GetFullPath(Constants.RootFolder + "Day6"), "InputTest.txt");

    [Test]
    public void GetObjectsFromFile_1()
    {
        // Arrange
        var objects = Functions.GetObjectsFromFile(filePath);

        // Assert
        Assert.That(objects.Count, Is.EqualTo(11));
    }

    [Test]
    public void Connected_1()
    {
        // Arrange
        var objects = Functions.GetObjectsFromFile(filePath);

        // Act
        var connectedB = objects.Single(o => o.Name == "B").ConnectedObjects.Count();
        var connectedL = objects.Single(o => o.Name == "L").ConnectedObjects.Count();

        // Assert
        Assert.That(connectedB, Is.EqualTo(3));
        Assert.That(connectedL, Is.EqualTo(1));
    }

    [Test]
    public void GetOrbitNameOrDefault_1()
    {
        // Arrange
        var objects = Functions.GetObjectsFromFile(filePath);

        // Act
        var orbitNameB = Functions.GetOrbitNameOrDefault("B", objects);
        var orbitNameL = Functions.GetOrbitNameOrDefault("L", objects);
        var orbitNameCOM = Functions.GetOrbitNameOrDefault("COM", objects);

        // Assert
        Assert.That(orbitNameB, Is.EqualTo("COM"));
        Assert.That(orbitNameL, Is.EqualTo("K"));
        Assert.That(orbitNameCOM, Is.Null);
    }

    [Test]
    public void GetOrbitsCount_1()
    {
        // Arrange
        var objects = Functions.GetObjectsFromFile(filePath);

        // Act
        var orbitCountB = Functions.GetOrbitsCount("B", objects);
        var orbitCountL = Functions.GetOrbitsCount("L", objects);
        var orbitCountCOM = Functions.GetOrbitsCount("COM", objects);

        // Assert
        Assert.That(orbitCountB, Is.EqualTo(1));
        Assert.That(orbitCountL, Is.EqualTo(7));
        Assert.That(orbitCountCOM, Is.EqualTo(0));
    }

    [Test]
    public void GetTotalOrbits_1()
    {
        // Arrange
        var objects = Functions.GetObjectsFromFile(filePath);

        // Act
        var totalOrbits = Functions.GetTotalOrbits(objects);

        // Assert
        Assert.That(totalOrbits, Is.EqualTo(42));
    }

    [Test]
    public void GetStepsBetween_1()
    {
        // Arrange
        var objects = Functions.GetObjectsFromFile(filePath);
        var b = objects.Single(o => o.Name == "B");
        var h = objects.Single(o => o.Name == "H");
        var k = objects.Single(o => o.Name == "K");
        var i = objects.Single(o => o.Name == "I");

        // Act
        var stepsBetweenBandH = Functions.GetStepsBetweenRecursive(b, h, new HashSet<string>());
        var stepsBetweenHandB = Functions.GetStepsBetweenRecursive(h, b, new HashSet<string>());
        var stepsBetweenKandI = Functions.GetStepsBetweenRecursive(k, i, new HashSet<string>());
        var stepsBetweenIandK = Functions.GetStepsBetweenRecursive(i, k, new HashSet<string>());

        // Assert
        Assert.That(stepsBetweenBandH, Is.EqualTo(2));
        Assert.That(stepsBetweenHandB, Is.EqualTo(2));
        Assert.That(stepsBetweenKandI, Is.EqualTo(4));
        Assert.That(stepsBetweenIandK, Is.EqualTo(4));
    }
}
