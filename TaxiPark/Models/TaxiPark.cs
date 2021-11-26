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

        public TaxiPark(string name, List<Car> cars)
        {
            this.Name = name;
            this.Cars = cars;
        }

        public TaxiPark()
        {
            this.Name = "Default";
            this.Cars = new List<Car>();
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
            this.Cars.Add(car);
        }

        public void AddCars(List<Car> cars)
        {
            this.Cars.AddRange(cars);
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
