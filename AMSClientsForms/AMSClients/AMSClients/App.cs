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
                                          new Video { Url = "http://Video1", },
                                          new Video { Url = "http://Video2"}                                       
                                      };

                _videos = new ObservableCollection<Video>(list.OrderBy(e => e.Url));
                return _videos;
            }
        }
        #endregion



    }
}
