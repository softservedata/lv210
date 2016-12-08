using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    /// <summary>
    /// Визначити клас Car з полями марка, колір, ціна.
    /// Створити два конструктори – дефолтний і з параметрами.
    /// Створити властивість доступу до поля колір. 
    /// Визначити методи 
    ///     Input() –  для введення даних про машину з консолі,                               
    ///     Print() - для виведення даних про машину на консоль                               
    ///     ChangePrice(double x) – для зміни ціни на х%
    ///
    /// Ввести дані про 3 авто, змінити їх ціну на 10%, вивести дані про авто.
    ///Ввести новий колір і пофарбувати авто з кольором white у вказаний колір
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Creating collection of cars
            int numberOfCars = 3;
            Car[] arrayOfCars = new Car[numberOfCars];

            for (int i = 0; i < arrayOfCars.Length; i++)
            {
                arrayOfCars[i] = Car.Input();
            }

            //Output results
            Console.WriteLine("---Original result---");
            foreach (Car car in arrayOfCars)
            {
                car.Print();
            }

            Console.WriteLine("\n---Change price---");
            foreach (Car car in arrayOfCars)
            {
                double percent = 10;
                car.ChangePrice(percent);
                car.Print();
            }

            Console.WriteLine("\n---Change color---");
            Console.Write("Enter new color:");
            string newColor = Console.ReadLine();
            foreach (Car car in arrayOfCars)
            {
                car.ChangeColorForWhiteCars(newColor);
                car.Print();
            }
        }
    }
}
