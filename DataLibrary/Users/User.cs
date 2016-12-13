using DataLibrary.Tests;
using DataLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataLibrary.Users
{
    [Serializable]
    public class User: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        public string Name { get { return _name; } set { _name = value; Changed("Name"); } }

        public string _password { get; private set; }

        public bool IsPhysician;

        public User user;
        

        public User(string name, string password, bool isPhysician)
        {
            this.Name = name;
            this._password = password;
            this.IsPhysician = isPhysician;
        }

        public void Changed(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override bool Equals(object obj)
        {

            User toCompare = obj as User;

            if (toCompare != null)
                return this.Name == toCompare.Name;

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public User()
        {

        }
    }
}
