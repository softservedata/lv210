using System;

namespace AppropriateFunctions
{
    public class Functions
    {
        public static int FindCountOfSomeCharactersInString(string entered_string, char [] char_collection)
        {
            int count = 0;
            for(int i= 0; i<entered_string.Length; i++)
            {
                if (IsNecessaryCharacter(entered_string[i], char_collection)) count++;
            }
            return count;
        }

        public static bool IsNecessaryCharacter(char character, char [] char_collection)
        {
            bool isFromCollection = false;
            foreach( var ch in char_collection)
            {
                if (character == ch)
                {
                    isFromCollection = true;
                    break;
                }
            }
            return isFromCollection;
        }
    }
}