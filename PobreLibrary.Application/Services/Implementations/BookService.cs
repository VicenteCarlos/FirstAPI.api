using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PobreLibrary.Application.InputModels;
using PobreLibrary.Application.Services.Interfaces;
using PobreLibrary.Application.ViewModels;
using PobreLibrary.Core.Entities;
using PobreLibrary.Infrastructure.Persistence;

namespace PobreLibrary.Application.Services.Implementations;

public class BookService : IBookService
{
    private readonly PobreLibraryDbContext _dbContext;
    
    public BookService(PobreLibraryDbContext dbContext)
    {
        _dbContext = dbContext;
     
    }
    
    public List<BookViewModel> GetAll()
    {
        var getAllBooks = _dbContext.Books
            .Select(book => new BookViewModel(
                book.Title,
                book.Description,
                book.Gender,
                book.PublicationDate,
                book.Autor
            )).ToList();
        
        return getAllBooks;

        // using (var sqlConnection = new SqlConnection(_connectionString))
        // {
        //     sqlConnection.Open();
        //
        //     var script = "SELECT Id, Description, Gebder, PublicationDate, Autor FROM Book";
        //
        //     return sqlConnection.Query<BookViewModel>(script).ToList();
        // }
    }

    public BookDetailsViewModel GetById(int id)
    {
        var findedBook = _dbContext.Books.SingleOrDefault(book => book.Id.Equals(id));

        if (findedBook == null) return null;

        return new BookDetailsViewModel(
            findedBook.Title,
            findedBook.Description,
            findedBook.Gender,
            findedBook.PublicationDate,
            findedBook.Autor
        );
    }

    public int Create(CreateBookInputModel inputModel)
    {
        var newBook = new Book(
            inputModel.Title, 
            inputModel.Description, 
            inputModel.Gender, 
            inputModel.PublicationDate,
            inputModel.Autor
        );

        _dbContext.Books.Add(newBook);
        _dbContext.SaveChanges();
        
        return newBook.Id;
    }

    public bool Update(int id, UpdateBookInputModel inputModel)
    {
        var findedBook = _dbContext.Books.SingleOrDefault(book => book.Id.Equals(id));

        if (findedBook == null) return false;
        
        findedBook.Update(
            inputModel.Title,
            inputModel.Description,
            inputModel.Gender
        );
        
        _dbContext.SaveChanges();

        return true;
    }

    public bool Delete(int id)
    {
        var findedBook = _dbContext.Books.SingleOrDefault(book => book.Id.Equals(id));

        if (findedBook == null) return false;

        _dbContext.Books.Remove(findedBook);
        _dbContext.SaveChanges();

        return true;
    }
}