using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Packets;
using DataLibrary.Users;

namespace AstServer
{
    public class AstrandServer
    {

        private TcpListener _tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 9004);

        private List<ConnectedPlayer> _connectedPlayers { get; set; } = new List<ConnectedPlayer>();

        public ServerStorage Storage { get; set; } = new ServerStorage();

        public AstrandServer()
        {
            run();
        }

        private void run()
        {
            _tcpListener.Start();
            while (true)
            {
                _connectedPlayers.Add(new ConnectedPlayer(_tcpListener.AcceptTcpClient(), this));
            }

            //_tcpListener.Stop();
        }

        public bool getConnectedPlayer(string username, out ConnectedPlayer cP)
        {
            cP = _connectedPlayers.Where(c => c.CurrentUser != null).Where(c => c.CurrentUser.Name == username).First();

            if (cP != null)
                return true;

            return false;
        }
    }
}
