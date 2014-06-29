using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Threading.Tasks;
using AMSClients.Model;
using AMSClients.Views;


namespace AMSClients
{
    public class App
    {

  
        /// <summary>
        ///   Returns the startup page.
        /// </summary>
        /// <returns>The main page.</returns>
        public static Page GetMainPage()
        {

            //returns a contentpage
            NavigationPage mainNav = new NavigationPage(new VideoListPage());
            return mainNav;


        }



        #region "Set Videos List"
        /// <summary>
        ///   Returns the startup page.
        /// </summary>
        /// <returns>The main page.</returns>

        static ObservableCollection<Video> _videos;
        public static ObservableCollection<Video> Videos
        {
            get
            {
                if (_videos != null)
                {
                    return _videos;
                }
                List<Video> list = new List<Video>
                                      {
                                          new Video { Url = "http://erik.origin.mediaservices.windows.net/0406c135-3c65-45f9-a088-cce323cc55ee/617a9594-f351-4e23-9f1b-c133752cd182.ism/Manifest(format=m3u8-aapl)" },
                                          new Video { Url = "http://wams.edgesuite.net/media/MPTExpressionData02/BigBuckBunny_1080p24_IYUV_2ch.ism/manifest(format=m3u8-aapl)"}                                       
                                      };

                _videos = new ObservableCollection<Video>(list.OrderBy(e => e.Url));
                return _videos;
            }
        }
        #endregion



    }
}
