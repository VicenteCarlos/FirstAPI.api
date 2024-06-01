using PobreLibrary.Application.ViewModels;
using PobreLibrary.Application.InputModels;
namespace PobreLibrary.Application.Services.Interfaces;

public interface IBookService
{
    List<BookViewModel> GetAll();
    BookDetailsViewModel GetById(int id);
    int Create(CreateBookInputModel inputModel);
    void Update(int id, UpdateBookInputModel inputModel);
    void Delete(int id);
}