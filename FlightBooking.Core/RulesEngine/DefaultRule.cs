namespace FlightBooking.Core.RulesEngine
{
    using FlightBooking.Core.Models;

    public class DefaultRule : RuleBase, IProceedFlight
    {
        public bool CanProceedFlight(SummaryDetail summaryDetail, int numberOfSeats, double minimumTakeOffPercentage)
        {
            return this.HasProfit(summaryDetail.ProfitSurplus)
                && this.HasCapacity(summaryDetail.TotalPassengers, numberOfSeats)
                && this.HasMinimumTakeOffPercentage(summaryDetail.TotalPassengers,
                    numberOfSeats, minimumTakeOffPercentage);
        }        
    }
}
