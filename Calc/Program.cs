using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wow.Data;
using NLog;

namespace Calc
{
    public class Numeric
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public double add(double arg0, double arg1)
        {
            logger.Info("logger.Info add(double arg0, double arg1)");
            return arg0 + arg1;
        }

        public double div(double arg0, double arg1)
        {
            return arg0 / arg1;
        }
    }

    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

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
            /*
            IUser user = User.Get()
                .SetEmail("a@a.ua")
                .SetPassword("123")
                .SetIsAdmin(true)
                .SetIsTeacher(true)
                .SetIsStudent(true)
                .Build();
            Console.WriteLine("email = " + user.GetEmail());
            */
            //
            //string assemblyPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
            //Console.WriteLine("assemblyPath = " + assemblyPath);
            //string filePath = AppDomain.CurrentDomain.BaseDirectory;
            //Console.WriteLine("filePath = " + filePath);
            //string absolutePathOfCurrentDirectory = System.IO.Directory.GetCurrentDirectory();
            //Console.WriteLine("absolutePathOfCurrentDirectory = " + absolutePathOfCurrentDirectory);
            //string fullPath = Path.GetFullPath("FileStorage/Users.csv");
            //Console.WriteLine("fullPath = " + fullPath);
            //string wantedPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            //Console.WriteLine("wantedPath = " + wantedPath);
            //
            //var assembly = typeof(Program).Assembly;
            //using (var stream = assembly.GetManifestResourceStream("Calc.Program.cs"))
            //using (var xmlReader = XmlReader.Create(stream)) { }
            //
            //foreach (IUser user in UserRepository.Get().FromDefaultCsv())
            //{
            //    Console.WriteLine("Email = " + user.GetEmail());
            //    Console.WriteLine("Password = " + user.GetPassword());
            //    Console.WriteLine("IsIsAdmin = " + user.GetIsAdmin());
            //}
            //
            logger.Trace("logger.Trace");
            logger.Debug("logger.Debug");
            logger.Info("logger.Info");
            logger.Warn("logger.Warn");
            logger.Error("logger.Error");
            logger.Fatal("logger.Fatal");
            //
            new Numeric().add(1, 2);
        }
    }
}
