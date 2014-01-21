using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    /// <summary>
    /// Basic API of a graph.
    /// Vertices are represented by integers starting from 0
    /// The graph is represented by:
    /// NOT set of edges (process inefficient)
    /// NOT Adjacency-matrix (space inefficient)
    /// -> Adjacency-list: an array of bags of adjacent vertices for each vertex
    /// </summary>
    public class Graph
    {
        private readonly int _V;
        private Bag<int>[] adj; 
        /// <summary>
        /// Creates an empty graph with V vertices
        /// </summary>
        /// <param name="V">Vertices count</param>
        public Graph(int V)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a graph from input
        /// </summary>
        public Graph(StreamReader input)
        {
            throw new NotImplementedException();
        }

        public int MyProperty { get; set; }
        /// <summary>
        /// Add an edge v-w
        /// </summary>
        public void AddEdge(int v, int w)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Vertices adjacent to v
        /// </summary>
        /// <param name="v">Vertex index</param>
        public IEnumerable<int> Adj(int v)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Number of vertices
        /// </summary>
        public int V { get { throw new NotImplementedException(); } }

        /// <summary>
        /// Number of edges
        /// </summary>
        public int E { get { throw new NotImplementedException(); } }

        public override string ToString()
        {
            throw new NotImplementedException(); 
        }
    }
}
