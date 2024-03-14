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

}
