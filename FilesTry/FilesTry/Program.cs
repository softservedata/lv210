using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesTry
{
    class Program
    {
        static void Main(string[] args)
        {
            File.Create("new_file.txt");
        }
    }
}
