using Global;

namespace Day6
{
    public class Program
    {
        static void Main(string[] args)
        {
            var rootDirectory = Path.GetFullPath(Constants.RootFolder + "Day6");
            var filePath = Path.Combine(rootDirectory, "Input.txt");
            var objects = Functions.GetObjectsFromFile(filePath);
            var totalOrbits = Functions.GetTotalOrbits(objects);
            var youOrb = objects.Single(o => o.Name == "YOU").ConnectedObjects.First();
            var sanOrb = objects.Single(o => o.Name == "SAN").ConnectedObjects.First();
            var stepsBetween = Functions.GetStepsBetweenRecursive(youOrb, sanOrb, new HashSet<string>());

            Console.WriteLine($"The result of Day6a is {totalOrbits}");
            Console.WriteLine($"The result of Day6b is {stepsBetween}");

        }

        
    }

}
