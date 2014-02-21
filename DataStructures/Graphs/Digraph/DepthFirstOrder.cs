using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graphs.Digraph
{
    public class DepthFirstOrder
    {
        private bool[] marked;
        private Stack<int> reversePath;

        public DepthFirstOrder(Digraph G)
        {
            reversePath = new Stack<int>();
            marked = new bool[G.V];
            for (int v = 0; v < G.V; v++)
                if (!marked[v])
                    DFS(G, v);            
        }

        private void DFS(Digraph G, int v)
        {
            marked[v] = true;
            foreach (var w in G.Adj(v))
            {
                if (!marked[w]) DFS(G,v);
            }
            reversePath.Push(v);
        }

        public IEnumerable<int> GetReversePath()
        {
            return reversePath;
        }

    }
}
