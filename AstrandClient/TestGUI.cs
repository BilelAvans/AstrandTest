using DataLibrary;
using DataLibrary.Packets;
using DataLibrary.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DataLibrary.Tests.AstrandWrapper;

namespace AstrandClient
{
    public partial class TestGUI : Form
    {

        public AstrandWrapper Test { get; set; }
        public Bike Bike { get; set; } = new BikeSim();

        public List<AstrandHistory> History = new List<AstrandHistory>();

        public delegate void runner();

        private PacketClient Client;
        
        public TestGUI(LoginPacket p, PacketClient client)
        {
            InitializeComponent();

            this.Client = client;

            History = p.getHistory();

            //newSession(new AstrandHistory("a", DateTime.Now, DateTime.Now.AddMinutes(6), new List<Measurement>(), new AstrandResults(true, 70, 135, 100, 25)));

            loadOptionsIntoTrainingsList();
            
        }

        public void GotMeasurement_Event(object sender, EventArgs args)
        {
            Measurement mes = sender as Measurement;

            if (mes != null)
            {
                // Set time at label
                runner du = () =>
                {
                    setMeasurementToLabels(mes);
                };

                if (currentTimeLabel.InvokeRequired)
                    currentTimeLabel.Invoke(du);
                else
                    du();
                

                (tabControl1.TabPages[0].Controls[0] as TestResultPanel).addMeasurement(mes, false);
            }
        }
        // Add session to client 
        // and send to server
        private void newSession(AstrandHistory h)
        {
            this.Client.sendPacket(new AstrandHistoryPacket(h, AstrandHistoryPacket.CommandType.NEW_HISTORY));
            History.Add(h);
            loadOptionsIntoTrainingsList();
        }

        private void Results_Saved(object sender, EventArgs args)
        {
            loadOptionsIntoTrainingsList();
        }

        private void loadOptionsIntoTrainingsList()
        {
            //History = AstrandHistory.GetHistory();

            trainingsListView.Clear();
            History.ForEach(his =>
            {
                var item = trainingsListView.Items.Add(his.Name);
                
            });

        }

        private void connectToBikeButton_Click(object sender, EventArgs e)
        {
            // Try connecting
            Debug.WriteLine("Try connect");
            var b = Bike.Connect();
            Debug.WriteLine(b);

            if (b)
                bikeConnectionStatusLabel.Text = "Connected";
             else
                bikeConnectionStatusLabel.Text = "Connection Failed";
            

        }

        private void startTestButton_Click(object sender, EventArgs e)
        {
            // Bike started?
            if (Bike.Connect())
            {
                tabControl1.TabPages.Clear();

                tabControl1.TabPages.Add(addTrainingTab());

                Bike.SetTime(00);
                // User data filled in?
                int age, weight;

                bool b = Int32.TryParse(weightTextBox.Text, out weight);
                b = Int32.TryParse(ageTextBox.Text, out age) && b;

                if (b && age > 0 && weight > 0 && sexComboBox.SelectedItem != null)
                {
                    // Test selected?
                    try
                    {
                        // Generate test
                        AstrandWrapper astrand = new AstrandWrapper(Bike, AstrandLibrary.CreateDataLibraryOne());
                        astrand.Handler += GotMeasurement_Event;
                        astrand.NewRequirements += Astrand_NewRequirements;
                        astrand.Done += Astrand_Done;

                        this.Test = astrand;
                        // Start test
                        astrand.Start();
                    }
                    catch (Exception) { }
                }
            }


        }

        private void Astrand_NewRequirements(object sender, EventArgs e)
        {
            AstrandPeriod aPeriod = sender as AstrandPeriod;

            if (aPeriod != null)
            {
                Action a = () => setAstrandPeriodData(aPeriod);

                if (this.InvokeRequired)
                    this.Invoke(a);
                else
                    a();
            }
        }

        private void Astrand_Done(object sender, EventArgs e)
        {
            AstrandWrapper astrand = sender as AstrandWrapper;

            if (astrand != null)
            {
                Action doStuff = () =>
                {
                    // User data filled in?
                    int age, weight;

                    bool b = Int32.TryParse(weightTextBox.Text, out weight);
                    b = Int32.TryParse(ageTextBox.Text, out age) && b;
                    
                    string gender = sexComboBox.SelectedItem.ToString();

                    if (b && age > 0 && weight > 0 && gender != "")
                    {
                        try
                        {
                            TestResultPanel resultPanel = (tabControl1.TabPages[0].Controls[0] as TestResultPanel);
                            AstrandResults results = astrand.endTest(age, weight, gender == "Female");
                            resultPanel.setResult(results);


                            // send results to server
                            newSession(resultPanel._history);

                            loadOptionsIntoTrainingsList();

                        }
                        catch (Exception ex)
                        {
                            Console.Write(ex.Message);
                        }
                    }
                };

                if (this.InvokeRequired)
                    this.Invoke(doStuff);
                else
                    doStuff();

            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Test.Stop();
        }

        private void pauseTestButton_Click(object sender, EventArgs e)
        {
            if (Test != null)
            {

                if (!Test.Paused)
                    pauseTestButton.Text = "UnPause";
                else
                    pauseTestButton.Text = "Pause";

                runStatusLabel.Text = Test.Status.ToString();
                Test.Paused = !Test.Paused;
                
            }
        }

        private void trainingsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set correct tab pages

        }

        private TabPage addTrainingTab(AstrandHistory his)
        {
            TabPage page = new TabPage();

            TestResultPanel panel = new TestResultPanel(his);
            panel.ResultsSaved += Results_Saved;

            page.Controls.Add(panel);

            return page;
        }

        private TabPage addTrainingTab()
        {
            TabPage page = new TabPage();

            TestResultPanel panel = new TestResultPanel();
            panel.ResultsSaved += Results_Saved;

            page.Controls.Add(panel);

            return page;
        }

        private void setAstrandPeriodData(AstrandPeriod aPeriod)
        {
            // Current data
            requiredPowerLabel.Text = aPeriod.requestedPower.ToString();
            requiredHeartRateLabel.Text = aPeriod.pulse.ToString();
            requiredRPMLabel.Text = aPeriod.rpm.ToString();

            // Required stats (Required rpm, etc..)

        }

        private Queue<AstrandPeriod> getTestFromListView()
        {

            if (trainingsListView.SelectedItems.Count > 0)
            {
                string itemname = trainingsListView.SelectedItems[0].Text;

                // Do something with item
            }
                        
            throw new NullReferenceException("No training was selected or found");
        }

        private void trainingsListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Console.WriteLine("Training ListView ItemSelection");
            if (sender != null && e.IsSelected)
            {

                if (Test != null && Test.Status == RunStatus.RUNNING)
                    Test.Stop();

                string historyName = trainingsListView.SelectedItems[0].Text.Split(' ').Last(t => !String.IsNullOrEmpty(t));
                History[0].Results.setWatts(100);
                
                tabControl1.TabPages.Clear();
                if (tabControl1.TabPages.Count == 0)
                    tabControl1.TabPages.Add(addTrainingTab(History.First((AstrandHistory h) => h.Name.Contains(historyName))));
                else
                    tabControl1.TabPages[0] = addTrainingTab(History.First((AstrandHistory h) => h.Name.Contains(historyName)));

                Console.WriteLine("Got meas");

            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            bool match = false;

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                foreach (ListViewItem item in trainingsListView.Items)
                {
                    if (item.Bounds.Contains(new Point(e.X, e.Y)))
                    {
                        MenuItem i = new MenuItem("Delete " + item.Text);
                        i.Tag = item;
                        i.Click += I_Click;
                        
                        trainingsListView.ContextMenu = new ContextMenu(new MenuItem[] { i });
                        //Client.sendPacket(new AstrandHistoryPacket(History.First(h => h.Name == item.Text), AstrandHistoryPacket.CommandType.DELETE_HISTORY));
                        match = true;
                        break;
                    }
                }
                if (match)
                {
                    trainingsListView.ContextMenu.Show(trainingsListView, new Point(e.X, e.Y));
                }
                else
                {
                    //Show listViews context menu
                }

            }

        }

        private void I_Click(object sender, EventArgs e)
        {

            MenuItem item = sender as MenuItem;
            
            if (item != null)
            {
                AstrandHistory history = History.First(his => his.Name == ((ListViewItem)item.Tag).Text);
                if (history != null)
                {
                    //history.delete();
                    Client.sendPacket(new AstrandHistoryPacket(history, AstrandHistoryPacket.CommandType.DELETE_HISTORY));
                    History.Remove(history);
                    trainingsListView.Items.Remove((ListViewItem)item.Tag);

                    // send delete astrand history packet
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        public void setMeasurementToLabels(Measurement m)
        {
            // Set last value labels to match last measurement obtained through this method
            currentHeartRateLabel.Text = m.Pulse.ToString();
            currentPowerLabel.Text = m.Act_power.ToString();
            currentRPMLabel.Text = m.Rpm.ToString();

            currentTimeLabel.Text = m.Time.Minutes + " " + m.Time.Seconds;
        }

        private void SimulationTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Change Simulation Type
            string item = (sender as ComboBox).Text as string;

            if (item != null)
            {
                if (item == "Bike")
                    Bike = new Bike();
                else if (item == "Simulator")
                    Bike = new BikeSim();
            }

        }
    }
}
