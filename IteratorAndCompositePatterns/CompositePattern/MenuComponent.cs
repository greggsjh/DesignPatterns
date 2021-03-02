using System;

namespace DesignPatterns.IteratorAndCompositePatterns.CompositePattern
{
    public abstract class MenuComponent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsVegetarian { get; set; }
        public virtual string Print()
        {
            throw new NotImplementedException();
        }
        public virtual void Add(MenuComponent menuComponent)
        {
            throw new NotSupportedException();
        }

        public virtual void Remove(MenuComponent menuComponent)
        {
            throw new NotSupportedException();
        }

        public virtual MenuComponent GetChild(int index)
        {
            throw new NotSupportedException();
        }
    }
}