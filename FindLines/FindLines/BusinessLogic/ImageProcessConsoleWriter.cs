using FindLines.BusinessObjects;
using FindLines.Interfaces;
using System;

namespace FindLines.BusinessLogic
{
    public class ImageProcessConsoleWriter : IProcessWriter<ImageProcessResult>
    {
        private const string PROCESS_STARTED_MESSAGE = "Process started...";
        private const string PROCESS_ENDED_MESSAGE = "Process ended...";

        public void WriteProcessEnd()
        {
            Console.WriteLine(PROCESS_ENDED_MESSAGE);
        }
        public void WriteProcessResult(ImageProcessResult result)
        {
            Console.WriteLine(result.ToString());
        }
        public void WriteProcessStart()
        {
            Console.WriteLine(PROCESS_STARTED_MESSAGE);
        }
    }
}
