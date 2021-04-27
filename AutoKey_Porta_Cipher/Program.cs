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
            Console.WriteLine("AUTOKEY CIPHER\n");
            AutoKey.Encrypt();
            AutoKey.Decrypt();

            Console.WriteLine("PORTA CIPHER\n");
            Porta.Decrypt("GOIINDUGAFYBXJQOFBNUYNXJWHRCBINZOLNSNJPJVGYSETY", "BONUSMARKS");
            Porta.Encrypt("THOSEWHOSOLVETHISWILLGETANEXTRAFIVEMARKSINFINAL", "BONUSMARKS");


            Console.ReadKey();
           
        }
    }
}
