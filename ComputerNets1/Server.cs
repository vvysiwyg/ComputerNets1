using MathNet.Numerics.Distributions;

namespace ComputerNets1
{
    public class Server
    {
        private static Random _random;
        private static NormalRandom _normalRandom;
        private const int Q_MAX = 15;

        public int ServerID { get; private set; }

        public double a {  get; set; }

        public double b { get; set; }

        public double Deviation { get; set; }

        public double Expectation { get; set; }

        public double Lambda { get; set; }

        public double TS { get; set; }

        public double TSMax { get; set; }
            
        public double T1 { get; set; }

        public double T2 { get; set; }

        public List<Task> Q { get; set; }

        public List<Task> InStream { get; set; }

        public List<Task> OutStream { get; set; }

        public List<Task> FinalOutStream { get; set; }

        public ServerCore Core1 { get; set; }

        public ServerCore Core2 { get; set; }

        public bool Type { get;set; }

        public bool K { get; set; }

        public bool IsShutdown { get; set; }

        public int L { get; set; }

        public double NextTau { get; set; }

        public double NextSigma { get; set; }

        public int I { get; set; }

        public double PrevT2 { get; set; }

        public double Intensity { get; set; }

        public List<ServerLog> ServerLogs { get; set; }
        
        public Dictionary<int, int> QueueLengthCounts { get; set; }

        public Dictionary<int, int> DeltaCounts { get; set; }

        public List<Server> NeighborServers { get; set; }

        public Server(double a, double b, double deviation, double expectation, double TSMax, int serverId, double lambda)
        {
            _random = new Random();
            _normalRandom = new NormalRandom();
            NeighborServers = new List<Server>();
            ServerID = serverId;
            IsShutdown = false;
            Lambda = lambda;
            Intensity = 0.0;

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
            FinalOutStream = new List<Task>();
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

            InitializeFirstTask();
        }

        public void InitializeFirstTask()
        {
            T1 = GenerateUniformDistribution();
            double initSigma = GenerateModuleGaussDistribution();
            NextSigma = initSigma;
            T2 = T1 + initSigma;
            TS = T1;
            Core1.Task = new Task(0, T1, T1, initSigma, T2, Poisson.Sample(_random, Lambda), 0);
            Core1.IsBusy = true;
            InStream.Add(Core1.Task);

            ServerLog serverLog = new ServerLog((Type == true ? "2" : "1"), T1.ToString(), initSigma.ToString(), T1.ToString(), T2.ToString(), (K == true ? "1" : "0"), L.ToString(), TS.ToString(), "Инициализация");
            ServerLogs.Add(serverLog);
        }

        public void ProcessTimeStep()
        {
            if (!IsShutdown)
            {
                ServerLog serverLog = new ServerLog();
                serverLog.Type = (Type == true ? "2" : "1");

                if (Type) // Окончание обслуживания
                {
                    double sigma = GenerateModuleGaussDistribution();
                    K = Core1.IsBusy || Core2.IsBusy;
                    HandleTask(sigma);

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
                        Task newTask = new Task(I, T1, NextTau, null, null, Poisson.Sample(_random, Lambda), 0);
                        InStream.Add(newTask);

                        if (K)
                        {
                            if (!DelegateTaskToCore(newTask))
                                if (L <= Q_MAX)
                                {
                                    Q.Add(newTask);
                                    L += 1;
                                    QueueLengthCounts[L]++;
                                }
                                else // Увеличиваем k на 1 и передаем соседнему серверу
                                {
                                    newTask.K_Fact++;

                                    if (newTask.K_Fact != newTask.K_Plan)
                                        TransferTaskToNeighborServer(newTask);
                                    else
                                        FinalOutStream.Add(newTask);
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

                if (TS >= TSMax)
                    IsShutdown = true;
            }
        }

        public void CalculateIntensity()
        {
            Intensity = (double)InStream.Count / TS;
        }

        public void TransferTaskToNeighborServer(Task task)
        {
            List<Server> chosenServers = NeighborServers.FindAll(f => f.Q.Count == NeighborServers.Min(ns => ns.Q.Count));
            int chosenServerIndex = 0;

            if(chosenServers.Count > 1)
                chosenServerIndex = _random.Next(0, chosenServers.Count);

            Server chosenServer = chosenServers[chosenServerIndex];

            if (chosenServer != null)
            {
                if (!chosenServer.DelegateTaskToCore(task))
                {
                    if (chosenServer.L <= Q_MAX)
                    {
                        chosenServer.InStream.Add(task);
                        chosenServer.Q.Add(task);
                        chosenServer.L += 1;
                        chosenServer.QueueLengthCounts[L]++;
                    }
                    else
                    {
                        task.K_Fact++;
                        chosenServer.TransferTaskToNeighborServer(task);
                    }
                }
            }
            else
                throw new Exception($"Не удалось передать задачу {task.I} от сервера {ServerID}");
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

            // Увеличиваем k на 1 и передаем соседнему серверу либо заканчиваем обслуживание задачи
            core.Task.K_Fact++;
            if (core.Task.K_Fact != core.Task.K_Plan)
                TransferTaskToNeighborServer(core.Task);
            else
                FinalOutStream.Add(core.Task);

            if (L == 0)
            {
                T2 = T1 + sigma;
                core.Task = null;
            }
            else
            {
                int indexOfHighPriorityTask = GetIndexOfHighPriorityTask(Q);
                core.Task = Q[indexOfHighPriorityTask];
                Q.RemoveAt(indexOfHighPriorityTask);
                L -= 1;
                QueueLengthCounts[L]++;
                T2 += sigma;
            }
        }

        public void UpdateDeltaCounts(double delta)
        {
            int integerPart = (int)Math.Truncate(delta);
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

        public int K_Plan { get; set; }

        public int K_Fact { get; set; }

        public double T { get; set; }

        public double Tau { get; set; }

        public double? Sigma { get; set; }

        public double? Delta { get; set; }

        public Task()
        {
            I = 0;
            K_Plan = 0;
            K_Fact = 0;
            T = 0.0;
            Tau = 0.0;
            Sigma = null;
            Delta = null;
        }

        public Task(int I, double T, double Tau, double? Sigma, double? Delta, int K_Plan, int K_Fact)
        {
            this.I = I;
            this.T = T;
            this.Tau = Tau;
            this.Sigma = Sigma;
            this.Delta = Delta;
            this.K_Plan = K_Plan;
            this.K_Fact = K_Fact;
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
