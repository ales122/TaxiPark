using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaxiPark.CarBody;
using TaxiPark.CarFuelType;
using TaxiPark.CarTransmission;
using TaxiPark.Models;

namespace TaxiPark
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isValid = true;
            Models.TaxiPark taxiPark = new Models.TaxiPark(5,6);
            var engine = new Engine(3000);
            var mercedes = new Brand("Mercedes Benz");
            var renault = new Brand("Renault");
            List<Car> cars = new List<Car>();
            var renaultTruck = new CargoTaxi(1, renault, "3567 UT-4", 2000, 156780, 7.5, 3000, 63,FuelType.Petrol,
                Body.Van, Transmission.Manual, engine);
            var poloPassenger = new PassengerTaxi(2, mercedes, "8112 PO-3", 2019,
                55000, 6.4, 4, 72,FuelType.Electricity,Body.Hatchback,Transmission.Automatic,engine);
            cars.Add(renaultTruck);
            cars.Add(poloPassenger);
            foreach (var item in cars)
            {
                var results = new List<ValidationResult>();
                var context = new ValidationContext(item);
                if (!Validator.TryValidateObject(item, context, results, true))
                {
                    foreach (var error in results)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }

                    isValid = false;
                }
            }

            if (isValid)
            {
                taxiPark.AddCars(cars);
                Console.WriteLine(taxiPark.GetTotalAmountOfCarInTaxiPark);
                taxiPark.ShowCarsInfo();
            }
          
        }
    }
}
