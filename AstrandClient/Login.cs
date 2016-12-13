using DataLibrary.Packets;
using DataLibrary.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstrandClient
{
    public partial class Login : Form
    {

        private PacketClient Client = new PacketClient();
        
        public Login()
        {
            InitializeComponent();

            Action action = async () => await doStuff();

            action();

            new Task(async () => await tryLogin("a", "b")).ConfigureAwait(true);
        }

        public async Task doStuff()
        {
            await Client.Connect("127.0.0.1", 9004);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text != "" && passwordTextBox.Text != "")
            {
                // Attempt login
                await tryLogin(usernameTextBox.Text, passwordTextBox.Text);
            }
        }

        private async Task tryLogin(string username, string pwd)
        {
            Console.WriteLine("hi");
            LoginPacket lPacket = new LoginPacket(usernameTextBox.Text, passwordTextBox.Text);

            LoginPacket lPack = await Client.sendAndReceiveWhileRunning(lPacket) as LoginPacket;
            Console.WriteLine("hi");
            if (lPack != null)
            {
                if (lPack.A)
                {
                    Console.WriteLine("hi");
                    // Nav to main lobby
                    TestGUI gui = new TestGUI();
                    gui.ShowDialog();
                    this.Dispose();
                }
            }
        }
    }
}
