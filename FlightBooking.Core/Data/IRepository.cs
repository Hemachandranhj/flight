namespace FlightBooking.Core.Data
{
    using System.Collections.Generic;

    /// <summary>
    /// interface to hold repository methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T: class 
    {
        // TODO: this method can return Task<T> if connecting to DB
        T Get();

        IList<T> GetAll();
    }
}
