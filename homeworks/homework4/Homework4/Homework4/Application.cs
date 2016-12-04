using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    class Application
    {
        public static void Main(){
           Person [] personsList = new Person[5];
            for(int i=0;i<personsList.Length;i++) {
                personsList[i] = new Person();
                personsList[i].Input();
               
                        }
            for (int i = 0; i < personsList.Length; i++)
            {
                if (personsList[i].Age() < 16) personsList[i].ChangeName("Very young");
                personsList[i].Output();
            }
                Console.ReadKey();
            
        }

    }
}
