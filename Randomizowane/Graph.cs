using System;
using System.Collections.Generic;
using System.Linq;

namespace Randomizowane
{
    public class Graph
    {
        public List<Node> V = new List<Node>();
        public List<Edge> E = new List<Edge>();
        
        public Graph(params int[] edges)
        {
            // create nodes and edges
            for (int i = 0; i < edges.Length - 1; i += 2)
            {
                Node from = FindNodeWithIndex(edges[i]);
                if (from == null)
                {
                    from = new Node(edges[i]);
                    V.Add(from);
                }

                Node to = FindNodeWithIndex(edges[i + 1]);
                if (to == null)
                {
                    to = new Node(edges[i + 1]);
                    V.Add(to);
                }

                E.Add(new Edge(from, to));
            }

            //Console.WriteLine("Created graph with {0} nodes and {1} edges", V.Count, E.Count);
        }

        public Node FindNodeWithIndex(int idx)
        {
            Node[] nodes = V.Select(n => n).Where(s => s.index == idx).ToArray();
            if (nodes.Length == 0)
                return null;
            else
                return nodes[0];
        }

        public void MinCut(bool printAll = true)
        {
            Random random = new Random();
            while (V.Count > 2)
            {
                int randomIndex = random.Next(0, E.Count - 1);
                if (printAll)
                    Console.WriteLine("Losowo wybrana krawędź: " + E[randomIndex]);
                Contraction(E[randomIndex], printAll);
            }
        }

        private void Contraction(Edge e, bool printAll = true)
        {
            if (printAll)
                Console.WriteLine("Ściągnięcie wzdłuż krawędzi {0} ({1} węzłów, {2} krawędzi)\n{3}", e, V.Count, E.Count, this);

            List<Edge> edgesToAdd = new List<Edge>();
            List<Edge> edgesToRemove = new List<Edge>();
            foreach (Edge edge in E)
            {
                if (edge != e && IsNodeConnectedWith(e.from, edge))
                {
                    if (e.from == edge.from)
                    {
                        edgesToAdd.Add(new Edge(edge.to, e.to));
                        edgesToRemove.Add(edge);
                    }
                    else
                    {
                        edgesToAdd.Add(new Edge(edge.from, e.to));
                        edgesToRemove.Add(edge);
                    }
                }
            }

            foreach (Edge edge in edgesToAdd)
                E.Add(edge);
            // remove loops
            foreach (Edge edge in E)
            {
                if (edge.from == edge.to)
                    edgesToRemove.Add(edge);
            }
            foreach (Edge edge in edgesToRemove)
                E.Remove(edge);
            E.Remove(e);
            V.Remove(e.from);

            if (printAll)
                Console.WriteLine("Po ściągnięciu wzdłuż krawędzi {0} ({1} węzłów, {2} krawędzi)\n{3}", e, V.Count, E.Count, this);
        }

        private bool IsNodeConnectedWith(Node n, Edge e)
        {
            if (e.from == n || e.to == n)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            string str = "Węzły: { ";
            foreach (Node n in V)
            {
                str += n + ", ";
            }
            str += "\b\b }\n";
            str += "Krawędzie:\n";
            foreach (Edge e in E)
            {
                str += e.from.index + " - " + e.to.index + "\n";
            }

            return str;
        }
    }
}
