using j2p.Domain.Entities;
using j2p.Domain.Interfaces.Repositories;
using j2p.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace j2p.Infra.Data.Repositories
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        private readonly j2pContext _context;

        public EventRepository(j2pContext context) 
            : base(context)
        {
            _context = context;
        }

        public Event Add(Event obj)
        {
            _context.Set<Event>().Add(obj);
            _context.SaveChanges();

            return obj;
        }

        public void Delete(Event obj)
        {
            _context.Set<Event>().Remove(obj);
            _context.SaveChanges();
        }

        public Event Update(Event obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }
    }
}
