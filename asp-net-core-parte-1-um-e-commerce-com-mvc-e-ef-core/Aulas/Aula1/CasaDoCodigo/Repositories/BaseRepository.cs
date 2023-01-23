using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
    }
}
