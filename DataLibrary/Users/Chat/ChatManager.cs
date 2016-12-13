using DamLibrary.Users.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamLibrary.Users.Chat
{
    [Serializable]
    public class ChatManager
    {

        public ChatRoom LobbyChat { get; private set; } = new ChatRoom("Main Lobby", 1);

        public List<ChatRoom> Chats { get; set; } = new List<ChatRoom>();



        public ChatManager()
        {
            //Chats.Add(LobbyChat);
        }

        public ChatRoom newChat(string creator)
        {
            ChatRoom newRoom = new ChatRoom(creator, uniqueID());


            Chats.Add(newRoom);

            return newRoom;
        }
        
        public bool chatExists(string name)
        {
            return Chats.Exists(chat => chat.Name == name);
        }

        public bool chatExists(int ID)
        {
            return Chats.Exists(chat => chat.ID == ID);
        }

        public ChatRoom getChat(string name)
        {
            return Chats.Where(chat => chat.Name == name).First();
        }

        public ChatRoom getChat(int ID)
        {
            return Chats.Where(chat => chat.ID == ID).First();
        }

        public int uniqueID()
        {
            int counter = 2;

            while (Chats.Exists(c => c.ID == counter))
            {
                counter++;
            }

            return counter;
        }

        public List<string> getUsersFromChat(string name)
        {
            return Chats.First(ch => ch.Name == name).Participants;
        }
    }
}
