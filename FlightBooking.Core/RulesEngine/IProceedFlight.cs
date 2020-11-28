using FlightBooking.Core.Models;

namespace FlightBooking.Core.RulesEngine
{
    public interface IProceedFlight
    {
        bool CanProceedFlight(SummaryDetail summaryDetail, int numberOfSeats, double minimumTakeOffPercentage);
    }
}
