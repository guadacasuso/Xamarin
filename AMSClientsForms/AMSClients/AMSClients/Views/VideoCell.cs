using Xamarin.Forms;

namespace AMSClients.Views
{
    /// <summary>
    ///   This class is a ViewCell that will be displayed for each video en the List
    /// </summary>
    class VideoCell : ViewCell
    {
        public VideoCell()
        {
            StackLayout urlLayout = CreateUrlLayout();
          
            StackLayout viewLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { urlLayout }
            };
            View = viewLayout;
        }


        /// <summary>
        ///   Create a layout to hold the url
        /// </summary>
        /// <returns>The url layout.</returns>
        static StackLayout CreateUrlLayout()
        {
            
            Label urlLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            urlLabel.SetBinding(Label.TextProperty, "Url");
       

            StackLayout urlLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { urlLabel }
            };
            return urlLayout;
        }
    }
}
