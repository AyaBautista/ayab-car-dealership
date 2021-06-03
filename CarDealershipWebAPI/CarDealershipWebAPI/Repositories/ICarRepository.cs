using System.Linq;
using CarDealershipWebAPI.Models;

namespace CarDealershipWebAPI.Repositories
{
    public interface ICarRepository
    {
        IQueryable<Car> GetCars();
    }
}
