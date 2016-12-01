using System;

namespace Color
{
    enum Colors { red, blue, green, yellow };
    class Program
    {
        
        static void Main(string[] args)
        {
            Colors myColor = new Colors();
            myColor = Colors.blue;
            Console.WriteLine("My favourite color is {0}", myColor);
            Console.ReadLine();
        }
    }
}
