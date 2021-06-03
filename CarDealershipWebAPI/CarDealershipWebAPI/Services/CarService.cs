using CarDealershipWebAPI.Models;
using CarDealershipWebAPI.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CarDealershipWebAPI.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepo;

        public CarService(ICarRepository carRepo)
        {
            _carRepo = carRepo;
        }

        public List<Car> GetFilteredCarData(CarFilter filter)
        {
            IQueryable<Car> carData = _carRepo.GetCars();

            // Change query results based on whether user is searching for an exact match
            if (filter.ShowExactMatches)
            {
                if (!string.IsNullOrEmpty(filter.Color))
                {
                    carData = carData
                        .Where(c => c.Color.Equals(filter.Color)
                            && c.HasHeatedSeats == filter.HasHeatedSeats
                            && c.HasLowMiles == filter.HasLowMiles
                            && c.HasNavigation == filter.HasNavigation
                            && c.HasPowerWindows == filter.HasPowerWindows
                            && c.HasSunroof == filter.HasSunroof
                            && c.IsFourWheelDrive == filter.IsFourWheelDrive);
                }
                else
                {
                    carData = carData
                        .Where(c => c.HasHeatedSeats == filter.HasHeatedSeats
                            && c.HasLowMiles == filter.HasLowMiles
                            && c.HasNavigation == filter.HasNavigation
                            && c.HasPowerWindows == filter.HasPowerWindows
                            && c.HasSunroof == filter.HasSunroof
                            && c.IsFourWheelDrive == filter.IsFourWheelDrive);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(filter.Color))
                {
                    carData = carData
                        .Where(c => (c.Color.Equals(filter.Color))
                            || (c.HasHeatedSeats == filter.HasHeatedSeats && filter.HasHeatedSeats == true)
                            || (c.HasLowMiles == filter.HasLowMiles && filter.HasLowMiles == true)
                            || (c.HasNavigation == filter.HasNavigation && filter.HasNavigation == true)
                            || (c.HasPowerWindows == filter.HasPowerWindows && filter.HasPowerWindows == true)
                            || (c.HasSunroof == filter.HasSunroof && filter.HasSunroof == true)
                            || (c.IsFourWheelDrive == filter.IsFourWheelDrive && filter.IsFourWheelDrive == true));
                }
                else
                {
                    carData = carData
                        .Where(c => (c.HasHeatedSeats == filter.HasHeatedSeats && filter.HasHeatedSeats == true)
                            || (c.HasLowMiles == filter.HasLowMiles && filter.HasLowMiles == true)
                            || (c.HasNavigation == filter.HasNavigation && filter.HasNavigation == true)
                            || (c.HasPowerWindows == filter.HasPowerWindows && filter.HasPowerWindows == true)
                            || (c.HasSunroof == filter.HasSunroof && filter.HasSunroof == true)
                            || (c.IsFourWheelDrive == filter.IsFourWheelDrive && filter.IsFourWheelDrive == true));
                }
            }

            return carData.ToList();
        }
    }
}