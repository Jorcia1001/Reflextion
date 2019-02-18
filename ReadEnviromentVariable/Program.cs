using System;
using System.Configuration;

namespace ReadEnviromentVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            string sAttr = Environment.ExpandEnvironmentVariables(
                ConfigurationManager.AppSettings.Get("Key0"));
            Console.WriteLine(sAttr);

            string sAttr1 = 
               ConfigurationManager.AppSettings.Get("Key1");
            Console.WriteLine(sAttr1);

            Console.ReadKey();

        }
    }
}
