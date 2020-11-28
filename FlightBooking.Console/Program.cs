using System;
using System.Collections.Generic;
using FlightBooking.Core.Data;
using FlightBooking.Core.Models;
using FlightBooking.Core.Report;
using FlightBooking.Core.RulesEngine;
using Microsoft.Extensions.DependencyInjection;

namespace FlightBooking.Console
{
    internal class Program
    {
        private static List<Passenger> _passengers = new List<Passenger>();
        private static readonly string empty = string.Empty;

        public static void Main(string[] args)
        {
            string command;
            do
            {
                System.Console.WriteLine("Please enter command.");
                command = System.Console.ReadLine() ?? empty;
                var enteredText = command.ToLower();
                if (enteredText.Contains("print summary"))
                {
                    var summarySegments = enteredText.Split(' ');
                    var rule = summarySegments.Length > 2 ? summarySegments[2] : empty;

                    var serviceProvider = AddDependencyInjection(rule);
                    var generateReport = serviceProvider.GetService<IGenerateReport>();

                    System.Console.WriteLine();
                    System.Console.WriteLine(generateReport.GetReport(_passengers));
                    _passengers.Clear();
                }
                else if (enteredText.Contains("add general"))
                {
                    AddPassenger(enteredText, PassengerType.General);
                }
                else if (enteredText.Contains("add loyalty"))
                {
                    AddPassenger(enteredText, PassengerType.LoyaltyMember, true);
                }
                else if (enteredText.Contains("add airline"))
                {
                    AddPassenger(enteredText, PassengerType.AirlineEmployee);
                }
                else if (enteredText.Contains("add discounted"))
                {
                    AddPassenger(enteredText, PassengerType.Discounted);
                }
                else if (enteredText.Contains("exit"))
                {
                    Environment.Exit(1);
                }
                else
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("UNKNOWN INPUT");
                    System.Console.ResetColor();
                }
            } while (command != "exit");
        }

        /// <summary>
        /// Add passenger method
        /// </summary>
        /// <param name="enteredText"></param>
        /// <param name="passengerType"></param>
        /// <param name="isLoyalCustomer"></param>
        private static void AddPassenger(string enteredText, PassengerType passengerType, bool isLoyalCustomer = false)
        {
            var passengerSegments = enteredText.Split(' ');
            _passengers.Add(new Passenger
            {
                Type = passengerType,
                Name = passengerSegments[2],
                Age = Convert.ToInt32(passengerSegments[3]),
                LoyaltyPoints = isLoyalCustomer ? Convert.ToInt32(passengerSegments[4]) : 0,
                IsUsingLoyaltyPoints = isLoyalCustomer ? Convert.ToBoolean(passengerSegments[5]) : false
            });
        }

        /// <summary>
        /// Register and configure all dependency classes
        /// </summary>
        /// <returns></returns>
        private static ServiceProvider AddDependencyInjection(string rule = null)
        {            
            var serviceCollection = new ServiceCollection()
                .AddSingleton<IGenerateReport, GenerateReport>()
                .AddSingleton<ISummaryHelper, SummaryHelper>()
                .AddSingleton<IRepository<FlightRoute>, FlightRouteRepository>()
                .AddSingleton<IRepository<Plane>, PlaneRepository>();

            switch (rule)
            {
                case "Relax":
                    serviceCollection.AddSingleton<IProceedFlight, RelaxRule>();
                    break;
                default:
                    serviceCollection.AddSingleton<IProceedFlight, DefaultRule>();
                    break;
            }

            return serviceCollection.BuildServiceProvider();
        }
    }
}
