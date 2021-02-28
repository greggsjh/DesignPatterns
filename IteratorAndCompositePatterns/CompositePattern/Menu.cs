namespace DesignPatterns.IteratorAndCompositePatterns.CompositePattern
{
    public class Menu : MenuComponent
    {
        public override string Print()
        {
            return base.Print();
        }

        public override void Remove(MenuComponent menuComponent)
        {
            base.Remove(menuComponent);
        }

        public override void Add(MenuComponent menuComponent)
        {
            base.Add(menuComponent);
        }

        public override MenuComponent GetChild(int index)
        {
            return base.GetChild(index);
        }
    }

}