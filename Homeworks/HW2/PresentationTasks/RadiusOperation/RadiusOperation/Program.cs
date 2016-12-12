using System;

namespace RadiusOperation
{
    class Program
    {
        public static double ParseAtempt()
        {
            double ReadVariable;
            bool ParseAtempt = double.TryParse(Console.ReadLine(), out ReadVariable);
            if (ParseAtempt)
            {
                return ReadVariable;
            }
            else
            {
                throw new FormatException("Wrong data type.");
            }
        }
        public static void CircleAction()
        {

        }
        static void Main(string[] args)
        {
            Console.Write("Input radius: ");
            try
            {
                double radius = ParseAtempt();
                Circle MyCircle = new Circle(radius);
                Sphere MySphere = new Sphere(radius);
                double length = MyCircle.CircleLength();
                double area = MyCircle.CircleArea();
                double volume = MySphere.SphereVolume();
                Console.WriteLine("Length: {0};\nArea: {1};\nVolume: {2};", length, area, volume);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
