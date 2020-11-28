namespace FlightBooking.Core.CalculateUtility
{
    using System.Collections.Generic;
    using System.Linq;

    using FlightBooking.Core.Models;
    
    public static class CalculationUtility
    {
        /// <summary>
        /// Get passenger count by type
        /// </summary>
        /// <param name="passengers"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int GetPassengerCount(List<Passenger> passengers, PassengerType type)
        {
            return passengers.Count(p => p.Type == type);
        }

        /// <summary>
        /// Calculates total baggage count
        /// </summary>
        /// <param name="generalPassengersCount"></param>
        /// <param name="loyalPassengersCount"></param>
        /// <param name="airlinePassengersCount"></param>
        /// <returns>Total Baggage count</returns>
        public static int CalulateTotalBaggageCount(int generalPassengersCount, int loyalPassengersCount, int airlinePassengersCount)
        {
            return (generalPassengersCount + loyalPassengersCount * 2 + airlinePassengersCount);
        }

        /// <summary>
        /// Calculates total flight cost
        /// </summary>
        /// <param name="totalPassengerCount"></param>
        /// <param name="baseCost"></param>
        /// <returns>Total flight cost</returns>
        public static double CalulateTotalFlightCost(int totalPassengerCount, double baseCost)
        {
            return (totalPassengerCount * baseCost);
        }

        /// <summary>
        /// Calulates total profit
        /// </summary>
        /// <param name="generalPassengersCount"></param>
        /// <param name="loyalPassengersWithNoRedeemPointsCount"></param>
        /// <param name="discountedPassengersCount"></param>
        /// <param name="basePrice"></param>
        /// <returns>Total profit</returns>
        public static double CalulateTotalProfit(
            int generalPassengersCount,
            int loyalPassengersWithNoRedeemPointsCount,
            int discountedPassengersCount,
            double basePrice)
        {
            return (generalPassengersCount + loyalPassengersWithNoRedeemPointsCount + discountedPassengersCount / 2) * basePrice;
        }

        /// <summary>
        /// Calculates profit surplus
        /// </summary>
        /// <param name="totalProfit"></param>
        /// <param name="totalFlightCost"></param>
        /// <returns>Profit surplus</returns>
        public static double CalulateProfitSurplus(
            double totalProfit,
            double totalFlightCost)
        {
            return totalProfit - totalFlightCost;
        }

        /// <summary>
        /// Calculats total loyalty points accured
        /// </summary>
        /// <param name="loyalPassengersWithRedeemPoints"></param>
        /// <param name="LoyaltyPointsGained"></param>
        /// <returns>Total loyalty points accured/returns>
        public static int CalulateTotalLoyaltyPointsRedeemed(
            int loyalPassengersWithRedeemPoints,
            int LoyaltyPointsGained)
        {
            return loyalPassengersWithRedeemPoints * LoyaltyPointsGained;
        }

        /// <summary>
        /// Calculats total loyalty points accured
        /// </summary>
        /// <param name="loyalPassengersWithNoRedeemPoints"></param>
        /// <param name="LoyaltyPointsGained"></param>
        /// <returns>Total loyalty points accured/returns>
        public static int CalulateTotalLoyaltyPointsAccrued(
            int loyalPassengersWithNoRedeemPoints,
            int LoyaltyPointsGained)
        {
            return loyalPassengersWithNoRedeemPoints * LoyaltyPointsGained;
        }

    }
}
