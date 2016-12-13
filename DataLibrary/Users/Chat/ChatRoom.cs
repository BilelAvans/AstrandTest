using System;
using System.Collections.Generic;
using System.Text;

namespace DamLibrary.Users.Chat
{
    [Serializable]
    public class ChatRoom
    {

        public string Name { get; private set; }

        private string Creator { get; set; }

        public List<string> Participants = new List<string>();

        public List<Chatje> Chats { get; set; } = new List<Chatje>();

        private int _maxUsers;

        public int ID { get; set; }
        
        public ChatRoom(string creator, int maxusers, int ID)
        {
            this.Creator = creator;
            this._maxUsers = maxusers;
            this.ID = ID;

            this.Participants.Add(creator);
        }

        public ChatRoom(string creator, int ID): this(creator, 10000, ID)
        {
        }

        public bool addToChat(User user)
        {
            if (!Participants.Contains(user.Name) && _maxUsers != Participants.Count)
            {
                this.Participants.Add(user.Name);
                return true;
            }

            return false;
        }

        public bool removeFromChat(User user)
        {
            if (Participants.Contains(user.Name))
                return Participants.Remove(user.Name);

            return false;
        }

        public bool addChat(Chatje c)
        {
            Chats.Add(c);

            return true;
        }

        public bool removeChat(Chatje c)
        {
            Chats.Remove(c);

            return true;
        }

        public List<Chatje> getChatsFrom(User u)
        {
            return Chats.FindAll(c => c.Sender == u.Name);
        }

        public List<Chatje> getChatsBetween(DateTime start, DateTime end)
        {
            return Chats.FindAll(c => c.SentOn > start && end > c.SentOn);
        }

    }
}
