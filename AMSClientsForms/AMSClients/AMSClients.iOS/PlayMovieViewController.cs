using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MediaPlayer;
using AMSClients.Model;
using System.Collections.ObjectModel;


namespace AMSClients.iOS
{
	public partial class PlayMovieViewController : UIViewController
	{
		MPMoviePlayerController moviePlayer;
        ObservableCollection<Video> _videos = new ObservableCollection<Video>();

		public PlayMovieViewController () : base ("PlayMovieRecipeViewController", null)
		{
		}
        
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
            
			// Release any cached data, images, etc that aren't in use.
		}
        
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

            LoadVideos();
            playMovie.SetTitle("Azure Media Services", UIControlState.Normal);
			playMovie.TouchUpInside += delegate {
			moviePlayer = new MPMoviePlayerController (NSUrl.FromString (_videos[1].Url));
            Console.Write(_videos[1].Url);
				View.AddSubview (moviePlayer.View);
				moviePlayer.SetFullscreen (true, true);
				moviePlayer.Play ();
			};
		}

        void LoadVideos()
        {
            if (_videos.Count == 0)
            {
                _videos = App.Videos;
            }
        }
         
        
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
            
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
            
			ReleaseDesignerOutlets ();
		}
        
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

