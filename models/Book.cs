namespace LibraryProgram.Models;

/// <summary>
/// Represents a book. The book's properties cannot be changed after the book is created.
/// </summary>
/// <param name="id">the book's id.</param>
/// <param name="title">the book's title.</param>
/// <param name="author">the book's author.</param>
public class Book(int id, string title, string author)
{
    public int Id { get; } = id;
    public string Title { get; set; } = title;
    public string Author { get; set; } = author;
}

