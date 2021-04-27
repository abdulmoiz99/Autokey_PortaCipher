using System;

namespace AutoKey_Porta_Cipher
{
    class AutoKey
    {
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
        public static void Encrypt()
        {
            string PlainText = "THEREISANOTHERTHINGINCRYPTOGRAPHYTHATINCREASESTHECOMPLEXITYOFTHESYSTEM", Key = "Key size", cipherText = "";
            Console.WriteLine("\nPlain Text: "+ PlainText);
            Console.WriteLine("Key: "+ Key);

            PlainText = PlainText.Replace(" ", string.Empty).ToUpper();
            Key = Key.Replace(" ", string.Empty).ToUpper();

            char[] PlainTextArray = PlainText.ToCharArray();
            char[] keyStream = KeyStream(PlainTextArray, Key.ToCharArray());



            for (int i = 0; i < PlainText.Length; i++)
            {

                int value = Main.GetAlphabetValue(PlainTextArray[i]) + Main.GetAlphabetValue(keyStream[i]);
                value = value % 26;
                cipherText += Main.GetAlphabetKey(value);
            }
            Console.WriteLine("Encrypted Text: " + cipherText);
        }
        public static void Decrypt()
        {
            string PlainText = "",
                Key = "KEYSIZE",
                cipherText = "DLCJMHWTUSKLMJTUWGNMEVYGCZWTTRNWRHNRTXUAKLALMFVYICGQHELBKHKDQXEMLWGYXT";

            Console.WriteLine("\n\nCipher Text: " + cipherText);
            Console.WriteLine("Key: " + Key);

            cipherText = cipherText.Replace(" ", string.Empty).ToUpper();
            Key = Key.Replace(" ", string.Empty).ToUpper();

            char[] cipherTextArray = cipherText.ToCharArray();
            char[] keyStream = KeyStream(cipherTextArray, Key.ToCharArray());


            int index = Key.Length;
            int keystreamSize = keyStream.Length;

            for (int i = 0; i < cipherText.Length; i++)
            {

                int value = Main.GetAlphabetValue(cipherTextArray[i]) - Main.GetAlphabetValue(keyStream[i]);
                value = value % 26;
                value = (value < 0) ? value + 26 : value;

                PlainText += Main.GetAlphabetKey(value);
                if (index < keystreamSize)
                {
                    keyStream[index] = Main.GetAlphabetKey(value);// To Add new key value
                    index++;
                }

            }
            Console.WriteLine(keyStream);

            Console.WriteLine("Decrypted Text: "+ PlainText);
        }
    }
}
