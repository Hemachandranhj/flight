namespace FlightBooking.Core.Models
{
    /// <summary>
    /// Class for flight route
    /// </summary>
    public class FlightRoute
    {
        /// <summary>
        /// Flight route constructor
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        public FlightRoute(string origin, string destination)
        {
            this.Title = $"{origin} to {destination}";
        }

        public string Title { get; }
        public double BasePrice { get; set; }
        public double BaseCost { get; set; }
        public int LoyaltyPointsGained { get; set; }
        public double MinimumTakeOffPercentage { get; set; }        
    }
}
