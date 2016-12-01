using System;

namespace RadiusOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            double r, length, area, volume;
            Console.WriteLine("Input radius");
            r = Convert.ToDouble(Console.ReadLine());
            length = 2 * r * Math.PI;
            area = Math.PI * Math.Pow(r, 2);
            volume = (4 / 3) * Math.PI * Math.Pow(r, 3);
            Console.WriteLine("Length: {0};\nArea: {1};\nVolume: {2};", length, area, volume);
            Console.ReadLine();
        }
    }
}
