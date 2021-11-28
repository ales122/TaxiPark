using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TaxiPark.CarBody;
using TaxiPark.CarFuelType;
using TaxiPark.CarTransmission;

namespace TaxiPark.Models
{
    public abstract class Car
    {
      
        public int Id { get; private set; }
        public Brand Brand { get; private set; }
        public string RegistrationNumber { get; set; }
        public FuelType FuelType { get; set; }
        [Range(1920,2021,ErrorMessage = "Invalid year of issue!(must be between 1920 to 2021)")]
        public int YearOfIssue { get; private set; }
        public int Mileage { get; set; }
        public double FuelConsumptionPerHundredKm { get; private set; }
        public Body Body { get; private  set; }

        [Range(10,200,ErrorMessage = "Not valid speed!")]
        public int Speed { get; private set; }
        public Transmission Transmission { get; private set; }

        public Engine Engine { get; private set; }

        public  Car(int id, Brand brand, string registrationNumber, int yearOfIssue, int mileage,
            double fuelConsumptionPerHundredKm, int speed,FuelType fuelType, Body body, Transmission transmission,Engine engine)
        {
            this.Id = id;
            this.Brand = brand;
            this.RegistrationNumber = registrationNumber;
            this.YearOfIssue = yearOfIssue;
            this.Mileage = mileage;
            this.FuelConsumptionPerHundredKm = fuelConsumptionPerHundredKm;
            this.Speed = speed;
            this.FuelType = fuelType;
            this.Body = body;
            this.Transmission = transmission;
            this.Engine = engine;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Brand:{Brand}\nRegistration number:{RegistrationNumber}\nYear of issue:{YearOfIssue}\nSpeed:{Speed}");
        }

        private string GenerateRegistrationNumber()
        {
            var random = new Random();
            var registrationNumber = $"{random.Next(1000, 9999)} ";
            for (int i = 0; i < 2; i++)
            {
                registrationNumber+=Convert.ToChar(random.Next(65, 91));
            }

            registrationNumber += $"-{random.Next(1, 7)}";

            return registrationNumber;
        }
        
    }
}
