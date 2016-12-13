using DataLibrary.Network;
using DataLibrary.Packets;
using DataLibrary.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary.Users;

namespace AstServer
{
    public class ConnectedPlayer
    {

        public delegate void DoVoid();

        private TcpClient _client;

        private BackgroundWorker _thread;

        private AstrandServer Server { get; set; }

        public User CurrentUser { get; set; }

        public ConnectedPlayer(TcpClient client, AstrandServer server)
        {
            this._client = client;
            this.Server = server;

            Console.WriteLine("Connected client");

            setThread();
        }

        public void setThread()
        {
            _thread = new BackgroundWorker();
            _thread.WorkerSupportsCancellation = true;
            _thread.WorkerReportsProgress = true;
            _thread.DoWork += _thread_DoWork;

            _thread.RunWorkerAsync();
        }
        
        public void stopThread()
        {
            _thread.CancelAsync();
        }

        public void doWhilePaused(DoVoid dv)
        {

            stopThread();

            dv();

            setThread();
            
        }

        public void sendPacket(Packet p)
        {
            DoVoid runner = () =>
            {
                Traffic.sendObject(p, _client.GetStream());
            };

            doWhilePaused(runner);
        }

        private void _thread_DoWork(object sender, DoWorkEventArgs e)
        {
            // Receive and send stuff
            while (!e.Cancel)
            {
                Thread.Sleep(250);

                if (_client.Available > 0)
                {
                    try
                    {
                        handleObject(Traffic.readObject(_client.GetStream()));
                    } catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                    }
                }
            }
        }

        private void handleObject(object o)
        {

            Packet pack = o as Packet;
            if (pack != null)
            {
                
                if (pack is LoginPacket)
                {
                    LoginPacket lPack = pack as LoginPacket;
                    lPack.A = Server.Storage.UserMan.AllUsers.Exists(u => u.Name == (string)lPack.data[0] && u._password == (string)lPack.data[1]);

                    if (lPack.A)
                    {
                        CurrentUser = Server.Storage.UserMan.AllUsers.First(u => u.Name == (string)lPack.data[0]);
                        lPack.data[2] = (User)CurrentUser;
                    }

                    Traffic.sendObject(lPack, _client.GetStream());

                }
            }


        }
    }
}
