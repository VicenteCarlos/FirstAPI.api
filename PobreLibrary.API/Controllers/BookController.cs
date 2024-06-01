using Microsoft.AspNetCore.Mvc;
using PobreLibrary.Application.InputModels;
using PobreLibrary.Application.Services.Interfaces;
using PobreLibrary.Models;
using Object = Mysqlx.Datatypes.Object;

namespace PobreLibrary.Controllers;

[Route("api/books")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var allBooks = _bookService.GetAll();
        
        return Ok(allBooks);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var book = _bookService.GetById(id);

        if (book == null)
        {
            return NotFound();
        }
        
        return Ok(book);
    }

    [HttpPost] // Por padrão o body da request já cai no post, ou seja, no parâmetro
    public IActionResult Create([FromBody] CreateBookInputModel inputModel) 
    {
        if (inputModel.Title.Length > 50)
        {
            return BadRequest();
        }

        var idBook = _bookService.Create(inputModel);

        return CreatedAtAction(nameof(GetById), new { id = idBook }, inputModel);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateBookInputModel inputModel)
    {
        var findedBook = _bookService.Update(id, inputModel);

        if (!findedBook) return NotFound();
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var findedBook = _bookService.Delete(id);

        if (!findedBook) NotFound();
        
        return NoContent();
    }
}