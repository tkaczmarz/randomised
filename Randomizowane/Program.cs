using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Randomizowane
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] nodes = new int[][] { new int[] { 1, 2, 3 }, new int[] { 0, 2, 3 }, new int[] { 1, 3, 0, 5 }, new int[] { 0, 2, 1, 4 },
                                          new int[] { 3, 5, 6 }, new int[] { 2, 4, 6, 7 }, new int[] {4, 5, 7 }, new int[] { 5, 6 } };
            Graph graph = new Graph(nodes);
            Console.WriteLine(graph);

            Console.ReadKey();
        }
    }
}
