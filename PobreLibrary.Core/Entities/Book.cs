namespace PobreLibrary.Core.Entities;

public class Book : BaseEntity
{
    public string Title { get;  set; }
    public string Description { get;  set; }
    public string Gender { get;  set; }
    public DateTime PublicationDate  { get;  set; }
    public string Autor { get;  set; }
    public DateTime CreatedAt { get;  set; }

    public Book(string title, string description, string gender, DateTime publicationDate, string autor)
    {
        Title = title;
        Description = description;
        Gender = gender;
        PublicationDate = publicationDate;
        Autor = autor;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(string title, string description, string gender)
    {
        Title = title;
        Description = description;
        Gender = gender;
    }
}