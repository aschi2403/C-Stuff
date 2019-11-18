using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AdvancedEFCore;
using Microsoft.EntityFrameworkCore;

namespace AdvancedEfCore
{
    partial class Program
    {
        private static async Task<IEnumerable<Book>> QueryBooksAsync(BookDataContext context)
        {
            //Return all books INCLUDING their genre
            return await context.Books.Include(b => b.Genre).ToArrayAsync();
        }

        private static async Task<IEnumerable<Book>> QueryFilteredBooksAsync(BookDataContext context)
        {
            // Deferred Execution

            var filteredBooks = context.Books.Where(b => b.Genre.GenreTitle == "Drama");

            filteredBooks = filteredBooks.Where(b => b.Language == "US");

            var resultBooks = await filteredBooks.ToArrayAsync();

            return resultBooks.Where(b => b.Title.Contains("bla"));
        }
    }
}
