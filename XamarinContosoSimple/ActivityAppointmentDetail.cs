using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace EvolveListView
{
	/// <summary>
	/// This is a pre-built single-Customer display screen, to demonstrate 
	/// starting a new activity with an Intent. It's not really part of the
	/// ListView training per se.
	/// </summary>
	[Activity (Label = "Appointment Detail")]
	public class ActivityAppointmentDetail : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			
			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.session_screen);

			var title = Intent.Extras.GetString ("Title");

			FindViewById<TextView> (Resource.Id.sessionTitleTextView).Text = title;
			// Exercise: populate the other fields :)
			// you could pass them all via PutString and GetString, 
			// or look up the Customer data again from this method
		}
	}
}