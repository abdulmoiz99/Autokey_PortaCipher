using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKey_Porta_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("AUTO KEY CIPHER");
            AutoKey.Encrypt();
            AutoKey.Decrypt();
        }
    }
}
