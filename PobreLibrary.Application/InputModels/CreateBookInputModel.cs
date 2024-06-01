namespace PobreLibrary.Application.InputModels;

public class CreateBookInputModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Gender { get; set; }
    public DateTime PublicationDate  { get; set; }
    public string Autor { get; set; }
}