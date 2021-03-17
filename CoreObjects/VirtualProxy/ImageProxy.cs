using System;

namespace DesignPatterns.CoreObjects.VirtualProxy
{
    public class ImageProxy : IIcon
    {
        private string _url;
        public ImageIcon ImageIcon { get; set; }

        public int Width
        {
            get
            {
                if (ImageIcon != null)
                {
                    return ImageIcon.Width;
                }
                return 800;
            }
            set => throw new NotImplementedException();
        }

        public int Height
        {
            get
            {
                if (ImageIcon != null)
                {
                    return ImageIcon.Height;
                }
                return 600;
            }
            set => throw new NotImplementedException();
        }

        public ImageProxy(string url)
        {
            _url = url;
        }
        public void PaintIcon()
        {
            throw new System.NotImplementedException();
        }
    }
}