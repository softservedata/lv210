using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task8
{
    class Program
    {
        const string Path = "E:\\C#\\Data\\";
       

        static void Main(string[] args)
        {
            List<Shape> shapeList = ListCreation();

            PrintRangeShapesToFile(shapeList, 10, 100);
            
            PrintShapesWithNameContainsLetterToFile(shapeList, "a");

            PrintShapesWithoutPerimeterLessValueToConsole(shapeList, 5);


            //5) Read all lines of text from file into array of strings.
            //Each array item contains one line from file.
            StreamReader reader = new StreamReader(Path + "LongTextFile.txt");
            reader.Dispose;
            List<string> textLines = new List<string>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                textLines.Add(line.Trim());
            }

            //6) Count and write the number of symbols in every line.
            foreach (var item in textLines)
            {
                Console.WriteLine(item.Length);
            }

            //7) Find the longest and the shortest line. 
            int max = textLines.Max(item => item.Length);
            string longestLine = textLines.Find(item => item.Length == max);
            int min = textLines.Min(item => item.Length);
            string shortestLine = textLines.Find(item => item.Length == min);

            Console.WriteLine("longestLine is {0}. Its length is {1}.", longestLine, longestLine.Length);

            Console.WriteLine("shortestLine is {0}. Its length is {1}.", shortestLine, shortestLine.Length);
            Console.ReadKey();

            //8) Find and write only lines, which consist of word "var"
            IEnumerable<string> textLinesContainsVar = textLines.Where<string>(item => item.Contains("var"));
            foreach (var item in textLinesContainsVar)
            {
                Console.WriteLine("Lines which consist of word 'var': ");
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
       
        //1) Create list of Shape and fill it with 6 different shapes (Circle and Square).
        public static List<Shape> ListCreation()
        {
            List<Shape> shapeList = new List<Shape>();
            string shapeName;
            int shapeFieldForCalcaulation;
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Please enter name of shape{0}", i);
                shapeName = Console.ReadLine();

                Console.WriteLine("Please enter radius/side of {0}", shapeName);
                shapeFieldForCalcaulation = Convert.ToInt32(Console.ReadLine());

                if (shapeName.ToLower().Contains("circle"))
                {
                    Circle cirle = new Circle(shapeName, shapeFieldForCalcaulation);
                    shapeList.Add(cirle);
                    continue;
                }
                if (shapeName.ToLower().Contains("square"))
                {
                    Square square = new Square(shapeName, shapeFieldForCalcaulation);
                    shapeList.Add(square);
                }
                else
                {
                    Console.WriteLine("You entered unsupported shape type ({0})!", shapeName);
                    i--;
                }
            }
            return shapeList;
        }

        //2) Find and write into the file shapes with area from range [10,100]
        public static void PrintRangeShapesToFile(List<Shape> shapeList, int from, int until)
        {
            IEnumerable<Shape> filteredShapeListByArea = shapeList.Where<Shape>(item => item.Area() >= from && item.Area() <= until);
            string fileName = "ShapesWithAreaFrom" + from + "To" + until + ".txt";
            Shape.printShapesToTheFile(filteredShapeListByArea, Path, fileName);
        }

        //3)Find and write into the file shapes which name contains letter 'a'
        private static void PrintShapesWithNameContainsLetterToFile(List<Shape> shapeList, string letter)
        {
            IEnumerable<Shape> filteredByNameShapeList = shapeList.Where<Shape>(item => item.Name.Contains(letter));
            string fileName = "ShapesWithNameContains" + letter + ".txt";
            Shape.printShapesToTheFile(filteredByNameShapeList, Path, fileName);
        }

        //4) Find and remove from the list all shapes with perimeter less then 5. Write resulted list into Console 
        private static void PrintShapesWithoutPerimeterLessValueToConsole(List<Shape> shapeList, int value)
        {
            shapeList.RemoveAll(item => item.Perimeter() < value);
            Shape.printShapesListToConsole(shapeList);
            Console.ReadKey();
        }
    }
}
