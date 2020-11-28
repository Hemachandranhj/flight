namespace FlightBooking.Core.Data
{
    using System.Collections.Generic;
    using FlightBooking.Core.Models;

    public class FlightRouteRepository : IRepository<FlightRoute>
    {
        public FlightRoute Get()
        {
            return new FlightRoute("London", "Paris")
            {
                BaseCost = 50,
                BasePrice = 100,
                LoyaltyPointsGained = 5,
                MinimumTakeOffPercentage = 0.7
            };
        }

        public IList<FlightRoute> GetAll()
        {
            return new List<FlightRoute>
            {
                new FlightRoute("London", "Paris")
                {
                    BaseCost = 50,
                    BasePrice = 100,
                    LoyaltyPointsGained = 5,
                    MinimumTakeOffPercentage = 0.7
                }
            };
        }
    }
}
