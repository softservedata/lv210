using System;

namespace RadiusOperation
{
    class Program
    {
        public static double ParseAtempt()
        {
            double ReadVariable;
            bool ParseAtempt = double.TryParse(Console.ReadLine(), out ReadVariable);
            if (ParseAtempt && ReadVariable > 0)
            {
                return ReadVariable;
            }
            else
            {
                throw new FormatException("Please, input positive <double> number");
            }
        }
        public static void CircleAction(double radius)
        {
            Circle MyCircle = new Circle(radius);
            double length = MyCircle.CircleLength();
            double area = MyCircle.CircleArea();
            Console.WriteLine("Length: {0};\nArea: {1};", length, area);
        }
        public static void SphereAction(double radius)
        {
            Sphere MySphere = new Sphere(radius);
            double volume = MySphere.SphereVolume();
            Console.WriteLine("Volume: {0};", volume);
        }
        static void Main(string[] args)
        {
            Console.Write("Input radius: ");
            try
            {
                double radius = ParseAtempt();
                CircleAction(radius);
                SphereAction(radius);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
