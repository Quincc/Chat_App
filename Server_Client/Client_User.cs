using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server_Client
{
    public class Client_User
    {
        public TcpClient Client { get; set; }
        public string Name { get; set; }
        public Client_User(TcpClient client, string name)
        {
            Client = client;
            Name = name;
        }
    }
}
