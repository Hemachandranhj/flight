using System;
using System.Text;
using FlightBooking.Core.Models;
using FlightBooking.Core.Common;

namespace FlightBooking.Core.Report
{
    /// <summary>
    /// Class to generate the summary report
    /// </summary>
    public class SummaryReport
    {        
        private static StringBuilder result = new StringBuilder();

        public static string GetSummary(SummaryDetail summaryDetail)
        {
            AppendSummary(GlobalConstants.FlightSummary, summaryDetail.Title, true);
            AppendSummary(GlobalConstants.TotalPassengers, summaryDetail.TotalPassengers.ToString());
            AppendSummary(GlobalConstants.GeneralSales, summaryDetail.GeneralPassengers.ToString(), false, true);
            AppendSummary(GlobalConstants.LoyalMembers, summaryDetail.LoyalPassengers.ToString(), false, true);
            AppendSummary(GlobalConstants.AirlineEmployee, summaryDetail.AirlinePassengers.ToString(), false, true);
            AppendSummary(GlobalConstants.DiscountedEmployee, summaryDetail.DiscountedPassengers.ToString(), true, true);
            AppendSummary(GlobalConstants.TotalExpectedBaggage, summaryDetail.TotalExpectedBaggage.ToString(), true);
            AppendSummary(GlobalConstants.TotalRevenue, summaryDetail.TotalProfit.ToString());
            AppendSummary(GlobalConstants.TotalFlightCost, summaryDetail.TotalCostOfFlight.ToString());

            AppendSummary(summaryDetail.ProfitSurplus > 0 ? GlobalConstants.FlightGeneratingProfit : GlobalConstants.FlightLosingMoney, 
                Convert.ToString(summaryDetail.ProfitSurplus), true);

            AppendSummary(GlobalConstants.TotalLoyalPointsGiven, summaryDetail.TotalLoyaltyPointsAccrued.ToString());
            AppendSummary(GlobalConstants.TotalLoyalPointsRedeemed, summaryDetail.TotalLoyaltyPointsRedeemed.ToString(), true);

            AppendSummary(summaryDetail.FlightMayProceed ? GlobalConstants.FlightMayProceed : GlobalConstants.FlightMayNotProceed, string.Empty);

            if(summaryDetail.CanOtherFlightsHandle)
            {
                AppendSummary(GlobalConstants.OtherSuitableAircraft, "");
                summaryDetail.FlightNames.ForEach(
                    x =>
                    {
                        AppendSummary(x, GlobalConstants.CouldHandleFlight);
                    });
            }

            return result.ToString();
        }

        private static void AppendSummary(string heading, string value, bool addVerticalWhiteSpace = false, bool addIndentation = false)
        {
            if (addIndentation)
            {
                result.Append($"{GlobalConstants.Indentation}");
            }

            result.Append($"{heading} {value}");
            result.AppendLine();

            if (addVerticalWhiteSpace)
            {
                result.AppendLine();
            }
        }
    }
}
