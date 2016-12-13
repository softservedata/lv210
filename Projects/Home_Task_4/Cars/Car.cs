using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    /// <summary>
    /// Class for Car objects. Conteins fields: model, color, price
    /// Methods: CreateNewCar() - creating new objects
    /// PrintInfoAboutCar() - display information
    /// ChangePriceForCar(..) - old price changes for new with discounted rate
    /// ChangeColorForWhiteCars() - change white cars to new custom color  
    /// </summary>
    public class Car
    {
        //fields
        private string carModel;
        private string carColor;
        private double carPrice;

        //Properties
        public string CarModel
        {
            set { carModel = value; }
            get { return carModel; }
        }

        public string CarColor
        {
            set { carColor = value; }
            get { return carColor; }
        }

        public double CarPrice
        {
            set
            {
                if (value > 0)
                {
                    carPrice = value;
                }

                else
                {
                    Console.WriteLine("Price should be greater than zero");
                }
            }

            get { return carPrice; }
        }

        public Car() { }

        public Car(string model, string color, double price)
        {
            carModel = model;
            CarColor = color;
            CarPrice = price;
        }

        /// <summary>
        /// Create new object for class Car
        /// </summary>
        /// <returns></returns>
        public static Car CreateNewCar()
        {
            Console.Write("Enter the car model: ");
            string carModel = Console.ReadLine();

            Console.Write("Enter the color of car: ");
            string carColor = Console.ReadLine();

            Console.Write("Enter the price of car: ");
            double carPrice;
            Double.TryParse(Console.ReadLine(), out carPrice);
            Console.WriteLine();

            return new Car(carModel, carColor, carPrice);
        }

        /// <summary>
        /// Displays information about model, color and price of car
        /// </summary>
        public string PrintInfoAboutCar()
        {
            string infoAboutCar = String.Format("Model: {0}. Color: {1}. Price {2:C}", carModel, carColor, carPrice);
            Console.WriteLine(infoAboutCar);
            return infoAboutCar;
        }

        /// <summary>
        /// Old price changes for new with discounted rate 
        /// </summary>
        /// <param name="percentOfPrice">Discount in percentage</param>
        /// <returns></returns>
        public double ChangePriceForCar(double percentOfPrice)
        {
            if ((percentOfPrice >= 0) && (percentOfPrice <= 100))
            {
                return CarPrice -= (CarPrice * percentOfPrice) / 100;
            }

            throw new Exception("Incorrect percentage");
        }

        /// <summary>
        /// Read new color from console and change white cars to new color
        /// </summary>
        /// <param name="newColor">New color for change</param>
        /// <returns></returns>
        public string ChangeColorForWhiteCars(string newColor)
        {
            if (CarColor == "white" || CarColor == "White")
            {
                CarColor = newColor;
            }
            return CarColor;
        }

    }
}
