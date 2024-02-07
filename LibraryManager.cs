using static LibraryProgram.Utils.IO;

namespace LibraryProgram;

public class LibraryManager(string name)
{
    private readonly string name = name;

    /// <summary>
    /// Begins the flow of the library program. Users can select from a list of options to interact with the library.
    /// </summary>
    public void Run()
    {
        Library library = new();

        Console.WriteLine($"Welcome to {name}! We hope you enjoy your time here. Happy reading!");
        Console.WriteLine("What would you like to do?");
        bool exit = false;

        while (!exit)
        {
            DisplayOptions();
            string option = GetUserInput("Please enter an option");
            Console.Clear();

            switch (option.ToLower())
            {
                case "a":
                    library.AddBook();
                    break;
                case "v":
                    library.ViewBooks();
                    break;
                case "x":
                    SayGoodbye();
                    exit = true;
                    break;
                case "b":
                    library.BorrowBook();
                    break;
                case "r":
                    library.ReturnBook();
                    break;
                default:
                    LogError($"'{option}' is an invalid option. Please try again.");
                    break;
            }
        }
    }

    private static void SayGoodbye()
    {
        Console.WriteLine("Goodbye!");
    }

    private static void DisplayOptions()
    {
        Console.WriteLine("\n=====================================");
        Console.WriteLine("1. Add a book (a)");
        Console.WriteLine("2. Borrow a book (b)");
        Console.WriteLine("3. View all books (v)");
        Console.WriteLine("4. Return a book (r)");
        Console.WriteLine("5. Exit (x)");
        Console.WriteLine("=====================================");
    }
}