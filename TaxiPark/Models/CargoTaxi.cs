using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPark.Models
{
    public class CargoTaxi : Car
    {
        [Range(100,100000,ErrorMessage = "Capacity value should be between 100 and 100000 kg")]
        public int CarryingCapacity { get; private set; }

        public double CostForOneHourOfUse { get; set; }
        public CargoTaxi():base()
        {
            this.CarryingCapacity = 1000;
            this.CostForOneHourOfUse = 5.5;
        }
        public CargoTaxi(int id,string brand, string registrationNumber, int yearOfIssue, int mileage,
            double fuelConsumptionPerHundredKm, int carryingCapacity, double costForOneHourOfUse, int speed)
            : base(id, brand, registrationNumber, yearOfIssue, mileage, fuelConsumptionPerHundredKm, speed)
        {
            this.CarryingCapacity = carryingCapacity;
            this.CostForOneHourOfUse = costForOneHourOfUse;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Carrying Capacity:{CarryingCapacity} kg\nCost for 1 hour of use:{CostForOneHourOfUse} $");
        }
    }
}
