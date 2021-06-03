using CarDealershipWebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarDealershipWebAPI.Repositories
{
    public class CarRepository : ICarRepository
    {
        public IQueryable<Car> GetCars()
        {
            using (DBModel db = new DBModel())
            {
                IQueryable<Car> queryResult = db.Cars;
                return queryResult;
            }
        }
    }
}