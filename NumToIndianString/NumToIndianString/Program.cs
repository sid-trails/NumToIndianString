using System;

namespace NumToIndianString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Number to convert");
            var ValueToConvert = Console.ReadLine();
            try
            { Console.WriteLine("============================Output=========================================");
               Console.WriteLine(NumberToStringConverter.Convert(ValueToConvert));
            }
            catch (NotSupportedException ne)
            {
                Console.WriteLine(ne.Message);
            }
            Console.WriteLine("============================Done=========================================");
            Console.ReadKey();
        }
    }
}