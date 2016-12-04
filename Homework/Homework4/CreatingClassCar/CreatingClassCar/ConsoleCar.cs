using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CreatingClassCar
{
    public class ConsoleCar: Car
    {
        public ConsoleCar():base(ReadBrand(),ReadColor(),ReadPrice())
        {

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
                throw new ArgumentException("\nInvalid price!");
            }
            
            return price;

        }
    }
}
