namespace DesignPatterns.CoreObjects.VirtualProxy
{
    public interface IIcon
    {
        int Width { get; set; }
        int Height { get; set; }
        void PaintIcon();
    }
}