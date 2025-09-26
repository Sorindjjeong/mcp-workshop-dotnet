using MyMonkeyApp;

/// <summary>
/// Main program class for the Monkey Console Application.
/// </summary>
public class Program
{
    private static readonly Random _random = new();
    
    /// <summary>
    /// Collection of ASCII art for random display.
    /// </summary>
    private static readonly string[] _asciiArt = new[]
    {
        @"
    🐒 MONKEY PARADISE 🐒
       /|   /|   
      ( :v:  )   
       |(_)|    
       ^^^^^^^^^^
",
        @"
    🙊 MONKEY BUSINESS 🙊
         .-""-.
        /  _  \
       |  (o)  |
        \  -  /
         `---`
",
        @"
    🐵 PRIMATE STATION 🐵
      ___====-_  _-====___
    _--^^^#####//      \\#####^^^--_
 _-^##########// (    ) \\##########^-_
-############//  |\^^/|  \\############-
",
        @"
    🙉 MONKEY MADNESS 🙉
        \   o   /
         \ ._. /
      ____) (____
     /.-.\ / /.-.\ 
     \   ` | `   /
      `---' '---`
"
    };

    /// <summary>
    /// Main entry point of the application.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    public static void Main(string[] args)
    {
        try
        {
            ShowWelcome();
            ShowMainMenu();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ An unexpected error occurred: {ex.Message}");
            Console.ResetColor();
        }
        finally
        {
            Console.WriteLine("\nPress any key to exit...");
            try
            {
                Console.ReadKey();
            }
            catch (InvalidOperationException)
            {
                // Console input may be redirected or not available
                // This is expected in headless environments
            }
        }
    }

    /// <summary>
    /// Displays the welcome screen with random ASCII art.
    /// </summary>
    private static void ShowWelcome()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(_asciiArt[_random.Next(_asciiArt.Length)]);
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welcome to the Monkey Console Application!");
        Console.WriteLine("Discover amazing monkey species from around the world! 🌍");
        Console.ResetColor();
        Console.WriteLine();
    }

    /// <summary>
    /// Displays and handles the main menu interactions.
    /// </summary>
    private static void ShowMainMenu()
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n🐒 MAIN MENU 🐒");
            Console.WriteLine("================");
            Console.ResetColor();
            
            Console.WriteLine("1. 📋 List all monkeys");
            Console.WriteLine("2. 🔍 Get details for a specific monkey by name");
            Console.WriteLine("3. 🎲 Get a random monkey");
            Console.WriteLine("4. 📊 Show statistics");
            Console.WriteLine("5. ❌ Exit app");
            
            Console.Write("\nPlease select an option (1-5): ");
            
            var input = Console.ReadLine();
            
            switch (input?.Trim())
            {
                case "1":
                    ListAllMonkeys();
                    break;
                case "2":
                    GetMonkeyByName();
                    break;
                case "3":
                    GetRandomMonkey();
                    break;
                case "4":
                    ShowStatistics();
                    break;
                case "5":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n👋 Thanks for using Monkey Console App! Goodbye!");
                    Console.ResetColor();
                    keepRunning = false;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n❌ Invalid option. Please try again.");
                    Console.ResetColor();
                    break;
            }

            if (keepRunning)
            {
                Console.WriteLine("\nPress any key to continue...");
                try
                {
                    Console.ReadKey();
                }
                catch (InvalidOperationException)
                {
                    // Console input may be redirected or not available
                    // This is expected in headless environments
                    System.Threading.Thread.Sleep(1000); // Small delay for readability
                }
                Console.Clear();
                ShowWelcome();
            }
        }
    }

    /// <summary>
    /// Lists all available monkeys in a formatted table.
    /// </summary>
    private static void ListAllMonkeys()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("📋 ALL MONKEYS");
        Console.WriteLine("==============");
        Console.ResetColor();

        var monkeys = MonkeyHelper.GetMonkeys().ToList();
        
        if (!monkeys.Any())
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No monkeys found in the database.");
            Console.ResetColor();
            return;
        }

        Console.WriteLine($"\nFound {monkeys.Count} monkey species:\n");
        
        // Header
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{"#",-3} {"Name",-25} {"Location",-25} {"Population",-12}");
        Console.WriteLine(new string('-', 70));
        Console.ResetColor();

        // Data rows
        for (int i = 0; i < monkeys.Count; i++)
        {
            var monkey = monkeys[i];
            Console.WriteLine($"{i + 1,-3} {monkey.Name,-25} {monkey.Location,-25} {monkey.Population,-12:N0}");
        }
    }

    /// <summary>
    /// Prompts user for a monkey name and displays its details.
    /// </summary>
    private static void GetMonkeyByName()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("🔍 FIND MONKEY BY NAME");
        Console.WriteLine("======================");
        Console.ResetColor();

        Console.Write("\nEnter the monkey name: ");
        var name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Please enter a valid monkey name.");
            Console.ResetColor();
            return;
        }

        var monkey = MonkeyHelper.GetMonkeyByName(name);

        if (monkey == null)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"❌ No monkey found with the name '{name}'.");
            Console.WriteLine("\n💡 Tip: Try searching for one of these available monkeys:");
            
            var availableMonkeys = MonkeyHelper.GetMonkeys().Select(m => m.Name).Take(5);
            foreach (var availableName in availableMonkeys)
            {
                Console.WriteLine($"   • {availableName}");
            }
            Console.ResetColor();
            return;
        }

        DisplayMonkeyDetails(monkey);
    }

    /// <summary>
    /// Gets and displays a random monkey.
    /// </summary>
    private static void GetRandomMonkey()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("🎲 RANDOM MONKEY SELECTION");
        Console.WriteLine("==========================");
        Console.ResetColor();

        Console.WriteLine("🎲 Rolling the dice for a random monkey...\n");
        
        // Add a small delay for dramatic effect
        System.Threading.Thread.Sleep(500);
        
        var monkey = MonkeyHelper.GetRandomMonkey();
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🎉 You got:");
        Console.ResetColor();
        
        DisplayMonkeyDetails(monkey);
    }

    /// <summary>
    /// Displays detailed information about a specific monkey.
    /// </summary>
    /// <param name="monkey">The monkey to display.</param>
    private static void DisplayMonkeyDetails(Monkey monkey)
    {
        Console.WriteLine($"\n{monkey.Image} {monkey.Name}");
        Console.WriteLine(new string('=', monkey.Name.Length + 2));
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("📍 Location: ");
        Console.ResetColor();
        Console.WriteLine(monkey.Location);
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("👥 Population: ");
        Console.ResetColor();
        Console.WriteLine($"{monkey.Population:N0}");
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("📝 Details: ");
        Console.ResetColor();
        Console.WriteLine(monkey.Details);
    }

    /// <summary>
    /// Shows application statistics.
    /// </summary>
    private static void ShowStatistics()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("📊 MONKEY STATISTICS");
        Console.WriteLine("===================");
        Console.ResetColor();

        var totalMonkeys = MonkeyHelper.GetTotalMonkeyCount();
        var randomAccessCount = MonkeyHelper.GetRandomAccessCount();
        var totalPopulation = MonkeyHelper.GetMonkeys().Sum(m => m.Population);

        Console.WriteLine($"\n🐒 Total monkey species: {totalMonkeys}");
        Console.WriteLine($"🎲 Random selections made: {randomAccessCount}");
        Console.WriteLine($"👥 Total population across all species: {totalPopulation:N0}");
        
        // Show top 3 most populous species
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n🏆 Top 3 Most Populous Species:");
        Console.ResetColor();
        
        var topMonkeys = MonkeyHelper.GetMonkeys()
            .OrderByDescending(m => m.Population)
            .Take(3)
            .ToList();

        for (int i = 0; i < topMonkeys.Count; i++)
        {
            var monkey = topMonkeys[i];
            Console.WriteLine($"   {i + 1}. {monkey.Name}: {monkey.Population:N0}");
        }
    }
}
