using System;
using System.Collections.Generic;

namespace HwFive
{
    class Program
    {
        public static void Main()
        {
            Dictionary<uint, string> dictionary = new Dictionary<uint, string>();

            DictionaryUtils dictionaryUtls = new DictionaryUtils();

            Console.WriteLine("Enter id press Enter than enter name. Press Enter." +
                            "Enter all vakues one by one");
            dictionary = dictionaryUtls.AddValuesToDictiuonary(3);
            dictionaryUtls.GetNameById(dictionary);
        }
    }
}
