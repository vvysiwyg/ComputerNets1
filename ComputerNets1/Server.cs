using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ComputerNets1
{
    public class Server
    {
        private static Random _random;
        private static NormalRandom _normalRandom;
        private const int Q_MAX = 15;

        public double a {  get; set; }

        public double b { get; set; }

        public double Deviation { get; set; }

        public double Expectation { get; set; }

        public double TS { get; set; }

        public double TSMax { get; set; }

        public double T1 { get; set; }

        public double T2 { get; set; }

        public List<Task> Q { get; set; }

        public List<Task> InStream { get; set; }

        public List<Task> OutStream { get; set; }

        public ServerCore Core1 { get; set; }

        public ServerCore Core2 { get; set; }

        public bool Type { get;set; }

        public bool K { get; set; }

        public int L { get; set; }

        public double NextTau { get; set; }

        public double NextSigma { get; set; }

        public int I { get; set; }

        public double PrevT2 { get; set; }

        public List<ServerLog> ServerLogs { get; set; }
        
        public Dictionary<int, int> QueueLengthCounts { get; set; }

        public Dictionary<int, int> DeltaCounts { get; set; }

        public Server(double a, double b, double deviation, double expectation, double TSMax)
        {
            _random = new Random();
            _normalRandom = new NormalRandom();

            this.a = a;
            this.b = b;

            Deviation = deviation;
            Expectation = expectation;

            TS = 0.0;
            this.TSMax = TSMax;
            T1 = 0.0;
            T2 = 0.0;
            Q = new List<Task>();
            InStream = new List<Task>();
            OutStream = new List<Task>();
            Core1 = new ServerCore();
            Core2 = new ServerCore();
            K = false;
            L = 0;
            Type = false;
            NextTau = 0.0;
            NextSigma = 0.0;
            PrevT2 = 0.0;
            I = -1;
            ServerLogs = new List<ServerLog>();
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
                {15, 0}
            };
        }

        public void RunServer()
        {
            T1 = GenerateUniformDistribution();
            double initSigma = GenerateModuleGaussDistribution();
            NextSigma = initSigma;
            T2 = T1 + initSigma;
            TS = T1;
            Core1.Task = new Task(0, T1, T1, initSigma, T2);
            Core1.IsBusy = true;
            InStream.Add(Core1.Task);

            ServerLog serverLog = new ServerLog((Type == true ? "2" : "1"), T1.ToString(), initSigma.ToString(), T1.ToString(), T2.ToString(), (K == true ? "1" : "0"), L.ToString(), TS.ToString(), "Инициализация");
            ServerLogs.Add(serverLog);

            while(TS < TSMax)
            {
                ProcessTimeStep();
            }
        }

        public void ProcessTimeStep()
        {
            ServerLog serverLog = new ServerLog();
            serverLog.Type = (Type == true ? "2" : "1");

            if (Type) // Окончание обслуживания
            {
                double sigma = GenerateModuleGaussDistribution();
                K = Core1.IsBusy || Core2.IsBusy;
                HandleTask(sigma);

/*                if (CurrentTask.I == 0)
                {
                    if (L == 0)
                    {
                        K = false;
                        HandleTask(sigma);
                        //T2 = T1 + sigma;
                        //NextSigma = sigma;
                        //OutStream.Add(CurrentTask);
                        //CurrentTask = null;
                    }
                    else
                    {
                        HandleTask(sigma);
                    }
                }
                else
                {
                    if (L == 0)
                    {
                        K = false;
                        HandleTask(sigma);
                        //CurrentTask.Sigma = NextSigma;
                        //CurrentTask.Delta = T2 - PrevT2;
                        //PrevT2 = T2;
                        //NextSigma = sigma;
                        //OutStream.Add(CurrentTask);
                        //T2 = T1 + sigma;
                        //CurrentTask = null;
                    }
                    else
                    {
                        HandleTask(sigma);
                    }
                }*/

                serverLog.Sigma = sigma.ToString();
                serverLog.T2 = T2.ToString();
                serverLog.Description = "Окончание обслуживания";
            }
            else // Приход задачи
            {
                double tau = GenerateUniformDistribution();
                T1 += tau;
                I++;

                if (I == 0)
                {
                    K = true;
                }
                else
                {
                    Task newTask = new Task(I, T1, NextTau, null, null);
                    InStream.Add(newTask);

                    if (K)
                    {
                        if(!DelegateTaskToCore(newTask))
                            if (L < Q_MAX)
                            {
                                Q.Add(newTask);
                                L += 1;
                                QueueLengthCounts[L]++;
                            }
                    }
                    else
                    {
                        Core1.Task = newTask;
                        Core1.IsBusy = true;
                        K = true;
                    }
                }

                NextTau = tau;

                serverLog.Tau = tau.ToString();
                serverLog.T1 = T1.ToString();
                serverLog.Description = "Приход задачи";
            }

            Type = T1 > T2;
            TS = Math.Min(T1, T2);

            serverLog.K = (K == true ? "1" : "0");
            serverLog.L = L.ToString();
            serverLog.TS = TS.ToString();

            ServerLogs.Add(serverLog);
        }

        public double GenerateUniformDistribution() => a + _random.NextDouble() * (b - a);

        public double GenerateModuleGaussDistribution() => Math.Abs(_normalRandom.NextDouble() * Deviation + Expectation);

        public int GetIndexOfHighPriorityTask(List<Task> queue)
        {
            int index = 0;
            double max = -1;

            for(int i = 0; i < queue.Count; i++)
            {
                if (queue[i].Sigma.HasValue && queue[i].Sigma.Value > max)
                {
                    max = queue[i].Sigma.Value;
                    index = i;
                }
            }

            return index;
        }

        public void HandleTask(double sigma)
        {
            // Вариант через сравнение времени выхода задачи с системным временем
            //ServerCore core;
            //if (Core1.IsBusy && Core2.IsBusy)
            //    core = (Math.Abs(Core1.Task.T + NextSigma - TS) < 1e-5) ? Core1 : Core2;
            //else
            //    core = Core1.IsBusy ? Core1 : Core2;

            // Вариант через порядковый номер задачи
            ServerCore core;
            if (Core1.IsBusy && Core2.IsBusy)
                core = Core1.Task.I < Core2.Task.I ? Core1 : Core2;
            else
                core = Core1.IsBusy ? Core1 : Core2;

            core.Task.Sigma = NextSigma;
            core.Task.Delta = T2 - PrevT2;
            UpdateDeltaCounts(core.Task.Delta.Value);
            PrevT2 = T2;
            NextSigma = sigma;
            core.IsBusy = false;
            OutStream.Add(core.Task);

            if (L == 0)
            {
                T2 = T1 + sigma;
                core.Task = null;
            }
            else
            {
                int indexOfHighPriorityTask = GetIndexOfHighPriorityTask(Q);
                core.Task = Q[indexOfHighPriorityTask];
                // CurrentTask.Sigma = sigma;
                Q.RemoveAt(indexOfHighPriorityTask);
                L -= 1;
                QueueLengthCounts[L]++;
                T2 += sigma;
            }

            /*            CurrentTask.Sigma = NextSigma;
                        CurrentTask.Delta = T2 - PrevT2;
                        PrevT2 = T2;
                        NextSigma = sigma;
                        OutStream.Add(CurrentTask);
                        int indexOfHighPriorityTask = GetIndexOfHighPriorityTask(Q);
                        CurrentTask = Q[indexOfHighPriorityTask]; // Проверить CurrentTask на null после удаления задачи из очереди
                        // CurrentTask.Sigma = sigma;
                        Q.RemoveAt(indexOfHighPriorityTask);
                        L -= 1;
                        T2 += sigma;*/
        }

        public void UpdateDeltaCounts(double delta)
        {
            int integerPart = (int)Math.Truncate(delta);
            double fractionalPart = delta - integerPart;

            DeltaCounts[integerPart]++;
        }

        public bool DelegateTaskToCore(Task newTask)
        {
            bool isDelegated = false;
            ServerCore? core = !Core1.IsBusy ? Core1 : !Core2.IsBusy ? Core2 : null;

            if (core != null)
            {
                core.Task = newTask;
                core.IsBusy = true;
                isDelegated = true;
            }

            return isDelegated;
        }
    }

    public class Task
    {
        public int I { get; set; }

        public double T { get; set; }

        public double Tau { get; set; }

        public double? Sigma { get; set; }

        public double? Delta { get; set; }

        public Task()
        {
            I = 0;
            T = 0.0;
            Tau = 0.0;
            Sigma = null;
            Delta = null;
        }

        public Task(int I, double T, double Tau, double? Sigma, double? Delta)
        {
            this.I = I;
            this.T = T;
            this.Tau = Tau;
            this.Sigma = Sigma;
            this.Delta = Delta;
        }
    }

    public class ServerCore
    {
        public Task? Task { get; set; }
        public bool IsBusy { get; set; }

        public ServerCore()
        {
            Task = null;
            IsBusy = false;
        }

        public ServerCore(Task task)
        {
            Task = task;
            IsBusy = true;
        }
    }

    public class ServerLog
    {
        public string Type { get; set; }
        public string Tau { get; set; }
        public string Sigma { get; set; }
        public string T1 { get; set; }
        public string T2 { get; set; }
        public string K { get; set; }
        public string L { get; set; }
        public string TS { get; set; }
        public string Description { get; set; }

        public ServerLog()
        {
            Type = string.Empty;
            Tau = string.Empty;
            Sigma = string.Empty;
            T1 = string.Empty;
            T2 = string.Empty;
            K = string.Empty;
            L = string.Empty;
            TS = string.Empty;
            Description = string.Empty;
        }

        public ServerLog(string Type, string Tau, string Sigma, string T1, string T2, string K, string L, string TS, string Description)
        {
            this.Type = Type;
            this.Tau = Tau;
            this.Sigma = Sigma;
            this.T1 = T1;
            this.T2 = T2;
            this.K = K;
            this.L = L;
            this.TS = TS;
            this.Description = Description;
        }
    }

    public class NormalRandom : Random
    {
        double prevSample = double.NaN;
        protected override double Sample()
        {
            if (!double.IsNaN(prevSample))
            {
                double result = prevSample;
                prevSample = double.NaN;
                return result;
            }

            double u, v, s;
            do
            {
                u = 2 * base.Sample() - 1;
                v = 2 * base.Sample() - 1;
                s = u * u + v * v;
            }
            while (u <= -1 || v <= -1 || s >= 1 || s == 0);
            double r = Math.Sqrt(-2 * Math.Log(s) / s);

            prevSample = r * v;
            return r * u;
        }
    }
}
