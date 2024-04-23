using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace ComputerNets1
{
    public class ResultVisualisation
    {
        private Form Form { get;set; }
        private Chart QueueLengthChart { get; set; }
        private Chart DeltaChart { get; set; }

        private Dictionary<double, Series> LnSeries { get; set; }

        private Dictionary<double, Series> AOutXSeries { get; set; }

        public ResultVisualisation() 
        {
            Form = new Form();
            LnSeries = new Dictionary<double, Series>();
            AOutXSeries = new Dictionary<double, Series>();
        }

        public ResultVisualisation(Form Form) 
        {
            this.Form = Form;

            LnSeries = new Dictionary<double, Series>();
            AOutXSeries = new Dictionary<double, Series>();

            QueueLengthChart = new Chart();
            ChartArea queueLengthChartArea = new ChartArea();
            QueueLengthChart.ChartAreas.Add(queueLengthChartArea);

            DeltaChart = new Chart();
            ChartArea deltaChartArea = new ChartArea();
            DeltaChart.ChartAreas.Add(deltaChartArea);

            QueueLengthChart.Dock = DockStyle.Fill;
            DeltaChart.Dock = DockStyle.Fill;

            TabPage queueLengthTabPage = this.Form.Controls.Find("tabPage2", true)[0] as TabPage;
            TabPage deltaTabPage = this.Form.Controls.Find("tabPage3", true)[0] as TabPage;
            queueLengthTabPage.Controls.Add(QueueLengthChart);
            deltaTabPage.Controls.Add(DeltaChart);
        }

        public void Visualize(Dictionary<int, int> queueLengthCounts, Dictionary<int, int> deltaCounts, double expectation)
        {
            Series QueueLengthSeries, DeltaSeries;
            List<double> queueLengthProbabilities = CalculateQueueLengthProbabilities(queueLengthCounts);
            List<double> deltaProbabilities = CalculateDeltaProbabilities(deltaCounts);
            List<double> queueLengthCumulativeProbabilities = new List<double>();
            List<double> deltaCumulativeProbabilities = new List<double>();

            if (!LnSeries.TryGetValue(expectation, out QueueLengthSeries))
            {
                QueueLengthSeries = new Series();
                QueueLengthSeries.Name = $"μ = {expectation}";
                QueueLengthSeries.ChartType = SeriesChartType.Line;
                QueueLengthChart.Series.Add(QueueLengthSeries);
                QueueLengthChart.Legends.Add(expectation.ToString());
                LnSeries.Add(expectation, QueueLengthSeries);
            }

            if (!AOutXSeries.TryGetValue(expectation, out DeltaSeries))
            {
                DeltaSeries = new Series();
                DeltaSeries.Name = $"μ = {expectation}";
                DeltaSeries.ChartType = SeriesChartType.Line;
                DeltaChart.Series.Add(DeltaSeries);
                Legend legend = DeltaChart.Legends.Add(expectation.ToString());
                AOutXSeries.Add(expectation, DeltaSeries);
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

            QueueLengthSeries.Points.DataBindXY(queueLengthCounts.Keys, queueLengthCumulativeProbabilities);
            DeltaSeries.Points.DataBindXY(deltaCounts.Keys, deltaCumulativeProbabilities);

            QueueLengthSeries.Points.Clear();
            DeltaSeries.Points.Clear();

            for (int i = 0; i < queueLengthProbabilities.Count; i++)
            {
                QueueLengthSeries.Points.AddXY(i, queueLengthCumulativeProbabilities[i]);
            }

            for (int i = 0; i < deltaProbabilities.Count; i++)
            {
                DeltaSeries.Points.AddXY(i, deltaCumulativeProbabilities[i]);
            }
        }

        public List<double> CalculateQueueLengthProbabilities(Dictionary<int, int> queueLengthCounts)
        {
            int countSum = queueLengthCounts.Values.Sum();
            List<double> probabilities = new List<double>();

            for(int i = 0; i < queueLengthCounts.Keys.Count; i++)
            {
                probabilities.Add((double)queueLengthCounts[i] / (double)countSum);
            }

            return probabilities;
        }

        public List<double> CalculateDeltaProbabilities(Dictionary<int, int> deltaCounts)
        {
            int countSum = deltaCounts.Values.Sum();
            List<double> probabilities = new List<double>();

            for (int i = 0; i < deltaCounts.Keys.Count; i++)
            {
                probabilities.Add((double)deltaCounts[i] / (double)countSum);
            }

            return probabilities;
        }
    }
}
