using System.Collections;

namespace DesignPatterns.CoreObjects.IteratorPattern
{
    public interface IMenu : IEnumerable
    {
        string Name { get; }
    }
}