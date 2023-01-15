using Server_Client;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using System.Net.Sockets;

TcpListener listener = new TcpListener(5050);
List<Client_User> clients = new List<Client_User>();
//Logger logger= LogManager.GetCurrentClassLogger();
var logger = LoggerFactory.Create(builder => builder.AddNLog()).CreateLogger<Program>();
var loggerMsg = LoggerFactory.Create(builder => builder.AddNLog()).CreateLogger<Program>();
Console.WriteLine(loggerMsg.ToString());

listener.Start();
logger.LogInformation("Server is working");

while (true)
{
    var client = listener.AcceptTcpClient();
    Task.Factory.StartNew(() =>
    {
        var sr = new StreamReader(client.GetStream());
        while (client.Connected)
        {
            var line = sr.ReadLine();
            if (line.Contains("Login: ") && !string.IsNullOrWhiteSpace(line.Replace("Login: ", "")))
            {
                var nickname = line.Replace("Login: ", "");
                if (clients.FirstOrDefault(t => t.Name == nickname) == null)
                {
                    clients.Add(new Client_User(client, nickname));
                    logger.LogInformation($"User '{nickname}' is joined to server");
                    break;
                }
                else
                {
                    var sw = new StreamWriter(client.GetStream());
                    sw.AutoFlush= true;
                    sw.WriteLine("This nickname is already taken");
                    client.Client.Disconnect(false);
                }
            }
        }

        while (client.Connected)
        {
            try
            {
                sr = new StreamReader(client.GetStream());
                var line = sr.ReadLine();
                SendMsg(line);
            }
            catch (Exception e)
            {
                logger.LogInformation(e.Message);
            }
        }
    });
}

async void SendMsg(string msg)
{
    await Task.Factory.StartNew(() =>
    {
        for (int i = 0; i < clients.Count; i++)
        {
            try
            {
                if (clients[i].Client.Connected)
                {
                    var sw = new StreamWriter(clients[i].Client.GetStream());
                    sw.AutoFlush = true;
                    sw.WriteLine(msg);
                    loggerMsg.LogInformation(msg);
                }
                else
                {
                    clients.RemoveAt(i);
                    logger.LogInformation($"{clients[i].Name} is disconnected");
                }
            }
            catch (Exception e)
            {
                logger.LogInformation(e.Message);
            }
        }
    });
}