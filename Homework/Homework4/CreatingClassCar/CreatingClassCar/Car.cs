using System.Drawing;

namespace CreatingClassCar
{
    public class Car
    {
        public string Brand { get; private set; }
        public Color Color{ get; private set; }
        public double Price { get; private set; }

        public Car(){ }

        public Car(string brand, Color color, double price)
        {
            this.Brand = brand;
            this.Color = color;
            this.Price = price;
        }

        public Car(double price)
        {
            this.Price = price;
        }

        public void ChangePricePercentage(double percent)
        {
            this.Price += ((Price * percent) / 100);
        }

        public void ChangePrice(double price)
        {
            this.Price = price;
        }

        public void ChangeColor(Color color)
        {
            this.Color = color;
        }

        public override string ToString()
        {
            //string interpolation
            return $"\nBrand is {this.Brand}, color is {this.Color.Name}, price is {this.Price}.";
        }
    }
}
