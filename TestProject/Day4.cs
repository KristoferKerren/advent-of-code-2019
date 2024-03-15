using Day4;

[TestFixture]
public class TestsDay4
{
    [Test]
    public void MeetCriterias_1()
    {
        // Arrange
        var password = 0;

        // Act
        var meetCriteriasThrippleCounts = Functions.MeetCriterias(password);
        var meetCriteriasThrippleNotCounts = Functions.MeetCriterias(password, true);

        // Assert
        Assert.That(meetCriteriasThrippleCounts, Is.EqualTo(false));
        Assert.That(meetCriteriasThrippleNotCounts, Is.EqualTo(false));
    }

    [Test]
    public void MeetCriterias_2()
    {
        // Arrange
        var password = 111111;

        // Act
        var meetCriteriasThrippleCounts = Functions.MeetCriterias(password);
        var meetCriteriasThrippleNotCounts = Functions.MeetCriterias(password, true);

        // Assert
        Assert.That(meetCriteriasThrippleCounts, Is.EqualTo(true));
        Assert.That(meetCriteriasThrippleNotCounts, Is.EqualTo(false));
    }

    [Test]
    public void MeetCriterias_3()
    {
        // Arrange
        var password = 223450;

        // Act
        var meetCriteriasThrippleCounts = Functions.MeetCriterias(password);
        var meetCriteriasThrippleNotCounts = Functions.MeetCriterias(password, true);

        // Assert
        Assert.That(meetCriteriasThrippleCounts, Is.EqualTo(false));
        Assert.That(meetCriteriasThrippleNotCounts, Is.EqualTo(false));
    }

    [Test]
    public void MeetCriterias_4()
    {
        // Arrange
        var password = 123789;

        // Act
        var meetCriteriasThrippleCounts = Functions.MeetCriterias(password);
        var meetCriteriasThrippleNotCounts = Functions.MeetCriterias(password, true);

        // Assert
        Assert.That(meetCriteriasThrippleCounts, Is.EqualTo(false));
        Assert.That(meetCriteriasThrippleNotCounts, Is.EqualTo(false));
    }

    [Test]
    public void MeetCriterias_5()
    {
        // Arrange
        var password = 112233;

        // Act
        var meetCriteriasThrippleCounts = Functions.MeetCriterias(password);
        var meetCriteriasThrippleNotCounts = Functions.MeetCriterias(password, true);

        // Assert
        Assert.That(meetCriteriasThrippleCounts, Is.EqualTo(true));
        Assert.That(meetCriteriasThrippleNotCounts, Is.EqualTo(true));
    }

    [Test]
    public void MeetCriterias_6()
    {
        // Arrange
        var password = 123444;

        // Act
        var meetCriteriasThrippleCounts = Functions.MeetCriterias(password);
        var meetCriteriasThrippleNotCounts = Functions.MeetCriterias(password, true);

        // Assert
        Assert.That(meetCriteriasThrippleCounts, Is.EqualTo(true));
        Assert.That(meetCriteriasThrippleNotCounts, Is.EqualTo(false));
    }

    [Test]
    public void MeetCriterias_7()
    {
        // Arrange
        var password = 111122;

        // Act
        var meetCriteriasThrippleCounts = Functions.MeetCriterias(password);
        var meetCriteriasThrippleNotCounts = Functions.MeetCriterias(password, true);

        // Assert
        Assert.That(meetCriteriasThrippleCounts, Is.EqualTo(true));
        Assert.That(meetCriteriasThrippleNotCounts, Is.EqualTo(true));
    }

    [Test]
    public void MeetCriterias_8()
    {
        // Arrange
        var password = 111123;

        // Act
        var meetCriteriasThrippleCounts = Functions.MeetCriterias(password);
        var meetCriteriasThrippleNotCounts = Functions.MeetCriterias(password, true);

        // Assert
        Assert.That(meetCriteriasThrippleCounts, Is.EqualTo(true));
        Assert.That(meetCriteriasThrippleNotCounts, Is.EqualTo(false));
    }
}