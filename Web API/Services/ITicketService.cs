using System.Collections.Generic;
using Web_API.Models;

namespace Web_API.Services
{
    public interface ITicketService
    {
        public IEnumerable<Ticket> GetAll();
        public Ticket GetById(int id);
        public int DeleteById(Ticket ticket);
        public int Update(Ticket ticket);
        public int Create(Ticket ticket);
    }
}