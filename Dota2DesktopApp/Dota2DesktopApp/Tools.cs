using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;

namespace Dota2DesktopApp
{
    class Tools
    {
        public static BitmapImage BytesToImage(byte[] bytes)
        {
            BitmapImage image = new BitmapImage();
            using(MemoryStream ms = new MemoryStream(bytes))
            {
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
            }
            return image;
        }
    }
}
