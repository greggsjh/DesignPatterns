using System;

namespace DesignPatterns.SingletonPattern
{
    public class ChocolateBoiler
    {
        private bool IsEmpty { get; set; }
        private bool IsBoiled { get; set; }

        //Eager instantiation
        /*
        private static readonly ChocolateBoiler _instance = new ChocolateBoiler();
        public static ChocolateBoiler Instance { get { return _instance; } }
        */

        //Lazy instantiation - Not thread-safe NEVER USE!!!
        /*
            private static ChocolateBoiler _instance;
            public static ChocolateBoiler Instance
            {
                get
                {
                    //lazy instantiation
                    if (_instance == null) 
                        _instance = new ChocolateBoiler();

                    return _instance;
                }
            }
        */

        //Lazy instantiation - Thread-safe
        /*
        private static class SingletonCreator
        {
            internal static readonly ChocolateBoiler uniqueInstance = new ChocolateBoiler();
        }

        public static ChocolateBoiler LazyInstance { get { return SingletonCreator.uniqueInstance; } }
        */

        //Lazy - Double-checked locking - Thread-safe
        private static object _sync = new object();
        private static ChocolateBoiler _instance = null;
        public static ChocolateBoiler Instance
        {
            get
            {
                if (_instance == null)//1st null check
                {
                    lock (_sync)
                    {
                        if (_instance == null) //2nd null check
                            _instance = new ChocolateBoiler();
                    }
                }
                return _instance;
            }
        }
        //Lazy - Built-in Singleton System.Lazy
        /*
        private static readonly Lazy<ChocolateBoiler> _instance = new Lazy<ChocolateBoiler>(() => new ChocolateBoiler());
        public static ChocolateBoiler Instance { get { return _instance.Value; } }
        */
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