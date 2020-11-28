namespace FlightBooking.Core.Report
{
    using System.Collections.Generic;
    using System.Linq;

    using FlightBooking.Core.Data;
    using FlightBooking.Core.Models;

    /// <summary>
    /// Class to generate report
    /// </summary>
    public class GenerateReport : IGenerateReport
    {
        private readonly ISummaryHelper summaryHelper;
        private readonly IRepository<FlightRoute> flightRouteRepository;
        private readonly IRepository<Plane> planeRepository;

        public GenerateReport(ISummaryHelper summaryHelper, IRepository<FlightRoute> flightRouteRepository, IRepository<Plane> planeRepository)
        {
            this.summaryHelper = summaryHelper;
            this.planeRepository = planeRepository;
            this.flightRouteRepository = flightRouteRepository;
        }

        public string GetReport(List<Passenger> passengers)
        {
            var flightRoute = this.flightRouteRepository.Get();
            var aircraft = this.planeRepository.Get();
            var aircrafts = this.planeRepository.GetAll().ToList();

            var summaryDetails = this.summaryHelper.GetSummary(passengers, flightRoute, aircraft, aircrafts);

            return SummaryReport.GetSummary(summaryDetails);
        }
    }
}
