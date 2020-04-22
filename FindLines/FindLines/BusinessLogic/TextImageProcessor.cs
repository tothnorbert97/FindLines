using FindLines.BusinessObjects;
using FindLines.Interface;
using FindLines.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace FindLines.BusinessLogic
{
    public class TextImageProcessor : IImageProcessor
    {
        private readonly IFileReader<IEnumerable<Pixel>> _imageFileReader;
        private readonly IFormSearcher<Line> _lineSearcher;
        private readonly IProcessWriter<ImageProcessResult> _imageProcessConsoleWriter;

        public TextImageProcessor()
        {
            _imageFileReader = new ImageFileReader();
            _lineSearcher = new LineSearcher();
            _imageProcessConsoleWriter = new ImageProcessConsoleWriter();
        }

        public void Process()
        {
            _imageProcessConsoleWriter.WriteProcessStart();
            foreach (var imageFilePath in _imageFileReader.CollectFilePaths())
            {
                var pixels = _imageFileReader.Read(imageFilePath);
                var fileName = Path.GetFileName(imageFilePath);
                _imageProcessConsoleWriter.WriteProcessResult(new ImageProcessResult(fileName) { Lines = _lineSearcher.Search(pixels) });
            }
            _imageProcessConsoleWriter.WriteProcessEnd();
        }
    }
}
