namespace FlightBooking.Core.Report
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FlightBooking.Core.CalculateUtility;
    using FlightBooking.Core.Models;
    using FlightBooking.Core.RulesEngine;

    /// <summary>
    /// Helper class top calculate and generate the summary details
    /// </summary>
    public class SummaryHelper : ISummaryHelper
    {
        private readonly IProceedFlight _proceedFlight;

        public SummaryHelper(IProceedFlight proceedFlight)
        {
            this._proceedFlight = proceedFlight;
        }

        /// <summary>
        /// Get the summary detail
        /// </summary>
        /// <param name="passengers"></param>
        /// <param name="flightRoute"></param>
        /// <param name="airCraft"></param>
        /// <param name="airCrafts"></param>
        /// <returns></returns>
        public SummaryDetail GetSummary(List<Passenger> passengers, FlightRoute flightRoute, Plane airCraft, List<Plane> airCrafts)
        {
            var totalPassengers = passengers.Count();
            var generalPassengersCount = CalculationUtility.GetPassengerCount(passengers, PassengerType.General);
            var loyalPassengersCount = CalculationUtility.GetPassengerCount(passengers, PassengerType.LoyaltyMember);
            var loyalPassengersWithNoRedeemPoints = passengers.Count(x => x.Type == PassengerType.LoyaltyMember && !x.IsUsingLoyaltyPoints);
            var loyalPassengersWithRedeemPoints = loyalPassengersCount - loyalPassengersWithNoRedeemPoints;
            var airlinePassengersCount = CalculationUtility.GetPassengerCount(passengers, PassengerType.AirlineEmployee);
            var discountedPassengerCount = CalculationUtility.GetPassengerCount(passengers, PassengerType.Discounted);
            var totalBaggageCount = CalculationUtility.CalulateTotalBaggageCount(generalPassengersCount, loyalPassengersCount, airlinePassengersCount);
            var totalCostOfFlight = CalculationUtility.CalulateTotalFlightCost(totalPassengers, flightRoute.BaseCost);
            var totalProfit = CalculationUtility.CalulateTotalProfit(generalPassengersCount, loyalPassengersWithNoRedeemPoints, discountedPassengerCount, flightRoute.BasePrice);
            var profitSurplus = CalculationUtility.CalulateProfitSurplus(totalProfit, totalCostOfFlight);
            var totalLoyaltyPointsAccrued = CalculationUtility.CalulateTotalLoyaltyPointsAccrued(loyalPassengersWithNoRedeemPoints, flightRoute.LoyaltyPointsGained);
            var totalLoyaltyPointsRedeemed = CalculationUtility.CalulateTotalLoyaltyPointsRedeemed(loyalPassengersWithRedeemPoints, Convert.ToInt32(Math.Ceiling(flightRoute.BasePrice)));
            var flightNames = GetFlightNames(airCraft, airCrafts);
            bool canOtherFlightsHandle = CanOtherFlightsHandle(airCraft, totalPassengers, flightNames);

            var summaryDetail = new SummaryDetail
            {
                Title = flightRoute.Title,
                TotalPassengers = totalPassengers,
                GeneralPassengers = generalPassengersCount,
                LoyalPassengers = loyalPassengersCount,
                AirlinePassengers = airlinePassengersCount,
                DiscountedPassengers = discountedPassengerCount,
                TotalExpectedBaggage = totalBaggageCount,
                TotalCostOfFlight = totalCostOfFlight,
                TotalProfit = totalProfit,
                ProfitSurplus = profitSurplus,
                TotalLoyaltyPointsAccrued = totalLoyaltyPointsAccrued,
                TotalLoyaltyPointsRedeemed = totalLoyaltyPointsRedeemed,
                CanOtherFlightsHandle = canOtherFlightsHandle,
                FlightNames = flightNames
            };

            summaryDetail.FlightMayProceed = this._proceedFlight.CanProceedFlight(summaryDetail, airCraft.NumberOfSeats, flightRoute.MinimumTakeOffPercentage);

            return summaryDetail;
        }

        /// <summary>
        /// Method to find can other flights handle the passengers
        /// </summary>
        /// <param name="airCraft"></param>
        /// <param name="totalPassengers"></param>
        /// <param name="flightNames"></param>
        /// <returns></returns>
        private static bool CanOtherFlightsHandle(Plane airCraft, int totalPassengers, List<string> flightNames)
        {
            return flightNames.Any() && totalPassengers > airCraft.NumberOfSeats;
        }

        /// <summary>
        /// Gets the flight names
        /// </summary>
        /// <param name="airCraft"></param>
        /// <param name="airCrafts"></param>
        /// <returns></returns>
        private static List<string> GetFlightNames(Plane airCraft, List<Plane> airCrafts)
        {
            return airCrafts.Where(x => x.NumberOfSeats > airCraft.NumberOfSeats).Select(x => x.Name).ToList();
        }
    }
}
