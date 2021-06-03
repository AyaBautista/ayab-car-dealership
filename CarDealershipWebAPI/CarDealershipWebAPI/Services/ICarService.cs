using CarDealershipWebAPI.Models;
using System.Collections.Generic;

namespace CarDealershipWebAPI.Services
{
    public interface ICarService
    {
        List<Car> GetFilteredCarData(CarFilter filter);
    }
}
