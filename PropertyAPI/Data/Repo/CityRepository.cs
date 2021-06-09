using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyAPI.Data.Interfaces;
using PropertyAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PropertyAPI.Data.Repo
{
    public class CityRepository : ICityRepository
    {
        private readonly PropertyDbContext _context;

        public CityRepository(PropertyDbContext context)
        {
            _context = context;
        }
        public void AddCity(City city)
        {
            _context.Cities.Add(city);
        }

        public void DeleteCity(int cityId)
        {
            var city = _context.Cities.Find(cityId);
            _context.Remove(city);
            //SaveAsync();
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<City> GetCity(int cityId)
        {
            return await _context.Cities.FindAsync(cityId);
        }
    }
}