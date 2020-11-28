using System.Collections.Generic;

namespace FlightBooking.Core.Models
{
    public class SummaryDetail
    {
        public string Title { get; set; }
        public int TotalPassengers { get; set; }
        public int GeneralPassengers { get; set; }
        public int LoyalPassengers { get; set; }
        public int AirlinePassengers { get; set; }
        public int DiscountedPassengers { get; set; }
        public double TotalProfit { get; set; }
        public double TotalCostOfFlight { get; set; }
        public int TotalExpectedBaggage { get; set; }
        public double ProfitSurplus { get; set; }
        public int TotalLoyaltyPointsAccrued { get; set; }
        public int TotalLoyaltyPointsRedeemed { get; set; }
        public bool FlightMayProceed { get; set; }

        public bool CanOtherFlightsHandle { get; set; }

        public List<string> FlightNames { get; set; }
    }
}
