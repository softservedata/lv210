using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Car
    {
        //fields
        private string carModel;
        private string carColor;
        private double carPrice;

        //Properties
        public string CarColor
        {
            set
            {
                carColor = value;
            }

            get
            {
                return carColor;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        Car() { }

        /// <summary>
        /// Constructor for class Car
        /// </summary>
        /// <param name="model">Car model</param>
        /// <param name="color">Car color</param>
        /// <param name="price">Car price</param>
        public Car(string model, string color, double price)
        {
            carModel = model;
            carColor = color;
            carPrice = price;
        }

        /// <summary>
        /// Method to Input data about cars
        /// </summary>
        /// <returns></returns>
        public static Car Input()
        {
            Console.Write("Enter the car model: ");
            string carModel = Console.ReadLine();

            Console.Write("Enter the color of car: ");
            string carColor = Console.ReadLine();

            Console.Write("Enter the price of car: ");
            double carPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();

            return new Car(carModel, carColor, carPrice);
        }

        /// <summary>
        /// Method to print info about cars
        /// </summary>
        public void Print()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("Model: {0}. Color: {1}. Price {2:C}", carModel, carColor, carPrice);
        }

        /// <summary>
        /// Change price of car 
        /// </summary>
        /// <param name="percentOfPrice">percentage of the price</param>
        /// <returns></returns>
        public double ChangePrice(double percentOfPrice)
        {
            return carPrice -= (carPrice * percentOfPrice) / 100;
        }

        /// <summary>
        /// Method change white cars to custom color 
        /// </summary>
        /// <param name="car">Car to change color</param>
        /// <returns></returns>
        public string ChangeColorForWhiteCars(string newColor)
        {
            if (CarColor == "white" || CarColor == "White")
            {
                carColor = newColor;
            }
            return CarColor;
        }

    }
}
