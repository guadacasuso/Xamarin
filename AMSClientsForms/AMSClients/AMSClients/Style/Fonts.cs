using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AMSClients.Style
{
    static class Fonts
    {

        public static Font LargeTitle;
        public static Font Title;
        public static Font SmallTitle;


        /// <summary>
        ///   Initialize the fonts for our application. The fonts used changes from
        ///   platform to platform.
        /// </summary>
        static Fonts()
        {
            Device.OnPlatform(() =>
            {
                LargeTitle = Font.OfSize("HelveticaNeue-UltraLight", 42);
                Title = Font.OfSize("HelveticaNeue-Light", 30);
                SmallTitle = Font.OfSize("HelveticaNeue-Light", 22);
               
            }, () =>
            {
                LargeTitle = Font.SystemFontOfSize(42);
                Title = Font.SystemFontOfSize(30);
                SmallTitle = Font.SystemFontOfSize(18);
             
            }, () =>
            {
                LargeTitle = Font.SystemFontOfSize(60);
                Title = Font.SystemFontOfSize(46);
                SmallTitle = Font.SystemFontOfSize(30);
  
            }
                );
        }

        static int PlatformSize(int size)
        {
            return Device.OnPlatform(size, size, (int)(size * 1.3));
        }
    }
}



