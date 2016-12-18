using System;

namespace Task1
{
    class Builder : IDeveloper
    {
        public string Tool { get; set; }
        
        public void Create()
        {
           Console.WriteLine("Builder with tool {0} is created",Tool);
        }

        public void Destroy()
        {
            Console.WriteLine("Builder was destroyed");
           
        }
    }
}
