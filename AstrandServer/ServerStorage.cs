using DataLibrary.Users;
using DataLibrary.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstServer
{
    public class ServerStorage
    {

        public ServerStorage() { }

        public UserManager UserMan { get; set; } = new UserManager();

        

    }
}
