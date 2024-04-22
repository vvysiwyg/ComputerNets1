using System.Windows.Forms.DataVisualization.Charting;

namespace ComputerNets1
{
    public partial class Form1 : Form
    {
        private static Random random;
        private static NormalRandom normalRandom;
        private Server server;
        private ResultVisualisation resultVisualisation;
        string filePath = @"C:\Users\Uzer\Desktop\Test.txt";
        string logPath = @"C:\Users\Uzer\Desktop\log.txt";
        string inStreamPath = @"C:\Users\Uzer\Desktop\InStream.txt";
        string outStreamPath = @"C:\Users\Uzer\Desktop\OutStream.txt";
        string queueLengthCounts_TS1000Path = @"C:\Users\Uzer\Desktop\QueueLengthCounts_TS1000.txt";
        string deltaCounts_TS1000Path = @"C:\Users\Uzer\Desktop\DeltaCounts_TS1000.txt";
        ServerCore testCore;

        public Form1()
        {
            InitializeComponent();
            random = new Random();
            normalRandom = new NormalRandom();
            resultVisualisation = new ResultVisualisation(this);
            testCore = new ServerCore();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server = new Server(0.1, 7, 1.3, 4, 1000);
            server.RunServer();

            dataGridView1.Rows.Clear();

            foreach (var log in server.ServerLogs)
            {
                dataGridView1.Rows.Add(log.Type, log.Tau, log.Sigma, log.T1, log.T2, log.K, log.L, log.TS, log.Description);
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

            resultVisualisation.Visualize(server.QueueLengthCounts, server.DeltaCounts);

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

            //queue = PopulateQueue(4);
            //int index = server.GetIndexOfHighPriorityTask(queue);

            //using (StreamWriter sw = new StreamWriter(logPath, false))
            //{
            //    foreach (var item in queue)
            //    {
            //        sw.WriteLine($"{item.I} sigma = {item.Sigma}");
            //    }
            //    sw.WriteLine($"Max index = {index}");
            //}
        }

        public List<Task> PopulateQueue(int iterationsCount)
        {
            List<Task> queue = new List<Task>();

            for(int i = 0; i < iterationsCount; i++)
                queue.Add(new Task(i, i + 1, 0.1 + random.NextDouble() * (7 - 0.1), Math.Abs(normalRandom.NextDouble() * 1.3 + 4), null));

            return queue;
        }

        public void GenerateModuleGaussDistribution()
        {
            double result = 0;
            int i = 100;
            double deviation = 1.3, expectation = 4;
            Dictionary<int, int> distribution = new Dictionary<int, int>()
            {
                {0, 0},
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 0}
            };
            List<double> otherNumbers = new List<double>();

            while (i > 0)
            {
                result = normalRandom.NextDouble();

                //if (result >= 11 && result < 15)
                //    distribution[0]++;
                //else if (result >= 15 && result < 19)
                //    distribution[1]++;
                //else if (result >= 19 && result < 23)
                //    distribution[2]++;
                //else if (result >= 23 && result < 27)
                //    distribution[3]++;
                //else if (result >= 27 && result <= 30)
                //    distribution[4]++;
                //else
                //    otherNumbers.Add(result);

                otherNumbers.Add(Math.Abs(result * deviation + expectation));

                i--;
            }

            //using (StreamWriter sw = new StreamWriter(filePath, false))
            //{
            //    foreach (int key in distribution.Keys)
            //    {
            //        sw.WriteLine($"{key} - {distribution[key]}");
            //    }
            //}

            using (StreamWriter sw = new StreamWriter(logPath, false))
            {
                foreach (double item in otherNumbers)
                {
                    sw.WriteLine(item);
                }
            }
        }

        public void GenerateUniformDistribution() 
        {
            double a, b;
            double result = 0;
            int i = 10000;
            Dictionary<int, int> distribution = new Dictionary<int, int>()
            {
                {0, 0},
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 0}
            };
            List<double> otherNumbers = new List<double>();

            double.TryParse(textBox1.Text, out a);
            double.TryParse(textBox2.Text, out b);

            while (i > 0)
            {
                result = a + random.NextDouble() * (b - a);

                if (result >= 11 && result < 15)
                    distribution[0]++;
                else if (result >= 15 && result < 19)
                    distribution[1]++;
                else if (result >= 19 && result < 23)
                    distribution[2]++;
                else if (result >= 23 && result < 27)
                    distribution[3]++;
                else if (result >= 27 && result <= 30)
                    distribution[4]++;
                else
                    otherNumbers.Add(result);

                i--;
            }

            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                foreach (int key in distribution.Keys)
                {
                    sw.WriteLine($"{key} - {distribution[key]}");
                }
            }

            using (StreamWriter sw = new StreamWriter(logPath, false))
            {
                foreach (double item in otherNumbers)
                {
                    sw.WriteLine(item);
                }
            }
        }
    }

    //public class NormalRandom : Random
    //{
    //    // сохранённое предыдущее значение
    //    double prevSample = double.NaN;
    //    protected override double Sample()
    //    {
    //        // есть предыдущее значение? возвращаем его
    //        if (!double.IsNaN(prevSample))
    //        {
    //            double result = prevSample;
    //            prevSample = double.NaN;
    //            return result;
    //        }

    //        // нет? вычисляем следующие два
    //        // Marsaglia polar method из википедии
    //        double u, v, s;
    //        do
    //        {
    //            u = 2 * base.Sample() - 1;
    //            v = 2 * base.Sample() - 1; // [-1, 1)
    //            s = u * u + v * v;
    //        }
    //        while (u <= -1 || v <= -1 || s >= 1 || s == 0);
    //        double r = Math.Sqrt(-2 * Math.Log(s) / s);

    //        prevSample = r * v;
    //        return r * u;
    //    }
    //}
}
