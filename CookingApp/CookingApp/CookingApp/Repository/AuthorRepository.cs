using CookingApp.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingApp.Models
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext appDbContext;
        public AuthorRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Author> AddAuthor(Author author)
        { 
            var result = await appDbContext.Author.AddAsync(author);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteAuthor(int authorId)
        {
            var result = await appDbContext.Author.
                FirstOrDefaultAsync(a => a.AuthorId == authorId);
            if (result != null)
            {
                appDbContext.Author.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Author> GetAuthor(int authorId)
        {
            return await appDbContext.Author.
               FirstOrDefaultAsync(a => a.AuthorId == authorId);
        }

        public async Task<Author> GetAuthorByEmail(string email)
        {
            return await appDbContext.Author.
                FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await appDbContext.Author.ToListAsync();
        }

        public async Task<IEnumerable<Author>> Search(string name)
        {
            IQueryable<Author> query = appDbContext.Author;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.FirstName.Contains(name) || a.LastName.Contains(name));

            }
            
            return await query.ToListAsync();
        }

        public async Task<Author> UpdateAuthor(Author author)
        {
            var result = await appDbContext.Author.FirstOrDefaultAsync
                (a => a.AuthorId == author.AuthorId);
            if (result != null)
            {
                result.FirstName = author.FirstName;
                result.LastName = author.LastName;
                result.Email = author.Email;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
    }

