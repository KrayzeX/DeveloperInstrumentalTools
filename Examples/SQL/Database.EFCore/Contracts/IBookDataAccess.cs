using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Database.EFCore.Entities;

namespace Database.EFCore.Contracts
{
    public interface IBookDataAccess
    {
        Task<IEnumerable<BookEntity>> GetAllAsync(CancellationToken ct = default);
    }
}