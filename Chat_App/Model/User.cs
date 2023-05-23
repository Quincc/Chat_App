using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_App.Model
{
	public class User
	{
		private string _id;

		public User(string id, string name)
		{
			_id = id;
			Name = name;
		}

		public string Name { get;set; }
		public string Get_Id()
		{ return _id; }
	}
}
