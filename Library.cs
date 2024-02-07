using static LibraryProgram.Utils.IO;
using LibraryProgram.Models;

namespace LibraryProgram;

/// <summary>
/// Represents a Library.
/// </summary>
public class Library
{
    /// <summary>
    /// The list of current books in the library.
    /// This list was chosen by ChatGPT.
    /// </summary>
    private readonly List<Book> books = [
        new(1, "The Hobbit", "J.R.R. Tolkien"),
        new(2, "1984", "George Orwell"),
        new(3, "To Kill a Mockingbird", "Harper Lee"),
        new(4, "Pride and Prejudice", "Jane Austen"),
        new(5, "The Great Gatsby", "F. Scott Fitzgerald"),
        new(6, "Moby Dick", "Herman Melville"),
        new(7, "War and Peace", "Leo Tolstoy"),
        new(8, "Hamlet", "William Shakespeare"),
        new(9, "The Catcher in the Rye", "J.D. Salinger"),
        new(10, "The Alchemist", "Paulo Coelho")
    ];

    private readonly List<Book> borrowedBooks = [];

    /// <summary>
    /// Asks user to input information about a new book to add. If a book with the same ID already
    /// exists, the book will not be added.
    /// </summary>
    public void AddBook()
    {
        string title = GetUserInput("Enter the title of the book");
        string author = GetUserInput("Enter the author of the book");
        if (!int.TryParse(GetUserInput("Enter a unique ID for the book (an integer)"), out int id))
        {
            LogError("Please enter a valid integer ID.");
            return;
        }

        if (books.Any(b => b.Id == id) || borrowedBooks.Any(b => b.Id == id))
        {
            LogError("A book with that ID already exists.");
            return;
        }

        Book book = new(id, title, author);
        books.Add(book);
    }

    /// <summary>
    /// Allows a user to borrow a book from the library. As long as the book is available, it will be
    /// moved from the list of books to the list of borrowed books.
    /// </summary>
    public void BorrowBook()
    {
        if (!int.TryParse(GetUserInput("Enter the ID of the book you want to borrow"), out int id))
        {
            LogError("Please enter a valid integer ID.");
            return;
        }

        Book? book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            Book? borrowed = borrowedBooks.FirstOrDefault(b => b.Id == id);
            if (borrowed != null)
            {
                LogError($"The book with ID {id} has already been borrowed.");
                return;
            }

            LogError($"No book with ID {id} is currently in the library.");
            return;
        }

        borrowedBooks.Add(book);
        books.Remove(book);
    }
    /// <summary>
    /// Displays all the current non-borrowed books in the library.
    /// </summary>
    public void ViewBooks()
    {
        foreach (Book book in books)
        {
            Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}");
        }
    }

    /// <summary>
    /// Allows a user to return a book to the library. As long as the book is borrowed, it will be
    /// moved from the list of borrowed books to the list of books.
    /// </summary>
    public void ReturnBook()
    {
        if (!int.TryParse(GetUserInput("Enter the ID of the book you want to return"), out int id))
        {
            LogError("Please enter a valid integer ID.");
            return;
        }

        Book? book = borrowedBooks.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            LogError("A book with that ID has not been borrowed.");
            return;
        }

        books.Add(book);
        borrowedBooks.Remove(book);

        Console.WriteLine($"Book of ID {id} returned successfully.");
    }
}