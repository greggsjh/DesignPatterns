using System.Text;

namespace DesignPatterns.AdapterAndFacadePattern.AdapterPattern
{
    public class TurkeyAdapter : IDuck
    {
        private ITurkey _turkey;
        public TurkeyAdapter(ITurkey turkey)
        {
            _turkey = turkey;
        }
        public string Fly()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                sb.AppendLine(_turkey.Fly());
            }
            return sb.ToString();
        }

        public string Quack()
        {
            return _turkey.Gobble();
        }
    }
}