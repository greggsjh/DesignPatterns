namespace DesignPatterns.CoreObjects.VirtualProxy
{
    public class ImageIcon : IIcon
    {
        public int Width { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Height { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void PaintIcon()
        {
            throw new System.NotImplementedException();
        }
    }
}