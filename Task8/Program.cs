using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task8
{
    class Program
    {
        private static int[,] Matrix;

        static void Main(string[] args)
        {

            List<Tuple<int, int>> graph = new List<Tuple<int, int>>();

            int edgeCount = GraphGenerator.edgeCount;
            
            graph = GraphGenerator.WalkGeneration();

            Matrix = new int[edgeCount, edgeCount];
            
            ConverGraph(graph);

            var res = new List<int>();

            int currentEdge = 0;

            var st = new Stack<int>();
            st.Push(0);

            while (st.Count != 0)
            {
                currentEdge = st.Peek();
                if (GraphGenerator.Count(Matrix, currentEdge) == 0)
                {
                    res.Add(currentEdge);
                    st.Pop();
                }
                else
                {
                    for (int i = Matrix.GetLength(1) - 1; i >= 0; i--)
                    {
                        if (Matrix[currentEdge, i] == 1)
                        {
                            RemoveVertice(currentEdge, i);
                            st.Push(i);
                            break;
                        }
                    }
                }
            }

            var resStr = "";
            for (int i = 0; i < res.Count; i++)
            {
                resStr += res[i] + "->";
            }
            Console.WriteLine(resStr.TrimEnd('-','>'));
        }


        static void ConverGraph(List<Tuple<int, int>> graph)
        {
            foreach (var tuple in graph)
            {
                Matrix[tuple.Item1, tuple.Item2] = 1;
                Matrix[tuple.Item2, tuple.Item1] = 1;
            }
        }

        static void RemoveVertice(int e1, int e2)
        {
            Matrix[e1, e2] = 0;
            Matrix[e2, e1] = 0;
        }
    }
}
