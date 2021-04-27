using System.Collections.Generic;

namespace AutoKey_Porta_Cipher
{
    class Main
    {
        private static IDictionary<char, int> Table = new Dictionary<char, int>() {
            {'A', 0} , {'B', 1} , {'C',2 } , {'D' ,3},
            {'E',4 } , {'F',5 } , {'G', 6} , {'H' ,7},
            {'I',8 } , {'J', 9} , {'K', 10} , {'L' ,11},
            {'M',12 } , {'N', 13} , {'O',14 } , {'P' ,15},
            {'Q',16 } , {'R',17 } , {'S', 18} , {'T' ,19},
            {'U',20 } , {'V',21 } , {'W',22 } , {'X' ,23},
            {'Y',24 } , {'Z',25 }
        };

        // lockuptable for ATBASH
        private static IDictionary<char, char> lookup_table = new Dictionary<char, char>() {
            {'A' , 'Z'} , {'B' , 'Y'} , {'C' , 'X'} , {'D' , 'W'},
            {'E' , 'V'} , {'F' , 'U'} , {'G' , 'T'} , {'H' , 'S'},
            {'I' , 'R'} , {'J' , 'Q'} , {'K' , 'P'} , {'L' , 'O'},
            {'M' , 'N'} , {'N' , 'M'} , {'O' , 'L'} , {'P' , 'K'} ,
            {'Q' , 'J'} , {'R' , 'I'} , {'S' , 'H'} , {'T' , 'G'},
            {'U' , 'F'} , {'V' , 'E'} , {'W' , 'D'} , {'X' , 'C'} ,
            {'Y' , 'B'} , {'Z' , 'A'}
        };
        public static int GetAlphabetValue(char Alphabet)
        {
            foreach (var keyValue in Table)
            {
                if (keyValue.Key == Alphabet)
                {
                    return keyValue.Value;
                }
            }
            return -1; // when there is an error
        }
        public static char GetAlphabetKey(int Value)
        {
            foreach (var keyValue in Table)
            {
                if (keyValue.Value == Value)
                {
                    return keyValue.Key;
                }
            }
            return ' '; // when there is an error
        }
        /// <summary>
        /// For Atbash Encryption
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static char GetAtbashValue(char key)
        {
            foreach (var keyValue in lookup_table)
            {
                if (keyValue.Key == key)
                {
                    return keyValue.Value;
                }
            }
            return ' '; // when there is an error
        }
        /// <summary>
        /// For Atbash Decryption
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static char GetAtbashKey(char value)
        {
            foreach (var keyValue in lookup_table)
            {
                if (keyValue.Value == value)
                {
                    return keyValue.Key;
                }
            }
            return ' '; // when there is an error
        }
    }
}
