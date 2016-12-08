using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationaAboutCar
{
    class Car
    {
        private string brand;
        private string color;
        private double price;

        public Car() { }

        public Car(string brand, string color, double price)
        {
            this.brand = brand;
            this.color = color;
            this.price = price;
        }

        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
         }

        public static Car Input()
        {
            Console.WriteLine("Information about car: ");
            Console.Write("Brand : ");
            var brand = Console.ReadLine();

            Console.Write("Color(for first charachter use uppercase) : ");
            var color = Console.ReadLine();

            Console.Write("Price : ");
            var price = double.Parse(Console.ReadLine());

            Console.WriteLine();

            return new Car(brand, color, price);
        }

        public void Print()
        {
            Console.WriteLine("Car's brand : {0}, car's color : {1}, car's price : {2}", brand, color, price);
        }

        public void ChangePrice(double percents)
        {
            price += (price * percents) / 100;

            Print();
        }

        public void ChangeColor()
        {
            if (Color == ConsoleColor.White.ToString())
            {
                Console.Write("\nInput new color : ");
                var newColor = Console.ReadLine();

                Color = newColor;

                Print();
            }
        }
    }
}
