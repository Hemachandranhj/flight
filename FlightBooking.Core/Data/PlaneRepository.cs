namespace FlightBooking.Core.Data
{
    using System.Collections.Generic;
    using FlightBooking.Core.Models;

    /// <summary>
    /// Repository to get plane details
    /// </summary>
    public class PlaneRepository : IRepository<Plane>
    {
        /// <summary>
        /// Method to get plane details by id
        /// </summary>
        /// <returns></returns>
        public Plane Get()
        {
            return new Plane {Id = 123, Name = "Antonov AN-2", NumberOfSeats = 12};
        }

        /// <summary>
        /// method to get all planes
        /// </summary>
        /// <returns></returns>
        public IList<Plane> GetAll()
        {
            return new List<Plane>
            {
                new Plane {Id = 123, Name = "Antonov AN-2", NumberOfSeats = 12},
                new Plane {Id = 124, Name = "Antonov AN-1", NumberOfSeats = 10},
                new Plane {Id = 125, Name = "Antonov AN-3", NumberOfSeats = 11},
                new Plane {Id = 345, Name = "Bombardier Q400", NumberOfSeats = 15},
                new Plane {Id = 678, Name = "ATR 640", NumberOfSeats = 16}
            };
        }
    }
}
