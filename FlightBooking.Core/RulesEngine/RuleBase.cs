namespace FlightBooking.Core.RulesEngine
{
    public abstract class RuleBase
    {
        protected bool HasProfit(double profitSurplus) => profitSurplus > 0;

        protected bool HasCapacity(int seatsTaken, int totalSeats) => seatsTaken < totalSeats;

        protected bool HasMinimumTakeOffPercentage(int seats, int totalSeats, double minimumTakeOffPercentage) => seats / (double)totalSeats > minimumTakeOffPercentage;
    }
}
