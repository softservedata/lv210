using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] staff=new Person[5];
            for(int i=0;i<5;i++)
            {
                staff[i]=new Person();
                Console.WriteLine("Enter information about person{0}",i);
                staff[i].Input();
            }
            for (int i = 0; i < 5;i++ )
            {
                staff[i].Output();
                Console.WriteLine(staff[i].Name +" " + staff[i].Age());
            }
            for (int i = 0; i < 5;i++ )
            {
                if(staff[i].Age()<16)
                {
                    staff[i].ChangeName("Very young");
                }
                Console.WriteLine(staff[i].Name + " " + staff[i].Age());              
            }
            Console.ReadKey();
        }
    }
}
