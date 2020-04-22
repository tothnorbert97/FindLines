using FindLines.BusinessObjects;
using FindLines.Converters;
using FindLines.Interface;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Data;

namespace FindLines.BusinessLogic
{
    public class ImageFileReader : IFileReader<IEnumerable<Pixel>>
    {
        private const string TEXT_FILE_SEARCH_PATTERN = "*.txt";
        private readonly string _imageDirectoryPath = Directory.GetCurrentDirectory() + @"\..\..\Images";
        private readonly string[] _enabledFileExtensions = new string[]
        {
            ".txt"
        };
        private readonly IValueConverter _imageFileConverter;

        public ImageFileReader()
        {
            _imageFileConverter = new ImageFileConverter();
        }

        public string[] CollectFilePaths()
        {
            return Directory.GetFiles(_imageDirectoryPath, TEXT_FILE_SEARCH_PATTERN);
        }

        public IEnumerable<Pixel> Read(string path)
        {
            if (!IsPathValid(path)) return null;
            return _imageFileConverter.Convert(File.ReadAllLines(path), null, null, null) as IEnumerable<Pixel>;
        }

        private bool IsPathValid(string path)
        {
            return !string.IsNullOrEmpty(path) &&
                File.Exists(path) &&
                _enabledFileExtensions.Contains(Path.GetExtension(path));
        }
    }
}
