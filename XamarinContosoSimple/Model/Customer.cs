using System;
using System.Json;
using System.Collections.Generic;

namespace EvolveListView.Model
{
	public class Customer
	{
		public Customer ()
		{
			Sessions = new List<Appointment> ();
		}

		public string Company  { get; set; }

		public int Id { get; set; }

		public string Name { get; set; }

		public string TwitterHandle { get; set; }

		public string Bio { get; set; }

		public string HeadshotUrl { get; set; }

		public List<Appointment> Sessions { get; set; }
	}
}

