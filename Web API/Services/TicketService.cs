using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Models;
using Web_API.Repositories;

namespace Web_API.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repository;

        public TicketService(ITicketRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _repository.GetAll();
        }

        public Ticket GetById(int id)
        {
            return _repository.GetById(id);
        }

        public int DeleteById(Ticket ticket)
        {
            return _repository.Delete(ticket);
        }

        public int Update(Ticket ticket)
        {
            return _repository.Update(ticket);
        }

        public int Create(Ticket ticket)
        {
            return  _repository.Create(ticket);
        }
    }
}
