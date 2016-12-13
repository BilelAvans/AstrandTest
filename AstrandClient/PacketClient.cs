using DataLibrary.Network;
using DataLibrary.Packets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AstrandClient
{
    public class PacketClient: BackgroundWorker
    {

        public event EventHandler PacketNotifier;

        private TcpClient _tcpClient = new TcpClient();

        public PacketClient()
        {
            this.WorkerReportsProgress = true;
            this.WorkerSupportsCancellation = true;
            this.DoWork += PacketClient_DoWork;
            
        }

        public async Task Start()
        {

            this.RunWorkerAsync();

            if (!_tcpClient.Connected)
                await this.Connect("127.0.0.1", 9004);
        }

        public void Stop()
        {
            this.CancelAsync();
        }

        private void PacketClient_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!e.Cancel)
            {
                //Thread.Sleep(100);

                if (_tcpClient.Connected)
                {
                    if (_tcpClient.Available > 0)
                    {
                        handlePacket(Traffic.readObject(_tcpClient.GetStream()));
                    }
                }
                
            }
        }

        private void handlePacket(object v)
        {
            Packet packet = v as Packet;

            if (packet != null)
            {
                PacketNotifier?.Invoke(v, new EventArgs());

                //if (packet is ???)
                //{

                //}
            }
        }

        public void sendPacket(object o)
        {
            Traffic.sendObject(o, _tcpClient.GetStream());
            
        }

        public object receivePacket()
        {
            object ob = Traffic.readObject(_tcpClient.GetStream());
            return ob;
        }

        public async Task<object> sendAndReceiveWhileRunning(Packet p)
        {
            Console.WriteLine("hi");
            bool restart = this.IsBusy;
            Console.WriteLine("hi");
            if (restart)
                Stop();

            sendPacket(p);
            object ob = receivePacket();

            Console.WriteLine("hi");
            if (restart)
                await Start();

            return ob;
        }

        public async Task Connect(string ip, int port)
        {
            IPAddress adres;
            bool gotIP = IPAddress.TryParse(ip, out adres);

            if (gotIP) {
                await _tcpClient.ConnectAsync(adres, port);
                //this.RunWorkerAsync();
            }
        }
        


    }
}
