using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CarDealershipWebAPI.Models;

namespace CarDealershipWebAPI.Controllers
{
    public class CarController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Car
        public IQueryable<Car> GetFilteredCarData([FromUri] CarFilter filter)
        {
            // A CarFilter parameter should always be provided.
            if (filter == null)
            {
                throw new Exception("No Car Filter was provided");
            }

            IQueryable<Car> queryResult = db.Cars;

            // Change query results based on whether user is searching for an exact match
            if(filter.ShowExactMatches)
            {
                if(!string.IsNullOrEmpty(filter.Color))
                {
                    queryResult = queryResult
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
                    queryResult = queryResult
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
                if(!string.IsNullOrEmpty(filter.Color))
                {
                    queryResult = queryResult
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
                    queryResult = queryResult
                        .Where(c => (c.HasHeatedSeats == filter.HasHeatedSeats && filter.HasHeatedSeats == true)
                            || (c.HasLowMiles == filter.HasLowMiles && filter.HasLowMiles == true)
                            || (c.HasNavigation == filter.HasNavigation && filter.HasNavigation == true)
                            || (c.HasPowerWindows == filter.HasPowerWindows && filter.HasPowerWindows == true)
                            || (c.HasSunroof == filter.HasSunroof && filter.HasSunroof == true)
                            || (c.IsFourWheelDrive == filter.IsFourWheelDrive && filter.IsFourWheelDrive == true));
                }
            }

            return queryResult;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}