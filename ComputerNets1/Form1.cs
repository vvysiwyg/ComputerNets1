using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.LinkLabel;

namespace ComputerNets1
{
    public partial class Form1 : Form
    {
        private Server server;
        private ResultVisualisation resultVisualisation;
        public Dictionary<int, int> QueueLengthCounts;
        public Dictionary<int, int> DeltaCounts;
        double a, b, expectation, deviation, TSMax; // 0.1, 7, 4, 1.3, 1000
        int experimentCount;
        string inStreamPath = @"C:\Users\Uzer\Desktop\InStream.txt";
        string outStreamPath = @"C:\Users\Uzer\Desktop\OutStream.txt";
        string queueLengthCounts_TS1000Path = @"C:\Users\Uzer\Desktop\QueueLengthCounts_TS1000.txt";
        string deltaCounts_TS1000Path = @"C:\Users\Uzer\Desktop\DeltaCounts_TS1000.txt";

        public Form1()
        {
            InitializeComponent();
            resultVisualisation = new ResultVisualisation(this);
            QueueLengthCounts = new Dictionary<int, int>()
            {
                {0, 1},
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 0},
                {5, 0},
                {6, 0},
                {7, 0},
                {8, 0},
                {9, 0},
                {10, 0},
                {11, 0},
                {12, 0},
                {13, 0},
                {14, 0},
                {15, 0}
            };
            DeltaCounts = new Dictionary<int, int>()
            {
                {0, 0},
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 0},
                {5, 0},
                {6, 0},
                {7, 0},
                {8, 0},
                {9, 0},
                {10, 0},
                {11, 0},
                {12, 0},
                {13, 0},
                {14, 0},
                {15, 0},
                {16, 0},
                {17, 0},
                {18, 0},
                {19, 0},
                {20, 0},
                {21, 0},
                {22, 0},
                {23, 0}
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(double.TryParse(aTextBox.Text, out a) &&
                double.TryParse(bTextBox.Text, out b) &&
                double.TryParse(expectationTextBox.Text, out expectation) &&
                double.TryParse(deviationTextBox.Text, out deviation) &&
                double.TryParse(tsMaxTextBox.Text, out TSMax) &&
                int.TryParse(experimentCountTextBox.Text, out experimentCount))
            {
                ClearDictionaries();
                try
                {
                    for (int i = 0; i < experimentCount; i++)
                    {
                        server = new Server(a, b, deviation, expectation, TSMax);
                        server.RunServer();

                        for (int j = 0; j < server.QueueLengthCounts.Keys.Count; j++)
                        {
                            QueueLengthCounts[j] += server.QueueLengthCounts[j];
                        }

                        for (int j = 0; j < server.DeltaCounts.Keys.Count; j++)
                        {
                            DeltaCounts[j] += server.DeltaCounts[j];
                        }
                    }

                    MessageBox.Show($"Эксперименты прошли успешно");
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Во время выполнения экмпериментов произошла ошибка: {ex.Message}");
                    return;
                }

                dataGridView1.Rows.Clear();

                foreach (var log in server.ServerLogs)
                {
                    dataGridView1.Rows.Add(log.Type, log.Tau, log.Sigma, log.T1, log.T2, log.K, log.L, log.TS, log.Description);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля");
                return;
            }

            using (StreamWriter sw = new StreamWriter(inStreamPath, false))
            {
                foreach (var item in server.InStream)
                {
                    sw.WriteLine($"{item.I}: время прихода = {item.T}, tau = {item.Tau}, sigma = {item.Sigma}, delta = {item.Delta}");
                }
            }

            using (StreamWriter sw = new StreamWriter(outStreamPath, false))
            {
                foreach (var item in server.OutStream)
                {
                    sw.WriteLine($"{item.I}: время прихода = {item.T}, tau = {item.Tau}, sigma = {item.Sigma}, delta = {item.Delta}");
                }
            }

            using (StreamReader reader = new StreamReader(queueLengthCounts_TS1000Path))
            {
                string line;
                int count;

                for (int i = 0; i < server.QueueLengthCounts.Keys.Count; i++)
                {
                    line = reader.ReadLine();
                    if (int.TryParse(line, out count))
                        server.QueueLengthCounts[i] += count;
                }
            }

            using (StreamReader reader = new StreamReader(deltaCounts_TS1000Path))
            {
                string line;
                int count;

                for (int i = 0; i < server.DeltaCounts.Keys.Count; i++)
                {
                    line = reader.ReadLine();
                    if (int.TryParse(line, out count))
                        server.DeltaCounts[i] += count;
                }
            }

            using (StreamWriter sw = new StreamWriter(queueLengthCounts_TS1000Path, false))
            {
                foreach (var item in server.QueueLengthCounts)
                {
                    sw.WriteLine(item.Value);
                }
            }

            using (StreamWriter sw = new StreamWriter(deltaCounts_TS1000Path, false))
            {
                foreach (var item in server.DeltaCounts)
                {
                    sw.WriteLine(item.Value);
                }
            }
        }

        private void buildChartsBtn_Click(object sender, EventArgs e)
        {
            resultVisualisation.Visualize(QueueLengthCounts, DeltaCounts, expectation);
        }

        private void ClearDictionaries()
        {
            for (int j = 0; j < QueueLengthCounts.Keys.Count; j++)
            {
                QueueLengthCounts[j] = 0;
            }

            for (int j = 0; j < DeltaCounts.Keys.Count; j++)
            {
                DeltaCounts[j] = 0;
            }
        }
    }
}
