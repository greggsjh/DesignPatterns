namespace DesignPatterns.AdapterAndFacadePattern.FacadePattern
{
    public class CdPlayer
    {
        public CdPlayer(string brand)
        {
            Brand = brand;
        }

        public string Brand { get; private set; }
    }
}