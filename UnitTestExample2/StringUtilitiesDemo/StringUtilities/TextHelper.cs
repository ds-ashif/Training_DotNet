namespace StringUtilities;

/// <summary>
/// Provides helper methods for working with strings.
/// </summary>
public class TextHelper
{
    /// <summary>
    /// Reverses the given string.
    /// </summary>
    /// <param name="text">Input string to reverse</param>
    /// <returns>Reversed string</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the input string is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when the input string is empty.
    /// </exception>
    public string Reverse(string text)
    {
        // Guard clause: null input is not allowed
        if (text == null)
            throw new ArgumentNullException(nameof(text));

        // Guard clause: empty string is considered invalid
        if (text.Length == 0)
            throw new ArgumentException(
                "Input string cannot be empty",
                nameof(text)
            );

        // Convert string to char array so it can be reversed
        char[] chars = text.ToCharArray();

        // Reverse the array in-place
        Array.Reverse(chars);

        // Create a new string from the reversed characters
        return new string(chars);
    }
}
