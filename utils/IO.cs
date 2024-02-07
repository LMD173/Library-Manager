namespace LibraryProgram.Utils;

public class IO
{
    /// <summary>
    /// Gets user input from the console.
    /// </summary>
    /// <param name="message">the prompt to ask the user.</param>
    /// <returns>the user's response.</returns>
    public static string GetUserInput(string message)
    {
        do
        {
            Console.Write($"{message}: ");
            string? input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Please enter a valid input.");
                continue;
            }

            return input;
        } while (true);
    }

    public static void LogError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}