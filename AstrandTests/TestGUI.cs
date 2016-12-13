using InterlinkLibrary;
using InterlinkLibrary.Tests;
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
using static InterlinkLibrary.Tests.AstrandWrapper;

namespace AstrandTest
{
    public partial class TestGUI : Form
    {

        public AstrandWrapper Test { get; set; }
        public Bike Bike { get; set; } = new BikeSim();

        public List<AstrandHistory> History = new List<AstrandHistory>();

        public delegate void runner();
        
        public TestGUI()
        {
            InitializeComponent();

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
                    currentTimeLabel.Text = mes.Time.Minutes + " " + mes.Time.Seconds;
                };

                if (currentTimeLabel.InvokeRequired)
                    currentTimeLabel.Invoke(du);
                else
                    du();
                

                (tabControl1.TabPages[0].Controls[0] as TestResultPanel).addMeasurement(mes, false);
            }
        }

        private void Results_Saved(object sender, EventArgs args)
        {
            loadOptionsIntoTrainingsList();
        }

        private void loadOptionsIntoTrainingsList()
        {
            History = AstrandHistory.GetHistory();

            trainingsListView.Clear();
            History.ForEach(his =>
            {
                var item = trainingsListView.Items.Add(his.Name);
                
            });

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
            // Bike started?
            if (!Bike.IsConnected)
                Bike.Connect();

            tabControl1.TabPages.Clear();

            tabControl1.TabPages.Add(addTrainingTab());

            Bike.SetTime(00);
            // User data filled in?
            int age, weight;

            bool b = Int32.TryParse(weightTextBox.Text, out weight);
            b = Int32.TryParse(ageTextBox.Text, out age) && b;
            
            if (b && age > 0 && weight > 0 && sexComboBox.SelectedItem != null)
            {
                Console.WriteLine("Starting test");
                // Test selected?
                try
                {
                    // Generate test
                    AstrandWrapper astrand = new AstrandWrapper(Bike, AstrandLibrary.CreateInterlinkLibraryOneShort());
                    astrand.Handler += GotMeasurement_Event;
                    astrand.Done += Astrand_Done;

                    this.Test = astrand;
                    // Start test
                    astrand.Start();
                    

                }
                catch (Exception) { }
            }
        }

        private void Astrand_Done(object sender, EventArgs e)
        {
            AstrandWrapper astrand = sender as AstrandWrapper;

            if (astrand != null)
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
                        AstrandResults results = astrand.endTest(age, weight, gender == "female");
                        (tabControl1.TabPages[0].Controls[0] as TestResultPanel).setResult(results);

                    } catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                    }
                }
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
                Test.Paused = !Test.Paused;

                runStatusLabel.Text = Test.Status.ToString();
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
            currentPowerLabel.Text = aPeriod.requestedPower.ToString();
            currentHeartRateLabel.Text = aPeriod.pulse.ToString();
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


            if (sender != null && e.IsSelected)
            {
                if (Test != null && Test.Status == RunStatus.RUNNING)
                    Test.Stop();

                string historyName = trainingsListView.SelectedItems[0].Text;
                //Console.WriteLine
                tabControl1.TabPages.Clear();
                if (tabControl1.TabPages.Count == 0)
                    tabControl1.TabPages.Add(addTrainingTab(History.First(h => h.Name.EndsWith(historyName))));
                else
                    tabControl1.TabPages[0] = addTrainingTab(History.First(h => h.Name.EndsWith(historyName)));

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
                        MenuItem i = new MenuItem("Delete "+ item.Text);
                        i.Tag = item;
                        i.Click += I_Click;
                        
                        trainingsListView.ContextMenu = new ContextMenu(new MenuItem[] { i });
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
                    history.delete();
                    History.Remove(history);
                    trainingsListView.Items.Remove((ListViewItem)item.Tag);
                }
            }
        }
    }
}
