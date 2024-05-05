using MathNet.Numerics;
using MathNet.Numerics.Integration;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.LinkLabel;

namespace ComputerNets1
{
    public partial class Form1 : Form
    {
        private ResultVisualisation resultVisualisation;
        public Dictionary<int, int> QueueLengthCounts;
        public Dictionary<int, int> DeltaCounts;
        public Dictionary<int, Dictionary<int, int>> newQueueLengthCounts;
        public Dictionary<int, Dictionary<int, int>> newDeltaCounts;
        double a, b, expectation, deviation, TSMax, lambda; // 0.1, 7, 4, 1.3, 1000
        int experimentCount, n, prevN;

        public Form1()
        {
            InitializeComponent();
            n = 0;
            prevN = 0;
            resultVisualisation = new ResultVisualisation(this);
            newQueueLengthCounts = new Dictionary<int, Dictionary<int, int>>();
            newDeltaCounts = new Dictionary<int, Dictionary<int, int>>();
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
            prevN = n;
            if (double.TryParse(aTextBox.Text, out a) &&
                double.TryParse(bTextBox.Text, out b) &&
                double.TryParse(expectationTextBox.Text, out expectation) &&
                double.TryParse(deviationTextBox.Text, out deviation) &&
                double.TryParse(tsMaxTextBox.Text, out TSMax) &&
                double.TryParse(lambdaTextBox.Text, out lambda) &&
                int.TryParse(experimentCountTextBox.Text, out experimentCount) &&
                int.TryParse(nTextBox.Text, out n))
            {
                ClearDictionaries();
                try
                {
                    for (int i = 0; i < experimentCount; i++)
                    {
                        resultVisualisation.Net = null;
                        ServersNet net = new ServersNet(n, a, b, deviation, expectation, TSMax, lambda);
                        resultVisualisation.Net = net;

                        do
                        {
                            foreach (Server item in net.AllServers)
                                item.ProcessTimeStep();
                        }
                        while (!net.IsAllServersShutdowned());

                        foreach (Server item in net.AllServers)
                        {
                            if (!newQueueLengthCounts.ContainsKey(item.ServerID))
                                newQueueLengthCounts.Add(item.ServerID, new Dictionary<int, int>());

                            for (int j = 0; j < item.QueueLengthCounts.Keys.Count; j++)
                            {
                                if (newQueueLengthCounts[item.ServerID].ContainsKey(j))
                                    newQueueLengthCounts[item.ServerID][j] += item.QueueLengthCounts[j];
                                else
                                    newQueueLengthCounts[item.ServerID].Add(j, item.QueueLengthCounts[j]);
                            }

                            if (!newDeltaCounts.ContainsKey(item.ServerID))
                                newDeltaCounts.Add(item.ServerID, new Dictionary<int, int>());

                            for (int j = 0; j < item.DeltaCounts.Keys.Count; j++)
                            {
                                if (newDeltaCounts[item.ServerID].ContainsKey(j))
                                    newDeltaCounts[item.ServerID][j] += item.DeltaCounts[j];
                                else
                                    newDeltaCounts[item.ServerID].Add(j, item.DeltaCounts[j]);
                            }

                            item.CalculateIntensity();
                            HandleUI(net);
                        }
                    }

                    MessageBox.Show($"Эксперименты прошли успешно");
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Во время выполнения экмпериментов произошла ошибка: {ex.Message}");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля");
                return;
            }
        }

        private void buildChartsBtn_Click(object sender, EventArgs e)
        {
            resultVisualisation.Visualize(newQueueLengthCounts, newDeltaCounts, expectation, n, prevN);
        }

        private void ClearDictionaries()
        {
            foreach(Dictionary<int, int> item in newQueueLengthCounts.Values)
                item.Clear();

            newQueueLengthCounts.Clear();

            foreach (Dictionary<int, int> item in newDeltaCounts.Values)
                item.Clear();

            newDeltaCounts.Clear();
        }

        private void HandleUI(ServersNet net)
        {
            tabControl2.Controls.Clear();
            foreach (var item in net.AllServers)
            {
                DataGridView newDGV = CreateDefaultDGVAndPopulateWithRows(item);
                TabPage newTp = CreateDefaultTabPage(newDGV, item);

                tabControl2.Controls.Add(newTp);
            }
        }

        private TabPage CreateDefaultTabPage(System.Windows.Forms.Control ctrlToAdd, Server server)
        {
            TabPage tabPage1 = new TabPage();

            tabPage1.BackColor = SystemColors.Control;
            tabPage1.Controls.Add(ctrlToAdd);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage" + server.ServerID;
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1428, 383);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Сервер " + server.ServerID;

            return tabPage1;
        }

        private DataGridView CreateDefaultDGVAndPopulateWithRows(Server server)
        {
            DataGridView dataGridView1 = new DataGridView();
            DataGridViewTextBoxColumn typeCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn tauCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn sigmaCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn t1Col = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn t2Col = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn kCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn lCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn tsCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn descCol = new DataGridViewTextBoxColumn();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { typeCol, tauCol, sigmaCol, t1Col, t2Col, kCol, lCol, tsCol, descCol });
            dataGridView1.Location = new Point(6, 6);
            dataGridView1.Name = "dataGridView" + server.ServerID;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1393, 315);
            dataGridView1.TabIndex = 2;

            typeCol.HeaderText = "Type";
            typeCol.MinimumWidth = 6;
            typeCol.Name = "typeCol" + server.ServerID;
            typeCol.ReadOnly = true;
            
            tauCol.HeaderText = "Tau";
            tauCol.MinimumWidth = 6;
            tauCol.Name = "tauCol" + server.ServerID;
            tauCol.ReadOnly = true;
             
            sigmaCol.HeaderText = "Sigma";
            sigmaCol.MinimumWidth = 6;
            sigmaCol.Name = "sigmaCol" + server.ServerID;
            sigmaCol.ReadOnly = true;
            
            t1Col.HeaderText = "T1";
            t1Col.MinimumWidth = 6;
            t1Col.Name = "t1Col" + server.ServerID;
            t1Col.ReadOnly = true;
            
            t2Col.HeaderText = "T2";
            t2Col.MinimumWidth = 6;
            t2Col.Name = "t2Col" + server.ServerID;
            t2Col.ReadOnly = true;
            
            kCol.HeaderText = "K";
            kCol.MinimumWidth = 6;
            kCol.Name = "kCol" + server.ServerID;
            kCol.ReadOnly = true;
            
            lCol.HeaderText = "L";
            lCol.MinimumWidth = 6;
            lCol.Name = "lCol" + server.ServerID;
            lCol.ReadOnly = true;
            
            tsCol.HeaderText = "TS";
            tsCol.MinimumWidth = 6;
            tsCol.Name = "tsCol" + server.ServerID;
            tsCol.ReadOnly = true;
             
            descCol.HeaderText = "Description";
            descCol.MinimumWidth = 6;
            descCol.Name = "descCol" + server.ServerID;
            descCol.ReadOnly = true;

            foreach (var log in server.ServerLogs)
            {
                dataGridView1.Rows.Add(log.Type, log.Tau, log.Sigma, log.T1, log.T2, log.K, log.L, log.TS, log.Description);
            }

            return dataGridView1;
        }
    }
}
