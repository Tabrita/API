using System.Threading.Tasks;
using PropertyAPI.Data.Interfaces;

namespace PropertyAPI.Data.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PropertyDbContext _context;

        public UnitOfWork(PropertyDbContext context)
        {
            _context = context;
        }
        public ICityRepository CityRepository => new CityRepository(_context);

        public async Task<bool> SaveAsync()
        {
            var i = await _context.SaveChangesAsync();
            if (i > 0)
            {
                return true;
            }
            return false;
        }
    }
}