using System.Collections.Generic;
using System.Linq;

namespace FindLines.BusinessObjects
{
    public class Line : Form
    {
        public Line()
        {
            Direction = new Pixel(0, 0);
        }

        public IEnumerable<Pixel> EndPoints
        {
            get { return new List<Pixel> { Pixels.First(), Pixels.Last() }; }
        }
        public Pixel Direction { get; set; }

        public void CalculateDirection(Pixel currentPixel, Pixel previousPixel)
        {
            if (currentPixel == null || previousPixel == null) return;
            var direction = currentPixel.Distance(previousPixel);
            if (direction.X != 0 && Direction.X == 0) Direction.X = direction.X;
            if (direction.Y != 0 && Direction.Y == 0) Direction.Y = direction.Y;
        }
        public bool IsPixelEndPoint(Pixel pixel, IEnumerable<Pixel> linePartPixels)
        {
            return pixel.SelectNeighbours(linePartPixels).Count() <= 1;
        }
        public IEnumerable<Pixel> NextPossibleLineParts(Pixel currentPixel, Pixel previousPixel, IEnumerable<Pixel> pixels)
        {
            var neighbours = currentPixel.SelectNeighbours(pixels).Where(pixel => !pixel.Equals(previousPixel)).ToList();
            if ((previousPixel == null && neighbours.Count() <= 2) || Direction.X == 0 || Direction.Y == 0) return neighbours;
            var possibleDirections = CalculatePossibleDirections(currentPixel);
            return neighbours.Where(neighbour => possibleDirections.Contains(neighbour));
        }
        private IEnumerable<Pixel> CalculatePossibleDirections(Pixel pixel)
        {
            return new List<Pixel>()
            {
                 pixel.Add(Direction),
                 pixel.Add(new Pixel(Direction.X,0)),
                 pixel.Add(new Pixel(0,Direction.Y)),
            };
        }

        public override bool Equals(object obj)
        {
            foreach (var endPoint in (obj as Line)?.EndPoints)
                if (!Pixels.Contains(endPoint)) return false;
            return true;
        }
        public override string ToString()
        {
            return string.Join(" ", EndPoints);
        }
    }
}
