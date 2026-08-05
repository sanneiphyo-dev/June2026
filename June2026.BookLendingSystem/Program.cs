// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


public class BookModel
{
    public int BookId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string? Publisher { get; set; }
    public string? Category { get; set; }
}