using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;

namespace CreatingClassCar
{
    ///<summary>
    /// This program creates class Car and class CarBuilder to read data from console.
    /// User enters information about three cars, then enters percents to change the price and some color. 
    /// If some car has color 'White', this color will be changed to the entered color.
    ///</summary>


    class Program
    {
        #region ActionsWithCars
        public static List<Car> CreateCars(int countOfCars)
        {
            var сars = new List<Car>();

            for (int i = 0; i < countOfCars; i++)
            {
                сars.Add(new Car(ReadBrand(), ReadColor(), ReadPrice()));
                var validationResults = сars[i].Validate();
                Validation(validationResults);
            }

            return сars;
        }

        public static void Validation(IList<ValidationFailure> validationResults)
        {
            if (validationResults.Any())
            {
                foreach (var validationResult in validationResults)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }

                throw new ArgumentException("Not valid data!");
            }
        }

        public static void ChangePriceOfAllCarsOnSomePersents(List<Car> cars, double persents)
        {
            foreach (var car in cars)
            {
                car.ChangePricePercentage(persents);
            }
        }
        public static void DisplayCars(List<Car> cars)
        {
            Console.WriteLine("\nInformation about cars:");
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
        public static void ChangeColorOfCarsWithSpecifiedColor(List<Car> cars, Color currectColor, Color changingColor)
        {
            foreach (var car in cars)
            {
                if (car.Color == currectColor) car.ChangeColor(changingColor);
            }
        }
        #endregion

        #region ReadData

        public static string ReadBrand()
        {
            Console.Write("\nBrand - ");
            var inputedBrand = Console.ReadLine();

            return inputedBrand;
        }

        public static Color ReadColor()
        {
            Console.Write("Color - ");
            var inputedColor = Console.ReadLine();
            Color color = Color.FromName(inputedColor);

            return color;
        }

        public static double ReadPrice()
        {
            Console.Write("Price - ");
            var inputedPrice = Console.ReadLine();
            var parser = new DataParser();
            var price = parser.Parse(inputedPrice);

            return price;
        }

        #endregion

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please, enter information about three cars:");
                int countOfCars = 3;
                var cars = CreateCars(countOfCars);
                DisplayCars(cars);

                var percents = 10;
                ChangePriceOfAllCarsOnSomePersents(cars, percents);
                Console.WriteLine($"\nPrice of all cars is changed on {percents} percents.\n");
                DisplayCars(cars);

                Console.WriteLine("\nPlease, enter some color:");
                Color color = ReadColor();
                ChangeColorOfCarsWithSpecifiedColor(cars, Color.White, color);
                DisplayCars(cars);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
