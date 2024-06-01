namespace PobreLibrary.Models;

public class CreateBookModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Gender { get; set; }
    public DateTime PublicationDate  { get; set; }
    public string Autor { get; set; }
}