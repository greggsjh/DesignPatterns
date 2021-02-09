namespace DesignPatterns.SingletonPattern
{
    public class ChocolateBoiler
    {
        private bool IsEmpty { get; set; }
        private bool IsBoiled { get; set; }

        private ChocolateBoiler _instance;
        public ChocolateBoiler Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ChocolateBoiler();

                return _instance;
            }
        }

        private ChocolateBoiler()
        {
            IsEmpty = true;
            IsBoiled = false;
        }

        public string Fill()
        {
            if (IsEmpty)
            {
                IsEmpty = false;
                IsBoiled = false;
                return "Fill the boiler with a milk/chocolate mixture.";
            }
            return "The boiler is already full.";
        }

        public string Drain()
        {
            if (!IsEmpty && IsBoiled)
            {
                IsEmpty = true;
                return "Drain the boiled milk and chocolate.";
            }

            return "The boiler is already empty or the mixture has not been boiled yet.";
        }

        public string Boil()
        {
            if (!IsEmpty && !IsBoiled)
            {
                IsBoiled = true;
                return "Bring the contents to a boil.";
            }
            return "The boiler is empty or the mixture is already boiling.";
        }

    }
}