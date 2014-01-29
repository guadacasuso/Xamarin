
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

using EvolveListView.Model;

namespace EvolveListView
{
	/// <summary>
	/// Demo 5: Add an index and fast-scrolling
	/// </summary>
	[Activity (Label = "My appointments", Icon="@drawable/ic_launcher")]			
	public class ActivityMyAppointments : ListActivity
	{
		private AdapterMyAppointments adapter;
		private List<Appointment> sessions;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			sessions = PopulateSessionData ();
			adapter = new AdapterMyAppointments(this, sessions);
			ListView.Adapter = adapter;
			ListView.FastScrollEnabled = true;
		}

		/// <summary>
		/// Demonstrates how to handle a row click
		/// </summary>
		protected override void OnListItemClick(ListView l, View v, int position, long id)
		{
			var title = adapter[position].Title;
			//TODO: Demo6: this is how we start the next screen
			var intent = new Intent(this, typeof(ActivityAppointmentDetail));
			intent.PutExtra("Title", title);
			StartActivity(intent);
		}

		/// <summary>
		/// Helper method to populate our session data
		/// </summary>
		protected List<Appointment> PopulateSessionData()
		{
			return new List<Appointment> () {
				new Appointment {Title="Discussion Insurance 1 - Customer 1",Speaker="Bryan Costanich", Location="Ballroom", Begins=new DateTime(2013,4,14,9,0,0)},
				new Appointment {Title="Discussion Insurance 2 - Customer 2",Speaker="Bryan Costanich", Location="Ballroom", Begins=new DateTime(2013,4,14,10,0,0)},
				new Appointment {Title="Discussion Insurance 3 - Customer 1",Speaker="Bryan Costanich", Location="Ballroom", Begins=new DateTime(2013,4,14,15,0,0)},

			};
		}
	}
}

