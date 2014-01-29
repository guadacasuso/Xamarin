
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
	[Activity (Label = "My Customers", Icon="@drawable/ic_launcher")]			
	public class ActivityMyCustomers : ListActivity
	{
		private AdapterMyCustomers adapter;
		private List<Customer> speakers;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			speakers = GetSpeakerData ();
			adapter = new AdapterMyCustomers(this, speakers);
			ListView.Adapter = adapter;

			ListView.FastScrollEnabled = true;
		}

		/// <summary>
		/// Demonstrates how to handle a row click
		/// </summary>
		protected override void OnListItemClick(ListView l, View v, int position, long id)
		{
			var speakerName = adapter[position].Name;
			//TODO: Demo6: this is how we start the next screen
			var intent = new Intent(this, typeof(ActivityCustomerDetail));
			intent.PutExtra("Name", speakerName);
			StartActivity(intent);
		}

		/// <summary>
		/// Helper method to populate our speaker data, 
		/// </summary>
		protected List<Customer> GetSpeakerData()
		{
			return new List<Customer> () {
				new Customer { Name = "John Zablocki", Company = "Contoso", HeadshotUrl = "images/speakers/john_zablocki.jpg", TwitterHandle ="codevoyeur" },
				new Customer { Name = "Miguel de Icaza", Company = "Contoso", HeadshotUrl = "images/speakers/miguel.jpg", TwitterHandle ="migueldeicaza"},
				new Customer { Name = "Aaron Bockover", Company = "Contoso", HeadshotUrl = "images/speakers/aaron.jpg", TwitterHandle ="abock" },
				new Customer { Name = "John Bubriski", Company = "Contoso", HeadshotUrl = "images/speakers/john_bubriski.jpg", TwitterHandle ="johnbubriski" },
				new Customer { Name = "Paul Betts", Company = "Contoso", HeadshotUrl = "images/speakers/paul.jpg", TwitterHandle ="xpaulbettsx" },
				new Customer { Name = "Louis DeJardin", Company = "Contoso", HeadshotUrl = "images/speakers/louis.jpg", TwitterHandle ="loudej" },
				new Customer { Name = "Scott Olson", Company = "Contoso", HeadshotUrl = "images/speakers/scott.jpg", TwitterHandle ="vagabondrev" },
				new Customer { Name = "Igor Moochnick", Company = "Contoso", HeadshotUrl = "images/speakers/igor.jpg", TwitterHandle ="igor_moochnick" },
				new Customer { Name = "Jérémie Laval", Company = "Contoso", HeadshotUrl = "images/speakers/jeremie.jpg", TwitterHandle ="jeremie_laval" },
				new Customer { Name = "Ananth Balasubramaniam", Company = "Contoso", HeadshotUrl = "images/speakers/ananth.jpg", TwitterHandle ="ananthonline" },
				new Customer { Name = "Bob Familiar", Company = "Contoso", HeadshotUrl = "images/speakers/bob.jpg", TwitterHandle ="bobfamiliar" },
				new Customer { Name = "Michael Hutchinson", Company = "Contoso", HeadshotUrl = "images/speakers/michael.jpg", TwitterHandle ="mjhutchinson" },
				new Customer { Name = "Jonathan Chambers", Company = "Contoso", HeadshotUrl = "images/speakers/jonathan.jpg", TwitterHandle ="jon_cham" },
				new Customer { Name = "Steve Millar", Company = "Contoso", HeadshotUrl = "images/speakers/steve.jpg", TwitterHandle ="samillar77" },
				new Customer { Name = "Somya Jain", Company = "Contoso", HeadshotUrl = "images/speakers/somya.jpg", TwitterHandle ="somya_j" },
				new Customer { Name = "Sam Lippert", Company = "Contoso", HeadshotUrl = "images/speakers/sam.jpg", TwitterHandle ="lippertz" },
				new Customer { Name = "Don Syme", Company = "Contoso", HeadshotUrl = "images/speakers/don.jpg", TwitterHandle ="dsyme" },
				new Customer { Name = "Dean Ellis", Company = "Contoso", HeadshotUrl = "images/speakers/dean.jpg", TwitterHandle ="infspacestudios" },
				new Customer { Name = "Jb Evain", Company = "Contoso", HeadshotUrl = "images/speakers/jb.jpg", TwitterHandle ="jbevain" },
				new Customer { Name = "Chris Hardy", Company = "Contoso", HeadshotUrl = "images/speakers/chris.jpg", TwitterHandle ="chrisntr" },
				new Customer { Name = "Demis Bellot", Company = "Contoso", HeadshotUrl = "images/speakers/demis.jpg", TwitterHandle ="demisbellot" },
				new Customer { Name = "Frank Krueger", Company = "Contoso", HeadshotUrl = "images/speakers/frank.jpg", TwitterHandle ="praeclarum" },
				new Customer { Name = "Greg Shackles", Company = "Contoso", HeadshotUrl = "images/speakers/greg.jpg", TwitterHandle ="gshackles" },
				new Customer { Name = "Phil Haack", Company = "Contoso", HeadshotUrl = "images/speakers/phil.jpg", TwitterHandle ="haacked" },
				new Customer { Name = "David Fowler", Company = "Contoso", HeadshotUrl = "images/speakers/david.jpg", TwitterHandle ="davidfowler" },
			};  		
		}
	}
}

