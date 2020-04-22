using FindLines.BusinessObjects;
using System.Collections.Generic;

namespace FindLines.Interfaces
{
    public interface IFormSearcher<T> where T: Form
    {
        IEnumerable<T> Search(IEnumerable<Pixel> pixels);
    }
}
