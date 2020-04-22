using System.Collections.Generic;

namespace FindLines.BusinessObjects
{
    public abstract class Form
    {
        public Form()
        {
            Pixels = new List<Pixel>();
        }

        public IList<Pixel> Pixels { get; set; }
    }
}
