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
	[Activity (Label = "Contoso Insurance", MainLauncher = true, Icon="@drawable/ic_launcher")]			
	public class ActivityMain : ListActivity
	{
		string[] items;
		
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			items = new string[] { "Login", "My Appointments", "My Clients" };
			ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
		}
		
		/// <summary>
		/// Demonstrates how to handle a row click
		/// </summary>
		protected override void OnListItemClick(ListView l, View v, int position, long id)
		{
            var intent = new Intent(this, typeof(ActivityLogin));
            if (position == 1)
                intent = new Intent(this, typeof(ActivityMyAppointments));
            else if (position == 2)
                intent = new Intent(this, typeof(ActivityMyCustomers));

			StartActivity(intent);
		}
	}
}