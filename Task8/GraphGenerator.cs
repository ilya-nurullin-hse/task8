using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    class GraphGenerator
    {
        public const int edgeCount = 50;

        public static List<Tuple<int, int>> WalkGeneration()
        {
            var rand = new Random();

            var res = new List<Tuple<int, int>>();

            int[,] Matrix = new int[edgeCount, edgeCount];

            int currentEdge = 0;
            int iterationCounter = 0;
            while ((iterationCounter < 50 || rand.NextDouble() >= 0.1) && iterationCounter <= 100)
            {
                var freeEdges = new List<int>();

                for (int i = 0; i < edgeCount - 1; i++)
                {
                    if (currentEdge == i)
                        continue;
                    
                    if (Matrix[currentEdge, i] == 0)
                        freeEdges.Add(i);
                }

                int nextEdge = freeEdges[rand.Next(freeEdges.Count - 1)];

                AddVertex(ref Matrix, ref res, currentEdge, nextEdge);
                currentEdge = nextEdge;
                iterationCounter++;
            }

            if (currentEdge == 0)
                return res;
            else
            {
                if (Matrix[0, currentEdge] == 0)
                {
                    AddVertex(ref Matrix, ref res, currentEdge, 0);
                    return res;
                }
                else
                {
                    AddVertex(ref Matrix, ref res, currentEdge, edgeCount - 1);
                    AddVertex(ref Matrix, ref res, edgeCount - 1, 0);
                    return res;
                }
            }

        }

        public static int Count(int[,] Matrix, int i)
        {
            int res = 0;

            for (int j = 0; j < Matrix.GetLength(1); j++)
            {
                if (Matrix[i, j] == 1)
                    res++;
            }

            return res;
        }

        static void AddVertex(ref int[,] Matrix, ref List<Tuple<int, int>> list, int a, int b)
        {
            Matrix[a, b] = 1;
            Matrix[b, a] = 1;
            list.Add(new Tuple<int, int>(a, b));
        }
       
    }
}