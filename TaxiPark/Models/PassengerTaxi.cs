using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPark.Models
{
    public class PassengerTaxi : Car
    {
        [Range(1,500,ErrorMessage = "Number of passengers should be between 1 and 500! ")]
        public int NumberOfPassenger { get; private set; }
        public double CostForFiveKmTrip { get; set; }

        public PassengerTaxi():base()
        {
            this.NumberOfPassenger = 4;
            this.CostForFiveKmTrip = 3;
        }

        public PassengerTaxi(int id,string brand, string registrationNumber, int yearOfIssue, int mileage,
            double fuelConsumptionPerHundredKm, int numberOfPassenger, double costForFiveKmTrip, int speed)
            : base(id, brand, registrationNumber, yearOfIssue, mileage, fuelConsumptionPerHundredKm, speed)
        {
            this.CostForFiveKmTrip = costForFiveKmTrip;
            this.NumberOfPassenger = numberOfPassenger;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Capacity of passengers:{NumberOfPassenger}\nCost for 5 km of trip:{CostForFiveKmTrip} $");
        }
    }
}
