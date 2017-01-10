using System.Collections.Generic;

namespace Inheritance
{
    /// <summary>
    /// A) Create Console Application project in VS.
    /// In Main() method declare Dictionary PhoneBook for keeping pairs PersonName-PhoneNumber
    /// 1) From file "phones.txt" read 9 pairs into PhoneBook.Write only PhoneNumbers into file "Phones.txt".
    /// 2) Find and print phone number by the given name(name input from console)
    /// 3) Change all phone numbers, which are in format 80######### into new format +380#########. 
    /// The result dictionary write into file "New.txt"
    /// B) Write a method ReadNumber(int start, int end), that reads from Console(or from file) integer number and return it, if it is in the range[start...end]. 
    /// If an invalid number or non-number text is read, the method should throw an exception.
    ///Using this method write a method Main(), that has to enter 10 numbers:
	///	a1, a2, ..., a10, such that 1 < a1< ... < a10< 100
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            List<Shape> shapes = new List<Shape>();

            ManipulationWithShapes s = new ManipulationWithShapes();

            shapes = s.GetSpecificShapes(1);
            s.Print(shapes);

            Shape biggestShape = s.FindMaxShape(shapes);

            shapes.Sort();
            s.Print(shapes);
        }
    }
}


