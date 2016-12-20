using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsProject
{
    interface IAnimal
    {
        string Name { get; set; }
        int Food { get; set; }

        void Voice();
        void Feed();
    }
}
