
using FlightBooking.Core.Models;
using System.Collections.Generic;

namespace FlightBooking.Core.Report
{
    public interface IGenerateReport
    {
        string GetReport(List<Passenger> passengers);
    }
}
