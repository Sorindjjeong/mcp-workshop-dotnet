namespace MyMonkeyApp;

/// <summary>
/// Represents a monkey species with its characteristics and information.
/// </summary>
public class Monkey
{
    /// <summary>
    /// Gets or sets the name of the monkey species.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the location where this monkey species is found.
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the details about the monkey species.
    /// </summary>
    public string Details { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the population count of this monkey species.
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// Gets or sets the image URL or description for the monkey.
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Returns a string representation of the monkey.
    /// </summary>
    /// <returns>A formatted string with monkey information.</returns>
    public override string ToString()
    {
        return $"{Name} from {Location} (Population: {Population:N0})";
    }
}