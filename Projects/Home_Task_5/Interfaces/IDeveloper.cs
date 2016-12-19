using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    interface IDeveloper
    {
        // Properties
        string Name { get; set; }
        string Tool { get; set; }

        // Methods
        void Create();
        void Destroy();
    }
}
