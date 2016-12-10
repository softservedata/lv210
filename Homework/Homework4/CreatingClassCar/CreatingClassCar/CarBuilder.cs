using System;
using System.Drawing;

namespace CreatingClassCar
{
    public class CarBuilder
    {
        public static Car BuildCar()
        {
            return new Car(ReadBrand(), ReadColor(), ReadPrice());
        }

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

            if (!color.IsKnownColor)
            {
               throw new ArgumentException("\nInvalid color!");
            }

            return color;           
        }

        public static double ReadPrice()
        {
            Console.Write("Price - ");
            var inputedPrice = Console.ReadLine();

            double price;

            if (!double.TryParse(inputedPrice, out price))
            {
                throw new FormatException("\nCan not convert to <double>!");
            }

            if (price<=0)
            {
                throw new ArgumentException("\nPrice can not be less or equal zero!");
            }
            
            return price;
        }
    }
}
