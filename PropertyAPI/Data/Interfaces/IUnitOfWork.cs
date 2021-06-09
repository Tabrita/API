using System.Threading.Tasks;

namespace PropertyAPI.Data.Interfaces
{
    public interface IUnitOfWork
    {
        ICityRepository CityRepository { get; }
        Task<bool> SaveAsync();
    }
}