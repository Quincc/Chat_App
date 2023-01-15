using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace Chat_App.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _Nick;
        public string Nick
        {
            get { return _Nick; }
            set { _Nick = value; }
        }
        private int _Port;
        public int Port
        {
            get { return _Port; }
            set { _Port = value; }
        }
        private string _Ip;
        public string Ip
        {
            get { return _Ip; }
            set { _Ip = value; }
        }
        private string _Chat;
        public string Chat
        {
            get { return _Chat; }
            set
            {
                _Chat = value;
                OnPropertyChanged();
            }
        }
        private string _Msg;
        public string Msg
        {
            get { return _Msg; }
            set { _Msg = value; OnPropertyChanged();}
        }
        private bool _isEnableConnectButton = true;
        public bool isEnableConnectButton
        {
            get { return _isEnableConnectButton; }
            set { _isEnableConnectButton = value; OnPropertyChanged(); }
        }
        TcpClient client;
        StreamReader sr;
        StreamWriter sw;
        public MainViewModel()
        {
            Ip = "192.168.0.164";
            Port = 5050;
            Nick = "Enter Your Username:";
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    try
                    {
                        if (client?.Connected == true)
                        {
                            var line = sr.ReadLine();
                            if (line != null)
                                Chat += line + '\n';
                            else
                            {
                                client.Close();
                                Chat += "ConnectedError\n";
                            }
                        }
                        Task.Delay(10).Wait();
                    }
                    catch (Exception e)
                    {

                        throw;
                    }
                }
            });
        }
        public AsyncCommand ConnectButton
        {
            get
            {
                return new AsyncCommand(() =>
                {
                    return Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            client = new TcpClient();
                            client.Connect(Ip, Port);
                            sw = new StreamWriter(client.GetStream());
                            sr = new StreamReader(client.GetStream());
                            sw.AutoFlush = true;
                            sw.WriteLine($"Login: {Nick}");
                            isEnableConnectButton = false;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    });
                });
            }
        }
        public AsyncCommand SendCommand
        {
            get
            {
                return new AsyncCommand(() =>
                {
                    return Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            sw.WriteLine($"{DateTime.Now.ToShortTimeString()} {Nick}: {Msg}");
                            Msg = "";
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    });
                });
            }
        }
    }
}
//(x) => client.Connected == false || client == null
//(x) => client.Connected == true && !string.IsNullOrWhiteSpace(Msg)