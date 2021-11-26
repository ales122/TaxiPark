using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaxiPark.Models;

namespace TaxiPark
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isValid = true;
            Models.TaxiPark taxiPark = new Models.TaxiPark();
            List<Car> cars = new List<Car>();
            var defaultCar = new PassengerTaxi();
            var renaultTruck = new CargoTaxi(1, "Renault", "3567 UT-4", 2000, 156780, 7.5, 3000, 10.7, 63);
            var poloPassenger = new PassengerTaxi(2, "Volkswagen Polo", "8112 PO-3", 2019, 55000, 6.4, 4, 7.2, 72);
            cars.Add(renaultTruck);
            cars.Add(defaultCar);
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
