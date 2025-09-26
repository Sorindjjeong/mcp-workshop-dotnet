namespace MyMonkeyApp;

/// <summary>
/// Static helper class that manages monkey data and provides various operations.
/// </summary>
public static class MonkeyHelper
{
    private static int _randomAccessCount = 0;
    private static readonly Random _random = new();

    /// <summary>
    /// Gets the collection of all available monkeys.
    /// </summary>
    private static readonly List<Monkey> _monkeys = new()
    {
        new Monkey
        {
            Name = "Proboscis Monkey",
            Location = "Borneo",
            Details = "Known for their distinctive large noses, especially in males. They are excellent swimmers and primarily eat leaves.",
            Population = 7000,
            Image = "🐒"
        },
        new Monkey
        {
            Name = "Golden Snub-nosed Monkey",
            Location = "China",
            Details = "These monkeys have beautiful golden fur and can survive in freezing temperatures at high altitudes.",
            Population = 8000,
            Image = "🙊"
        },
        new Monkey
        {
            Name = "Mandrill",
            Location = "Central Africa",
            Details = "The largest monkey species with colorful faces and rumps. They live in large social groups.",
            Population = 800000,
            Image = "🦍"
        },
        new Monkey
        {
            Name = "Japanese Macaque",
            Location = "Japan",
            Details = "Also known as snow monkeys, famous for bathing in hot springs during winter.",
            Population = 114000,
            Image = "🐵"
        },
        new Monkey
        {
            Name = "Howler Monkey",
            Location = "Central and South America",
            Details = "Known for their loud howls that can be heard up to 5 kilometers away. They are the loudest land animals.",
            Population = 150000,
            Image = "🙉"
        },
        new Monkey
        {
            Name = "Spider Monkey",
            Location = "Central and South America",
            Details = "Have long limbs and prehensile tails that act like a fifth hand. They are excellent climbers.",
            Population = 250000,
            Image = "🐒"
        },
        new Monkey
        {
            Name = "Capuchin Monkey",
            Location = "Central and South America",
            Details = "Highly intelligent monkeys known for using tools. They are often featured in movies and TV shows.",
            Population = 300000,
            Image = "🐵"
        },
        new Monkey
        {
            Name = "Squirrel Monkey",
            Location = "South America",
            Details = "Small, colorful monkeys with distinctive yellow and black coloring. They live in large troops.",
            Population = 500000,
            Image = "🙊"
        }
    };

    /// <summary>
    /// Gets all available monkeys.
    /// </summary>
    /// <returns>A collection of all monkeys.</returns>
    public static IEnumerable<Monkey> GetMonkeys()
    {
        return _monkeys.AsReadOnly();
    }

    /// <summary>
    /// Gets a random monkey from the collection and increments the access count.
    /// </summary>
    /// <returns>A randomly selected monkey.</returns>
    public static Monkey GetRandomMonkey()
    {
        _randomAccessCount++;
        var randomIndex = _random.Next(_monkeys.Count);
        return _monkeys[randomIndex];
    }

    /// <summary>
    /// Finds a monkey by name (case-insensitive).
    /// </summary>
    /// <param name="name">The name of the monkey to find.</param>
    /// <returns>The monkey if found, otherwise null.</returns>
    public static Monkey? GetMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        return _monkeys.FirstOrDefault(m => 
            string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets the number of times a random monkey has been accessed.
    /// </summary>
    /// <returns>The random access count.</returns>
    public static int GetRandomAccessCount()
    {
        return _randomAccessCount;
    }

    /// <summary>
    /// Gets the total number of monkeys in the collection.
    /// </summary>
    /// <returns>The total count of monkeys.</returns>
    public static int GetTotalMonkeyCount()
    {
        return _monkeys.Count;
    }
}