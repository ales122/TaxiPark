using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPark.Models
{
    public abstract class Car
    {
      
        public int Id { get; set; }

        [StringLength(20, MinimumLength = 1)]
        public string Brand { get; private set; }
        public string RegistrationNumber { get; set; }

        [Range(1920,2021,ErrorMessage = "Invalid year of issue!(must be between 1920 to 2021)")]
        public int YearOfIssue { get; private set; }
        public int Mileage { get; set; }
        public double FuelConsumptionPerHundredKm { get; private set; }

        [Range(10,200,ErrorMessage = "Not valid speed!")]
        public int Speed { get; private set; }

        protected Car(int id, string brand, string registrationNumber, int yearOfIssue, int mileage,
            double fuelConsumptionPerHundredKm, int speed)
        {
            this.Id = id;
            this.Brand = brand;
            this.RegistrationNumber = registrationNumber;
            this.YearOfIssue = yearOfIssue;
            this.Mileage = mileage;
            this.FuelConsumptionPerHundredKm = fuelConsumptionPerHundredKm;
            this.Speed = speed;
        }

        protected Car()
        {  
            this.Id = new Random().Next();
            this.Brand = "Citroen";
            this.RegistrationNumber = $"{GenerateRegistrationNumber()}";
            this.YearOfIssue = 2010;
            this.Mileage = 155000;
            this.Speed = 70;
            this.FuelConsumptionPerHundredKm = 7.1;
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
