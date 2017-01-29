using System;

namespace HwFive
{
    public class Builder : IDeveloper
    {
        private string bldTool;

        public string Tool
        {
            get
            {
                return this.bldTool;
            }
            set
            {
                this.bldTool = value;
            }
        }

        public void Create()
        {
            Console.WriteLine("Builder: Create() method executes using tool {0}", Tool);
            Console.ReadKey();
        }

        public void Destroy()
        {
            Console.WriteLine("Builder: Destroy() method executes using tool {0}", Tool);
            Console.ReadKey();
        }
    }
}
