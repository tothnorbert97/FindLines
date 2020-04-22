using FindLines.BusinessObjects;
using FindLines.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace FindLines.Converters
{
    public class ImageFileConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var image = value as string[];
            if (image == null) return null;
            var pixels = new List<Pixel>();
            for (int column = 0; column < image.Length; column++)
            {
                pixels.AddRange(ConvertTextRow(image[column], column));
            }
            return pixels;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Pixel> ConvertTextRow(string text, int column)
        {
            var pixels = new List<Pixel>();
            for (int row = 0; row < text.Length; row++)
            {
                pixels.Add(new Pixel(row, column) { Color = (PointColorEnum)int.Parse(text[row].ToString()) });
            }
            return pixels;
        }
    }
}
