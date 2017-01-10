using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    abstract class Shape : IComparable<Shape>
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Shape(string name)
        {
            this.Name = name;
        }
        public abstract double Area();
        public abstract double Perimeter();

        public int CompareTo(Shape obj)
        {
            if (this.Area() > obj.Area())
                return 1;
            if (this.Area() < obj.Area())
                return -1;
            else
                return 0;
        }
        public static void printShapesToTheFile(IEnumerable<Shape> shapeList, string pathToDestinationFile, string destinationFileName)
        {
            using (StreamWriter writer = new StreamWriter(pathToDestinationFile + destinationFileName))
            {
                foreach (Shape item in shapeList)
                {
                    writer.WriteLine(item.Name + " has perimeter "+item.Perimeter() +" and area " + item.Area());
                }
            }
        }
        public static void printShapesListToConsole(IEnumerable<Shape> shapeList) 
        {
            foreach (Shape item in shapeList) 
            {
                Console.WriteLine(item.Name + " has perimeter " + item.Perimeter() + " and area " + item.Area());
            }
        }
    }
}