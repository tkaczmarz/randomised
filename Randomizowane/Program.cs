using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Randomizowane
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] edges = { 0, 1, 0, 2, 0, 3, 1, 2, 1, 3, 2, 3, 2, 5, 3, 4, 4, 5, 4, 6, 5, 6, 5, 7, 6, 7 };
            Graph graph = new Graph(edges);
            int attempts = 10;
            Console.WriteLine("Obliczanie najmniejszego rozcięcia dla grafu ({0} prób):\n{1}", attempts, graph);

            List<int> cuts = new List<int>();
            for (int i = 0; i < attempts; i++)
            {
                graph = new Graph(edges);
                if (i != 0)
                    graph.MinCut(false);
                else
                    graph.MinCut();
                cuts.Add(graph.E.Count);
            }

            int minCut = int.MaxValue;
            for (int i = 0; i < cuts.Count; i++)
            {
                if (cuts[i] < minCut)
                    minCut = cuts[i];
            }

            Console.WriteLine("Najmniejsze cięcie: " + minCut);

            Console.Write("Wszystkie próby: { ");
            foreach (int cut in cuts)
                Console.Write(cut + ", ");
            Console.Write("\b\b }");

            Console.ReadKey();
        }
    }
}
