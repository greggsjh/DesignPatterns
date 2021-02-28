using System.Collections;

namespace DesignPatterns.IteratorAndCompositePatterns.IteratorPattern
{
    public interface IMenu : IEnumerable
    {
        string Name { get; }
    }
}