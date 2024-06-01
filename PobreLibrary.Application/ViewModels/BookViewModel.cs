namespace PobreLibrary.Application.ViewModels;

public class BookViewModel
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Gender { get; private set; }
    public DateTime PublicationDate  { get; private set; }
    public string Autor { get; private set; }

    public BookViewModel(string title, string description, string gender, DateTime publicationDate, string autor)
    {
        Title = title;
        Description = description;
        Gender = gender;
        PublicationDate = publicationDate;
        Autor = autor;
    }
}