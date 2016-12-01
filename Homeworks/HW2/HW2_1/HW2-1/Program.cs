using System;
using System.Web;

namespace HW2_1
{
    struct Dog
    {
        public string Name;
        public string Mark;
        public int Age;
        public void toString()
        {
            Console.WriteLine("Name : {0}", Name);
            Console.WriteLine("Mark : {0}", Mark);
            Console.WriteLine("Age : {0}", Age);
        }
    };
    enum HTTPError { Unauthorized = 401, Forbidden = 403, Conflict = 409, Gone = 410}
    class Program
    {


        static void Main(string[] args)
        {
            double a, b, c;
            Console.WriteLine("Input 3 float numbers:");
            a = Convert.ToDouble(Console.ReadLine());
            b = Convert.ToDouble(Console.ReadLine());
            c = Convert.ToDouble(Console.ReadLine());
            if ((a <= 5) && (a >= -5))
                Console.WriteLine("First number belong to the range [-5,5]");
            else
                Console.WriteLine("First number not belong to the range [-5,5]");
            if ((b <= 5) && (b >= -5))
                Console.WriteLine("Second number belong to the range [-5,5]");
            else
                Console.WriteLine("Second number not belong to the range [-5,5]");
            if ((c <= 5) && (c >= -5))
                Console.WriteLine("Third number belong to the range [-5,5]");
            else
                Console.WriteLine("Third number not belong to the range [-5,5]");
            Console.WriteLine("*****************************************************************");
            int a1, b1, c1;
            Console.WriteLine("Input 3 integer numbers:");
            a1 = Convert.ToInt32(Console.ReadLine());
            b1 = Convert.ToInt32(Console.ReadLine());
            c1 = Convert.ToInt32(Console.ReadLine());
            int min = 1000000;
            int max = 0;
            if (a1 > max)
                max = a1;
            if (b1 > max)
                max = b1;
            if (c1 > max)
                max = c1;
            Console.WriteLine("Max = {0}", max);
            if (a1 < min)
                min = a1;
            if (b1 < min)
                min = b1;
            if (c1 < min)
                min = c1;
            Console.WriteLine("Min = {0}", min);
            Console.WriteLine("*****************************************************************");
            Dog myDog = new Dog();      
            Console.WriteLine("Input dog`s name");
            myDog.Name = Console.ReadLine();
            Console.WriteLine("Input dog`s mark");
            myDog.Mark = Console.ReadLine();
            Console.WriteLine("Input dog`s age");
            myDog.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Information about dog:");
            myDog.toString();
            Console.ReadLine();
        }
    }
}
