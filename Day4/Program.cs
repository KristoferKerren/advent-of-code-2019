namespace Day4
{
    public class Program
    {
        static void Main(string[] args)
        {
            var minPassword = 236491;
            var maxPassword = 713787;
            var count4a = 0;
            var count4b = 0;
            for (var password = minPassword; password <= maxPassword; password++)
            {
                var meets4a = Functions.MeetCriterias(password);
                var meets4b = Functions.MeetCriterias(password, true);
                if (meets4a) count4a++;
                if (meets4b) count4b++;
            }
            Console.WriteLine($"The result of Day4a is {count4a}");
            Console.WriteLine($"The result of Day4b is {count4b}");
        }

    }

}
