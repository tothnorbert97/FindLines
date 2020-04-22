using System.Collections.Generic;

namespace FindLines.BusinessObjects
{
    public class ImageProcessResult
    {
        private const string IMAGE_PROCESSING_RESULT_STRING_FORMAT = "{0} {1}";
        private const string LINE_SEPARATOR = " ";

        public ImageProcessResult(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; private set; }
        public IEnumerable<Line> Lines { get; set; }

        public override string ToString()
        {
            return string.Format(IMAGE_PROCESSING_RESULT_STRING_FORMAT, FileName, string.Join(LINE_SEPARATOR, Lines));
        }
    }
}
