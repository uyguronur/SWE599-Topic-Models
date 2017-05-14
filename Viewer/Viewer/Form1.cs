using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Viewer
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<int, Dictionary<Tuple<int, string>, double>> _categoryDistributionOverDocuments;
        private readonly Dictionary<int, IList<WordDistribution>> _wordDistributionOverCategories;
        private int _currentItr;
        private Timer _timer;

        public Form1()
        {
            InitializeComponent();
            _categoryDistributionOverDocuments = new Dictionary<int, Dictionary<Tuple<int, string>, double>>();
            _wordDistributionOverCategories = new Dictionary<int, IList<WordDistribution>>();
        }

        private void button_browse_Click(object sender, EventArgs e)
        {
            var dialogResult = folderBrowserDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                textBox_folder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            var path = textBox_folder.Text;
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show(this, "Please select a path!", "Error");
                return;
            }
            if (!Directory.Exists(path))
            {
                MessageBox.Show(this, "Please select a valid path!", "Error");
            }
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                if (file.EndsWith("_dtd.csv"))
                {
                    ParseAndLoadDtdFile(file);
                }
                else
                if (file.EndsWith("_twd.csv"))
                {
                    ParseAndLoadTwdFile(file);
                }
            }

            _currentItr = _categoryDistributionOverDocuments.Keys.Min();
            UpdateChart();
        }

        private void ParseAndLoadDtdFile(string filePath)
        {
            var fileName = Path.GetFileName(filePath);
            var itr = int.Parse(fileName.Substring(0, fileName.IndexOf("_")));

            var results = new Dictionary<Tuple<int, string>, double>();
            var lines = File.ReadAllLines(filePath);
            for (var i = 1; i < lines.Length; i++)
            {
                var values = lines[i].Split(',');
                var docName = values[0];
                for (var j = 1; j < values.Length; j++)
                {
                    results.Add(Tuple.Create(j, docName), double.Parse(values[j]));
                }
            }
            _categoryDistributionOverDocuments.Add(itr, results);
        }

        private void ParseAndLoadTwdFile(string filePath)
        {
            var fileName = Path.GetFileName(filePath);
            var itr = int.Parse(fileName.Substring(0, fileName.IndexOf("_")));

            var results = new List<WordDistribution>();
            var lines = File.ReadAllLines(filePath);
            for (var i = 1; i < lines.Length; i++)
            {
                var values = lines[i].Split(',');
                var word = values[0];
                for (var j = 1; j < values.Length; j++)
                {
                    results.Add(new WordDistribution()
                    {
                        Word = word,
                        Value = double.Parse(values[j]),
                        Topic = j
                    });
                }
            }
            _wordDistributionOverCategories.Add(itr, results);
        }

        private void UpdateChart()
        {
            label_itr.Text = $"{_currentItr}/{_categoryDistributionOverDocuments.Keys.Max()}";
            chart1.Series.Clear();
            var dist = _categoryDistributionOverDocuments[_currentItr];
            foreach (var d in dist)
            {
                var series = chart1.Series.FirstOrDefault(f => f.Name == d.Key.Item2);
                if (series == null)
                {
                    series = new Series(d.Key.Item2);
                    chart1.Series.Add(series);
                }
                series.Points.Add(new DataPoint()
                {
                    XValue = d.Key.Item1,
                    YValues = new[] { d.Value }
                });
            }
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 1;

            dataGridView1.Rows.Clear();
            var topiics = _wordDistributionOverCategories[_currentItr].Select(s => s.Topic).Distinct().OrderBy(o=>o);

            foreach (var topiic in topiics)
            {
                var items = _wordDistributionOverCategories[_currentItr].Where(w => w.Topic == topiic).OrderByDescending(o => o.Value).Take(3).ToArray();
                dataGridView1.Rows.Add(topiic, $"{items[0].Word}=>{items[0].Value}", $"{items[1].Word}=>{items[1].Value}", $"{items[2].Word}=>{items[2].Value}");
            }
            dataGridView1.Refresh();
        }

        private void UpdateIteration(int num)
        {
            var max = _categoryDistributionOverDocuments.Keys.Max();
            var min = _categoryDistributionOverDocuments.Keys.Min();
            var desired = _currentItr + num;
            if (desired > max)
                desired = max;
            else if (desired < min)
                desired = min;
            while (desired <= max && desired >= min && !_categoryDistributionOverDocuments.ContainsKey(desired))
            {
                if (num > 0)
                    desired++;
                if (num < 0)
                    desired--;
            }
            if (_categoryDistributionOverDocuments.ContainsKey(desired))
            {
                _currentItr = desired;
                UpdateChart();
            }
        }

        private void StartAutomaticIteration()
        {
            if (_timer != null)
                return;
            _timer = new Timer()
            {
                Interval = 500,
            };
            _timer.Tick += (o, args) =>
            {
                if (_categoryDistributionOverDocuments.Keys.Max() > _currentItr)
                    UpdateIteration(1);
                else
                    StopAutomaticIteration();
            };
            _timer.Start();
        }

        private void StopAutomaticIteration()
        {
            if (_timer == null)
                return;
            _timer.Stop();
            _timer = null;
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            UpdateIteration(+1);
        }

        private void button_next_fast_Click(object sender, EventArgs e)
        {
            UpdateIteration(10);
        }

        private void button_next_last_Click(object sender, EventArgs e)
        {
            UpdateIteration(_categoryDistributionOverDocuments.Keys.Max());
        }

        private void button_prev_Click(object sender, EventArgs e)
        {
            UpdateIteration(-1);
        }

        private void button_prev_fast_Click(object sender, EventArgs e)
        {
            UpdateIteration(-10);
        }

        private void button_first_Click(object sender, EventArgs e)
        {
            UpdateIteration(-1 * _categoryDistributionOverDocuments.Keys.Max());
        }

        private void button_play_Click(object sender, EventArgs e)
        {
            StartAutomaticIteration();
        }

        private void button_pause_Click(object sender, EventArgs e)
        {
            StopAutomaticIteration();
        }
    }

    public class WordDistribution
    {
        public int Topic { get; set; }

        public string Word { get; set; }

        public double Value { get; set; }
    }
}