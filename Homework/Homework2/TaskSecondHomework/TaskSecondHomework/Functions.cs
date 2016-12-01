using System;


namespace Function
{
    public class Function
    {
        #region Task1
        public static bool AreInRange(float x, float a, float b)
        {
            if (x >= a && x <= b) return true; else return false;
        }

        public static bool logical_conjunction(bool a, bool b, bool c)
        {
            return a & b & c;
        }


        public static int CheckNumbers()
        {
            Console.WriteLine("Enter three numbers:");
            string x1_s = Console.ReadLine();
            string x2_s = Console.ReadLine();
            string x3_s = Console.ReadLine();

            float x1, x2, x3;
            try
            {
                x1 = Convert.ToSingle(x1_s);
                x2 = Convert.ToSingle(x2_s);
                x3 = Convert.ToSingle(x3_s);
            }
            catch(Exception)
            {
                Console.WriteLine("Incorrect data!");
                return 0;
            }

            Console.WriteLine();
            Console.WriteLine("All these numbers are from the interval [-5,5] - {0} ", logical_conjunction(AreInRange(x1, -5, 5), AreInRange(x2, -5, 5), AreInRange(x3, -5, 5)));
            Console.ReadLine();
            return 0;
        }

        #endregion

        #region Task2
        public static int max(int a, int b, int c)
        {
            if (a > b && a > c)
                return a;
            else if (b > c) return b;
            else return c;
        }

        public static int min(int a, int b, int c)
        {
            if (a < b && a < c)
                return a;
            else if (b < c) return b;
            else return c;
        }

        public static int FindMinMax()
        {
            Console.WriteLine("Enter three numbers:");
            string x1_s = Console.ReadLine();
            string x2_s = Console.ReadLine();
            string x3_s = Console.ReadLine();

            int x1, x2, x3;
            try
            {
                x1 = Convert.ToInt32(x1_s);
                x2 = Convert.ToInt32(x2_s);
                x3 = Convert.ToInt32(x3_s);
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect data!");
                return 0;
            }

            Console.WriteLine();
            Console.WriteLine("Max - {0} ", max(x1,x2,x3));
            Console.WriteLine("Min - {0} ", min(x1, x2, x3));
            Console.ReadLine();
            return 0;
        }

        #endregion

        #region Task3
        enum Errors { Bad_Request = 400, Unauthorized, Payment_Required, Forbidden, Not_Found };

        public static int GetErrorName()
        {
            Console.Write("Write error number -");
            string error_str = Console.ReadLine();

            int error_number;
            try
            {
                error_number = Convert.ToInt32(error_str);
            }
            catch(Exception)
            {
                Console.WriteLine("Incorrect data!");
                return 0;
            }

            Console.WriteLine("");
            Console.WriteLine("Error name - {0}", (Errors)error_number);
            Console.ReadLine();
            return 0;
        }

        #endregion

        #region Task4
        struct Dog
        {
            public string Name;
            public string Mark;
            public int Age;

            public void ToString()
            {
                Console.WriteLine("This is a dog. It name is {0}, it mark is {1}, it age is {2}", Name, Mark, Age);
            }
        }

        public static int GetInformationAboutDog()
        {
            Console.WriteLine("Enter data about your dog:");
            Console.Write("Name - ");
            string name = Console.ReadLine();
            Console.Write("Mark - ");
            string mark = Console.ReadLine();
            Console.Write("Age - ");
            string age_str = Console.ReadLine();

            int age;
            try
            {
                age = Convert.ToInt32(age_str);
            }
            catch(Exception)
            {
                Console.WriteLine();
                Console.WriteLine("Incorrect data!");
                return 0;
            }
            Dog myDog;
            myDog.Name = name;
            myDog.Mark = mark;
            myDog.Age = age;

            Console.WriteLine("");
            myDog.ToString();
            Console.ReadLine();
            return 0;
        }
        #endregion
    }
}
