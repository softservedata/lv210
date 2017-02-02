using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wow.Data;

namespace Calc
{
    public class Numeric
    {

        public double add(double arg0, double arg1)
        {
            return arg0 + arg1;
        }

        public double div(double arg0, double arg1)
        {
            return arg0 / arg1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
            Numeric numeric = new Numeric();
            double arg0;
            double arg1;
            //
            Console.Write("arg0 = ");
            Double.TryParse(Console.ReadLine(), out arg0);
            //
            Console.Write("arg0 = ");
            Double.TryParse(Console.ReadLine(), out arg1);
            //
            Console.WriteLine("arg0 + arg1 = " + numeric.add(arg0, arg1));
            Console.WriteLine("arg0 / arg1 = " + numeric.div(arg0, arg1));
            */
            //User user = new User("aa2@u.ua", "123", true, true, true);
            //
            // using setters
            //User user = new User();
            //user.SetEmail("a@a.ua");
            //user.SetPassword("123");
            //user.SetIsAdmin(true);
            //user.SetIsTeacher(true);
            //user.SetIsStudent(true);
            //
            // add fluent interface
            //User user = new User()
            //    .SetEmail("a@a.ua")
            //    //.SetPassword("123")
            //    //.SetIsAdmin(true)
            //    .SetIsTeacher(true)
            //    .SetIsStudent(true);
            //
            // add static factory
            //User user = User.Get()
            //    .SetEmail("a@a.ua")
            //    //.SetPassword("123")
            //    //.SetIsAdmin(true)
            //    .SetIsTeacher(true)
            //    .SetIsStudent(true);
            //
            // add builder
            //User user = User.Get()
            //    .SetEmail("a@a.ua")
            //    .SetPassword("123")
            //    .SetIsAdmin(true)
            //    .SetIsTeacher(true)
            //    .SetIsStudent(true)
            //    .Build();
            //Console.WriteLine("email = " + user.GetEmail());
            //Console.WriteLine("email = " + user.SetEmail("qwqw"));
            //
            // add dependency inversion
            IUser user = User.Get()
                .SetEmail("a@a.ua")
                .SetPassword("123")
                .SetIsAdmin(true)
                .SetIsTeacher(true)
                .SetIsStudent(true)
                .Build();
            Console.WriteLine("email = " + user.GetEmail());
        }
    }
}
