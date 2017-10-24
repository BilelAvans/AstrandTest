using DataLibrary.Tests;
using DataLibrary;
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
using System.Windows.Forms.DataVisualization.Charting;
using static DataLibrary.Tests.AstrandWrapper;
using static System.Windows.Forms.TabControl;
using Newtonsoft.Json;

namespace AstrandClient
{
    public partial class TestResultPanel : UserControl
    {
        public delegate void Runner();

        private bool IsLocked { get { return _history != null; } }

        public AstrandHistory _history { get; set; }

        private List<Measurement> _measurements = new List<Measurement>();

        private AstrandResults _result;

        public event EventHandler ResultsSaved;

        public TestResultPanel()
        {
            InitializeComponent();

            configCharts();
            
        }

        public TestResultPanel(AstrandHistory history): this()
        {
            this._history = history;
            
            setPanelFromHistory(history);
        }

        private void setPanelFromHistory(AstrandHistory history)
        {
            Console.WriteLine("Setpanelfromhistory");
            _history.Measurements.ForEach(m => addMeasurement(m, true));
            setResult(_history.Results);

        }

        private void configCharts()
        {
            Runner run = () =>
            {
                
                chart1.Series[0].IsXValueIndexed = true;
                chart1.Series[2].IsXValueIndexed = true;
                chart1.Series[2].IsXValueIndexed = true;

                chart1.ChartAreas[0].AxisX.Interval = 10;
                chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
                chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
                chart1.ChartAreas[0].AxisX.Maximum = 15;
                chart1.ChartAreas[0].AxisX.IsStartedFromZero = false;

            };

            if (chart1.InvokeRequired)
                chart1.Invoke(run);
            else
                run();
        }

        public void addMeasurement(Measurement m, bool fromHistory)
        {
            if (!fromHistory)
                _measurements.Add(m);
            
            Runner run = () =>
            {

                chart1.Series[0].Points.AddXY(m.Time.ToString(@"mm\:ss"), m.Pulse);
                chart1.Series[1].Points.AddXY(m.Time.ToString(@"mm\:ss"), m.Act_power);
                chart1.Series[2].Points.AddXY(m.Time.ToString(@"mm\:ss"), m.Rpm);

                if (chart1.Series[0].Points.Count > 10)
                {
                    chart1.Series[0].Points.RemoveAt(0);

                }
                if (chart1.Series[1].Points.Count > 10)
                    chart1.Series[1].Points.RemoveAt(0);
                if (chart1.Series[2].Points.Count > 10)
                    chart1.Series[2].Points.RemoveAt(0);

                chart1.ChartAreas[0].RecalculateAxesScale();
            };

            if (chart1.InvokeRequired)
                chart1.Invoke(run);
            else
                run();

        }

        public TestResultPanel setResult(AstrandResults result)
        {
            Runner Do = () =>
            {
                Console.WriteLine("Set results");
                resultLabel.Text = result.ToString();
                this._result = result;
            };

            if (resultLabel.InvokeRequired)
                resultLabel.Invoke(Do);
            else
                Do();

            return this;
        }

        private void saveToHistory()
        {
            //string filename = 
            //_history = new AstrandHistory(_history.Name, DateTime.Now, DateTime.Now, _measurements, _result);
            //Console.WriteLine("Saved? " + _history.saveFile());
            Saved(_history);

            sendHistoryToServer(_history);
        }

        private void sendHistoryToServer(AstrandHistory hist)
        {
            var a = JsonConvert.SerializeObject(hist);

            Debug.WriteLine(a);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveToHistory();
        }

        private void Saved(AstrandHistory his)
        {
            ResultsSaved?.Invoke(his, new EventArgs());
        }
    }
}
