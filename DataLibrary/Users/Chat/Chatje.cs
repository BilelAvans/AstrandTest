using System;
using System.Collections.Generic;
using System.Text;

namespace DamLibrary.Users.Chat
{
    [Serializable]
    public class Chatje
    {
        public string Sender { get; private set; }
        public string Message { get; private set; }

        public DateTime SentOn { get; private set; }
        
        public Chatje(string Message, string sender)
        {
            this.Message = Message;
            this.Sender = sender;
            this.SentOn = DateTime.Now;
        }

    }
}
