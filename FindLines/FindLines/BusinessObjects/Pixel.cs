using FindLines.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FindLines.BusinessObjects
{
    public class Pixel
    {
        private const string POINT_STRING_FORMAT = "({0},{1})";
        private const int NEIGHBOUR_DISTANCE = 1;

        public Pixel(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public PointColorEnum Color { get; set; }
        public bool IsLinePart
        {
            get { return Color == PointColorEnum.Black; }
        }

        public Pixel Add(Pixel point)
        {
            return new Pixel(X + point.X, Y + point.Y);
        }
        public Pixel Distance(Pixel point)
        {
            if (point == null) return new Pixel(0, 0);
            return new Pixel(X - point.X, Y - point.Y);
        }
        public IEnumerable<Pixel> SelectNeighbours(IEnumerable<Pixel> pixels)
        {
            return pixels
                .Where(pixel => pixel != this &&
                    Math.Abs(X - pixel.X) <= NEIGHBOUR_DISTANCE &&
                    Math.Abs(Y - pixel.Y) <= NEIGHBOUR_DISTANCE)
                .ToList();
        }

        public override bool Equals(object obj)
        {
            return (obj as Pixel)?.X == X &&
                (obj as Pixel)?.Y == Y;
        }
        public override string ToString()
        {
            return string.Format(POINT_STRING_FORMAT, X, Y);
        }
    }
}
