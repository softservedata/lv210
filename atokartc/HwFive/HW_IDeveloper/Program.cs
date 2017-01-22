using System.Collections.Generic;
namespace HwFive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IDeveloper> workers = new List<IDeveloper>();
            workers.Add(new Programmer() { Tool = "VS2012" });
            workers.Add(new Programmer() { Tool = "VS2015" });
            workers.Add(new Builder() { Tool = "Perforator1" });
            workers.Add(new Builder() { Tool = "Perforator2" });

            foreach (IDeveloper worker in workers)
            {
                worker.Create();
                worker.Destroy();
            }
        }
    }
}  

