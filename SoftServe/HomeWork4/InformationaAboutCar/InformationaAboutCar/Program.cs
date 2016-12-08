using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationaAboutCar
{
    class Program
    {
        /// <summary>
        /// Визначити клас Car з полями марка, колір, ціна. 
        /// Створити два конструктори – дефолтний і з параметрами.
        /// Створити властивість доступу до поля колір.
        /// Визначити методи Input() –  для введення даних про машину з консолі,
        ///                    Print() - для виведення даних про машину на консоль
        ///                    ChangePrice(double x) – для зміни ціни на х%
        /// Ввести дані про 3 авто, змінити їх ціну на 10%, вивести дані про авто.
        /// Ввести новий колір і пофарбувати авто з кольором white у вказаний колір
        /// </summary>
        
        static void Main(string[] args)
        {
            int carCount = 3;
            List<Car> carList = new List<Car>();

            for (int i = 0; i < carCount; i++)
            {
                carList.Add(Car.Input());
            }

            carList.ForEach(c => c.Print());

            Console.WriteLine("\nPrice increased!\n");

            carList.ForEach(c => c.ChangePrice(10));

            carList.ForEach(c => c.ChangeColor());

            Console.ReadKey();
        }
    }
}
