using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Users
{
    [Serializable]
    public class UserManager
    {

        public List<User> AllUsers { get; private set; } = new List<User>();

        public UserManager() {
            AllUsers.Add(new User("a", "b", false));
            AllUsers.Add(new User("b", "b", true));
        }
    }
}
