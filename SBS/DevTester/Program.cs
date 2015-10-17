using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTester
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSecurity();
        }

        private static void TestSecurity()
        {
            Console.WriteLine("--------------- Generated Keys ---------------");
            var keyXml = Security.PKIService.GeneratePublicAndPrivateKey().ToString();
            Console.WriteLine(keyXml);

            Console.WriteLine("--------------- Data ---------------");
            var data = "testing encryption";
            Console.WriteLine("Data: {0}", data);

            Console.WriteLine("--------------- Encrypted Data ---------------");
            var encryptedData = Security.PKIService.EncryptData("testing encryption", keyXml).ToString();
            Console.WriteLine(encryptedData);


            Console.WriteLine("--------------- Decrypted Data ---------------");
            Console.WriteLine(Security.PKIService.DecryptData(encryptedData, keyXml).ToString());
            
            // Jon was here.
            Console.ReadLine();
        }
    }
}
