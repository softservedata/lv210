using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Program
    {
        public enum HTTPError
        {
            Bad_Request = 400,
            Unautorized,
            Payment_Required,
            Forbidden,
            Not_Found
        }
        static void Main(string[] args)
        {
            #region Task1
            Console.WriteLine("Input 3 float numbers divided by space: ");
            string[] inputData = Console.ReadLine().Split(' ');

            for (int i = 0; i < inputData.Length; i++)
            {
                if (float.Parse(inputData[i]) <= 5 && float.Parse(inputData[i]) >= -5)
                {
                    Console.WriteLine("{0} belong to the range [-5,5]", inputData[i]);
                }
                else
                    Console.WriteLine("{0} not belong to the range [-5,5]", inputData[i]);
            }
            Console.WriteLine();
            #endregion

            #region Task2
            Console.WriteLine("Input 3 integer numbers divided by space:");
            string[] inputDataInteger = Console.ReadLine().Split(' ');

            int[] array = new int[inputDataInteger.Length];

            for (int i = 0; i < inputDataInteger.Length; i++)
            {
                array[i] = int.Parse(inputDataInteger[i]);
            }

            Array.Sort(array);

            Console.WriteLine("Min value : {0}, max value : {1}", array[0], array[array.Length - 1]);
            Console.WriteLine();
            #endregion

            #region Task3
            Console.WriteLine("Input number of error from range [400, 404]");
            int errorNumber = int.Parse(Console.ReadLine());

            HTTPError error = (HTTPError)errorNumber;

            switch (error)
            {
                case HTTPError.Bad_Request:
                    string str = HTTPError.Bad_Request.ToString();
                    Console.WriteLine("Error name : {0} ", str);
                    break;
                case HTTPError.Forbidden:
                    str = HTTPError.Forbidden.ToString();
                    Console.WriteLine("Error name : {0} ", str);
                    break;
                case HTTPError.Not_Found:
                    str = HTTPError.Not_Found.ToString();
                    Console.WriteLine("Error name : {0} ", str);
                    break;
                case HTTPError.Payment_Required:
                    str = HTTPError.Payment_Required.ToString();
                    Console.WriteLine("Error name : {0} ", str);
                    break;
                case HTTPError.Unautorized:
                    str = HTTPError.Unautorized.ToString();
                    Console.WriteLine("Error name : {0} ", str);
                    break;
                default:
                    Console.WriteLine("Inputed incorrect number!");
                    break;
            }
            Console.WriteLine();
            #endregion

            #region Task4
            Dog myDog = new Dog();
            Console.WriteLine("Input dog name:");
            myDog.Name = Console.ReadLine();
            Console.WriteLine("Input dog mark:");
            myDog.Mark = Console.ReadLine();
            Console.WriteLine("Input dog age:");
            myDog.Age = int.Parse(Console.ReadLine());

            myDog.ToString();
            #endregion

            Console.ReadKey();
        }
    }

    public struct Dog
    {
        public string Name;
        public string Mark;
        public int Age;

        public void ToString()
        {
            Console.WriteLine("Dog name is {0}, mark is {1}, age is {2}", Name, Mark, Age);
        }
    }

}
