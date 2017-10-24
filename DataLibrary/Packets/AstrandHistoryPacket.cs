using DataLibrary.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Packets
{
    [Serializable]
    public class AstrandHistoryPacket: Packet
    {
        public enum CommandType { NEW_HISTORY, DELETE_HISTORY }

        public AstrandHistoryPacket(AstrandHistory a, CommandType command): base()
        {
            this.data = new object[2];

            this.data[0] = a;
            this.data[1] = command;
        }

        public CommandType getCommand()
        {
            try
            {
                return (CommandType)this.data[1];
            } catch (Exception)
            {
                return CommandType.DELETE_HISTORY;
            }
        }

        public bool hasHistory()
        {
            try
            {
                return ((AstrandHistory)this.data[0] != null);

            } catch (Exception)
            {
                return false;
            }
        }

        public AstrandHistory getHistory()
        {
            return (AstrandHistory)this.data[0];
        }
    }
}
