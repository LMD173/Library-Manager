namespace LibraryProgram;

public class Program
{
    public static void Main()
    {
        LibraryManager libraryManager = new("Libs");
        libraryManager.Run();
    }
}
