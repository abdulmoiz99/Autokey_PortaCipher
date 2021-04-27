using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKey_Porta_Cipher
{
    class Porta
    {
        public static char[] KeyStream(char[] plainText, char[] Key)
        {
            int index = 0;
            char[] keyStreamArray = new char[plainText.Length];
            for (int i = 0; i < plainText.Length; i++)
            {
                if (index >= Key.Length)
                {
                    index = 0;
                }
                keyStreamArray[i] = Key[index];
                index++;
                    
            }
            return keyStreamArray;
        }

        public static void Decrypt(string CipherText, string Key)
        {
            CipherText = CipherText.Replace(" ", string.Empty).ToUpper();
            char[] cipherTextArray = CipherText.ToCharArray();

            char[] KeyArray = Porta.KeyStream(cipherTextArray, Key.ToCharArray());

            string PlainText = "";
            for (int i = 0; i < CipherText.Length; i++)
            {
                int index = Cipher.GetAlphabetValue(cipherTextArray[i]);
                PlainText += Cipher.GetPortaValue(index, KeyArray[i]);
            }

            Console.WriteLine("Decrypted Text: " + PlainText);
        }

        public static void Encrypt(string plainText, string Key)
        {
            plainText = plainText.Replace(" ", string.Empty).ToUpper();
            char[] plainTextArray = plainText.ToCharArray();

            char[] KeyArray = Porta.KeyStream(plainTextArray, Key.ToCharArray());

            string cipherText = "";
            for (int i = 0; i < plainText.Length; i++)
            {
                int index = Cipher.GetAlphabetValue(plainTextArray[i]);
                cipherText += Cipher.GetPortaValue(index, KeyArray[i]);
            }

            Console.WriteLine("Encrypted Text: " + cipherText);
        }

    }
}
