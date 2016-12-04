using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CreatingClassCar
{
    public class Car
    {
        public string Brand { get; private set; }
        public Color Color{ get; set; }
        public double Price { get; private set; }

        public Car(){ }

        public Car(string Brand, Color Color, double Price)
        {
            this.Brand = Brand;
            this.Color = Color;
            this.Price = Price;
        }

        public void ChangePrice (double percent)
        {
            this.Price = (Price*percent)/100;
        }

        public override string ToString()
        {
            return string.Format("\nBrand is {0}, color is {1}, price is {2}.", this.Brand, this.Color.Name, this.Price);
        }

    }
}
