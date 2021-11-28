using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPark.Models
{
    public class TaxiPark
    {

        public string Name { get; set; }
        private readonly List<Car> Cars;
        public double CostForPassengerCars { get; set; }
        public double CostForCargoCars { get; set; }
        public TaxiPark(string name, List<Car> cars,double costForCargoCars,double costForPassengerCars)
        {
            this.Name = name;
            this.Cars = cars;
            this.CostForCargoCars = costForCargoCars;
            this.CostForPassengerCars = costForPassengerCars;
        }

        public TaxiPark(double costForCargoCars, double costForPassengerCars)
        {
            this.Name = "Default";
            this.Cars = new List<Car>();
            this.CostForCargoCars = costForCargoCars;
            this.CostForPassengerCars = costForPassengerCars;
        }

        public int GetTotalAmountOfCarInTaxiPark => this.Cars.Count;
        public IEnumerable<Car> SortCarsByFuelConsumption()
        {
            return this.Cars.OrderBy(c => c.FuelConsumptionPerHundredKm);
        }

        public Car GetCarBySpeed(int minSpeed, int maxSpeed)
        {
            return this.Cars.FirstOrDefault(c => c.Speed > minSpeed && c.Speed < maxSpeed);
        }

        public void AddCar(Car car)
        {
            if (car is CargoTaxi)
            {
                var cargoTaxi = (CargoTaxi) car;
                cargoTaxi.CostForOneHourOfUse = this.CostForCargoCars;
            }

            if (car is PassengerTaxi)
            {
                var passengerTaxi = (PassengerTaxi) car;
                passengerTaxi.CostForFiveKmTrip = this.CostForPassengerCars;
            }
            this.Cars.Add(car);
        }

        public void AddCars(List<Car> cars)
        {
            foreach (var item in cars)
            {
                AddCar(item);
            }
        }

        public Car FindCarById(int id)
        {
            return this.Cars.FirstOrDefault(c => c.Id == id);
        }
        public void DeleteCar(int id)
        {
            var car = FindCarById(id);
            this.Cars.Remove(car);
        }

        public List<Car> GetAllTaxiParkCars()
        {
            return this.Cars;
        }

        public void ShowCarsInfo()
        {
            foreach (var item in this.Cars)
            {
              item.PrintInfo();
              Console.WriteLine();
            }
        }
    }
}
