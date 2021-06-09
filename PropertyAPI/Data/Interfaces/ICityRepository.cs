using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyAPI.Models;

namespace PropertyAPI.Data.Interfaces
{
    public interface ICityRepository
    {
        Task<City> GetCity(int cityId);
        Task<IEnumerable<City>> GetCitiesAsync();

        void AddCity(City city);
        void DeleteCity(int cityId);
    }
}