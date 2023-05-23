using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_App.Model
{
	public class Message
	{
		public Message(string msg, User sender, User Receiver, DateTime date)
		{
			Msg = msg;
			this.Sender = sender;
			this.Receiver = Receiver;
			this.Date = date;
		}
		private int id;
		public string Msg { get; set; }
		public User Sender { get; set; }
        public User Receiver { get; set; }
		public DateTime Date { get; set; }
		public void SetID(int value)
		{
			id = value;
		}
    }
}
