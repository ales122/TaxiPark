using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiPark.CarBody;
using TaxiPark.CarFuelType;
using TaxiPark.CarTransmission;

namespace TaxiPark.Models
{
    public class CargoTaxi : Car
    {
        [Range(100,100000,ErrorMessage = "Capacity value should be between 100 and 100000 kg")]
        public int CarryingCapacity { get; private set; }

        public double CostForOneHourOfUse { get; set; }

        public CargoTaxi(int id,Brand brand, string registrationNumber, int yearOfIssue, int mileage,
            double fuelConsumptionPerHundredKm, int carryingCapacity, int speed, FuelType fuelType, Body body, Transmission transmission,Engine engine)
            : base(id, brand, registrationNumber, yearOfIssue, mileage, fuelConsumptionPerHundredKm, speed,fuelType,body,transmission,engine)
        {
            this.CarryingCapacity = carryingCapacity;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Carrying Capacity:{CarryingCapacity} kg\nCost for 1 hour of use:{CostForOneHourOfUse} $");
        }
    }
}
