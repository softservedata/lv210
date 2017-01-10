using System;

namespace Pres4_Car
{
    public class Car
    {
        private string mark;
        private string color;
        private double price;
        
        public Car()
        {
        }
        
        public Car(string m, string c, int p)
        {
            mark=m;
            color=c;
            price=p;
        }
        
        public string Color
        {
            set
            {
                color = value;
            }
            get
            {
                return color;
            }
        }

        public void Input()
        {
            Console.Write("Enter mark of car: ");
            this.mark=Console.ReadLine();
            Console.Write("Enter color of car: ");
            this.color=Console.ReadLine();
            Console.Write("Enter price of car: ");
            this.price=Convert.ToInt32(Console.ReadLine());
        }

        public void Print()
        {
            Console.WriteLine();
            Console.WriteLine("Car has mark {0} and {1} color and costs {2} $", this.mark, this.color, this.price);
            Console.ReadKey();
        }

        public void ChangePrice(double persent)
        {
            this.price=this.price+this.price*persent/100;
        }
    }
}
