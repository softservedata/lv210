using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_char
{
    /// <summary>
    /// Read the text as a string value and culculate the counts of characters 'a', 'o', 'i', 'e' in this text.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            int a_v = 0, o_v = 0, i_v = 0, e_v = 0;

            Console.WriteLine("Type some text:");
            string str = Console.ReadLine();

            //loop
            foreach (char s in str)
            {
                switch (s)
                {
                    case 'a':
                    case 'A':
                        a_v++;
                        break;

                    case 'o':
                    case 'O':
                        o_v++;
                        break;

                    case 'i':
                    case 'I':
                        i_v++;
                        break;

                    case 'e':
                    case 'E':
                        e_v++;
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine("\n----------RESULT----------");
            Console.WriteLine("Char 'a-A' used {0} times", a_v);
            Console.WriteLine("Char 'o-O' used {0} times", o_v);
            Console.WriteLine("Char 'i-I' used {0} times", i_v);
            Console.WriteLine("Char 'e-E' used {0} times", e_v);
        }
    }
}
