using AstrandTest.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AstrandTest.Tests.AstrandWrapper;

namespace AstrandTest
{
    public partial class TestGUI : Form
    {

        public AstrandWrapper Test { get; set; }
        public Bike Bike { get; set; } = new Bike();

        public TestGUI()
        {
            InitializeComponent();

            TabPage page = new TabPage("This Training");
            page.Controls.Add(new TestResultPanel());
            tabControl1.TabPages.Add(page);
        }
        
        private void connectToBikeButton_Click(object sender, EventArgs e)
        {
            // Try connecting
            Bike.Connect();
            var b = Bike.BikePort?.IsOpen;
            
            if (b.Value)
            {
                bikeConnectionStatusLabel.Text = "Connected";
            } else
            {
                bikeConnectionStatusLabel.Text = "Connection Failed";
            }

        }

        private void startTestButton_Click(object sender, EventArgs e)
        {
            // User data filled in?
            int age, weight;

            bool b = Int32.TryParse(weightTextBox.Text, out weight);
            b = Int32.TryParse(ageTextBox.Text, out age) && b;

            string gender = sexComboBox.SelectedText;
            
            if (b && age > 0 && weight > 0 && gender != "")
            {
                // Generate test
                AstrandWrapper astrand = new AstrandWrapper(Bike, AstrandLibrary.CreateAstrandTestOneShort());
                this.Test = astrand;
                // Start test
                astrand.Start();

                while (!astrand.CancellationPending) { }
                // We are done now
                AstrandResults results = astrand.endTest(age, weight, gender == "female");

                Console.WriteLine("Your blabla is :" + results.score);
            }

        }

        private void resetButton_Click(object sender, EventArgs e)
        {

        }

        private void pauseTestButton_Click(object sender, EventArgs e)
        {
            if (Test != null)
                Test.Paused = !Test.Paused;            
        }
    }
}
