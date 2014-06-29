using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using System;
using AMSClients.Model;
using AMSClients.Style;

namespace AMSClients.Views
{
    class VideoListPage: ContentPage
    {
        StackLayout _stackLayout;
        ListView _videoListView;

        ObservableCollection<Video> _videos = new ObservableCollection<Video>();
        
 
        public VideoListPage()
        {
            LoadVideos();
            Title = "Video List";
            LoadVideosView();
            Content = _stackLayout;
        }


        void LoadVideos()
        {
                if (_videos.Count == 0)
                {
                    _videos = App.Videos;
                }
        }
         

        void LoadVideosView()
        {
             _videoListView = new ListView
                            {
                                RowHeight = 50,
                                ItemTemplate = new DataTemplate(typeof(VideoCell))
                            };

            _videoListView.ItemSelected += VideoListOnItemSelected;


            // Create a grid to hold the Labels & Entry controls.
            Grid inputGrid = new Grid
            {
                ColumnDefinitions =
                                 {
                                     new ColumnDefinition { Width = GridLength.Auto },
                                 },
                Children =
                                 {
                                     { new Label { Text = "Videos List:", Font = Fonts.Title, TextColor = Colours.SubTitle }, 0, 0 },
                                     }
            };


            // Add the controls to a StackLayout 
            _stackLayout = new StackLayout
            {
                Children =
                          {
                              inputGrid,
                              _videoListView
                          }
            };
        }

        /// <summary>
        /// TODO: This method is invoked when the user selects an video. Will open up the Detail for that video as well as the plater.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="eventArg">Event argument.</param>
        async void VideoListOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView listView = (ListView)sender;
            if (listView.SelectedItem == null)
            {
                return;
            }

            await Navigation.PushAsync(new VideoDetailPage((Video)e.SelectedItem));
            listView.SelectedItem = null;
        }

        /// <summary>
        ///   Helper method that will create a Xamarin.Forms Entry control on the screen.
        /// </summary>
        /// <returns>A Xamarin.Forms Entry control.</returns>
        /// <param name="propertyName">The name of the property to bind to.</param>
        View CreateEntryFor(string propertyName)
        {
            Entry input = new Entry
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            input.SetBinding(Entry.TextProperty, propertyName);
            return input;
        }

        protected override void OnAppearing()
        {
            // This method is invoked by Xamarin.Forms at some point when the 
            // page is being displayed.
            base.OnAppearing();
            LoadVideos();
            _videoListView.ItemsSource = _videos;
        }
    }
}
