using System.Collections.Generic;

namespace AutoKey_Porta_Cipher
{
    class Cipher
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

        // lockuptable for PortaCipher
        private static IDictionary<string, string> portaTable = new Dictionary<string, string>() {
            { "AB" , "NOPQRSTUVWXYZABCDEFGHIJKLM" } ,
            { "CD" , "OPQRSTUVWXYZNMABCDEFGHIJKL" } ,
            { "EF" , "PQRSTUVWXYZNOLMABCDEFGHIJK" } ,
            { "GH" , "QRSTUVWXYZNOPKLMABCDEFGHIJ" } ,
            { "IJ" , "RSTUVWXYZNOPQJKLMABCDEFGHI" } ,
            { "KL" , "STUVWXYZNOPQRIJKLMABCDEFGH" } ,
            { "MN" , "TUVWXYZNOPQRSHIJKLMABCDEFG" } ,
            { "OP" , "UVWXYZNOPQRSTGHIJKLMABCDEF" } ,
            { "QR" , "VWXYZNOPQRSTUFGHIJKLMABCDE" } ,
            { "ST" , "WXYZNOPQRSTUVEFGHIJKLMABCD" } ,
            { "UV" , "XYZNOPQRSTUVWDEFGHIJKLMABC" } ,
            { "WX" , "YZNOPQRSTUVWXCDEFGHIJKLMAB" } ,
            { "YX" , "ZNOPQRSTUVWXYBCDEFGHIJKLMA" }
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
        public static char[] KeyStream(char[] plainText, char[] Key)
        {
            int index = 0;
            char[] keyStream = new char[plainText.Length];
            for (int i = 0; i < plainText.Length; i++)
            {
                if (i < Key.Length)
                {
                    keyStream[i] = Key[i];
                }
                else
                {
                    keyStream[i] = plainText[index++];
                }
            }
            return keyStream;
        }

        public static char GetPortaValue(int cipherTextIndex, char key)
        {
            char cipher = '-';
            foreach (var keyValue in portaTable)
            {
                if (keyValue.Key.Contains(key.ToString()))
                {
                    string value = keyValue.Value;
                    cipher = value[cipherTextIndex];
                }
            }
            return cipher;
        }
    }
}
