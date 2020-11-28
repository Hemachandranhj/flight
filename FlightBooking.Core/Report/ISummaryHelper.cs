namespace FlightBooking.Core.Report
{
    using System.Collections.Generic;
    using FlightBooking.Core.Models;

    public interface ISummaryHelper
    {
        SummaryDetail GetSummary(List<Passenger> passengers, FlightRoute flightRoute, Plane airCraft, List<Plane> aircrafts);
    }
}
