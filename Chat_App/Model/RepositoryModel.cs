using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Chat_App.Model
{
	internal class RepositoryModel
	{
		public static SqlConnection CreateConnection()
		{
			string connectionString = @"Server = DESKTOP-TAL5DVV; Database = ChatDB; Integrated Security = true";
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();
			return connection;
		}
		public static void Add(Message msg)
		{
			SqlConnection connection = CreateConnection();
			SqlCommand cmd = new SqlCommand("insert into TableofMsg output INSERTED.ID values(@Message, @SenderID, @ReceiverID, @Date)", connection);
			cmd.Parameters.AddWithValue("@Message", msg.Msg);
			cmd.Parameters.AddWithValue("@SenderID", msg.Sender.Get_Id());
			cmd.Parameters.AddWithValue("@ReceiverID", msg.Receiver.Get_Id());
			cmd.Parameters.AddWithValue("@Date", msg.Date);
			msg.SetID((int)cmd.ExecuteScalar());
			connection.Close();
		}
	}
}
