using System.Windows.Forms.DataVisualization.Charting;

namespace ComputerNets1
{
    public class ResultVisualisation
    {
        private Form Form { get;set; }

        private Dictionary<int, Dictionary<double, Series>> LnSeries { get; set; }

        private Dictionary<int, Dictionary<double, Series>> AOutXSeries { get; set; }

        public ServersNet Net { get; set; }

        private TabControl TabControl3 { get; set; }

        private TabControl TabControl4 { get; set; }

        public ResultVisualisation() 
        {
            Form = new Form();
        }

        public ResultVisualisation(Form Form) 
        {
            this.Form = Form;

            LnSeries = new Dictionary<int, Dictionary<double, Series>>();
            AOutXSeries = new Dictionary<int, Dictionary<double, Series>>();

            TabControl3 = this.Form.Controls.Find("tabControl3", true)[0] as TabControl;
            TabControl4 = this.Form.Controls.Find("tabControl4", true)[0] as TabControl;
        }

        public void Visualize(Dictionary<int, Dictionary<int, int>> queueLengthCounts,
            Dictionary<int, Dictionary<int, int>> deltaCounts,
            double expectation,
            int n,
            int prevN)
        {
            if (n != prevN)
                VisualizeWithRedraw(queueLengthCounts, deltaCounts, expectation);
            else
                VisualizeWithoutRedraw(queueLengthCounts, deltaCounts, expectation);
        }

        private void VisualizeWithRedraw(Dictionary<int, Dictionary<int, int>> queueLengthCounts,
            Dictionary<int, Dictionary<int, int>> deltaCounts,
            double expectation)
        {
            Reset();
            foreach (var server in Net.AllServers)
            {
                LnSeries.Add(server.ServerID, new Dictionary<double, Series>());
                AOutXSeries.Add(server.ServerID, new Dictionary<double, Series>());

                Chart QueueLengthChart = new Chart();
                QueueLengthChart.Name = "QueueLengthChart" + server.ServerID;
                ChartArea queueLengthChartArea = new ChartArea();
                QueueLengthChart.ChartAreas.Add(queueLengthChartArea);

                Chart DeltaChart = new Chart();
                DeltaChart.Name = "DeltaChart" + server.ServerID;
                ChartArea deltaChartArea = new ChartArea();
                DeltaChart.ChartAreas.Add(deltaChartArea);

                QueueLengthChart.Dock = DockStyle.Fill;
                DeltaChart.Dock = DockStyle.Fill;

                TabPage queueLengthTabPage = CreateDefaultTabPage(QueueLengthChart, server, "tabPageLn" + server.ServerID);
                TabPage deltaTabPage = CreateDefaultTabPage(DeltaChart, server, "tabPageAOutX" + server.ServerID);
                queueLengthTabPage.Controls.Add(QueueLengthChart);
                deltaTabPage.Controls.Add(DeltaChart);
                TabControl3.Controls.Add(queueLengthTabPage);
                TabControl4.Controls.Add(deltaTabPage);

                Series QueueLengthSeries, DeltaSeries;
                Dictionary<int, double> queueLengthProbabilities = CalculateQueueLengthProbabilities(queueLengthCounts[server.ServerID]);
                Dictionary<int, double> deltaProbabilities = CalculateDeltaProbabilities(deltaCounts[server.ServerID]);
                List<double> queueLengthCumulativeProbabilities = new List<double>();
                List<double> deltaCumulativeProbabilities = new List<double>();

                QueueLengthSeries = new Series();
                QueueLengthSeries.Name = $"μ = {expectation}";
                QueueLengthSeries.ChartType = SeriesChartType.Spline;
                QueueLengthChart.Series.Add(QueueLengthSeries);
                QueueLengthChart.Legends.Add(expectation.ToString());
                LnSeries[server.ServerID].Add(expectation, QueueLengthSeries);

                DeltaSeries = new Series();
                DeltaSeries.Name = $"μ = {expectation}";
                DeltaSeries.ChartType = SeriesChartType.Spline;
                DeltaChart.Series.Add(DeltaSeries);
                DeltaChart.Legends.Add(expectation.ToString());
                AOutXSeries[server.ServerID].Add(expectation, DeltaSeries);

                queueLengthCumulativeProbabilities.Add(queueLengthProbabilities[0]);
                deltaCumulativeProbabilities.Add(deltaProbabilities[0]);

                for (int i = 1; i < queueLengthProbabilities.Count; i++)
                {
                    queueLengthCumulativeProbabilities.Add(queueLengthCumulativeProbabilities[i - 1] + queueLengthProbabilities[i]);
                }

                for (int i = 1; i < deltaProbabilities.Count; i++)
                {
                    deltaCumulativeProbabilities.Add(deltaCumulativeProbabilities[i - 1] + deltaProbabilities[i]);
                }

                for (int i = 0; i < queueLengthProbabilities.Count; i++)
                {
                    QueueLengthSeries.Points.AddXY(i, queueLengthCumulativeProbabilities[i]);
                }

                for (int i = 0; i < deltaProbabilities.Count; i++)
                {
                    DeltaSeries.Points.AddXY(i, deltaCumulativeProbabilities[i]);
                }
            }
        }

        private void VisualizeWithoutRedraw(Dictionary<int, Dictionary<int, int>> queueLengthCounts,
            Dictionary<int, Dictionary<int, int>> deltaCounts,
            double expectation)
        {
            foreach (var server in Net.AllServers)
            {
                Chart QueueLengthChart = TabControl3.Controls.Find("QueueLengthChart" + server.ServerID, true).FirstOrDefault() as Chart;
                Chart DeltaChart = TabControl4.Controls.Find("DeltaChart" + server.ServerID, true).FirstOrDefault() as Chart;
                
                Series QueueLengthSeries, DeltaSeries;
                Dictionary<int, double> queueLengthProbabilities = CalculateQueueLengthProbabilities(queueLengthCounts[server.ServerID]);
                Dictionary<int, double> deltaProbabilities = CalculateDeltaProbabilities(deltaCounts[server.ServerID]);
                List<double> queueLengthCumulativeProbabilities = new List<double>();
                List<double> deltaCumulativeProbabilities = new List<double>();

                if (!LnSeries[server.ServerID].TryGetValue(expectation, out QueueLengthSeries))
                {
                    QueueLengthSeries = new Series();
                    QueueLengthSeries.Name = $"μ = {expectation}";
                    QueueLengthSeries.ChartType = SeriesChartType.Spline;
                    QueueLengthChart.Series.Add(QueueLengthSeries);
                    QueueLengthChart.Legends.Add(expectation.ToString());
                    LnSeries[server.ServerID].Add(expectation, QueueLengthSeries);
                }

                if (!AOutXSeries[server.ServerID].TryGetValue(expectation, out DeltaSeries))
                {
                    DeltaSeries = new Series();
                    DeltaSeries.Name = $"μ = {expectation}";
                    DeltaSeries.ChartType = SeriesChartType.Spline;
                    DeltaChart.Series.Add(DeltaSeries);
                    DeltaChart.Legends.Add(expectation.ToString());
                    AOutXSeries[server.ServerID].Add(expectation, DeltaSeries);
                }

                queueLengthCumulativeProbabilities.Add(queueLengthProbabilities[0]);
                deltaCumulativeProbabilities.Add(deltaProbabilities[0]);

                for (int i = 1; i < queueLengthProbabilities.Count; i++)
                {
                    queueLengthCumulativeProbabilities.Add(queueLengthCumulativeProbabilities[i - 1] + queueLengthProbabilities[i]);
                }

                for (int i = 1; i < deltaProbabilities.Count; i++)
                {
                    deltaCumulativeProbabilities.Add(deltaCumulativeProbabilities[i - 1] + deltaProbabilities[i]);
                }

                for (int i = 0; i < queueLengthProbabilities.Count; i++)
                {
                    QueueLengthSeries.Points.AddXY(i, queueLengthCumulativeProbabilities[i]);
                }

                for (int i = 0; i < deltaProbabilities.Count; i++)
                {
                    DeltaSeries.Points.AddXY(i, deltaCumulativeProbabilities[i]);
                }
            }
        }

        private void Reset()
        {
            foreach (Dictionary<double, Series> item in LnSeries.Values)
                item.Clear();

            LnSeries.Clear();

            foreach (Dictionary<double, Series> item in AOutXSeries.Values)
                item.Clear();

            AOutXSeries.Clear();

            TabControl3.Controls.Clear();
            TabControl4.Controls.Clear();
        }

        private TabPage CreateDefaultTabPage(Control ctrlToAdd, Server server, string tabName)
        {
            TabPage tabPage1 = new TabPage();

            tabPage1.BackColor = SystemColors.Control;
            tabPage1.Controls.Add(ctrlToAdd);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = tabName;
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1428, 383);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Сервер " + server.ServerID;

            return tabPage1;
        }

        public Dictionary<int, double> CalculateQueueLengthProbabilities(Dictionary<int, int> queueLengthCounts)
        {
            int countSum = queueLengthCounts.Values.Sum();
            Dictionary<int, double> probabilities = new Dictionary<int, double>();

            for(int i = queueLengthCounts.Keys.Min(); i < queueLengthCounts.Keys.Max() + 1; i++)
            {
                if (!queueLengthCounts.ContainsKey(i))
                    queueLengthCounts.Add(i, 0);

                probabilities.Add(i, (double)queueLengthCounts[i] / (double)countSum);
            }

            return probabilities;
        }

        public Dictionary<int, double> CalculateDeltaProbabilities(Dictionary<int, int> deltaCounts)
        {
            int countSum = deltaCounts.Values.Sum();
            Dictionary<int, double> probabilities = new Dictionary<int, double>();

            for (int i = deltaCounts.Keys.Min(); i < deltaCounts.Keys.Max() + 1; i++)
            {
                if (!deltaCounts.ContainsKey(i))
                    deltaCounts.Add(i, 0);

                probabilities.Add(i, (double)deltaCounts[i] / (double)countSum);
            }

            return probabilities;
        }
    }
}
