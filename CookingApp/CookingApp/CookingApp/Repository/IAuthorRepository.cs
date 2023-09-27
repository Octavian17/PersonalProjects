using CookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingApp.Models
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> Search(string name);
        Task<IEnumerable<Author>> GetAuthors();
        Task<Author> GetAuthor(int authorId);
        Task<Author> GetAuthorByEmail(string email);
        Task<Author> AddAuthor(Author author);
        Task<Author> UpdateAuthor(Author author);
        Task DeleteAuthor(int authorId);
    }
}
