using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Database.EFCore.Contracts;
using Database.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.EFCore.Implementations
{
    public class BookDataAccess : IBookDataAccess
    {
        private ExampleContext ExampleContext { get; }
        
        public BookDataAccess(ExampleContext exampleContext)
        {
            ExampleContext = exampleContext;
        }

        public async Task<IEnumerable<BookEntity>> GetAllAsync(CancellationToken ct = default)
        {
            return await this.ExampleContext.Books
                .Include(x => x.Category)
                .OrderBy(x => x.Rating)
                .ToListAsync(ct);
        }
    }
}