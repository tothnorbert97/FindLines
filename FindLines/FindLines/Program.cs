using FindLines.BusinessLogic;
using System;

namespace FindLines
{
    class Program
    {
        static void Main(string[] args)
        {
            var imageProcessor = new TextImageProcessor();
            imageProcessor.Process();
            Console.ReadKey();
        }
    }
}
