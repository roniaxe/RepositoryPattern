using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Data;
using Web_API.Models;

namespace Web_API.Repositories
{
    public class TicketRepository : GenericEntityFrameworkRepository<Ticket, int>, ITicketRepository
    {
        public TicketRepository(ProjectDbContext dbContext) : base(dbContext)
        {
        }
    }
}
