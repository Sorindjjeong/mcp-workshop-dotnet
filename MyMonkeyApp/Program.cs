using MyMonkeyApp;

class Program
{
    private static readonly string[] AsciiArts = new[]
    {
        @"  (\__/)
  (•ㅅ•)
  / 　 づ",
        @"  ／￣￣￣＼
 /　●　●　\
(　●　●　　)
 \＿＿＿／",
        @"  (o o)
 /|\_/|\
 (     )",
        @"  (¬‿¬)
 ( ͡° ͜ʖ ͡°)",
        @" ʕ•ᴥ•ʔ"
    };

    static async Task Main()
    {
        await MonkeyHelper.InitializeAsync();
        var rand = new Random();
        while (true)
        {
            Console.Clear();
            // 랜덤 ASCII 아트 출력
            if (rand.Next(2) == 0)
            {
                Console.WriteLine(AsciiArts[rand.Next(AsciiArts.Length)]);
                Console.WriteLine();
            }
            Console.WriteLine("==== Monkey Console App ====");
            Console.WriteLine("1. List all monkeys");
            Console.WriteLine("2. Get details for a specific monkey by name");
            Console.WriteLine("3. Get a random monkey");
            Console.WriteLine("4. Exit app");
            Console.Write("Select an option: ");
            var input = Console.ReadLine();
            Console.WriteLine();
            switch (input)
            {
                case "1":
                    var monkeys = MonkeyHelper.GetMonkeys();
                    Console.WriteLine("| Name                | Location                | Population |");
                    Console.WriteLine("-------------------------------------------------------------");
                    foreach (var m in monkeys)
                    {
                        Console.WriteLine($"| {m.Name,-20} | {m.Location,-22} | {m.Population,9} |");
                    }
                    break;
                case "2":
                    Console.Write("Enter monkey name: ");
                    var name = Console.ReadLine();
                    var monkey = MonkeyHelper.GetMonkeyByName(name ?? "");
                    if (monkey != null)
                    {
                        Console.WriteLine($"Name: {monkey.Name}\nLocation: {monkey.Location}\nPopulation: {monkey.Population}\nDetails: {monkey.Details}\nLatitude: {monkey.Latitude}\nLongitude: {monkey.Longitude}");
                    }
                    else
                    {
                        Console.WriteLine("Monkey not found.");
                    }
                    break;
                case "3":
                    var randomMonkey = MonkeyHelper.GetRandomMonkey();
                    if (randomMonkey != null)
                    {
                        Console.WriteLine($"Random Monkey: {randomMonkey.Name}\nLocation: {randomMonkey.Location}\nPopulation: {randomMonkey.Population}\nDetails: {randomMonkey.Details}");
                        Console.WriteLine($"Random pick count: {MonkeyHelper.GetRandomPickCount()}");
                    }
                    else
                    {
                        Console.WriteLine("No monkeys available.");
                    }
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
