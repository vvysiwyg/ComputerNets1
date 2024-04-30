using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ComputerNets1
{
    public class ServersNet
    {
        public StarGraph3X ServersGraph { get; set; }

        public List<Server> AllServers { get; set; }

        public List<Server> CentralServers { get; set; }

        public Dictionary<int, List<Server>> PeripheralServers { get; set; }            // ключ - id центрального сервера

        public string Log { get; set; }

        public ServersNet(int n, double a, double b, double deviation, double expectation, double TSMax, double lambda) 
        {
            Log = "";
            ServersGraph = new StarGraph3X(n);
            AllServers = new List<Server>();
            CentralServers = new List<Server>()
            {
                new Server(a, b, deviation, expectation, TSMax, 0, lambda),                                 // 1 центр
                new Server(a, b, deviation, expectation, TSMax, ServersGraph.StarGraphN, lambda),           // 2 центр
                new Server(a, b, deviation, expectation, TSMax, ServersGraph.StarGraphN * 2, lambda)        // 3 центр
            };
            PeripheralServers = new Dictionary<int, List<Server>>();
            AllServers.AddRange(CentralServers);

            foreach (KeyValuePair<int, List<int>> item in ServersGraph.PeripheralNodes)
            {
                Server centralServer = CentralServers.FirstOrDefault(f => f.ServerID == item.Key);
                List<Server> peripheralServers = new List<Server>();

                if (centralServer != null)
                {
                    foreach(int i in item.Value)
                    {
                        peripheralServers.Add(new Server(a, b, deviation, expectation, TSMax, i, lambda));
                    }
                }

                PeripheralServers.Add(item.Key, peripheralServers);
                AllServers.AddRange(peripheralServers);
            }

            ConnectCenters();

            foreach(Server server in CentralServers)
                ConnectCenterWithPeripheral(server);
        }

        public bool IsAllServersShutdowned()
        {
            bool isCentralServersShutdowned = true, isPeripheralServersShutdowned = true;

            isPeripheralServersShutdowned = !PeripheralServers.Any(all => all.Value.Find(f => f.IsShutdown == false) != null);  // Проверить вернут ли эта и нижняя функции одинаковые значения
            isPeripheralServersShutdowned = PeripheralServers.All(all => all.Value.All(a => a.IsShutdown));
            isCentralServersShutdowned = CentralServers.All(all => all.IsShutdown);

            return isCentralServersShutdowned && isPeripheralServersShutdowned;
        }

        public void ConnectCenters()
        {
            if(CentralServers != null && CentralServers.Count == 3)
            {
                ConnectWith(CentralServers[0], CentralServers[1]);
                ConnectWith(CentralServers[0], CentralServers[2]);
                ConnectWith(CentralServers[1], CentralServers[2]);
            }
        }

        public void ConnectCenterWithPeripheral(Server center)
        {
            List<Server> list;

            if(PeripheralServers.TryGetValue(center.ServerID, out list))
            {
                foreach(Server server in list)
                {
                    ConnectWith(center, server);
                }
            }
        }

        public void ConnectWith(Server from, Server to, bool bothSide = true)
        {
            from.NeighborServers.Add(to);

            if (bothSide)
                to.NeighborServers.Add(from);
        }
    }

    public class StarGraph3X : Graph
    {
        public int StarGraphN { get; private set; }

        public List<int> StarsCenters { get; set; }

        public Dictionary<int, List<int>> PeripheralNodes { get; set; }

        public StarGraph3X(int n) : base(3*n)
        {
            StarGraphN = n;
            PeripheralNodes = new Dictionary<int, List<int>>();
            StarsCenters = new List<int>()
            {
                0,
                n,
                2*n
            };

            // Связывание центров между собой
            AddEdge(StarsCenters[0], StarsCenters[1], 1);
            AddEdge(StarsCenters[0], StarsCenters[2], 1);
            AddEdge(StarsCenters[1], StarsCenters[2], 1);

            // Связывание центров с переферийными узлами
            AddPeripheralNodesToCenter(StarsCenters[0], n - 1);
            AddPeripheralNodesToCenter(StarsCenters[1], n - 1);
            AddPeripheralNodesToCenter(StarsCenters[2], n - 1);
        }

        public void AddPeripheralNodesToCenter(int center, int numberOfNodesToAdd)
        {
            List<int> localPeripheralNodes = new List<int>();

            for(int i = 0; i < numberOfNodesToAdd; i++)
            {
                int index = center + i + 1;
                AddEdge(center, index, 1);
                localPeripheralNodes.Add(index);
            }

            PeripheralNodes.Add(center, localPeripheralNodes);
        }
    }

    public class Graph
    {
        public int N { get; private set; } // Количество вершин

        public int Diameter { get; set; }

        public Dictionary<int, int> PathsCount { get; set; }

        public List<(int, int)>[] adj; // Список смежности

        public Graph(int n)
        {
            N = n;
            Diameter = 0;
            PathsCount = new Dictionary<int, int>();
            adj = new List<(int, int)>[N];
            for (int i = 0; i < N; ++i)
                adj[i] = new List<(int, int)>();
        }

        public Graph()
        {
            N = 0;
            Diameter = 0;
            adj = new List<(int, int)>[N];
            PathsCount = new Dictionary<int, int>();
        }

        // Добавление ребра в граф
        public void AddEdge(int u, int v, int w)
        {
            adj[u].Add((v, w));
            adj[v].Add((u, w));
        }

        public void CalculateDiameter()
        {
            int maxDist = -1;

            for (int i = 0; i < N; i++)
            {
                int[] dists = Dijkstra(i);
                int max = dists.Max();

                if(max > maxDist)
                    maxDist = max;
            }

            Diameter = maxDist;
        }

        public void CalculatePathsCount()
        {
            PathsCount.Clear();

            for (int i = 0; i < N; i++)
            {
                int[] dists = Dijkstra(i);

                for(int j = 0; j < dists.Length; j++)
                {
                    if (i == j)
                        continue;

                    if (PathsCount.ContainsKey(dists[j]))
                        PathsCount[dists[j]]++;
                    else
                        PathsCount.Add(dists[j], 1);
                }
            }
        }

        public double GetAveragePathLength()
        {
            if (PathsCount.Count > 0)
                return PathsCount.Keys.Average();
            else
                return -1.0;
        }

        public int ConnectivityFunction(int x)
        {
            if (x == 0)
                return 1;
            else if (x == 1)
                return 0;
            else
                throw new ArgumentException("Некорректный x");
        }

        // Поиск кратчайшего пути с помощью алгоритма Дейкстры
        public int[] Dijkstra(int src)
        {
            int[] dist = new int[N]; // Массив для хранения кратчайших расстояний

            // Инициализация расстояний как "бесконечность"
            for (int i = 0; i < N; ++i)
                dist[i] = int.MaxValue;

            // Установка расстояния от исходной вершины до самой себя как 0
            dist[src] = 0;

            // Создание минимальной кучи (priority queue)
            var pq = new SortedSet<(int, int)>();
            pq.Add((0, src));

            // Пока очередь не пуста
            while (pq.Count > 0)
            {
                // Извлечение вершины с минимальным расстоянием
                var (_, u) = pq.Min;
                pq.Remove(pq.Min);

                // Обновление расстояний до смежных вершин
                foreach (var (v, w) in adj[u])
                {
                    // Если найден более короткий путь
                    if (dist[v] > dist[u] + w)
                    {
                        // Обновление расстояния
                        pq.Remove((dist[v], v));
                        dist[v] = dist[u] + w;
                        pq.Add((dist[v], v));
                    }
                }
            }

            return dist;
        }
    }
}
