using FindLines.BusinessObjects;
using FindLines.Enums;
using FindLines.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FindLines.BusinessLogic
{
    public class LineSearcher : IFormSearcher<Line>
    {
        public IEnumerable<Line> Search(IEnumerable<Pixel> pixels)
        {
            var lines = new List<Line>();
            var linePartPixels = FilterLinePartPixels(pixels);
            foreach (var pixel in linePartPixels)
            {
                var line = SearchLineByPixel(pixel, linePartPixels);
                if (line != null && !lines.Contains(line)) lines.Add(line);
            }
            return lines;
        }

        private Line SearchLineByPixel(Pixel pixel, IEnumerable<Pixel> linePartPixels)
        {
            var line = new Line();
            if (line.IsPixelEndPoint(pixel, linePartPixels))
            {
                return CollectLineParts(line, pixel, linePartPixels);
            }
            return null;
        }
        private Line CollectLineParts(Line line, Pixel pixel, IEnumerable<Pixel> linePartPixels)
        {
            var currentPixel = pixel;
            Pixel previousPixel = null;
            do
            {
                line.Pixels.Add(currentPixel);
                line.CalculateDirection(currentPixel, previousPixel);
                var nextPixel = line.NextPossibleLineParts(currentPixel, previousPixel, linePartPixels).FirstOrDefault();
                previousPixel = currentPixel;
                currentPixel = nextPixel;
            } while (currentPixel != null);
            return line;
        }
        private IEnumerable<Pixel> FilterLinePartPixels(IEnumerable<Pixel> pixels)
        {
            return pixels.Where(pixel => pixel.IsLinePart).ToList();
        }
    }
}
