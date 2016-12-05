using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CreatingClassCar
{
    ///<summary>
    /// This program creates class Car and some kind of wrapper to read data from console.
    /// User enters information about three cars, then enters percents to change the price and some color. 
    /// If some car has color 'White', this color will be changed to the entered color.
    ///</summary>
    ///

    class Program
    {
        public static List<ConsoleCar> ReadCars()
        {
            var сars = new List<ConsoleCar>();
            var count = 3;

            Console.WriteLine("Please, enter information about three cars:");

            for (int i = 0; i < count; i++)
            {

                Console.WriteLine("\nCar №{0}:", (i + 1).ToString());
                var car = new ConsoleCar();
                сars.Add(car);
            }

            return сars;
        }


        public static void ChangePrice(List<ConsoleCar> cars)
        {
            Console.WriteLine("\nInformation about cars:");
            foreach (var car in cars)
            {
                car.ChangePrice(10);
                Console.WriteLine(car);
            }
        }

        public static void ChangeColor(List<ConsoleCar> cars)
        {
            Console.WriteLine("\nPlease, enter new color:");
            Color color = ConsoleCar.ReadColor();

            foreach (var car in cars)
            {
                if (car.Color == Color.White) car.Color = color;
                Console.WriteLine(car);
            }
        }

        static void Main(string[] args)
        {
            try
            {
                var cars = ReadCars();
                ChangePrice(cars);
                ChangeColor(cars);    
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
