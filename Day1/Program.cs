using Global;

namespace Day1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var rootDirectory = Path.GetFullPath(Constants.RootFolder + "Day1");
            var filePath = Path.Combine(rootDirectory, "Input.txt");

            try
            {
                var input = new List<int>();
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        input.Add(int.Parse(line));
                    }
                }

                var sum = 0;
                while (input.Count > 0)
                {
                    input = ParseToFuels(input);
                    sum += input.Sum();
                }
                Console.WriteLine($"The result of Day1a is {sum}");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }

        public static int ParseToFuel(int input)
        {
            return (input / 3) - 2;
        }
        public static List<int> ParseToFuels(List<int> input)
        {
            return input.Select(ParseToFuel).Where(i => i > 0).ToList();
        }
    }
}
