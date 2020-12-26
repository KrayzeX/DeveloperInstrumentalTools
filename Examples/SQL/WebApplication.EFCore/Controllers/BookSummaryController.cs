using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Database.EFCore.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.EFCore.Controllers
{
    [ApiController]
    [Route("books")]
    public class BookSummaryController : ControllerBase
    {
        private ILogger<BookSummaryController> Logger { get; }
        private IBookDataAccess BookDataAccess { get; }
        private IMapper Mapper { get;  }
        

        public BookSummaryController(ILogger<BookSummaryController> logger, IBookDataAccess bookDataAccess, IMapper mapper)
        {
            Logger = logger;
            BookDataAccess = bookDataAccess;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BookSummary>> Get(CancellationToken ct = default)
        {
            this.Logger.LogDebug($"{nameof(BookSummaryController)}.{nameof(Get)} executed");
            
            return this.Mapper.Map<IEnumerable<BookSummary>>(await this.BookDataAccess.GetAllAsync(ct));
        }
    }
}