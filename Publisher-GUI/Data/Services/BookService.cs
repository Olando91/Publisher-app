using Models.Book;
using Publisher_GUI.Data.Forms;
using Publisher_GUI.Data.Repositories;
using Publisher_GUI.Models;

namespace Publisher_GUI.Data.Services;

public class BookService
{
    private readonly BookRepository _bookRepo;

    public BookService(BookRepository bookRepo)
    {
        _bookRepo = bookRepo;
    }

    public async Task<List<Book>> GetAllBooksNoAuth() 
    {
        try
        {
            var books = await _bookRepo.GetAllBooksNoAuth();

            return books.Data;
        }
        catch (Error e)
        {
            throw e;
        }
    }

    public async Task<List<Book>> GetAllBooks()
    {
        try
        {
            var books = await _bookRepo.GetAllBooks();

            return books.Data;
        }
        catch (Error e)
        {
            throw e;
        }
    }

    public async Task DeleteBook(Guid bookId) 
    {
        try
        {
            await _bookRepo.DeleteBook(bookId);
        }
        catch (Error e) 
        {
            throw e;
        }
    }

    public async Task EditBook(EditBookForm editedBook)
    {
        try
        {
            await _bookRepo.EditBook(editedBook);
        }
        catch (Error e)
        {
            throw e;
        }
    }
}
