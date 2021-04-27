using System;

namespace AutoKey_Porta_Cipher
{
    class AutoKey
    {

        public static void Encrypt()
        {
            string PlainText = "THEREISANOTHERTHINGINCRYPTOGRAPHYTHATINCREASESTHECOMPLEXITYOFTHESYSTEM", Key = "Key size", cipherText = "";
            Console.WriteLine("\nPlain Text: " + PlainText);
            Console.WriteLine("Key: " + Key);

            PlainText = PlainText.Replace(" ", string.Empty).ToUpper();
            Key = Key.Replace(" ", string.Empty).ToUpper();

            char[] PlainTextArray = PlainText.ToCharArray();
            char[] keyStream = Cipher.KeyStream(PlainTextArray, Key.ToCharArray());



            for (int i = 0; i < PlainText.Length; i++)
            {

                int value = Cipher.GetAlphabetValue(PlainTextArray[i]) + Cipher.GetAlphabetValue(keyStream[i]);
                value = value % 26;
                cipherText += Cipher.GetAlphabetKey(value);
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
            char[] keyStream = Cipher.KeyStream(cipherTextArray, Key.ToCharArray());


            int index = Key.Length;
            int keystreamSize = keyStream.Length;

            for (int i = 0; i < cipherText.Length; i++)
            {

                int value = Cipher.GetAlphabetValue(cipherTextArray[i]) - Cipher.GetAlphabetValue(keyStream[i]);
                value = value % 26;
                value = (value < 0) ? value + 26 : value;

                PlainText += Cipher.GetAlphabetKey(value);
                if (index < keystreamSize)
                {
                    keyStream[index] = Cipher.GetAlphabetKey(value);// To Add new key value
                    index++;
                }

            }
            Console.WriteLine(keyStream);

            Console.WriteLine("Decrypted Text: " + PlainText);
        }
    }
}
